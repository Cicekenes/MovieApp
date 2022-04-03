using Microsoft.EntityFrameworkCore;
using MovieApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Dal
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> db):base(db)
        {

        }
        public DbSet<Actors> ?Actors { get; set; }
        public DbSet<Categories> ?Categories { get; set; }
        public DbSet<Comments> ?Comments { get; set; }
        public DbSet<Movies> ?Movies { get; set; }
        public DbSet<Series> ?Series { get; set; }
        public DbSet<Users> ?Users { get; set; }
    }
}
