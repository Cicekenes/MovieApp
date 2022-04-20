using MovieApp.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Uow
{
    public interface IUnitOfWork
    {
        IAuthRepository _authRepository { get; }
        IAdminRepository _adminRepository { get; }
        IActorsRepository _actorsRepository { get; }
        ICategoriesRepository _categoriesRepository { get; }
        ICommentsRepository _commentsRepository { get; }
        IMoviesRepository _moviesRepository { get; }
        ISeriesRepository _seriesRepository { get; }
        IUsersRepository _usersRepository { get; }
        void Save();
    }
}
