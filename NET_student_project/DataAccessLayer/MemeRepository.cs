using NET_student_project.Models;
using NET_student_project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;

namespace NET_student_project.DataAccessLayer
{
    public class MemeRepository
    {
        private readonly IGagDbContext _gagDb = new GagDbContext();
        private readonly IMapper _mapper;
        public MemeRepository()
        {
            _gagDb = new GagDbContext();
            _mapper = AutoMapperConfig.Initialize();
        }
        public MemeRepository(IGagDbContext gagDb)
        {
            _gagDb = gagDb;
        }
        public async Task<MemeModel> GetAsync(int id)
            => await _gagDb.Memes.Include(u => u.Comments.Select(x => x.User)).Include(b => b.Comments).FirstOrDefaultAsync(m => m.Id == id);

        public MemeModel Get(int id)
            =>  _gagDb.Memes.Include(b => b.Comments).FirstOrDefault(m => m.Id == id);

        public ShortMemeViewModel GetShortMeme(int id) 
            => _mapper.Map<MemeModel, ShortMemeViewModel>(Get(id));

        public async Task<ShortMemeViewModel> GetShortMemeAsync(int id) 
            => _mapper.Map<MemeModel, ShortMemeViewModel>(await GetAsync(id));

        public async Task<DetailedMemeViewModel> GetDetailedMemeAsync(int id) 
            => _mapper.Map<MemeModel, DetailedMemeViewModel>(await GetAsync(id));
      
        public PointsMemeViewModel GetPointsMeme(MemeModel meme)
        => new PointsMemeViewModel
        {
            MemeId = meme.Id,
            Points = meme.Points,
            SComments = _gagDb.Comments.Where(c => c.MemeId == meme.Id).Count()
        };
        public async Task<List<ShortMemeViewModel>> GetShortMemesAsync(string type)
        {
            if (type == "Hot")
            {
                var list = await _gagDb.Memes.AsQueryable().Where(x => x.Points > 400).ToListAsync();
                return _mapper.Map<List<MemeModel>, List<ShortMemeViewModel>>(list); ;
            }
            if (type == "Trending")
            {
                var list = await _gagDb.Memes.AsQueryable().Where(m => m.Points <= 400 && m.Points > 100).ToListAsync();
                return _mapper.Map<List<MemeModel>, List<ShortMemeViewModel>>(list); ;
            }
            else
            {
                var list = await _gagDb.Memes.AsQueryable().Where(m => m.Points <= 100).ToListAsync();
                return _mapper.Map<List<MemeModel>, List<ShortMemeViewModel>>(list);
            }
        }       
        public async Task<List<ShortMemeViewModel>> GetMemeByCategory(string categoryName)
        {
            var list = await _gagDb.Memes.Where(x => x.Category.Name == categoryName).ToListAsync();
            return _mapper.Map<List<MemeModel>, List<ShortMemeViewModel>>(list);
        }
    }
}