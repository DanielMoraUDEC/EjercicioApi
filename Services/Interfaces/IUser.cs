using DataAccess.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Interfaces
{
    public interface IUser
    {
        public Task<PetitionResponse> GetAllUsers();
        public Task<PetitionResponse> GetByUserId(int userId);
        public Task<PetitionResponse> AddUser(User user);
        public Task<PetitionResponse> UpdateUser(User user);
        public Task<PetitionResponse> DeleteUser(int userId);
    }
}
