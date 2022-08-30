using DataAccess.ApplicationDbContext;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules.BusinessObject
{
    public class BOUser
    {
        private readonly ApplicationDbContext _db;
        public string message;
        public object result = "";
        public BOUser(ApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<bool> GetAllUsers()
        {
            try
            {
                result = await _db.Users.ToListAsync();
                message = "Usuarios consultados con éxito";
                return true;
            }
            catch (Exception ex)
            {
                message = $"Un error ocurrio al consultar los usuarios. {ex.Message}";
                return false;
            }
        }


        public async Task<bool> AddUser(User user)
        {
            try
            {
                _db.Users.Add(user);
                if(await _db.SaveChangesAsync() <= 0)
                {
                    message = "No fue posible agregar el usuario";
                    return true;
                }
                message = "Usuario agregado con exito";
                return true;
            }
            catch (Exception ex)
            {
                message = $"Un error ocurrio al guardar el usuario. {ex.Message}";
                return false;
            }
        }
    }
}
