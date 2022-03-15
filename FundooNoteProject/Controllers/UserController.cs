using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FundooNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        //[HttpPost("Register")]
        //public IActionResult Registration(UserRegistration User)
        //{
        //    try
        //    {
        //        //var result = userBL.Registration(user);
        //        //var result = this.userBL.Registration(User);
        //        if (result != null)
        //            return this.Ok(new { success = true, message = "Registration Successful", data = result });
        //        else
        //            return this.BadRequest(new { success = false, message = "Registration UnSuccessful" });
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        [HttpPost("Register")]
        public IActionResult UserRegistration(UserRegModel userRegistration)
        {
            try
            {
                var result = userBL.Registration(userRegistration);
                if (result != null)
                    return this.Ok(new { success = true, message = "Registration Successful", data = result });
                else
                    return this.BadRequest(new { success = false, message = "Registration UnSuccessful" });
           

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("Login")]

        public IActionResult login(UserLogin userLogin)
        {
            try
            {
                var result = userBL.login(userLogin);

                if (result != null)
                    return this.Ok(new { success = true, message = "Login Successful", data = result });
                else
                    return this.BadRequest(new { success = false, message = "Login UnSuccessful" });

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("ForgetPassword")]

        public IActionResult ForgetPassword(string email)
        {
            try
            {
                var result = userBL.ForgetPassword(email);

                if (result != null)
                    return this.Ok(new { success = true, message = "Mail Sent is Successful" });
                else
                    return this.BadRequest(new { success = false, message = "Enter valid Email" });

            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPut("ResetPassword")]

        public IActionResult ResetPassword(string password, string confirmPassword)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = userBL.ResetPassWord(email, password, confirmPassword);

                if (!result)
                    return this.BadRequest(new { success = false, message = "Enter valid Password" });
                else
                    
                return this.Ok(new { success = true, message = "Reset Passsword is Successful" });

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}