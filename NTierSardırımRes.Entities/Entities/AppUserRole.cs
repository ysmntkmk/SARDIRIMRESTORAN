﻿using Microsoft.AspNetCore.Identity;
using NTierSardırımRes.Entities.Enums;
using NTierSardırımRes.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.Entities.Entities
{
    public class AppUserRole : IdentityUserRole<int>, IEntity
    {
        public AppUserRole() 
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }


        // Relation Properties
        public virtual AppUser User { get; set; }
        public virtual AppRole Role { get; set; }
    }
}
