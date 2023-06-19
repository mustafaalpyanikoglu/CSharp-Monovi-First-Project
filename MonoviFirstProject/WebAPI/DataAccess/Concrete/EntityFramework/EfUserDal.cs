using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : GenericRepository<User, Context>, IUserDal
    {
        public EfUserDal(Context context) : base(context)
        {
        }
    }
}