﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Insert(user);
            return new SuccessResult(UserMessages.UserAdded);
        }

        [SecuredOperation("admin,mudur,personel")]
        public IResult Delete(int userId)
        {
            var dataResult = _userDal.Get(x => x.Id == userId);
            if (dataResult != null)
            {
                _userDal.Delete(dataResult);
                return new SuccessResult(UserMessages.UserDeleted);
            }
            return new ErrorResult(UserMessages.UserNotFound);
        }

        [SecuredOperation("admin,mudur,personel")]
        public IDataResult<List<User>> GetAll()
        {
            var dataResult = _userDal.GetAll();
            if (dataResult != null)
            {
                return new SuccessDataResult<List<User>>(dataResult, UserMessages.UsersList);
            }
            return new ErrorDataResult<List<User>>(UserMessages.UserNotFound);
        }

        [SecuredOperation("admin,mudur,personel")]
        public IDataResult<User> GetById(int id)
        {
            var dataResult = _userDal.Get(u => u.Id == id);
            if (dataResult != null)
            {
                return new SuccessDataResult<User>(dataResult, UserMessages.OneUsersList);
            }
            return new ErrorDataResult<User>(UserMessages.UserNotFound);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var dataResult = _userDal.Get(u => u.Email == email);
            if (dataResult != null)
            {
                return new SuccessDataResult<User>(dataResult, UserMessages.OneUsersList);
            }
            return new ErrorDataResult<User>(UserMessages.UserNotFound);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(UserMessages.UserUpdated);
        }
    }
}
