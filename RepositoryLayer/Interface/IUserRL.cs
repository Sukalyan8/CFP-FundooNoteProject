using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public UserEntity Registration(UserRegModel User);
        public string login(UserLogin userLogin);
        public string ForgetPassword(string email);
        public bool ResetPassWord(string email, string password, string confirmPassword);
    }
}
