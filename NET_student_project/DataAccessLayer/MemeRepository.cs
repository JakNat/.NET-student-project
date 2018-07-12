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

        public List<MemeViewModel> GetAllHotMemes()
        {
            return _gagDb.Categories.SelectMany(c => c.Memes).Where(m => m.Points > 400).ToList().Select(m => new MemeViewModel
            {
                ImagePath = m.ImagePath,
                MemeId = m.Id,
               
                Points = m.Points,
                Title = m.Title,
                SComments = 0//m.Comments.Count,
                
                
            }
            ).ToList();
            
        }
        public List<MemeViewModel> GetAllTrendingMemes()
        {
            return _gagDb.Categories.SelectMany(c => c.Memes).Where(m => m.Points <= 400 && m.Points > 100).Select(m => new MemeViewModel
            {
                ImagePath = m.ImagePath,
                MemeId = m.Id,
                Points = m.Points,
                Title = m.Title,
                SComments = m.Comments.Count

            }
            ).ToList();

        }
        public List<MemeViewModel> GetAllFreshMemes()
        {
            return _gagDb.Categories.SelectMany(c => c.Memes).Where(m => m.Points <= 100).Select(m => new MemeViewModel
            {
                ImagePath = m.ImagePath,
                MemeId = m.Id,
                Points = m.Points,
                Title = m.Title,
                SComments = m.Comments.Count

            }
            ).ToList();

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
                        }

                    }).ToList()

                    //   Comments = m.Comments.Select(c => new CommentViewModel
                    // {
                    //    Text = c.Text
                    //}).ToList()

                };
            }
            return new DetailedMemeViewModel
            {
                ImagePath = m.ImagePath,

                Points = m.Points,
                Title = m.Title,
                Comments = _gagDb.Comments.Where(c => c.MemeId == id).Select(c => new CommentViewModel
                {
                    Text = c.Text,
                     User = new UserViewModel
                     {
                         Name = c.User.Name,
                         ImagePath = c.User.ImagePath
                     }
                }).ToList()

               
            };
        }
        public List<MemeViewModel> GetMemeByCategory(string categoryName)
        {
            var a = _gagDb.Categories.Where(c => c.Name == categoryName).SelectMany(c => c.Memes).ToList();
            return a.Select(m => new MemeViewModel
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