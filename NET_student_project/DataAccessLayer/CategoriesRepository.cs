using NET_student_project.Models;
using NET_student_project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_student_project.DataAccessLayer
{
    public class CategoriesRepository
    {
        private readonly GagDbContext _gagDb = new GagDbContext();
        public List<CategoryModel> GetAllCategories()
        {
            return _gagDb.Categories.ToList();
        }
    }
}