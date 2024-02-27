using NTierSardırımRes.Entities.Enums;
using NTierSardırımRes.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Entities.Base
{
    public abstract class BaseEntitiy : IEntity

    {
        public bool IsActive;

        public BaseEntitiy()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }

        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
        bool IEntity.IsActive { get; set; }
    }
}

