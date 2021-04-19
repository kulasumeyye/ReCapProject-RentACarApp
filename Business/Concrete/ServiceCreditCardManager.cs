using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ServiceCreditCardManager : IServiceCreditCardService
    {
        private IServiceCreditCardDal _serviceCreditCardDal;

        public ServiceCreditCardManager(IServiceCreditCardDal serviceCreditCardDal)
        {
            _serviceCreditCardDal = serviceCreditCardDal;
        }
        public IResult Buy(BuyDetailDto buyDto)
        {
            var result = _serviceCreditCardDal.Buy(buyDto);
            if (result.Success)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(result.Message);
            }
        }
        public IResult Refund(BuyDetailDto buyDto)
        {

            _serviceCreditCardDal.Refund(buyDto);
            return new SuccessResult();
        }
    }
}
