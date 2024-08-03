using Bunnisses.Security.Interface;
using Data.DTO;
using Data.Implements;
using Data.Interfaces;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnisses.Security.Implements
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserData data;

        public UserBusiness(IUserData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await this.data.GetAll();
        }


        public async Task<UserDto> GetById(int id)
        {
            var user = await data.GetById(id);

            return new UserDto
            {
                Id = user.Id,
                Nombre_usuario = user.Nombre_usuario,
                Contraseña = user.Contraseña,
                PersonId = user.PersonId,
                person = user.person,
                State = user.State,
            };

        }

        public async Task<User> Save(UserDto entity)
        {
            User user = new User();
            user = this.mapearDatos(user, entity);

            return await data.Save(user);
        }


        public async Task Update(int Id, UserDto entity)
        {
            User user = await this.data.GetById(Id);
            if (user == null)
            {
                throw new ArgumentNullException("Registro no encontrado", nameof(entity));
            }
            user = this.mapearDatos(user, entity);

            await this.data.Update(user);
        }


        private User mapearDatos(User user, UserDto entity)
        {
            user.Id = entity.Id;
            user.Nombre_usuario = entity.Nombre_usuario;
            user.Contraseña = entity.Contraseña;
            user.PersonId = entity.PersonId;
            user.person = entity.person;
            user.State = entity.State;

            return user;
        }

        public async Task<User> GetByUsername(User user, int Id)
        {
            return await this.data.GetByUsername(user, Id);
        }

        public async Task<User> GetByPassword(User user, int Id)
        {
            return await this.data.GetByPassword(user, Id);
        }

    }
}