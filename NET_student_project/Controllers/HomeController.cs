using NET_student_project.DataAccessLayer;
using NET_student_project.Models;
using NET_student_project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET_student_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly GagDbContext _conferencesDb = new GagDbContext();
        private readonly CategoriesRepository _categoriesRepository = new CategoriesRepository();
        public ActionResult Index()
        {



                
            var Categories = _categoriesRepository.GetAllCategories();
            var CategoriesViews = _categoriesRepository.GetAllCategories().Select(c => new CategoryViewModel()
            {
                Name = c.Name
            }).ToList();
            var UserList = _conferencesDb.Users.ToList();

           

           // var userLists = _conferencesDb.Users.ToList();
             return View(Categories);
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
    }
}