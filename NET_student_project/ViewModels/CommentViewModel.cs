using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_student_project.ViewModels
{
    public class CommentViewModel : BaseCategoriesViewModel
    {
        public int CommentId { get; set; }
        public int Upvotes { get; set; }
        public string Text { get; set; }
        public  UserViewModel User { get; set; }
        public virtual ICollection<CommentViewModel> SubComments  { get; set; }

    }
}