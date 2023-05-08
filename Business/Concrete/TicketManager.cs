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
    public class TicketManager : ITicketService
    {
        ITicketDal _ticketDal;
        public TicketManager(ITicketDal ticketDal)
        {
            _ticketDal = ticketDal;
        }
        public IResult Add(Ticket ticket)
        {
            _ticketDal.Add(ticket);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(Ticket ticket)
        {
            _ticketDal.Delete(ticket);
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<Ticket>> GetAll()
        {
            return new SuccessDataResult<List<Ticket>>(_ticketDal.GetList().ToList());
        }             

        public IDataResult<List<Ticket>> GetByCustomerId(int id)
        {
            return new SuccessDataResult<List<Ticket>>(_ticketDal.GetList(t => t.CustomerId == id).ToList());
        }

        public IDataResult<Ticket> GetById(int id)
        {
            return new SuccessDataResult<Ticket>(_ticketDal.Get(t => t.Id == id));
        }

        public IDataResult<List<Ticket>> GetByTripId(int tripId)
        {
            return new SuccessDataResult<List<Ticket>>(_ticketDal.GetList(t => t.TripId == tripId));
        }
        public IDataResult<List<TicketDto>> GetAllTicketDto()
        {
            return new SuccessDataResult<List<TicketDto>>(_ticketDal.GetAllTripDto().ToList());
        }

        public IDataResult<List<TicketDto>> GetTicketDtoByIdentityNumber(string identityNumber)
        {
            return new SuccessDataResult<List<TicketDto>>(_ticketDal.GetAllTripDto(t=>t.IdentityNumber==identityNumber).ToList());
        }

        public IResult Update(Ticket ticket)
        {
            _ticketDal.Update(ticket);
            return new SuccessResult(Messages.UpdatedSuccess);
        }
           
        //sefer ait dolu koltuk numaraları alınıyor
        public IDataResult<List<int>> GetSeatNumberOfTripList(int tripId)
        {
            //seçilen sefere ait bilet listesi alınıyor
           var ticketList= GetByTripId(tripId).Data;
            List<int> seatNumberOfTripList = new List<int>();
           //bilet listesindeki koltuk numaraları listesi oluşturuluyor
            foreach (var item in ticketList)
            {
                seatNumberOfTripList.Add(_ticketDal.Get(t => t.Id == item.Id).SeatNumber);
            }
            return new SuccessDataResult<List<int>>(seatNumberOfTripList);

        }
    }
}
