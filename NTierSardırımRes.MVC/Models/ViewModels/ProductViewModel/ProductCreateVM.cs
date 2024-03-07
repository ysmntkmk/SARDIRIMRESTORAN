using NTierSardırımRes.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.ProductViewModel
{
    public class ProductCreateVM
    {
       
        [Required(ErrorMessage = "Ürün adı boş geçilemez!")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Ürün fiyat boş geçilemez!")]
        public decimal? UnitPrice { get; set; }
        [Required(ErrorMessage = "Ürün açıklaması boş geçilemez!")]

        public string Description { get; set; }

        public DataStatus Status { get; set; }
    }
}
