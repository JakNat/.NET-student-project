using NET_student_project.DataAccessLayer;
using NET_student_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_student_project.ViewModels
{
    public class MemesViewModel : BaseCategoriesViewModel
    {
        public List<ShortMemeViewModel> Memes { get; set; }
    }

    public class ShortMemeViewModel 
    {
        public int MemeId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public int Points { get; set; }
        public int SComments { get; set; }
    }

    public class ShortMemesListViewModel : BaseCategoriesViewModel
    {
        public ShortMemesListViewModel()
        {
            LikedMemes = new List<ShortMemeViewModel>();
            DisLikedMemes = new List<ShortMemeViewModel>();
        }

        public List<ShortMemeViewModel> Memes { get; set; }
        public List<ShortMemeViewModel> LikedMemes { get; set; }
        public List<ShortMemeViewModel> DisLikedMemes { get; set; }

        public void SetLikedMemes(UserModel user)
        {
            var userRepo = new UserRepository();
            var memeRepo = new MemeRepository();
     
            foreach(var meme in Memes)
            {
                if(userRepo.IsLikedByUser(user, meme.MemeId))
                {
                   LikedMemes.Add(meme);
                }else if (userRepo.IsDisLikedByUser(user, meme.MemeId))
                {
                    DisLikedMemes.Add(meme);
                }
            }
        }
    }
    /*  public class ShortMemeViewModel 
      {
          public int MemeId { get; set; }
          public string Title { get; set; }
          public string ImagePath { get; set; }
          public int Points { get; set; }
          public int SComments { get; set; }
          public List<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
          public CommentModel Comment { get; set; }
      }*/
    public class DetailedMemeViewModel : BaseCategoriesViewModel
    {
        public int MemeId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public int Points { get; set; }
        public int SComments { get; set; }
        public List<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
        public CommentModel Comment { get; set; }
    }
}