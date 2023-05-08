using Business.Abstract;
using Business.Contans;
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
    public class TownManager : ITownService
    {
        ITownDal _townDal;
        public TownManager(ITownDal townDal)
        {
            _townDal = townDal;
        }
        public IResult Add(Town town)
        {
            _townDal.Add(town);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(Town town)
        {
            _townDal.Delete(town);
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<Town>> GetAll()
        {
            return new SuccessDataResult<List<Town>>(_townDal.GetList());
        }
        public IDataResult<List<TownDto>> GetAllTownDto()
        {
            return new SuccessDataResult<List<TownDto>>(_townDal.GetAllTownDto());
        }
        public IDataResult<List<TownDto>> GetTownDtoByCityName(string cityName)
        {
            return new SuccessDataResult<List<TownDto>>(_townDal.GetAllTownDto(t=>t.CityName==cityName));
        }

        public IDataResult<Town> GetById(int id)
        {
            return new SuccessDataResult<Town>(_townDal.Get(t => t.Id == id));
        }

        public IDataResult<List<TownDto>> GetTownDtoByTownName(string townName)
        {
            return new SuccessDataResult<List<TownDto>>(_townDal.GetAllTownDto(t => t.TownName == townName));
        }

        public IResult Update(Town town)
        {
            _townDal.Update(town);
            return new SuccessResult(Messages.UpdatedSuccess);
        }

        public IDataResult<List<Town>> GetByCityId(int cityId)
        {
            return new SuccessDataResult<List<Town>>(_townDal.GetList(t => t.CityId == cityId));
        }
    }
}
