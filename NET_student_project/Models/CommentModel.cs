using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NET_student_project.Models
{
    public class CommentModel
    {
        [Key]
        public int CommentId { get; set; }

        public DateTime ReleaseTime { get; set; }
        public int Upvotes { get; set; }
        public List<CommentModel> ResponseComments { get; set; }


    }
}