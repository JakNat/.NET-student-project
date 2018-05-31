using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NET_student_project.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MemeModel> Memes { get; set; }


    }
} 