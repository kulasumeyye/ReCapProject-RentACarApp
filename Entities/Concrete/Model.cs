using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Model:IEntity
    {
        public int Id { get; set; }
        public int ModelNo { get; set; }
    }
}
