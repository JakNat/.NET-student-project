using NET_student_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NET_student_project.DataAccessLayer
{
    public class GagDbContext : DbContext
    {
        public GagDbContext() : base()
        {
            //Database.SetInitializer<ConferencesCompanyDbContext>(new DropCreateDatabaseIfModelChanges<ConferencesCompanyDbContext>());
            Database.SetInitializer(new GagDbInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<MemeModel> Memes { get; set; }
        public DbSet<CommentModel> Comments{ get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
    }
}