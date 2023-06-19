using Core.Utilities.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(int userId);
        IResult Update(User user);
        IDataResult<User> GetById(int id);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByMail(string email);
    }
}
