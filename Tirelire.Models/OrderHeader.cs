using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tirelire.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public string? AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        [ValidateNever]
        public AppUser? AppUser { get; set; }
        public DateTime DateCommande { get; set; }
        public DateTime DateLivraison { get; set; }
        public double OrderTotal { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateOnly PaymentDueDate { get; set; }
        //use to identify each payment
        public string? PaymentIntentId { get; set; }

        //.....info about who pay
        [Required]
        public string? Nom {  get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
