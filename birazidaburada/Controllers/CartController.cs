using birazidaburada.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace birazidaburada.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        IProductRepository _productRepository;
        ICategoryRepository _categoryRepository;
        IUsersRepository _userRepository;
        
        public CartController(IProductRepository productRepository,ICategoryRepository categoryRepository,IUsersRepository userRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            
        }
        public ActionResult Index()
        {
            if (Session["chart"] == null)
                Session["chart"] = new Chart();
            ViewBag.Categories = _categoryRepository.Select(c => !c.ParentCategory_Id.HasValue).ToList();
            Chart model = (Chart)Session["chart"];
            return View(model);
        }
        public JsonResult AddToChart(int productId)
        {
            if (Session["chart"] == null)
            {
                Session["chart"] = new Chart();
            }
            Chart c = (Chart)Session["chart"];
            c.Products.Add(_productRepository.FindById(productId));





            //1.yol    //return new JsonResult() { Data = new { count = c.Products.Count(), total = c.Products.Sum(x => x.DiscountPrice) } };

            //2.yol
            ChartSummary result = new ChartSummary();
            result.Count = c.Products.Count();
            result.Price = c.Products.Sum(x => x.DiscountPrice).Value;
            //2.a
            //return Json(c.Products.Count);
            //2.b

            return new JsonResult() { Data = result };
        }

        public ActionResult AddWishes(int id)
        {

            Users usr = (Users)Session["UserLogin"];
            usr.Wishes.Add(_productRepository.FindById(id));
            _userRepository.Save();
            

            return RedirectToAction("Index","Home");
        }
       
        public ActionResult WishesList(int id)
        {
            ViewBag.Categories = _categoryRepository.Select(c => !c.ParentCategory_Id.HasValue).ToList();
            Users usr = _userRepository.FindById(id);
            return View(usr);
        }
    }
}