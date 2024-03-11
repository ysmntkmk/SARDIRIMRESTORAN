namespace NTierSardırımRes.MVC.Models.ViewModels.ReservationViewModel
{
    public class ReservationUptadeVM
    {
        public int ID { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Date { get; set; }
        public float Hour { get; set; }

        public int? CustomerID { get; set; }
        public int? AppUserID { get; set; }

    }
}
