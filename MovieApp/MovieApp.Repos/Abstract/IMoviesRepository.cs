﻿using MovieApp.Core;
using MovieApp.Dto;
using MovieApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Repos.Abstract
{
    public interface IMoviesRepository:IBaseRepository<Movies>
    {
        public List<MoviesList> GetMoviesLists();
    }
}
