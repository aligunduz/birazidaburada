using birazidaburada.Models;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace birazidaburada.Controllers
{
    public class HomeController : Controller
    {
        ICategoryRepository _categoryRepository;
        IProductRepository _productRepository;
        IBannerRepository _bannerRepository;

        public HomeController(ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            IBannerRepository bannerRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _bannerRepository = bannerRepository;
        }
        

        public ActionResult Index()
        {
            if (Session["chart"] == null)
            {
                Session["chart"] = new Chart();
            }
            ViewBag.Categories = _categoryRepository.Select(c => !c.ParentCategory_Id.HasValue).ToList();
            HomeViewModel model = new HomeViewModel();
            model.products = _productRepository.Select().ToList();
            model.bannerTop = _bannerRepository.Select(c => c.BannerType == 3).OrderByDescending(c => c.Id).First();

            model.bannerMiddle = _bannerRepository.Select(c => c.BannerType == 2).ToList();
            model.bannerBottom = _bannerRepository.Select(c => c.BannerType == 1).ToList();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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

        public ActionResult ProductDetail(int id)
        {
            if (Session["chart"] == null)
            {
                Session["chart"] = new Chart();
            }
            ViewBag.Categories = _categoryRepository.Select(c => !c.ParentCategory_Id.HasValue).ToList();
            return View(_productRepository.FindById(id));
        }
    }
}