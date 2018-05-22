using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NET_student_project.Models
{
    public class MemeModel
    {
        [Key]
        public int MemeId { get; set; }
        public int Points { get; set; }
        public int Comments { get; set; }
        public DateTime RelesaseTime { get; set; }
        public UserModel User { get; set; }
        public CategoryModel Category { get; set; }

        public MemeModel(UserModel user, CategoryModel category)
        {
            User = user;
            Category = category;
            Points = 0;
            Comments = 0;
            RelesaseTime = DateTime.Now;
        }
    }
}