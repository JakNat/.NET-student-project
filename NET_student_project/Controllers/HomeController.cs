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
        private readonly GagDbContext _gagDb = new GagDbContext();
           private readonly CategoriesRepository _categoriesRepository = new CategoriesRepository();
        private readonly MemeRepository _memeRepository = new MemeRepository();
        public ActionResult Index()
        {       
         
             return View(new MemesViewModel
             {
                 Memes = _memeRepository.GetAllHotMemes(),
                 CategoriesNames = _categoriesRepository.GetAllCategoriesNames()
             });
        }
      
        public ActionResult Hot()
        {

            return View(new MemesViewModel
            {
                Memes = _memeRepository.GetAllHotMemes(),
                CategoriesNames = _categoriesRepository.GetAllCategoriesNames()
            });
        }
        public ActionResult Trending()
        {

            return View(new MemesViewModel
            {
                Memes = _memeRepository.GetAllTrendingMemes(),
                CategoriesNames = _categoriesRepository.GetAllCategoriesNames()
            });
        }
        public ActionResult Fresh()
        {

            return View(new MemesViewModel
            {
                Memes = _memeRepository.GetAllFreshMemes(),
                CategoriesNames = _categoriesRepository.GetAllCategoriesNames()
            });
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