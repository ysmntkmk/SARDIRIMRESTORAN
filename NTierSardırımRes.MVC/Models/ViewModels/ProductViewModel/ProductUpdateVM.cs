using NTierSardırımRes.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.ProductViewModel
{
    public class ProductUpdateVM
    {

        public int ID { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }
        public string Description { get; set; }

     
    }
}
