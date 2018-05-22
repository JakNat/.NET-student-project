using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_student_project.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public List<MemeViewModel> UserMemes { get; set; }
        public List<CommentViewModel> UserComments { get; set; }
    }
}