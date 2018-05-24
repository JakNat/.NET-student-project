﻿using NET_student_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_student_project.DataAccessLayer
{

    public class MemesRepository
    {
        private readonly GagDbContext _gagDb = new GagDbContext();

        public List<MemeModel> GetAllHotMemes()
        {
            return _gagDb.Memes.Where(m => m.Points > 500).ToList();
        }
        public List<MemeModel> GetAllTrendingMemes()
        {
            return _gagDb.Memes.Where(m => m.Points <= 500 && m.Points > 100).ToList();
        }
        public List<MemeModel> GetAllFreshMemes()
        {
            return _gagDb.Memes.Where(m => m.Points <= 100).ToList();
        }
    }
}