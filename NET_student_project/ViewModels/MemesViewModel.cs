using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_student_project.ViewModels
{
    public class MemesViewModel : BaseCategoriesViewModel
    {
        public List<MemeViewModel> Memes { get; set; }
    }
}