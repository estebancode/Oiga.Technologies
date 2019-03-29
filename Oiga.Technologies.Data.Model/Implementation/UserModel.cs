
#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using NHibernate;
using NHibernate.Linq;
using Oiga.Technologies.Data.Entities.Database;
using Oiga.Technologies.Data.Entities.DTO;
using Oiga.Technologies.Data.Entities.Entity;
using Oiga.Technologies.Data.Model.Interfaces;

#endregion

namespace Oiga.Technologies.Data.Model.Implementation
{
    public class UserModel : IUserModel
    {
        public async Task<UserDTO> CreateAsync(UserDTO entity)
        {
            using (ISession _context = NhibernateSession.OpenSession())
            {
                using (ITransaction transaction = _context.BeginTransaction())   //  Begin a transaction
                {
                    var userEntity = Mapper.Map<UserDTO, User>(entity);
                    await _context.SaveAsync(userEntity); //  Save the book in session
                    transaction.Commit();   //  Commit the changes to the database
                    return Mapper.Map<User, UserDTO>(userEntity);
                }
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (ISession _context = NhibernateSession.OpenSession())
            {
                User userEntity = await _context.GetAsync<User>(id);

                using (ITransaction transaction = _context.BeginTransaction())
                {
                    await _context.DeleteAsync(userEntity);
                    transaction.Commit();
                    return true;
                }
            }
        }

        public async Task<bool> EditAsync(UserDTO entity)
        {
            using (ISession _context = NhibernateSession.OpenSession())
            {
                using (ITransaction transaction = _context.BeginTransaction())
                {

                    User userEntity = Mapper.Map<UserDTO, User>(entity);
                    await _context.SaveOrUpdateAsync(userEntity);
                    transaction.Commit();
                    return true;
                }
            }
        }

        public async Task<List<UserDTO>> GetAll(int quantity = 0)
        {
            using (ISession _context = NhibernateSession.OpenSession())
            {

                if (quantity == 0)
                    return await _context.Query<User>().ProjectTo<UserDTO>().ToListAsync();
                else
                {
                    return await _context.Query<User>().Take(quantity).ProjectTo<UserDTO>().ToListAsync();
                }
            }
        }

        public async Task<List<UserDTO>> GetAllBy(Expression<Func<UserDTO, bool>> condition)
        {
            using (ISession _context = NhibernateSession.OpenSession())
            {
                return await _context.Query<User>().ProjectTo<UserDTO>().Where(condition).ToListAsync();
            }
        }

        public List<UserDTO> GetAllSync()
        {
            using (ISession session = NhibernateSession.OpenSession())
            {
                var result = session.Query<User>().ToList();

                var list = Mapper.Map<List<User>, List<UserDTO>>(result);
                return list;
            }
        }

        public async Task<UserDTO> GetBy(Expression<Func<UserDTO, bool>> condition)
        {
            using (ISession _context = NhibernateSession.OpenSession())
            {
                return await _context.Query<User>().ProjectTo<UserDTO>().FirstOrDefaultAsync(condition);
            }
        }

        public async Task<UserDTO> GetById(int id)
        {
            using (ISession _context = NhibernateSession.OpenSession())
            {
                var entity = await _context.Query<User>().Where(u => u.Id == id).FirstOrDefaultAsync();
                return Mapper.Map<User, UserDTO>(entity);
            }
        }
    }
}
