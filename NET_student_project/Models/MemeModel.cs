using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NET_student_project.Models
{
    public class MemeModel
    {
        [Key]
        public int Id { get; set; }
        public string ImagePath { get; set; }
     //   [Required]
        public string Title { get; set; }
        public int Points { get; set; }
        public virtual ICollection<CommentModel> Comments  { get; set; } 
        //    public DateTime RelesaseTime { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual CategoryModel Category { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }

       
    }
}