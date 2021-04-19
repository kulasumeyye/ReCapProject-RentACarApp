using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class BuyDetailDto : IDto
    {
        public string Name { get; set; }
        public long Amount { get; set; }
        public string CreditCardNumber { get; set; }
        public string SecurityNumber { get; set; }
        public string MounthOfExpirationDate { get; set; }
        public string YearOfExpirationDate { get; set; }
    }
}
