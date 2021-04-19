using Core;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public int DailyPrice { get; set; }
        public int CarFindexPoint { get; set; }
        public int CustomerFindexPoint { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
