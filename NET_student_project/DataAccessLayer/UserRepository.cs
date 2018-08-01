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

    }
}