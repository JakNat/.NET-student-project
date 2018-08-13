using NET_student_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_student_project.DataAccessLayer
{
    public class UserRepository
    {
        private GagDbContext _gag = new GagDbContext();
        
       public List<string> GetAvatarsPath()
        {
            var list = new List<string>();
            foreach(var user in _gag.Users)
            {
                var path = user.ImagePath;
                if (!list.Contains(path)) 
                {
                    list.Add(path);
                }

            }
            return list;
        }
        public bool IsLikedByUser(UserModel user, MemeModel meme)
        {
            if (user.LikedMemes.Exists(l => l == meme))
            {
                return true;
            }
            else
                return false;
        }

        public bool IsDislikedByUser(UserModel user, MemeModel meme)
        {
            if (user.NotLikedMemes.Exists(l => l == meme))
            {
                return true;
            }
            else
                return false;
        }

    }
}