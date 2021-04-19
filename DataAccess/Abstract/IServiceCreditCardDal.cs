using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IServiceCreditCardDal : IEntityRepository<ServiceCreditCard>
    {

        IResult Buy(BuyDetailDto buyDto);
        bool Refund(BuyDetailDto buyDto);
    }
}
