using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NET_student_project.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }
        // public DateTime Updated { get; set; }
        public virtual ICollection<MemeModel> Memes { get; set; }
        public virtual ICollection<CommentModel> Comments { get; set; }
        public string LikedMemesString { get; set; }
        public string DisLikedMemesString { get; set; }
        public List<int> LikedMemes
        {
            get
            {
                if (string.IsNullOrEmpty(LikedMemesString))
                {
                    return new List<int>();
                }
                return LikedMemesString.Split(';').Select(int.Parse).ToArray().ToList();
            }
            set
            {
                LikedMemesString = string.Join(";", value);
            }
        }
        public List<int> DisLikedMemes
        {
            get
            {
                if (string.IsNullOrEmpty(DisLikedMemesString))
                {
                    return new List<int>();
                }
                return DisLikedMemesString.Split(';').Select(int.Parse).ToArray().ToList();
            }
            set
            {
                DisLikedMemesString = string.Join(";", value);
            }
        }
        public bool IsLikingMeme(int id)
        {
            if (LikedMemes.Exists(i => i == id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsDisLikingMeme(int id)
        {
            if (DisLikedMemes.Exists(i => i == id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddLikedMeme(int id)
        {
            if (string.IsNullOrEmpty(LikedMemesString))
            {
                LikedMemesString += id;
            }
            else
            {
                LikedMemesString += ";";
                LikedMemesString += id;
            }
        }
        public void AddDisLikedMeme(int id)
        {
            if (string.IsNullOrEmpty(DisLikedMemesString))
            {
                DisLikedMemesString += id;
            }
            else
            {
                DisLikedMemesString += ";";
                DisLikedMemesString += id;
            }
        }
        public void RemoveDisLikedMeme(int id)
        {
            List<int> list = new List<int>();
            foreach(var x in DisLikedMemes)
            {
                if(x != id)
                {
                    list.Add(x);
                }
            }
            DisLikedMemes = list;
            DisLikedMemesString = string.Join(";", DisLikedMemes);
        }
        public void RemoveLikedMeme(int id)
        {
            List<int> list = new List<int>();
            foreach (var x in LikedMemes)
            {
                if (x != id)
                {
                    list.Add(x);
                }
            }
            LikedMemes = list;
            LikedMemesString = string.Join(";", LikedMemes);
        }
    }
}