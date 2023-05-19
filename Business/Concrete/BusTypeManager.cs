﻿using Business.Abstract;
using Business.Contans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BusTypeManager : IBusTypeService
    {
        IBusTypeDal _busTypeDal;
        public BusTypeManager(IBusTypeDal busTypeDal)
        {
            _busTypeDal = busTypeDal;
        }
        [ValidationAspect(typeof(BusTypeValidator))]
        public IResult Add(BusType busType)
        {
            IResult result = BussinessRules.Run(CheckIfBusTypeNameExists(busType.BusTypeName));
            if (result!=null)
            {
                return result;
            }
            _busTypeDal.Add(busType);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(BusType busType)
        {
            _busTypeDal.Delete(busType);
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<BusType>> GetAll()
        {
            return new SuccessDataResult<List<BusType>>(_busTypeDal.GetList().ToList());
        }

        public IDataResult<BusType> GetById(int id)
        {
            return new SuccessDataResult<BusType>(_busTypeDal.Get(b => b.Id == id));
        }
        [ValidationAspect(typeof(BusTypeValidator))]
        public IResult Update(BusType busType)
        {
            IResult result = BussinessRules.Run(CheckIfBusTypeNameExists(busType.BusTypeName));
            if (result != null)
            {
                return result;
            }
            _busTypeDal.Update(busType);
            return new SuccessResult(Messages.UpdatedSuccess);
        }
        private IResult CheckIfBusTypeNameExists(string busTypeName)
        {

            var result = _busTypeDal.GetList(p => p.BusTypeName == busTypeName).Any();
            if (result)
            {
                return new ErrorResult(Messages.BusTypeNameAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
