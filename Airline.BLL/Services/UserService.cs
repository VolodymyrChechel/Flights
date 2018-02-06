using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Airline.BLL.DTO;
using Airline.BLL.Infrastructure;
using Airline.BLL.Interfaces;
using Airline.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Airline.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }


        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task<OperationDetails> Create(UserDto userDto)
        {
            IdentityUser user = await Database.Users.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new IdentityUser {Email = userDto.Email, UserName = userDto.Name};
                var result = await Database.Users.CreateAsync(user, userDto.Password);
                if (result.Errors.Any())
                {
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                }
                await Database.Users.AddToRoleAsync(user.Id, userDto.Role);

                Database.Save();
                return new OperationDetails(true, "User was successfully registered", "");
            }
            else
            {
                return new OperationDetails(false, "User with this login is already exist", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDto userDto)
        {
            ClaimsIdentity claim = null;

            IdentityUser user = await Database.Users.FindAsync(userDto.Email, userDto.Password);

            if (user != null)
                claim = await Database.Users.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            return claim;
        }

        public async Task SetInitialData(List<UserDto> users, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.Roles.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new IdentityRole{Name = roleName };
                    await Database.Roles.CreateAsync(role);
                }
            }

            foreach (var user in users)
            {
                await Create(user);
            }
        }
    }
}