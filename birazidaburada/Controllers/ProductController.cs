using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace birazidaburada.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        IProductRepository _productRespository;
        ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRespository = productRepository;
            _categoryRepository = categoryRepository;
        }


        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Detail(int id)
        {
            if (Session["chart"] == null)
            {
                Session["chart"] = new Chart();
            }
            ViewBag.Categories = _categoryRepository.Select(c => !c.ParentCategory_Id.HasValue).ToList();

            var product = _productRespository.FindById(id);


            return View(product);

        }
    }
}