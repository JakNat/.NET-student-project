using Microsoft.AspNet.Identity;
using NET_student_project.DataAccessLayer;
using NET_student_project.Models;
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
      
        [Authorize]
        [HttpPost]
        public ActionResult _AddPoint(int id)
        {
            ViewBag.Status = 1;
            var identity = (ClaimsIdentity)User.Identity;
            var name = identity.GetUserName();
            var user = _gag.Users.First(u => u.Name == name);
            var meme = _gag.Memes.First(m => m.Id == id);
            
            if (user.DisLikedMemes.Exists(l => l == id))
            {
                meme.Points += 2;
                user.RemoveDisLikedMeme(id);
                user.AddLikedMeme(id);
            }
            else if (user.LikedMemes.Exists(i => i == id))
            {
                meme.Points--;
                user.RemoveLikedMeme(id);
                _gag.SaveChanges();
                var shortMeme2 = _memeRepository.GetShortMemeById(id);
                return PartialView("_AddPoint", shortMeme2);
            }
            else
            {
                user.AddLikedMeme(id);
                meme.Points++;
            }
            _gag.SaveChanges();

            var shortMeme = _memeRepository.GetShortMemeById(id);
            return PartialView("_Liked", shortMeme);
        }

        [Authorize]
        public ActionResult _DecPoint(int id)
        {
            ViewBag.Status = 3;
            var identity = (ClaimsIdentity)User.Identity;
            var name = identity.GetUserName();
            var user = _gag.Users.First(u => u.Name == name);
            var meme = _gag.Memes.First(m => m.Id == id);
           
            if (user.DisLikedMemes.Exists(l => l == id))
            {
                meme.Points ++;
                user.RemoveDisLikedMeme(id);
                _gag.SaveChanges();
                var shortMeme2 = _memeRepository.GetShortMemeById(id);
                return PartialView("_AddPoint", shortMeme2);
            }
            else if (user.LikedMemes.Exists(i => i == id))
            {
                meme.Points--;
                meme.Points--;
                user.RemoveLikedMeme(id);
                user.AddDisLikedMeme(id);
            }
            else
            {
                user.AddDisLikedMeme(id);
                meme.Points--;
            }
            _gag.SaveChanges();

            var shortMeme = _memeRepository.GetShortMemeById(id);
            return PartialView("_DisLiked",shortMeme);
        }
    }
}