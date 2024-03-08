﻿using NTierSardırımRes.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace NTierSardırımRes.MVC.Models.ViewModels.CustomerVİewModel
{
    public class CustomerCreateVM

    {
        public CustomerCreateVM() 
        {
           DataStatus status = DataStatus.Inserted;
        }
        [Required(ErrorMessage = " adı boş geçilemez!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = " Soyadı boş geçilemez!")]
        public string LastName { get; set; }
        public string? Adress { get; set; }

        public string? Phone { get; set; }

        public string Email { get; set; }


    }
}
