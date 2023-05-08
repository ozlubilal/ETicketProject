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
    public class RouteManager : IRouteService
    {
        IRouteDal _routeDal;
        public RouteManager(IRouteDal routeDal)
        {
            _routeDal = routeDal;
        }

        public IResult Add(Route route)
        {
            _routeDal.Add(route);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(Route route)
        {
            _routeDal.Delete(route);
            return new SuccessResult(Messages.UpdatedSuccess);
        }

        public IDataResult<List<Route>> GetAll()
        {
            return new SuccessDataResult<List<Route>>(_routeDal.GetList());
        }
        public IDataResult<Route> GetByTownsId(int startTownId,int finishTownId)
        {
            return new SuccessDataResult<Route>(_routeDal.Get(r => r.StartTownId == startTownId && r.FinishTownId == finishTownId));
        }

        public IDataResult<Route> GetById(int id)
        {
            return new SuccessDataResult<Route>(_routeDal.Get(r => r.Id == id));
        }       

        public IResult Update(Route route)
        {
            _routeDal.Update(route);
            return new SuccessResult(Messages.UpdatedSuccess);
        }

        public IDataResult<List<RouteDto>> GetAllRouteDto()
        {
            return new SuccessDataResult<List<RouteDto>>(_routeDal.GetAllTripDto());
        }
    }
}
