using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NET_student_project.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<MemeModel> UserMemes { get; set; }
        public List<CommentModel> UserComments { get; set; }
        public DateTime Updated { get; set; }

        public UserModel(string name, string password)
        {
            Name = name;
            Password = password;
            UserMemes = new List<MemeModel>();
            UserComments = new List<CommentModel>();
            Updated = DateTime.Now;
        }
    }
}