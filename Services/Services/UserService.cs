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

        public async Task<PetitionResponse> GetByUserId(int userId)
        {
            BOUser objeto = new BOUser(_db);
            var result = await objeto.GeyUserById(userId);

            return new PetitionResponse
            {
                Success = result,
                URL = "api/User/TraerUsuario",
                Message = objeto.message,
                Result = objeto.result
            };
        }

        public async Task<PetitionResponse> getUsuarioID(int UserId)
        {
            BOUser objeto = new BOUser(_db);
            var result = await objeto.GeyUserById(UserId);

            return new PetitionResponse
            {
                Success = result,
                URL = "api/User/TraerUsuario",
                Message = objeto.message,
                Result = objeto.result
            };
            
        }

        public async Task<PetitionResponse> UpdateUser(User user, int id)
        {
            BOUser objUser = new BOUser(_db);
            var result = await objUser.UpdtUser(user, id);

            return new PetitionResponse
            {
                Success = result,
                URL = "api/User/UpdtUser",
                Message = objUser.message,
                Result = objUser.result
            };
        }
    }
}
