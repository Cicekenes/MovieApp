using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieApp.Dal;
using MovieApp.Dto;
using MovieApp.Entities.Concrete;
using MovieApp.Repos.Abstract;
using MovieApp.Repos.Concrete;
using MovieApp.Uow;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MovieApp")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IActorsRepository, ActorsRepository>();
builder.Services.AddScoped<IAdminRepository,AdminRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepos>();
builder.Services.AddScoped<ICommentsRepository,CommentsRepository>();
builder.Services.AddScoped<IMoviesRepository,MoviesRepository>();
builder.Services.AddScoped<ISeriesRepository,SeriesRepository>();
builder.Services.AddScoped<IUsersRepository,UsersRepository>();
builder.Services.AddScoped<Users>();
builder.Services.AddScoped<LoginModel>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x=>
{
    x.RequireHttpsMetadata = false; //https alan�na gerek yok
    x.TokenValidationParameters = new TokenValidationParameters // jwt konfig�rasyonu
    {
        ValidIssuer = "http://localhost", // jwt kim taraf�ndan olu�turulur
        ValidAudience = "http://localhost", // kim taraf�ndan kullan�lacak
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("movieappsecurity")), // jwtnin tam halini verir
        ValidateIssuerSigningKey = true, //token'nin ��z�m� i�in
        ValidateLifetime = true, //ger�ek zamanl� �al��abilmesi i�in
        ClockSkew = TimeSpan.Zero // zaman fark� olu�mamas� ad�na
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
