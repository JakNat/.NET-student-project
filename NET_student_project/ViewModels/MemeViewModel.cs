using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_student_project.ViewModels
{
    public class MemeViewModel
    {
        public int Points { get; set; }
        public int Comments { get; set; }
        public UserViewModel User { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}