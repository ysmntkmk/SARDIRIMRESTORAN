namespace NTierSardırımRes.MVC.Models.ViewModels.LoginViewModel
{
    public class AppUserVM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
      
        public bool EmailConfirmed { get; set; }
        public List<string> Roles { get; set; }
    }
}
