using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IServiceCreditCardService
    {
        //Servis kullanımı için yazıldı
        IResult Buy(BuyDetailDto buyDto);
        IResult Refund(BuyDetailDto buyDto);
    }
}
