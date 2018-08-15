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
        private readonly IGagDbContext _gagDb = new GagDbContext();
        public CategoriesRepository()
        {
            _gagDb = new GagDbContext();
        }
        public CategoriesRepository(IGagDbContext gagDb)
        {
            _gagDb = gagDb;
        }
        public List<CategoryModel> GetAllCategories()
        {
            return _gagDb.Categories.ToList();
        }
        public List<string> GetAllCategoriesNames()
        {
            return _gagDb.Categories.Select(c => c.Name).ToList();
        }
    }
}