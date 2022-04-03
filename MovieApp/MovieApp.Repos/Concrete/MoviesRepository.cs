﻿using MovieApp.Core;
using MovieApp.Dal;
using MovieApp.Entities.Concrete;
using MovieApp.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repos.Concrete
{
    public class MoviesRepository : BaseRepository<Movies>,IMoviesRepository
    {
        public MoviesRepository(Context db) : base(db)
        {
        }
    }
}
