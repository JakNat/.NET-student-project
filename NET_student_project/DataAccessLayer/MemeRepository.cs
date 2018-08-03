using NET_student_project.Models;
using NET_student_project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NET_student_project.DataAccessLayer
{
    public class MemeRepository
    {
        private readonly IGagDbContext _gagDb = new GagDbContext();
        public MemeRepository()
        {
            _gagDb = new GagDbContext();
        }
        public MemeRepository(IGagDbContext gagDb)
        {
            _gagDb = gagDb;
        }
        public List<ShortMemeViewModel> GetAllShortMemeByPopularity(string type)
        {
            if (type == "Hot")
            {
                return _gagDb.Categories.SelectMany(c => c.Memes).Where(m => m.Points > 400).ToList().Select(m => new ShortMemeViewModel
                {
                    ImagePath = m.ImagePath,
                    MemeId = m.Id,
                    Points = m.Points,
                    Title = m.Title,
                    SComments = _gagDb.Comments.Where(c => c.MemeId == m.Id).Count()
                }
                ).ToList();
            }
            if (type == "Trending")
            {
                return _gagDb.Categories.SelectMany(c => c.Memes).Where(m => m.Points <= 400 && m.Points > 100).Select(m => new ShortMemeViewModel
                {
                    ImagePath = m.ImagePath,
                    MemeId = m.Id,
                    Points = m.Points,
                    Title = m.Title,
                    SComments = _gagDb.Comments.Where(c => c.MemeId == m.Id).Count()
                }
                ).ToList();
            }
            else
            {
                return _gagDb.Categories.SelectMany(c => c.Memes).Where(m => m.Points <= 100).Select(m => new ShortMemeViewModel
                {
                    ImagePath = m.ImagePath,
                    MemeId = m.Id,
                    Points = m.Points,
                    Title = m.Title,
                    SComments = _gagDb.Comments.Where(c => c.MemeId == m.Id).Count()
                }
                ).ToList();
            }
        }
        public ShortMemeViewModel GetShortMemeById(int id)
        {
            var m = _gagDb.Categories.SelectMany(c => c.Memes).First(c => c.Id == id);
         
                return new ShortMemeViewModel
                {
                    MemeId = m.Id,
                    ImagePath = m.ImagePath,
                    Points = m.Points,
                    Title = m.Title,
                    SComments = _gagDb.Comments.Where(c => c.MemeId == id).Count()
                };                
        }



        public DetailedMemeViewModel GetMemeById(int id)
        {
            var m = _gagDb.Categories.SelectMany(c => c.Memes).First(c => c.Id == id);
            if (m.Comments != null)
            {
                return new DetailedMemeViewModel
                {
                    ImagePath = m.ImagePath,

                    Points = m.Points,
                    Title = m.Title,
                    Comments = m.Comments.Select(c => new CommentViewModel
                    {
                        Text = c.Text,
                        Upvotes = c.Upvotes,
                        User = new UserViewModel
                        {
                            Name = c.User.Name,
                            ImagePath = c.User.ImagePath
                        },
                        SubComments = c.SubComments.Select(sc => new CommentViewModel
                        {
                            Text = sc.Text,
                            Upvotes = sc.Upvotes,
                            User = new UserViewModel
                            {
                                Name = sc.User.Name,
                                ImagePath = sc.User.ImagePath
                            }
                        }).ToList()
                    }).ToList()
                };
            }
            return new DetailedMemeViewModel
            {
                ImagePath = m.ImagePath,
                Points = m.Points,
                Title = m.Title,
                Comments = _gagDb.Comments.Where(c => c.MemeId == id).Select(c => new CommentViewModel
                {
                    CommentId = c.Id,
                    Text = c.Text,
                     User = new UserViewModel
                     {
                         Name = c.User.Name,
                         ImagePath = c.User.ImagePath
                     }
                }).ToList()       
            };
        }
        public List<ShortMemeViewModel> GetMemeByCategory(string categoryName)
        {
            var a = _gagDb.Categories.Where(c => c.Name == categoryName).SelectMany(c => c.Memes).ToList();
            return a.Select(m => new ShortMemeViewModel
            {
                ImagePath = m.ImagePath,
                MemeId = m.Id,
                Points = m.Points,
                Title = m.Title,
              //  SComments = m.Comments.Count()
            }).ToList();
        }
    }
}