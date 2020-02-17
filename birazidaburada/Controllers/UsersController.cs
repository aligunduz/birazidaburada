using birazidaburada.ActionsFilters;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace birazidaburada.Controllers
{
    [Erişebilirlik]
    public class UsersController : Controller
    {
        // GET: Users
        IUsersRepository _userRepository;
        ICategoryRepository _categoryRepository;
        public UsersController(IUsersRepository userRepository,ICategoryRepository categoryRepository)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(_userRepository.Select());
        }
        public ActionResult Sepetim()
        {
            return View();
        }
        public ActionResult WishesList()
        {
            Users usr = (Users)Session["UserLogin"];
            ViewBag.Categories = _categoryRepository.Select(c => !c.ParentCategory_Id.HasValue).ToList();
            return View(usr);
        }
    }
}