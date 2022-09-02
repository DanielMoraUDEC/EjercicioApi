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

        public async Task<bool> UpdtUser(User user, int id)
        {
            try
            {
                if (user.UserId == id || !CheckName(user.Name))
                {
                    _db.Users.Update(user);
                    if (await _db.SaveChangesAsync() <= 0)
                    {
                        message = "No fue posible actualizar el usuario";
                        return true;
                    }
                    message = "Usuario actualizado con exito";
                    return true;
                }
                else
                {
                    message = "El id del usuario no coincide o el nombre ya está registrado";
                    return false;
                }
            }
            catch(Exception ex)
            {
                message = $"Un error ocurrió al actualizar el usuario. {ex.Message}";
                return false;
            }
        }

        private bool CheckName(string name)
        {
            return _db.Users.Any(x => x.Name == name);
        }

        public async Task<bool> GeyUserById(int UserID){

            try{
                if (_db.Users.Any(x => x.UserId == UserID))
                {
                    result = _db.Users.FirstOrDefault(x => x.UserId == UserID);
                    return true;
                }
                else
                {
                    message = $"Usuario no encontrado";
                    return false;
                }
            }
            catch(Exception ex){
                message = $"Un error ocurrio al buscar el usuario. {ex.Message}";
                return false;
                //comentario que no sirve
            }
        }
    }
}
