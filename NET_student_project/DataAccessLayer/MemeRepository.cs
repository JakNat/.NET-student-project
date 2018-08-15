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
        public MemeModel GetMemeModelById(int id)
        {
            return _gagDb.Memes.First(m => m.Id == id);
        }
        public ShortMemeViewModel GetShortMemeById(int id)
        {
            var m = GetMemeModelById(id);
           
            return new ShortMemeViewModel
            {
                MemeId = m.Id,
                ImagePath = m.ImagePath,
                Points = m.Points,
                Title = m.Title,
                SComments = _gagDb.Comments.Where(c => c.MemeId == id).Count()
            };
        }
        public DetailedMemeViewModel GetDetailedMemeById(int id)
        {
            var m = GetMemeModelById(id);
            return new DetailedMemeViewModel
            {
                MemeId = m.Id,
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
        public PointsMemeViewModel GetPointsMeme(MemeModel meme)
        {
            return new PointsMemeViewModel
            {
                MemeId = meme.Id,
                Points = meme.Points,
                SComments = _gagDb.Comments.Where(c => c.MemeId == meme.Id).Count()
            };
        }
        public List<ShortMemeViewModel> GetAllShortMemeByPopularity(string type)
        {
            if (type == "Hot")
            {
                return _gagDb.Memes.Where(m => m.Points > 400).ToList().Select(m => new ShortMemeViewModel
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
        public List<ShortMemeViewModel> GetMemeByCategory(string categoryName)
        {
            var memes = _gagDb.Memes.Where(x => x.Category.Name == categoryName);
            return memes.Select(m => new ShortMemeViewModel
            {
                ImagePath = m.ImagePath,
                MemeId = m.Id,
                Points = m.Points,
                Title = m.Title,
            }).ToList();
        }
    }
}