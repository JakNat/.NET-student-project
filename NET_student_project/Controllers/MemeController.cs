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
        private readonly UserRepository _userRepository = new UserRepository();

        UserModel GetLoggedUser()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var name = identity.GetUserName();
            var user = _gag.Users.First(u => u.Name == name);
            return user;
        }
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
        public ActionResult _LikePost(int id)
        {
            var user = GetLoggedUser();
            var meme = _gag.Memes.First(m => m.Id == id);
            if (user.IsDisLikingMeme(id))
            {
                meme.Points += 2;
                user.RemoveDisLikedMeme(id);
                user.AddLikedMeme(id);
            }
            else if (user.IsLikingMeme(id))
            {
                meme.Points--;
                user.RemoveLikedMeme(id);
                _gag.SaveChanges();
                var MemePoints2 = _memeRepository.GetPointsMemeViewModelByMemeModel(meme);
                return PartialView("_AddPoint", MemePoints2);
            }
            else
            {
                user.AddLikedMeme(id);
                meme.Points++;
            }
            _gag.SaveChanges();
            var MemePoints = _memeRepository.GetPointsMemeViewModelByMemeModel(meme);
            return PartialView("_Liked", MemePoints);
        }

        [Authorize]
        public ActionResult _DisLikePost(int id)
        {
            var user = GetLoggedUser();
            var meme = _gag.Memes.First(m => m.Id == id);
            if (user.IsDisLikingMeme(id))
            {
                meme.Points++;
                user.RemoveDisLikedMeme(id);
                _gag.SaveChanges();
                var MemePoints2 = _memeRepository.GetPointsMemeViewModelByMemeModel(meme);
                return PartialView("_AddPoint", MemePoints2);
            }
            else if (user.IsLikingMeme(id))
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
            var MemePoints = _memeRepository.GetPointsMemeViewModelByMemeModel(meme);
            return PartialView("_DisLiked", MemePoints);
        }
    }
}