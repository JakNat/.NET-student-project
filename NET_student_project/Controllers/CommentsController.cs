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
    public class CommentsController : Controller
    {
        private readonly GagDbContext _gagDb = new GagDbContext();
        private readonly MemeRepository _memeRepository = new MemeRepository();
        private readonly UserRepository _userRepository = new UserRepository();
        UserModel GetLoggedUser()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var name = identity.GetUserName();
            var user = _gagDb.Users.First(u => u.Name == name);
            return user;
        }
        [Authorize]
        [HttpPost]
        public ActionResult _AddComment(int id, string message)
        {
            CommentModel comm = new CommentModel
            {
                User = GetLoggedUser(),
                Text = message,
                Meme = _gagDb.Memes.First(x => x.Id == id)
            };
            _gagDb.Comments.Add(comm);
            _gagDb.SaveChanges();
            return PartialView(_memeRepository.GetDetailedMemeById(id));
        }     
    }
}