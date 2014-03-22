using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace BankingCheck_MichaelArellano.Models
{

    public class BankingCheck
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [DataType(DataType.Text)]
        [Display(Name = "Pay To")]
        public string AccountName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Check Date")]
        public DateTime CheckDate { get; set; }

        [Required]
        [Range(.01, 99999999.99, ErrorMessage = "Amount must be between {1} and {2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Amount")]
        public decimal AmountInNumbers { get; set; }

        public bool IsCheckVisible { get; set; }
        public string AmountInWords { get; set; }
    }

}