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
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int ProduitId {  get; set; }
        [ForeignKey("ProduitId")]
        [ValidateNever]
        public Produit? Produit { get; set; }
        [Range(1,100,ErrorMessage ="Saissisez une valeur entre 1 et 100 !")]
        public int Count { get; set; }

        public string? AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        [ValidateNever]
        public AppUser? AppUser { get; set; }
        [NotMapped]
        public double Price { get; set; }

    }
}
