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
        public int Id { get; set; }
   //     [Required]
        public string Name { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }
        // public DateTime Updated { get; set; }
        public virtual ICollection<MemeModel> Memes { get; set; }
        public virtual ICollection<CommentModel> Comments { get; set; }

      
    }
}