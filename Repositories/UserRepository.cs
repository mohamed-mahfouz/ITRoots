using ITRoots.Models;
using ITRoots.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITRoots.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository()
        {
            this._dbContext = new ApplicationDbContext();
        }

        public User AddUser(RegisterViewModel registerViewModel)
        {
           

            var user = new User
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                ConfirmPassword = registerViewModel.ConfirmPassword,
                Email = registerViewModel.Email,
                Password = registerViewModel.Password,
                UserName = registerViewModel.UserName,            
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            var userRole = "User";
            if (_dbContext.Users.Count() == 1)
                userRole = "Admin";

            _dbContext.UserRoles.Add(new UserRole { UserId = user.Id, RoleId = _dbContext.Roles.First(r => r.RoleName == userRole).Id });
            _dbContext.SaveChanges();
            return user;
        }

    }
}