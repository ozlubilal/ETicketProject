using Business.Abstract;
using Business.Contans;
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
    public class GenderManager : IGenderService
    {
        IGenderDal _genderDal;
        public GenderManager(IGenderDal genderDal)
        {
            _genderDal = genderDal;
        }
        public IResult Add(Gender gender)
        {
            _genderDal.Add(gender);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(Gender gender)
        {
            _genderDal.Delete(gender);
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<Gender>> GetAll()
        {
            return new SuccessDataResult<List<Gender>>(_genderDal.GetList().ToList());
        }

        public IDataResult<Gender> GetById(int id)
        {
            return new SuccessDataResult<Gender>(_genderDal.Get(g => g.Id == id));
        }

        public IResult Update(Gender gender)
        {
            _genderDal.Update(gender);
            return new SuccessResult(Messages.UpdatedSuccess);
        }
    }
}
