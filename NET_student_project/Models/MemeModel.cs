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
       
        public CategoryModel Category { get; set; }
        public virtual UserModel User { get; set; }
       
    }
}