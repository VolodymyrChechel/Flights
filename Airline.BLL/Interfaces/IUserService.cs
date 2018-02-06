using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Airline.BLL.DTO;
using Airline.BLL.Infrastructure;

namespace Airline.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDto userDto);
        Task<ClaimsIdentity> Authenticate(UserDto userDto);
        Task SetInitialData(UserDto adminDto, List<string> roles);
    }
}