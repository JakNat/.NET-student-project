using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace NET_student_project.ViewModels
{
    public class MemeViewModel : BaseCategoriesViewModel
    {
        public int MemeId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public int Points { get; set; }
        public List<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
        public int SComments { get; set; }
        public UserViewModel User { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}