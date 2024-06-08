
using Microsoft.AspNetCore.Identity;
using RoomService.Core.ApiResponse;
using RoomService.Domain.Entities;
using RoomService.Domain.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomService.Core.Abstraction
{
    public interface IUserRepository
    {
        Task<ApiResponse<object>> CreateUser(UsersDto model);
        Task<ApiResponse<object>> LoginUser(UsersDto model);
    }
}
