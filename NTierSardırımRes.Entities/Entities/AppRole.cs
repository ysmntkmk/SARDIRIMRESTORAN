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
    public class AppRole : IdentityRole<int>, IEntity
    {
        public AppRole() 
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        //Id
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

     

        // Relation Properties
        public virtual List<AppUserRole> UserRoles { get; set; }
       
    }
}
