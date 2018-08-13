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
            var identity = (ClaimsIdentity)User.Identity;
            var name = identity.GetUserName();
            var user = _gag.Users.First(u => u.Name == name);
            var meme = _gag.Memes.First(m => m.Id == id);
            if (user.NotLikedMemes.Exists(l => l == meme))
            {
                meme.Points += 2;
                user.NotLikedMemes.Remove(meme);
                _gag.Users.First(u => u.Name == name).LikedMemes.Add(_gag.Memes.First(m => m.Id == id));
            }
            else if (user.LikedMemes.Exists(l => l == meme))
            {
                meme.Points--;
                user.LikedMemes.Remove(meme);
            }
            else
            {
                _gag.Users.First(u => u.Name == name).LikedMemes.Add(_gag.Memes.First(m => m.Id == id));
                _gag.Memes.First(m => m.Id == id).Points++;
            }
            _gag.SaveChanges();
            var shortMeme = _memeRepository.GetShortMemeById(id);
            return PartialView(shortMeme);
        }

        [Authorize]
        public ActionResult _DecPoint(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var name = identity.GetUserName();
            var user = _gag.Users.First(u => u.Name == name);
            var meme = _gag.Memes.First(m => m.Id == id);
            if (user.NotLikedMemes.Exists(l => l == meme))
            {
                meme.Points++;
                user.NotLikedMemes.Remove(meme);
            }
            else if (user.LikedMemes.Exists(l => l == meme))
            {
                meme.Points -= 2;
                user.LikedMemes.Remove(meme);
                user.NotLikedMemes.Add(meme);
            }
            else
            {
                user.NotLikedMemes.Add(meme);
                meme.Points--;
            }
            try
            {
                _gag.SaveChanges();
            }
            catch (Exception)
            {
            }
            var shortMeme = _memeRepository.GetShortMemeById(id);
            return PartialView("_AddPoint",shortMeme);
        }
    }
}