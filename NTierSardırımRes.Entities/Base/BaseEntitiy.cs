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
        public string CreatedIpAddress { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedIpAddress { get; set; }
        public string UpdatedComputerName { get; set; }
        public string CreatedComputerName { get; set; }
    }
}

