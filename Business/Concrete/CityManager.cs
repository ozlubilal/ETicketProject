using Business.Abstract;
using Business.Contans;
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
    public class CityManager : ICityService
    {
        ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }
        public IResult Add(City city)
        {
            IResult result = BussinessRules.Run(CheckIfBusTypeNameExists(city.CityName));
            if (result != null)
            {
                return result;
            }
            _cityDal.Add(city);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(City city)
        {

            _cityDal.Delete(city);
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetList().ToList());
        }

        public IDataResult<City> GetById(int id)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.Id == id));
        }

        public IResult Update(City city)
        {
            IResult result = BussinessRules.Run(CheckIfBusTypeNameExists(city.CityName));
            if (result != null)
            {
                return result;
            }
            _cityDal.Update(city);
            return new SuccessResult(Messages.UpdatedSuccess);
        }
        private IResult CheckIfBusTypeNameExists(string cityName)
        {

            var result = _cityDal.GetList(p => p.CityName == cityName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CityNameAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
