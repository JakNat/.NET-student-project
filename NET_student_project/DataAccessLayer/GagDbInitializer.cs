
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
                "/Content/Images/meme.png",
                "/Content/Images/meme2.jpg",
                "/Content/Images/meme3.jpg",
                "/Content/Images/meme4.jpg",
                "/Content/Images/meme5.jpg",
                "/Content/Images/meme6.jpg",
                "/Content/Images/meme7.jpg",
                "/Content/Images/meme8.jpg",
                "/Content/Images/meme9.jpg",
                "/Content/Images/meme10.jpg",
                "/Content/Images/meme11.jpg",
                "/Content/Images/meme12.jpg",
                "/Content/Images/meme13.jpg",
                "/Content/Images/meme14.jpg",
                "/Content/Images/meme15.jpg",
                "/Content/Images/meme16.jpg",
                "/Content/Images/meme17.jpg",
                "/Content/Images/meme18.jpg", };
              
            int sizeImagePatcges = ImagesPathes.Count;
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
                        Points = 3212,
                        Title = "Funny.title1",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user6"),
                        Points = 2464,
                        Title = "Funny.title2",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user7"),
                        Points = 1243,
                        Title = "Funny.title3",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
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
                        Points = 453,
                        Title = "Wallpaper.title1",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user8"),
                        Points = 35,
                        Title = "Wallpaper.title2",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user7"),
                        Points = 25,
                        Title = "Wallpaper.title3",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
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
                        Points = 65,
                        Title = "Pic Of The Day.title1",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user7"),
                        Points = 876,
                        Title = "Pic Of The Day.title2",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user5"),
                        Points = 321,
                        Title = "Pic Of The Day.title3",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    }

                }},
                new CategoryModel(){
                Name = "Animals",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user2"),
                        Points = 765,
                        Title = "Animals.title1",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user2"),
                        Points = 654,
                        Title = "Animals.title2",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user3"),
                        Points = 456,
                        Title = "Animals.title3",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    }

                }},
                new CategoryModel(){
                Name = "Ask 9GAG",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user4"),
                        Points = 32,
                        Title = "Ask 9GAG.title1",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user4"),
                        Points = 22,
                        Title = "Ask 9GAG.title2",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user8"),
                        Points = 78,
                        Title = "Ask 9GAG.title3",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    }

                }},
                new CategoryModel(){
                Name = "Awesome",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user2"),
                        Points = 321,
                        Title = "Awesome.title1",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user4"),
                        Points = 785,
                        Title = "Awesome.titl2e",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user8"),
                        Points = 364,
                        Title = "Awesome.title3",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    }

                }},
                new CategoryModel(){
                Name = "WTF",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user1"),
                        Points = 98,
                        Title = "wtf.title1",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user6"),
                        Points = 1035,
                        Title = "wtf.title2",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user7"),
                        Points = 32,
                        Title = "wtf.title3",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    }

                }},
                new CategoryModel(){
                Name = "Country",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user1"),
                        Points = 42,
                        Title = "Country.title1",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user4"),
                        Points = 2765,
                        Title = "Country.title2",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user3"),
                        Points = 968,
                        Title = "Country.title3",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    }

                }},
                new CategoryModel(){
                Name = "Food",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user5"),
                        Points = 600,
                        Title = "Food.title1"
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user6"),
                        Points =130,
                        Title = "Food.title2"
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user7"),
                        Points = 87,
                        Title = "Food.title3"
                    }

                }},
                new CategoryModel(){
                Name = "Gaming",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user8"),
                        Points = 4,
                        Title = "Gaming.title1",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]


                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user2"),
                        Points = 232,
                        Title = "Gaming.title2",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user4"),
                        Points = 521,
                        Title = "Gaming.title3",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    }

                }},
                new CategoryModel(){
                Name = "Gif",
                Memes = new List<MemeModel>
                {
                    new MemeModel
                    {
                        User = Users.First(u => u.Name == "user4"),
                        Points = 123,
                        Title = "Gif.title1",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                     new MemeModel
                    {
                        User = Users.First(u => u.Name == "user5"),
                        Points = 13,
                        Title = "Gif.title3",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    },
                      new MemeModel
                    {
                        User = Users.First(u => u.Name == "user2"),
                        Points = 500,
                        Title = "Gif.title2",
                        ImagePath = ImagesPathes[rd.Next(0,sizeImagePatcges)]
                    }

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