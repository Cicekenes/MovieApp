using Microsoft.EntityFrameworkCore;
using MovieApp.Dal;
using MovieApp.Repos.Abstract;
using MovieApp.Repos.Concrete;
using MovieApp.Uow;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MovieApp")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IActorsRepository, ActorsRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepos>();
builder.Services.AddScoped<ICommentsRepository,CommentsRepository>();
builder.Services.AddScoped<IMoviesRepository,MoviesRepository>();
builder.Services.AddScoped<ISeriesRepository,SeriesRepository>();
builder.Services.AddScoped<IUsersRepository,UsersRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
