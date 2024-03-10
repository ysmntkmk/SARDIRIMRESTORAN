namespace NTierSardırımRes.MVC.Models.ViewModels.CustomerViewModel
{
    public class CustomerUpdateVM
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Adress { get; set; }

        public string? Phone { get; set; }

        public string Email { get; set; }
    }
}
