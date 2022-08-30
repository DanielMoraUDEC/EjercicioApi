using BusinessObject.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _iUser;
        public UserController(IUser iUser)
        {
            _iUser = iUser ?? throw new ArgumentNullException(nameof(iUser));
        }

        [HttpGet("GetUsers")]
        public async Task<PetitionResponse> GetUsers() => 
            await _iUser.GetAllUsers();

        [HttpPost("AddUser")]
        public async Task<PetitionResponse> AddUser(User user) =>
            await _iUser.AddUser(user);

        [HttpPatch("UpdtUser")]
        public async Task<PetitionResponse> UpdtUser(User user) =>
            await _iUser.UpdateUser(user, user.UserId);

    }
}
