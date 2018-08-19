using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NET_student_project.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        //     public DateTime ReleaseTime { get; set; }
        public int Upvotes { get; set; }
        [ForeignKey("Meme")]
        public int MemeId { get; set; }
        public virtual MemeModel Meme { get; set; }
        //public List<CommentModel> ResponseComments { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
        public virtual ICollection<CommentModel> SubComments { get; set; }
    }
}