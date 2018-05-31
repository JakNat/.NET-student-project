using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_student_project.ViewModels
{
    public class CategoryViewModel : BaseCategoriesViewModel
    {
        public string Name { get; set; }
        public virtual ICollection<MemeViewModel> Memes { get; set; }
    }
}