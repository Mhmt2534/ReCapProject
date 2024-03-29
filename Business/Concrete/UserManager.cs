﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;
    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public IResult Add(Users users)
    {
        _userDal.Add(users);
        return new SuccessResult(Messages.UserAdded);
    }

    public IResult Delete(Users users)
    {
        _userDal.Delete(users);
        return new SuccessResult(Messages.UserDeleted);
    }

  

    public IDataResult<List<Users>> GetAll()
    {
        return new SuccessDataResult<List<Users>>(_userDal.GetAll(),Messages.UserListed);
    }

    public IDataResult<Users> GetById(int id)
    {
        return new SuccessDataResult<Users>(_userDal.Get(u=>u.Id==id),Messages.UserCall);
    }

    public IDataResult<List<CompanyAndUserDetailDto>> GetDetail()
    {
        return new SuccessDataResult<List<CompanyAndUserDetailDto>>(_userDal.CompanyAndUserDetail(),Messages.UserListed);
    }

    public IResult Update(Users users)
    {
        _userDal.Update(users);
        return new SuccessResult(Messages.UserUpdated);
    }
}
