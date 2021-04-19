using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();


            }
        }

        public IResult AddUserAsCustomer()
        {
            using (RentACarContext context = new RentACarContext())
            {

                var resultUser = context.Users.OrderByDescending(u => u.Id).FirstOrDefault();

                if (resultUser.Id != -1)
                {
                    Customer customer = new Customer() { UserId = resultUser.Id, FindexPoint = 1900, CompanyName = resultUser.FirstName +" "+ resultUser.LastName };
                    context.Customers.Add(customer);
                    context.SaveChanges();
                    return new SuccessResult();
                }

                return new ErrorResult();
            } 
        }

    }
}
