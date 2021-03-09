using System.Collections.Generic;
using System.Threading.Tasks;
using RrNetBack.Common.Models.Pagination;
using RrNetBack.Domain.Models.Users;

namespace RrNetBack.DAL.Repository.Users
{
    public interface IUsersRepository : IBaseRepository<UserModel>
    {
        Task<PaginationModel<UserModel>> GetList(PaginationModel model,
            bool? orderByReg, bool? orderByLastActivity);
        Task CreateBulk(IEnumerable<UserModel> models);
        Task DeleteBulk(IEnumerable<UserModel> models);
        IEnumerable<UserModel> GetUsersByLifetime(ushort upperLimit);
    }
}