using NTierSardırımRes.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.IngredientViewModel
{
    public class IngredientCreateVM
    {
        public IngredientCreateVM()
        {
            Status = DataStatus.Inserted;
        }

        [Required(ErrorMessage = "Boş geçilemez!")]
        public string Name { get; set; }
        public int UnitsInStock { get; set; }
        public DataStatus Status { get; set; }
    }
}
