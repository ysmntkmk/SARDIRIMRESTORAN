using NTierSardırımRes.BLL.Abstracts;
using NTierSardırımRes.BLL.Concretes;
using NTierSardırımRes.DAL.Context;
using NTierSardırımRes.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSardırımRes.BLL.Services
{
    public class AppUserRepository:BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(SardirimContext context) : base(context) 
        { 

        }
    }
}
