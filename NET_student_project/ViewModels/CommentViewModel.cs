using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_student_project.ViewModels
{
    public class CommentViewModel
    {
        public DateTime ReleaseTime { get; set; }
        public int Upvotes { get; set; }
        public List<CommentViewModel> ResponseComments { get; set; }
    }
}