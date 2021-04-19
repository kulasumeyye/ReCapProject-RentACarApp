﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string CardNumber { get; set; }
        public string SecurityNumber { get; set; }
        public string MounthOfExpirationDate { get; set; }
        public string YearOfExpirationDate { get; set; }
        public long Balance { get; set; }
    }
}
