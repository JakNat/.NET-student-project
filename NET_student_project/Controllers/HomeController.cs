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
        public ActionResult MemeDetail(int id)
        {
            var meme = _memeRepository.GetMemeById(id);
            meme.CategoriesNames = _categoriesRepository.GetAllCategoriesNames();
            return View(meme);
        }
        public ActionResult MemesGetByCategory(string id)
        {
            ViewBag.Title = id;
          
            return View(new MemesViewModel
            {
                Memes = _memeRepository.GetMemeByCategory(id),
            CategoriesNames = _categoriesRepository.GetAllCategoriesNames()
            });
        }

    }
}