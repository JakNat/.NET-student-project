using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_student_project.Models
{
    public class CategoryModel
    {
        public string Name { get; set; }

        public CategoryModel(string name)
        {
            Name = name;
        }
    }
}