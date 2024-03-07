﻿using NTierSardırımRes.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Entities.Interfaces
{
    public interface IEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set;}
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
       



    }
}
