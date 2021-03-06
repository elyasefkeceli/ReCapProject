using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User users)
        {
            _userDal.Add(users);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User users)
        {
            _userDal.Delete(users);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.UserId==userId));
        }

        public IResult Update(User users)
        {
            _userDal.Update(users);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
