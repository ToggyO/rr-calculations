using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RrNetBack.Common.Models.Pagination;
using RrNetBack.Domain.Models.Users;

namespace RrNetBack.DAL.Repository.Users.Implementation
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;
        
        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginationModel<UserModel>> GetList(PaginationModel model,
            bool? orderByReg, bool? orderByLastActivity)
        {
            var count = await _context.Users.CountAsync();
            var users = _context.Users.Skip((model.Page - 1) * model.PageSize)
                .Take(model.PageSize);

            if (orderByReg != null && orderByReg != false)
                users = users.OrderBy(x => x.RegistartionDate);

            if (orderByLastActivity != null && orderByLastActivity != false)
                users = users.OrderByDescending(x => x.LastActivityDate);

            await users.ToListAsync();
            var result = new PaginationModel<UserModel>
            {
                Page = model.Page,
                PageSize = model.PageSize,
                Total = count,
                Items = users,
            };
            return result;
        }
        
        public async Task<UserModel> Create(UserModel entity)
        {
            var user = await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            var result = user.Entity;
            return result;
        }

        public async Task CreateBulk(IEnumerable<UserModel> models)
        {
            await _context.Users.AddRangeAsync(models);
            await _context.SaveChangesAsync();
        }

        public async Task<UserModel> Delete(int id)
        {
            var entity = await _context.Users.FindAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteBulk(IEnumerable<UserModel> models)
        {
            _context.RemoveRange(models);
            await _context.SaveChangesAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            var entity = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public async Task<UserModel> Update(UserModel entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<UserModel> GetUsersByLifetime(ushort upperLimit)
        {
            var users = _context.Users
                .FromSqlInterpolated(
                    $"SELECT * FROM \"Users\" as u WHERE extract(day from u.\"LastActivityDate\") - extract(day from u.\"RegistartionDate\") >= {upperLimit}")
                .ToList();
            return users;
        }
    }
}