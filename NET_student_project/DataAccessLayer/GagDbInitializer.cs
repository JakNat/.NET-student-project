
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
            List<string> CommentsBase = new List<string>();
            for (int i = 2; i <= 24; i++)
            {
                ImagesPathes.Add("/Content/Images/meme" + i + ".jpg");
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
                        MemeId = i * 46,
                        Points = rd.Next(0, 700),
                        Title = "Random title " + category.Name + " [" + i.ToString() + "]",
                        ImagePath = ImagesPathes[rd.Next(0, ImagesPathes.Count)],
                        Comments = new List<CommentModel>
                        {
                            new CommentModel
                            {
                                CommentId = rd.Next(0,100000),
                                Upvotes = rd.Next(0,259),
                                User = Users[rd.Next(0, Users.Count)],
                                Text = "Example comment [1] " 
                            },
                             new CommentModel
                            {
                                CommentId = rd.Next(0,100000),
                                Upvotes = rd.Next(0,259),
                                User = Users[rd.Next(0, Users.Count)],
                                Text = "Example comment [2] "
                            },
                              new CommentModel
                            {
                                CommentId = rd.Next(0,100000),
                                Upvotes = rd.Next(0,259),
                                User = Users[rd.Next(0, Users.Count)],
                                Text = "Example comment [3] "
                            },
                               new CommentModel
                            {
                                CommentId = rd.Next(0,100000),
                                Upvotes = rd.Next(0,259),
                                User = Users[rd.Next(0, Users.Count)],
                                Text = "Example comment [4] "
                            }
                        }
                    });
                }
            }
            var Memes = Categories.Select(c => c.Memes).ToList();
            
            context.Users.AddRange(Users);
            //   context.Memes.AddRange(Memes);
            context.Categories.AddRange(Categories);
            base.Seed(context);
        }
    }


}