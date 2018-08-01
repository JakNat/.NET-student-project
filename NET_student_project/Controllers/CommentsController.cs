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

        public ActionResult AddComment()
        {
            return PartialView();
        }
        [Authorize]
        [ChildActionOnly]
        [HttpPost]
        public ActionResult AddComment(int id, string message)
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
            return PartialView();
        }

        public ActionResult _AddSubComment(int commentid)
        {
            ViewBag.id = commentid;
            return PartialView();
        }
        [Authorize]
        [ChildActionOnly]
        [HttpPost]
        public ActionResult _AddSubComment(int commentid, string subMessage)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var name = identity.GetUserName();
            CommentModel comm = new CommentModel
            {
                User = _gagDb.Users.First(x => x.Name == name),
                Text = subMessage,
               
            };
            try
            {
                _gagDb.Comments.First(c => c.Id == commentid).SubComments.Add(comm);
            }
            catch (Exception)
            {
                _gagDb.Comments.First(c => c.Id == commentid).SubComments = new List<CommentModel>();
                _gagDb.Comments.First(c => c.Id == commentid).SubComments.Add(comm);
            }
           
            _gagDb.SaveChanges();

            return PartialView(

            );
        }


    }
}