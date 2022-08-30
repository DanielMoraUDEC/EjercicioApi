using BusinessObject.Interfaces;
using DataAccess.ApplicationDbContext;
using DataAccess.Models;
using Rules.BusinessObject;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Services
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _db;
        public UserService(ApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<PetitionResponse> AddUser(User user)
        {
            BOUser objUser = new BOUser(_db);
            var result = await objUser.AddUser(user);

            return new PetitionResponse
            {
                Success = result,
                URL = "api/User/AddUser",
                Message = objUser.message,
                Result = objUser.result
             };

        }

        public Task<PetitionResponse> DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<PetitionResponse> GetAllUsers()
        {
            BOUser objUser = new BOUser(_db);
            var result = await objUser.GetAllUsers();

            return new PetitionResponse
            {
                Success = result,
                URL = "api/User/GetAllUsers",
                Message = objUser.message,
                Result = objUser.result
            };
        }

        public Task<PetitionResponse> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<PetitionResponse> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
