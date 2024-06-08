using RoomService.Core.ApiResponse;
using RoomService.Domain.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomService.Core.Abstraction
{
    public interface IUserService
    {
        Task<ApiResponse<object>> CreateUser(UsersDto model);
        Task<ApiResponse<object>> LoginUser(UsersDto model);
    }
}
