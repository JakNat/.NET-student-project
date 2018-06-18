using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_student_project.ViewModels
{
    public class DetailedMemeViewModel : BaseCategoriesViewModel
    {
        public int MemeId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public int Points { get; set; }
        public int SComments { get; set; }
        public List<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
    }
}