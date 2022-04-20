using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Dto;
using MovieApp.Entities.Concrete;
using MovieApp.Services.JWToken;
using MovieApp.Uow;

namespace MovieApp.Services.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        Users _users;

        public AuthController(IUnitOfWork unitOfWork, Users users)
        {
            _unitOfWork = unitOfWork;
            _users = users;
        }

        [HttpPost(Name = "Register")]
        public IActionResult Register(RegisterModel model)
        {
            _users.UserName = model.UserName;
            _users.Mail = model.Mail;
            _unitOfWork._authRepository.Register(_users, model.Password);
            // Save metodunu kullanmama sebebimiz Register'da save metodunun çalışmasıdır
            return Ok(_users); //return ok http status üretir
        }


        [HttpPost(Name = "UserLogin")]
        public IActionResult UserLogin(LoginModel model)
        {
            Users users = _unitOfWork._authRepository.Login(model.UserName, model.Password);
            var token = new BuildToken().CreateToken();
            if (users == null)
            {
                return Unauthorized();
            }
            else
            {
                return Created("", token);
            }
        }

        //[HttpPost(Name ="Deneme2")]
        //public IActionResult Deneme2()
        //{
        //    return Created("",new BuildToken().CreateToken());
        //}


        [Authorize]
        [HttpGet(Name ="Deneme")]
        public IActionResult Deneme()
        {
            return Ok("Kullanıcı girişi başarılı");
        }

       

    }
}
