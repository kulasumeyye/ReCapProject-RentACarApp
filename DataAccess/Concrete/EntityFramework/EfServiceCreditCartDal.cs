using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfServiceCreditCardDal : EfEntityRepositoryBase<ServiceCreditCard, RentACarContext>, IServiceCreditCardDal
    {
        public IResult Buy(BuyDetailDto buyDto)
        {
            using (RentACarContext context = new RentACarContext())
            {

                var serviceCreditCard = context.Set<ServiceCreditCard>().SingleOrDefault(c => c.CardNumber == buyDto.CreditCardNumber
                && c.SecurityNumber == buyDto.SecurityNumber
                && c.MounthOfExpirationDate == buyDto.MounthOfExpirationDate
                && c.YearOfExpirationDate == buyDto.YearOfExpirationDate 
                && c.Name == buyDto.Name);
                if (serviceCreditCard != null)
                {
                    if (serviceCreditCard.Balance >= buyDto.Amount)
                    {
                        serviceCreditCard.Balance -= buyDto.Amount;
                        var updateServiceCreditCard = context.Entry(serviceCreditCard);
                        updateServiceCreditCard.State = EntityState.Modified;
                        context.SaveChanges();

                        var creditCard = context.CreditCards.SingleOrDefault(c => c.CardNumber == buyDto.CreditCardNumber
                              && c.SecurityNumber == buyDto.SecurityNumber
                              && c.MounthOfExpirationDate == buyDto.MounthOfExpirationDate
                              && c.YearOfExpirationDate == buyDto.YearOfExpirationDate
                              && c.UserName == buyDto.Name);

                            if (creditCard != null)
                            {
                                creditCard.Balance = serviceCreditCard.Balance;
                                var updateCreditCard = context.Entry(creditCard);
                                updateCreditCard.State = EntityState.Modified;
                                context.SaveChanges();
                            }

                        return new SuccessResult("Ödemeniz gerçekleştirilmiştir.");
                    }
                    return new ErrorResult("Yetersiz Bakiye.");

                }
                else
                {
                    return new ErrorResult("Kart Bilgileri Hatalı.");
                }



            }
        }

        public bool Refund(BuyDetailDto buyDto)
        {
            using (RentACarContext contex = new RentACarContext())
            {
                var serviceCreditCard = contex.Set<ServiceCreditCard>().SingleOrDefault(c => c.CardNumber == buyDto.CreditCardNumber);
                serviceCreditCard.Balance += buyDto.Amount;

                var creditCard = contex.Set<CreditCard>().SingleOrDefault(c => c.CardNumber == buyDto.CreditCardNumber);
                creditCard.Balance = serviceCreditCard.Balance;

                var updateServiceCreditCard = contex.Entry(serviceCreditCard);
                updateServiceCreditCard.State = EntityState.Modified;
                contex.SaveChanges();

                var updateCreditCard = contex.Entry(creditCard);
                updateCreditCard.State = EntityState.Modified;
                contex.SaveChanges();
                return true;
            }
        }
    }
}
