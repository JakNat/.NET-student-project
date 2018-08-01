using Microsoft.AspNet.Identity;
using NET_student_project.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace NET_student_project.Controllers
{
    public class MemeController : Controller
    {
        // GET: Meme
        private readonly GagDbContext _gag = new GagDbContext();
        private readonly MemeRepository  _memeRepository = new MemeRepository();
        private readonly CategoriesRepository _categoriesRepository = new CategoriesRepository();

        public ActionResult MemeDetail(int id)
        {
            var meme = _memeRepository.GetMemeById(id);
            meme.CategoriesNames = _categoriesRepository.GetAllCategoriesNames();

            return View(meme
            );
        }

        [Authorize]
        public ActionResult AddPoint(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var name = identity.GetUserName();
            if(_gag.Users.First(u => u.Name == name).LikedMemes.Exists(x => x.Id == id))
            {
                return RedirectToAction("Index", "Home");
            }
            _gag.Users.First(u => u.Name == name).LikedMemes.Add(_gag.Memes.First(m => m.Id == id));
            _gag.Memes.First(m => m.Id == id).Points++;
            _gag.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        [Authorize]
        public ActionResult DecPoint(int id)
        {
            _gag.Memes.First(m => m.Id == id).Points--;
            _gag.SaveChanges();
            return RedirectToAction("Hot","Home");
        }
    }
}