using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace NTierSardırımRes.MVC.Models.ViewModels.AppUserViewModel
{
    public class AppUserVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Roles { get; set; }
        public List<SelectListItem> RoleItems { get; set; }
        public string SelectedRole { get; set; } // Eklendi: Seçilen rolü tutmak için
    }
}
