﻿using Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        User GetByEmail(string email);
        IDataResult<UserDetailDto> GetUserDtoByEmail(string email);
        IDataResult<List<UserDetailDto>> GetAllUserDto();
        IDataResult<UserDetailDto> GetUserDtoById(int id);
        public List<OperationClaim> GetClaims(User user);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);


    }
}
