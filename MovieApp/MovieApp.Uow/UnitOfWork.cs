﻿ using MovieApp.Dal;
using MovieApp.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        Context _db;
        public IAdminRepository _adminRepository { get; private set; }
        public IActorsRepository _actorsRepository { get; private set; }
        public ICategoriesRepository _categoriesRepository { get; private set; }
        public ICommentsRepository _commentsRepository { get; private set; }
        public IMoviesRepository _moviesRepository { get; private set; }
        public ISeriesRepository _seriesRepository { get; private set; }
        public IUsersRepository _usersRepository { get; private set; }
        public IAuthRepository _authRepository { get; private set; }

        public UnitOfWork(Context db, IAdminRepository adminRepository,IActorsRepository actorsRepository, ICategoriesRepository categoriesRepository, ICommentsRepository commentsRepository, IMoviesRepository moviesRepository, ISeriesRepository seriesRepository, IUsersRepository usersRepository,IAuthRepository authRepository)
        {
            _db = db;
            _adminRepository = adminRepository;
            _actorsRepository = actorsRepository;
            _categoriesRepository = categoriesRepository;
            _commentsRepository = commentsRepository;
            _moviesRepository = moviesRepository;
            _seriesRepository = seriesRepository;
            _usersRepository = usersRepository;
            _authRepository = authRepository;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
