using NET_student_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace NET_student_project.DataAccessLayer
{

    public class GagDbContext : DbContext, IGagDbContext
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

        public IDbSet<UserModel> Users { get; set; }
        public IDbSet<MemeModel> Memes { get; set; }
        public IDbSet<CommentModel> Comments{ get; set; }
        public IDbSet<CategoryModel> Categories { get; set; }


        
    }

    public interface IGagDbContext
    {
        IDbSet<UserModel> Users { get; set; }
         IDbSet<MemeModel> Memes { get; set; }
         IDbSet<CommentModel> Comments { get; set; }
         IDbSet<CategoryModel> Categories { get; set; }
        int SaveChanges();
    }
    public class FakeGagDbContext : IGagDbContext
    {
        public IDbSet<UserModel> Users { get; set; }
        public IDbSet<MemeModel> Memes { get; set; }
        public IDbSet<CommentModel> Comments { get; set; }
        public IDbSet<CategoryModel> Categories { get; set; }

        public FakeGagDbContext()
        {
            Random rd = new Random();
            List<string> ImagesPathes = new List<string>
            {
                "/Content/Images/meme1.png"
              };
            for (int i = 2; i <= 24; i++)
            {
                ImagesPathes.Add("/Content/Images/meme" + i + ".jpg");
            }



            int sizeImagePatcges = ImagesPathes.Count;
            var Users = new List<UserModel>();

            for (int i = 1; i < 30; i++)
            {
                Users.Add(new UserModel
                {
                    Name = "user" + i,
                    ImagePath = "/Content/AvatarImages/RandomAvatar (" + i + ").jpg",



                    Password = "psswd" + i
                });
            }

            var CommentsBase = new List<CommentModel>
            {
                             new CommentModel
                            {
                                Text = "bla bla bbla bardzo bardzo fajne",
                                User =  Users[rd.Next(0, Users.Count)],
                                Upvotes = rd.Next(0,376)
                            },new CommentModel
                            {
                                Text = "FFFajne",
                                User = Users[rd.Next(0, Users.Count)],
                                Upvotes = rd.Next(0,376)
                            },new CommentModel
                            {
                                Text = "nie fajne",
                                User = Users[rd.Next(0, Users.Count)],
                                Upvotes = rd.Next(0,376)
                            },new CommentModel
                            {
                                Text = "xDDDDDD",
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
                                Text = "Non retard units anyone?",
                                User = Users[rd.Next(0, Users.Count)],
                                Upvotes = rd.Next(0,376)
                            },

            };

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

            foreach (var category in Categories)
            {
                int id = 1;
                int size = rd.Next(6, 14);
                for (int i = 0; i < size; i++)
                {
                    id++;
                    category.Memes.Add(new MemeModel
                    {
                        User = Users[rd.Next(0, Users.Count)],

                        Points = rd.Next(0, 700),
                        Title = "Random title " + category.Name + " [" + i.ToString() + "]",
                        ImagePath = ImagesPathes[rd.Next(0, ImagesPathes.Count)],

                        Comments = new List<CommentModel> {
                               new CommentModel
                            {
                                Text = "bla bla bbla bardzo bardzo fajne",
                                User =  Users[rd.Next(0, Users.Count)],
                                Upvotes = rd.Next(0,376)
                            },new CommentModel
                            {
                                Text = "FFFajne",
                                User = Users[rd.Next(0, Users.Count)],
                                Upvotes = rd.Next(0,376)
                            },new CommentModel
                            {
                                Text = "nie fajne",
                                User = Users[rd.Next(0, Users.Count)],
                                Upvotes = rd.Next(0,376)
                            },new CommentModel
                            {
                                Text = "xDDDDDD",
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
                                Text = "Non retard units anyone?",
                                User = Users[rd.Next(0, Users.Count)],
                                Upvotes = rd.Next(0,376)
                            }

                            },


                    });
                }
            }
            this.Memes = new FakeDbSet<MemeModel>();
            this.Categories = new FakeDbSet<CategoryModel>();
            this.Users = new FakeDbSet<UserModel>();
            foreach(var u in Users)
            {
                this.Users.Add(u);
            }
            this.Comments = new FakeDbSet<CommentModel>();
            foreach(var cat in Categories)
            {
                this.Categories.Add(cat);
                foreach(var meme in cat.Memes)
                {
                    Memes.Add(meme);
        
                }
            }
        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}