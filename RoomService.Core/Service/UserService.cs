using Microsoft.AspNetCore.Identity;
using RoomService.Core.Abstraction;
using RoomService.Core.ApiResponse;
using RoomService.Domain.Entities;
using RoomService.Domain.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomService.Core.Service
{
    public class UserService : IUserService
    {
      
        
        private readonly IUserRepository _userRepository; 
        public UserService(IUserRepository userRepository) 
        {
        _userRepository = userRepository;
        }
        public async Task<ApiResponse<object>> CreateUser(UsersDto model)
        {

            return (model is not null) ? await _userRepository.CreateUser(model): new FailureApiResponse("","User regiteristration failed");


        }

       
        public async Task<ApiResponse<object>> LoginUser(UsersDto model)
        {
            
         return (model is not null) ? await _userRepository.LoginUser(model) : new FailureApiResponse("","User Login failed"); 
            
        }
    }
}         