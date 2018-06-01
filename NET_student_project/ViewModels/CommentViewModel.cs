using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_student_project.ViewModels
{
    public class CommentViewModel : BaseCategoriesViewModel
    {
       
        public int Upvotes { get; set; }
        public string Text { get; set; }
        public List<CommentViewModel> ResponseComments { get; set; }
        public virtual UserViewModel User { get; set; }
    }
}