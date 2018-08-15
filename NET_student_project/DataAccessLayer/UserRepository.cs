using Microsoft.AspNet.Identity;
using NET_student_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace NET_student_project.DataAccessLayer
{
    public class UserRepository
    {
        private GagDbContext _gag = new GagDbContext();
        public List<string> GetAvatarsPath()
        {
            var list = new List<string>();
            foreach (var user in _gag.Users)
            {
                var path = user.ImagePath;
                if (!list.Contains(path))
                {
                    list.Add(path);
                }
            }
            return list;
        }
        public bool IsLikedByUser(UserModel user, int memeId)
        {
            return user.LikedMemes.Exists(l => l == memeId) ? true : false;
        }
        public bool IsDisLikedByUser(UserModel user, int memeId)
        {
            return user.DisLikedMemes.Exists(l => l == memeId) ? true : false;
        }
    }
}