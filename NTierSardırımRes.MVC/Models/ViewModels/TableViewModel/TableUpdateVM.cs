namespace NTierSardırımRes.MVC.Models.ViewModels.TableViewModel
{
    public class TableUpdateVM
    {
        public int ID { get; set; }
        public bool Available { get; set; }
        public string TableNo { get; set; }
        public string Description { get; set; }
        public int? AppUserID { get; set; } //Simulasyonlarda kolaylık olması adına nullable int yapılmıstır...
    }
}
