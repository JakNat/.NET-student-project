
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NET_student_project.Models;

namespace NET_student_project.DataAccessLayer
{
    public class GagDbInitializer : DropCreateDatabaseAlways<GagDbContext>
    {
        protected override void Seed(GagDbContext context)

        {
            Random rd = new Random();
            List<string> ImagesPathes = new List<string>
            {
                "/Content/Images/meme1.png"
              };
            for (int i  = 2; i <= 24; i++)
            {
                ImagesPathes.Add("/Content/Images/meme" +i +".jpg");
            }
              
            int sizeImagePatcges = ImagesPathes.Count;
            var Users = new List<UserModel>();
            
            for (int i = 0; i < 10; i++)
            {
                Users.Add(new UserModel {
                    Name = "user" + i,
                    UserId = i
                });
            }

            var Categories = new List<CategoryModel>
            {
                new CategoryModel()
                {
                Name = "Funny",
                Memes = new List<MemeModel>
                {
                }
                },
                new CategoryModel(){
                Name = "Wallpaper",
                Memes = new List<MemeModel>
                {          
                }
                },
                new CategoryModel(){
                Name = "Pic Of The Day",
                Memes = new List<MemeModel>
                {                    
                }},
                new CategoryModel(){
                Name = "Animals",
                Memes = new List<MemeModel>
                {                  
                }},
                new CategoryModel(){
                Name = "Ask 9GAG",
                Memes = new List<MemeModel>
                {                  
                }},
                new CategoryModel(){
                Name = "Awesome",
                Memes = new List<MemeModel>
                {                  
                }},
                new CategoryModel(){
                Name = "WTF",
                Memes = new List<MemeModel>
                {                   
                }},
                new CategoryModel(){
                Name = "Food",
                Memes = new List<MemeModel>
                {                   
                }},
                new CategoryModel(){
                Name = "Gaming",
                Memes = new List<MemeModel>
                {                  
                }},
                new CategoryModel(){
                Name = "Gif",
                Memes = new List<MemeModel>
                {                   
                }}

            };

            foreach(var category in Categories)
            {
                int size = rd.Next(4, 10);
                for (int i = 0; i < size; i++)
                {
                    category.Memes.Add(new MemeModel
                    {
                        User = Users[rd.Next(0, Users.Count)],
                        MemeId = i*46,
                        Points = rd.Next(0, 700),
                        Title = "Random title " + category.Name + " [" + i.ToString() + "]",
                            ImagePath = ImagesPathes[rd.Next(0, ImagesPathes.Count)]                 
                    });
                }
            }
            var Memes = Categories.Select(c => c.Memes).ToList();
            // var Memes = new List<MemeModel>
            //{
            /*

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
             */
            //   new MemeModel(new UserModel("user","pswd"),new CategoryModel("gaming")),
            // new MemeModel(new UserModel("use","psw"),new CategoryModel("funny")



            //   )};

            context.Users.AddRange(Users);
            //   context.Memes.AddRange(Memes);
            context.Categories.AddRange(Categories);
            base.Seed(context);
        }
    }


}