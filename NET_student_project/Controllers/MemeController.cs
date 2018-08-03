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

        public ActionResult _ShortMeme(int id)
        {
            var meme = _memeRepository.GetShortMemeById(id);
            return PartialView(meme);
        }
        public ActionResult MemeDetail(int id)
        {
            var meme = _memeRepository.GetMemeById(id);
            meme.CategoriesNames = _categoriesRepository.GetAllCategoriesNames();
            return View(meme);
        }

     
        public ActionResult _Points(int id)
        {
            ViewBag.check = 0;
            try
            {
                var identity = (ClaimsIdentity)User.Identity;
                var name = identity.GetUserName();
                var user = _gag.Users.First(u => u.Name == name);
                var meme = _gag.Memes.First(m => m.Id == id);
               if (user.LikedMemes.Exists(l => l == meme))
                {
                    ViewBag.check = 1;
                }
               else if (user.NotLikedMemes.Exists(l => l == meme))
                {
                    ViewBag.check = 2;
                }
            }
            catch (Exception)
            {}
            return PartialView(_memeRepository.GetShortMemeById(id));
        }

        [Authorize]
        public ActionResult AddPoint(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var name = identity.GetUserName();
            var user = _gag.Users.First(u => u.Name == name);
            var meme = _gag.Memes.First(m => m.Id == id);
            _gag.Users.First(u => u.Name == name).LikedMemes.Add(_gag.Memes.First(m => m.Id == id));
                _gag.Memes.First(m => m.Id == id).Points++;
            if (user.NotLikedMemes.Exists(l => l == meme))
            {
                meme.Points++;
                user.NotLikedMemes.Remove(meme);
            }
            _gag.SaveChanges();
                return RedirectToAction("Index", "Home"); 
        }
        [Authorize]
        public ActionResult DecPoint(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var name = identity.GetUserName();
            var user = _gag.Users.First(u => u.Name == name);
            var meme = _gag.Memes.First(m => m.Id == id);
            if (user.LikedMemes.Exists(l => l == meme))
            {
                meme.Points--;
                user.LikedMemes.Remove(meme);
            }
            _gag.Users.First(u => u.Name == name).NotLikedMemes.Add(_gag.Memes.First(m => m.Id == id));
            _gag.Memes.First(m => m.Id == id).Points--;
            _gag.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult NeutralPoint(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var name = identity.GetUserName();
            var user = _gag.Users.First(u => u.Name == name);
            var meme = _gag.Memes.First(m => m.Id == id);
            if (user.LikedMemes.Exists(l => l == meme))
            {
                meme.Points--;
                user.LikedMemes.Remove(meme);
            }
            else if (user.NotLikedMemes.Exists(l => l == meme))
            {
                meme.Points++;
                user.NotLikedMemes.Remove(meme);
            }         
            _gag.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}