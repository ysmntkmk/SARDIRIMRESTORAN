namespace NTierSardırımRes.MVC.Models.ViewModels.AppRoleViewModel
{
    public class RoleAssignVM
    {
        internal List<RoleAssignVM> Roles;

        public string Id { get; set; }
        public string Name { get; set; }
        public bool Exist { get; set; }
    }
}
