using Business.Abstract;
using Business.Contans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IUserService _userService;
        IAuthService _authService;
        public CustomerManager(ICustomerDal customerDal,IUserService userService,IAuthService authService)
        {
            _customerDal = customerDal;
            _userService = userService;
            _authService = authService;
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(CustomerAddDto customerAddDto)
        {
            var result = BussinessRules.Run(CheckIfIdentityNumberExists(customerAddDto));
            if (result != null)
            {
                return result;
            }

            UserForRegisterDto userForRegisterDto = new UserForRegisterDto
            {
                Email = customerAddDto.Email,
                Password = customerAddDto.Password,
                FirstName = customerAddDto.FirstName,
                LastName = customerAddDto.LastName,
                OperationClaimId = 2,
            };
            _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            Customer customer = new Customer
            {
                UserId = _userService.GetByEmail(customerAddDto.Email).Id,
                IdentityNumber = customerAddDto.IdentityNumber,
                PhoneNumber = customerAddDto.PhoneNumber,
                GenderId = customerAddDto.GenderId,
            };

            _customerDal.Add(customer);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetList());
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(r => r.Id == id));
        }

        public IDataResult<Customer> GetByIdentityNumber(string identityNumber)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(r => r.IdentityNumber == identityNumber));
        }

        
        public IDataResult<Customer> GetByPhoneNumber(string phoneNumber)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(r => r.PhoneNumber == phoneNumber));
        }

        public IDataResult<Customer> GetByUserId(int userId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(r => r.UserId == userId)); 
        }
        public IDataResult<List<CustomerDto>> GetAllCustomerDto()
        {
            return new SuccessDataResult<List<CustomerDto>>(_customerDal.GetAllCustomerDto());
        }

        public IResult Update(CustomerAddDto customerAddDto)
        {
            var result = BussinessRules.Run(CheckIfIdentityNumberExists(customerAddDto));
            if (result != null)
            {
                return result;
            }


            Customer customer = _customerDal.Get(r => r.Id == customerAddDto.Id);
            User user = _userService.GetById(customer.UserId).Data;
            user.FirstName = customerAddDto.FirstName;
            user.LastName = customerAddDto.LastName;
            user.Email = customerAddDto.Email;            
            _userService.Update(user);

            customer.IdentityNumber = customerAddDto.IdentityNumber;
            customer.PhoneNumber = customerAddDto.PhoneNumber;
            customer.GenderId = customerAddDto.GenderId;
            _customerDal.Update(customer);
            return new SuccessResult(Messages.UpdatedSuccess);
        }

        public IDataResult<CustomerDto> GetCustomerDtoById(int id)
        {
            return new SuccessDataResult<CustomerDto>(_customerDal.GetAllCustomerDto(r => r.Id == id).FirstOrDefault());
        }
        private IResult CheckIfIdentityNumberExists(CustomerAddDto customerAddDto)
        {
            var result = _customerDal.GetList(c => c.IdentityNumber == customerAddDto.IdentityNumber).Any();
            if (result)
            {
                return new ErrorResult(Messages.customerAlreadyExistsByIdenityNumber);
            }
            return new SuccessResult();
        }       
    }
}
