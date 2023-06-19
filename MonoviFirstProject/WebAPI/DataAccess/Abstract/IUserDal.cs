using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal:IRepository<User>
    {
    }
}