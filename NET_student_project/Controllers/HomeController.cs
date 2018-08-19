using Microsoft.AspNet.Identity;
using NET_student_project.DataAccessLayer;
using NET_student_project.Models;
using NET_student_project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index(string id = "Hot",int page = 0)
        {
            ViewBag.id = id;
            ViewBag.page = page;
            var memeList = await  _memeRepository.GetShortMemesAsync(id);
            ShortMemesListViewModel list = null;
            if (page * 9 + 9 > memeList.Count)
            {
                list = new ShortMemesListViewModel
                {
                    Memes = memeList.GetRange(page * 9, memeList.Count - page * 9),
                    CategoriesNames = _categoriesRepository.GetAllCategoriesNames()
                };
            }
            list = new ShortMemesListViewModel
            {
                Memes = memeList.GetRange(page * 9, 9),
                CategoriesNames = _categoriesRepository.GetAllCategoriesNames()
            };
            if (Request.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)User.Identity;
                var name = identity.GetUserName();
                var user = _gagDb.Users.First(u => u.Name == name);
                list.SetLikedMemes(user);
            }
            return View(list);
        }
        public async Task<ActionResult> MemesGetByCategory(string id = "Funny")
        {
            ViewBag.Title = id;
            var list = new ShortMemesListViewModel
            {
                Memes = await _memeRepository.GetMemeByCategory(id),
                CategoriesNames = _categoriesRepository.GetAllCategoriesNames()
            };
            if (Request.IsAuthenticated)
            {
                
                var identity = (ClaimsIdentity)User.Identity;
                var name = identity.GetUserName();
                var n = Request.UserHostName;
                var user = _gagDb.Users.First(u => u.Name == name);
                list.SetLikedMemes(user);
            }
            return View(list);
        }
    }
}