using Microsoft.AspNet.Identity;
using NET_student_project.DataAccessLayer;
using NET_student_project.Models;
using NET_student_project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace NET_student_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGagDbContext _gagDb;
           private readonly CategoriesRepository _categoriesRepository = new CategoriesRepository();
        private readonly MemeRepository _memeRepository = new MemeRepository();

        public HomeController()
        {
            _gagDb = new GagDbContext();
        }

        public HomeController(IGagDbContext gagDb, CategoriesRepository categoriesRepository, MemeRepository memeRepository)
        {
            _gagDb = gagDb;
            _categoriesRepository = categoriesRepository;
            _memeRepository = memeRepository;
        }

        public ActionResult Hot(string id)
        {
            var a = _memeRepository.GetAllHotMemes();
            if (id == "Hot")
            {
                 a = _memeRepository.GetAllHotMemes();
            }
            else if(id == "Trending")
            {
                 a = _memeRepository.GetAllTrendingMemes();
            }
            else if (id == "Fresh")
            {
                a = _memeRepository.GetAllFreshMemes();
            }
            return View(new MemesViewModel
            {
                Memes = a,
                CategoriesNames = _categoriesRepository.GetAllCategoriesNames()
            });
        }

        public ActionResult MemeDetail(int id)
        {    
            var meme = _memeRepository.GetMemeById(id);
            meme.CategoriesNames = _categoriesRepository.GetAllCategoriesNames();
            
            return View(meme
            );
        }
        [Authorize]
        [HttpPost]
        public ActionResult MemeDetail(int id, string message)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var name = identity.GetUserName();
            CommentModel comm = new CommentModel
            {
                User = _gagDb.Users.First(x => x.Name == name),
                Text = message,
                Meme = _gagDb.Memes.First(x => x.Id == id)
            };

            _gagDb.Comments.Add(comm);
            _gagDb.SaveChanges();
            var meme = _memeRepository.GetMemeById(id);
            
            meme.CategoriesNames = _categoriesRepository.GetAllCategoriesNames();

            return View(meme
            );
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