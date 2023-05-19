using Business.Abstract;
using Business.Contans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetList().ToList());
        }

        public IDataResult<List<UserDetailDto>> GetAllUserDto()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        public User GetByEmail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<UserDetailDto> GetUserDtoById(int id)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetails().Where(u => u.UserId == id).FirstOrDefault());
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            //User user = new User
            //{
            //    Id = user.Id,
            //    FirstName = userForUpdateDto.FirstName,
            //    LastName = userForUpdateDto.LastName,
            //    Email = userForUpdateDto.Email,
            //};
            _userDal.Update(user);
            return new SuccessResult(Messages.UpdatedSuccess);
        }

        public IDataResult<UserDetailDto> GetUserDtoByEmail(string email)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetails().Where(u => u.Email == email).FirstOrDefault());
        }
    }
}
