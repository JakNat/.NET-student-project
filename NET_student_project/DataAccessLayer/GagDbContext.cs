using NET_student_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace NET_student_project.DataAccessLayer
{
    public class GagDbContext : DbContext
    {
        public GagDbContext() : base("GagContext")
        {

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;

            //Database.SetInitializer<ConferencesCompanyDbContext>(new DropCreateDatabaseIfModelChanges<ConferencesCompanyDbContext>());
            Database.SetInitializer(new GagDbInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<MemeModel> Memes { get; set; }
        public DbSet<CommentModel> Comments{ get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
    }
}