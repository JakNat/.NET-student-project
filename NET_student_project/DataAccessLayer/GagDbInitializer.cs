
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
                new UserModel(){
                    Name = "user1"
                },
                new UserModel(){
                    Name = "user2"
                },
                new UserModel(){
                    Name = "user3"
                },
                new UserModel(){
                    Name = "user4"
                },
                new UserModel(){
                    Name = "user5"
                },
                new UserModel(){
                    Name = "user6"
                },
                new UserModel(){
                    Name = "user7"
                },
                new UserModel(){
                    Name = "user8"
                },
               
                
            };

            var Categories = new List<CategoryModel>
            {
                new CategoryModel()
                {
                Name = "Funny",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user1"),
                        Points = 3212
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user6"),
                        Points = 2464
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user7"),
                        Points = 1243
                    }

                }
                },
                new CategoryModel(){
                Name = "Wallpaper",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user1"),
                        Points = 453
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user8"),
                        Points = 35
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user7"),
                        Points = 25
                    }

                }

                },
                new CategoryModel(){
                Name = "Pic Of The Day",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user3"),
                        Points = 65
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user7"),
                        Points = 876
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user5"),
                        Points = 321
                    }

                }},
                new CategoryModel(){
                Name = "Animals",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user2"),
                        Points = 765
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user2"),
                        Points = 654
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user3"),
                        Points = 456
                    }

                }},
                new CategoryModel(){
                Name = "Ask 9GAG",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user4"),
                        Points = 32
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user4"),
                        Points = 22
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user8"),
                        Points = 78
                    }

                }},
                new CategoryModel(){
                Name = "Awesome",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user2"),
                        Points = 321
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user4"),
                        Points = 785
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user8"),
                        Points = 364
                    }

                }},
                new CategoryModel(){
                Name = "WTF",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user1"),
                        Points = 98
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user6"),
                        Points = 1035
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user7"),
                        Points = 32
                    }

                }},
                new CategoryModel(){
                Name = "Country",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user1"),
                        Points = 42
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user4"),
                        Points = 2765
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user3"),
                        Points = 968
                    }

                }},
                new CategoryModel(){
                Name = "Food",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user5"),
                        Points = 600
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user6"),
                        Points =130
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user7"),
                        Points = 87
                    }

                }},
                new CategoryModel(){
                Name = "Gaming",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user8"),
                        Points = 4
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user2"),
                        Points = 232
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user4"),
                        Points = 521
                    }

                }},
                new CategoryModel(){
                Name = "Gif",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user4"),
                        Points = 123
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user5"),
                        Points = 13
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user2"),
                        Points = 500
                    }

                }}
               
            };
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