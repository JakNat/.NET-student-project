
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
            for (int i = 1; i < 30; i++)
            {
                Users.Add(new UserModel {
                    Name = "user" + i,
                    ImagePath = "/Content/AvatarImages/RandomAvatar (" + i + ").jpg",
                    Password = "psswd"+i
                });
            }
            
            var Categories = new List<CategoryModel>
            {
                new CategoryModel()
                {
                Name = "Funny",
                Memes = new List<MemeModel>()
                },
                new CategoryModel(){
                Name = "Wallpaper",
                Memes = new List<MemeModel>()
                },
                new CategoryModel(){
                Name = "Pic Of The Day",
                Memes = new List<MemeModel>()
                },
                new CategoryModel(){
                Name = "Animals",
                Memes = new List<MemeModel>()
                },
                new CategoryModel(){
                Name = "Ask 9GAG",
                Memes = new List<MemeModel>()
                },
                new CategoryModel(){
                Name = "Awesome",
                Memes = new List<MemeModel>()
                },
                new CategoryModel(){
                Name = "WTF",
                Memes = new List<MemeModel>()
                },
                new CategoryModel(){
                Name = "Food",
                Memes = new List<MemeModel>()
                },
                new CategoryModel(){
                Name = "Gaming",
                Memes = new List<MemeModel>()
                },
                new CategoryModel(){
                Name = "Gif",
                Memes = new List<MemeModel>()
                }
            };
            foreach(var category in Categories)
            {
                int id = 1;
                int size = rd.Next(6, 14);
                for (int i = 0; i < size; i++)
                {
                    var CommentsBase = new List<CommentModel>
                    {
                             new CommentModel
                            {
                                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                                "Proin nibh augue, suscipit a, scelerisque sed, lacinia in, mi." +
                                " Cras vel lorem. Etiam pellentesque aliquet tellus." +
                                " Phasellus pharetra nulla ac diam.",
                                User =  Users[rd.Next(0, Users.Count)],
                                Upvotes = rd.Next(0,376)
                            },new CommentModel
                            {
                                Text = "Quisque semper justo at risus. Donec venenatis," +
                                " turpis vel hendrerit interdum, dui ligula ultricies purus," +
                                " sed posuere libero dui id orci.",
                                User = Users[rd.Next(0, Users.Count)],
                                Upvotes = rd.Next(0,376)
                            },new CommentModel
                            {
                                Text = "Nam congue, pede vitae dapibus aliquet, elit magna vulputate arcu," +
                                " vel tempus metus leo non est. Etiam sit amet lectus quis est congue mollis. " +
                                "Phasellus congue lacus eget neque.",
                                User = Users[rd.Next(0, Users.Count)],
                                Upvotes = rd.Next(0,376)
                            },new CommentModel
                            {
                                Text = "Praesent sodales velit quis augue. Cras suscipit," +
                                " urna at aliquam rhoncus, urna quam viverra nisi," +
                                " in interdum massa nibh nec erat.",
                                User = Users[rd.Next(0, Users.Count)],
                                Upvotes = rd.Next(0,376)
                            },new CommentModel
                            {
                                Text = "WWow",
                                User = Users[rd.Next(0, Users.Count)],
                                Upvotes = rd.Next(0,376)
                            },new CommentModel
                            {
                                Text = "(-.-)))",
                                User = Users[rd.Next(0, Users.Count)],
                                Upvotes = rd.Next(0,376)
                            },new CommentModel
                            {
                                Text = "Phasellus ornare, ante vitae consectetuer consequat," +
                                " purus sapien ultricies dolor, et mollis pede metus eget nisi. ",
                                User = Users[rd.Next(0, Users.Count)],
                                Upvotes = rd.Next(0,376)
                            },
                    };
                    id++;
                    category.Memes.Add(new MemeModel    
                    {
                        User = Users[rd.Next(0, Users.Count)],
                        Points = rd.Next(0, 700),
                        Title = "Random title " + category.Name + " [" + i.ToString() + "]",
                        ImagePath = ImagesPathes[rd.Next(0, ImagesPathes.Count)],                
                        Comments = new List<CommentModel> {
                             CommentsBase[0],
                             CommentsBase[1],
                             CommentsBase[2],
                             CommentsBase[3],
                             CommentsBase[4],
                             CommentsBase[5],
                             CommentsBase[6],           
                            },
                    });
                }
            }
            Categories.ForEach(c => context.Categories.Add(c));
            base.Seed(context);
        }
    }


}