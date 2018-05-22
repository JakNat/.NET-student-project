
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NET_student_project.Models;

namespace NET_student_project.DataAccessLayer
{
    public class GagDbInitializer : DropCreateDatabaseIfModelChanges<GagDbContext>
    {
        protected override void Seed(GagDbContext context)
        {
            var Users = new List<UserModel>
            {
                new UserModel("user1","passwd1"),
                new UserModel("user2","passwd2"),
                new UserModel("user3","passwd3"),
                new UserModel("user4","passwd4"),
                new UserModel("user5","passwd5"),
                new UserModel("user6","passwd6"),
                new UserModel("user7","passwd7"),
                new UserModel("user8","passwd8"),
                
            };
           
            var Categories = new List<CategoryModel>
            {
                new CategoryModel("Funny"),
                new CategoryModel("SuperHero"),
                new CategoryModel("Wallpaper"),
                new CategoryModel("Pic Of The Day"),
                new CategoryModel("Animals"),
                new CategoryModel("Ask 9GAG"),
                new CategoryModel("Awesome"),
                new CategoryModel("WTF"),
                new CategoryModel("Country"),
                new CategoryModel("Food"),
                new CategoryModel("Gaming"),
                new CategoryModel("GIF")
            };
            var Memes = new List<MemeModel>
            {

                new MemeModel(Users.First(p => p.Name == "user1"),Categories.First(p => p.Name == "GIF")),
                new MemeModel(Users.First(p => p.Name == "user1"),Categories.First(p => p.Name == "Gaming")),
                new MemeModel(Users.First(p => p.Name == "user1"),Categories.First(p => p.Name == "Country")),
                new MemeModel(Users.First(p => p.Name == "user2"),Categories.First(p => p.Name == "GIF")),
                new MemeModel(Users.First(p => p.Name == "user3"),Categories.First(p => p.Name == "Animals")),
                new MemeModel(Users.First(p => p.Name == "user3"),Categories.First(p => p.Name == "Animals")),
                new MemeModel(Users.First(p => p.Name == "user3"),Categories.First(p => p.Name == "Wallpaper")),
                new MemeModel(Users.First(p => p.Name == "user3"),Categories.First(p => p.Name == "Pic Of The Day")),
                new MemeModel(Users.First(p => p.Name == "user4"),Categories.First(p => p.Name == "Superhero")),
                new MemeModel(Users.First(p => p.Name == "user5"),Categories.First(p => p.Name == "Funny")),
                new MemeModel(Users.First(p => p.Name == "user5"),Categories.First(p => p.Name == "GIF")),
                new MemeModel(Users.First(p => p.Name == "user5"),Categories.First(p => p.Name == "Funny")),
                new MemeModel(Users.First(p => p.Name == "user5"),Categories.First(p => p.Name == "GIF")),
                new MemeModel(Users.First(p => p.Name == "user6"),Categories.First(p => p.Name == "Animals")),
                new MemeModel(Users.First(p => p.Name == "user7"),Categories.First(p => p.Name == "Funny")),
                new MemeModel(Users.First(p => p.Name == "user7"),Categories.First(p => p.Name == "Food")),
                new MemeModel(Users.First(p => p.Name == "user7"),Categories.First(p => p.Name == "Food")),
                new MemeModel(Users.First(p => p.Name == "user7"),Categories.First(p => p.Name == "Pic Of The Day")),
                new MemeModel(Users.First(p => p.Name == "user8"),Categories.First(p => p.Name == "Gaming")),
             
                
             

            };

            context.Users.AddRange(Users);
            context.Memes.AddRange(Memes);
            context.Categories.AddRange(Categories);    
            base.Seed(context);
        }
    }


}