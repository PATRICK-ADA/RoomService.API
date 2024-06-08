using Microsoft.AspNetCore.Identity;
using RoomService.Core.Abstraction;
using RoomService.Core.ApiResponse;
using RoomService.Domain.Entities;
using RoomService.Domain.UserDto;
using RoomService.Infrastructure.Data;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RoomService.Core.Service
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public UserRepository(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
             
        }

        public async Task<ApiResponse<object>> CreateUser(UsersDto model)
        {
            var user = new UserModel
            {
                UserName = model.Email,
                Email = model.Email,
                Password = model.Password
            };

            var result = await _userManager.CreateAsync(user, model.Password);
           
            if (result.Succeeded is false)
            {
                return new FailureApiResponse("User Creation Failed", result);
            }
            return new SuccessApiResponse<UsersDto>("User Creation Successful", result);
        }


        public async Task<ApiResponse<object>> LoginUser(UsersDto model)
        {

            var result = await _userManager.FindByNameAsync(model.Email);

            if (result is null)
            {
                return new FailureApiResponse("","User does not exist");
            }
            
            if (model.Password == result.Password && model.Email == result.UserName)
            {

                await _signInManager.SignInAsync(result, true);
                return new SuccessApiResponse<UsersDto>("User Logged in Successfully", result);
            }
            return new FailureApiResponse("","User Login failed");

        }
    }
}
