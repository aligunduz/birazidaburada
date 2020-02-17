using birazidaburada.ActionsFilters;
using birazidaburada.Models;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace birazidaburada.Controllers
{
    
    public class AdminController : Controller
    {
        ICategoryRepository _categoryRepository;
        IProductImageRepository _productImageRepository;
        IProductRepository _productRepository;
        IBannerRepository _bannerRepository;
        IUsersRepository _userRepository;
        public AdminController(ICategoryRepository categoryRepository,
            IProductImageRepository productImageRepository,
            IProductRepository productRepository,
            IBannerRepository bannerRepository,
            IUsersRepository userRepository)
        {
            _bannerRepository = bannerRepository;
            _categoryRepository = categoryRepository;
            _productImageRepository = productImageRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            List<Category> model = new List<Category>();
            model = _categoryRepository.Select().ToList();
            return View(model);
        }

        public ActionResult Create()
        {

            var model = _categoryRepository.Select(c => !c.ParentCategory_Id.HasValue).ToList();

            List<SelectListItem> cats = new List<SelectListItem>();

            cats.Add(new SelectListItem() { Text = "Seçiniz", Value = "-1" });
            foreach (var item in model)
            {
                cats.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            ViewBag.Categories = cats;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
            model.CreateDate = DateTime.Now;
            if (model.ParentCategory_Id == -1)
                model.ParentCategory_Id = null;
            _categoryRepository.Add(model);
            _categoryRepository.Save();
            return RedirectToAction("Categories");
        }


        public JsonResult UploadProductImage(int productId, HttpPostedFileBase productImage, string isMainStr)
        {
            bool isMain = isMainStr == "on";
            ProductImage pi = new ProductImage();
            pi.CreateDate = DateTime.Now;
            pi.IsMain = isMain;


            pi.Product_Id = productId;
            pi = _productImageRepository.Add(pi);

            _productImageRepository.Save();

            string fullPath = @"C:\Users\AG\Desktop\asıl kodlar\AÇBENİBESTİEE\birazidaburada\birazidaburada\MyImages\" + productId + "_" + pi.Id + ".jpg";
            productImage.SaveAs(fullPath);
            return Json(1);
        }

        [Erişebilirlik]
        public ActionResult CreateProduct(int? id)
        {
            Product model = new Product();
            ViewBag.hasId=false;
            if (id.HasValue)
            {
                ViewBag.hasId = true;
                model = _productRepository.FindById(id.Value);
            }

            List<SelectListItem> cats = new List<SelectListItem>();
            var categories = _categoryRepository.Select().ToList();


            cats.Add(new SelectListItem() { Text = "Seçiniz", Value = "-1" });
            foreach (var item in categories)
            {
                        if (model.Id > 0 && model.Category.Id == item.Id)
                {
                    cats.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString(), Selected = true });
                }
                else
                {
                    cats.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
                }
            }
            ViewBag.Categories = cats;

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product model)
        {

            if (model.Id > 0)
            {
                _productRepository.Update(model, model.Id);

                //var product = ctx.Products.First(c => c.Id == model.Id);
                //product.Category_Id = model.Category_Id;
                //// product.CreateDate = model.CreateDate;
                //product.Name = model.Name;
                //product.Price = model.Price;
                //product.Description = model.Description;
            }
            else
            {
                model.CreateDate = DateTime.Now;
                model = _productRepository.Add(model);
            }
            _productRepository.Save();

            List<SelectListItem> cats = new List<SelectListItem>();
            var categories = _categoryRepository.Select();

            cats.Add(new SelectListItem() { Text = "Seçiniz", Value = "-1" });
            foreach (var item in categories)
            {
                cats.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewBag.Categories = cats;

            return View(model);
        }

        public ActionResult ListProducts()
        {
            return View(_productRepository.Select());
        }
        [Erişebilirlik]
        public ActionResult ListBanners()
        {
            return View(_bannerRepository.Select());
        }
        [Erişebilirlik]
        public ActionResult CreateBanner()
        {
            return View(createBannerModel());
        }

        public BannerViewModel createBannerModel( )
        {
            var products = _productRepository.Select();
            List<SelectListItem> productList = new List<SelectListItem>();

            productList.Add(new SelectListItem() { Text = "Seçiniz", Value = "0" });

            foreach (var item in products)
            {
                productList.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }

            List<SelectListItem> typeList = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Top", Value = "3" },
                new SelectListItem() { Text = "Bottom", Value = "1" },
                new SelectListItem() { Text = "Middle", Value = "2" }
            };

            BannerViewModel model = new BannerViewModel();
            model.BannerTypes = typeList;
            model.Products = productList;
            return model;
        }

        [HttpPost]
        public ActionResult CreateBanner(BannerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                BannerViewModel existing = createBannerModel();
                model.BannerTypes = existing.BannerTypes;
                model.Products = existing.Products;
                return View(model);
            }
            Banner banner = new Banner();
            banner.ProductId = model.ProductId;
            banner.BannerType = model.BannerType;
            _bannerRepository.Add(banner);
            _bannerRepository.Save();
            return RedirectToAction("ListBanners");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Users usr = new Users();
                usr.CreateDate = DateTime.Now;
                usr.Name = model.Name;
                usr.Password = model.Password;
                usr.UserType = 0;
                _userRepository.Add(usr);
                _userRepository.Save();
            }
            
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserViewModel model)
        {
            IEnumerable<Users> userlistesi = _userRepository.Select();
            foreach (var item in userlistesi)
            {
                if(model.Name==item.Name && model.Password == item.Password)
                {
                     Session["UserLogin"] = item;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session["UserLogin"] = null;
            return RedirectToAction("Index","Home");
        }
    }
}