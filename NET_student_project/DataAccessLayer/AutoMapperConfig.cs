using AutoMapper;
using NET_student_project.Models;
using NET_student_project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_student_project.DataAccessLayer
{
    public class AutoMapperConfig
    {
        private readonly GagDbContext _gag = new GagDbContext();
        public static IMapper Initialize()
        {
            
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MemeModel, ShortMemeViewModel>().
                ForMember(meme => meme.MemeId, map => map.MapFrom(p => p.Id)).
                ForMember(meme => meme.SComments, map => map.MapFrom(p => p.Comments.Count()));

                cfg.CreateMap<CommentModel, CommentViewModel>().
                ForMember(comment => comment.CommentId, map => map.MapFrom(p => p.Id));

                cfg.CreateMap<UserModel, UserViewModel>();

                cfg.CreateMap<MemeModel, DetailedMemeViewModel>().
                ForMember(meme => meme.MemeId, map => map.MapFrom(p => p.Id));
         
            })
       .CreateMapper();
        }
       
    }
}