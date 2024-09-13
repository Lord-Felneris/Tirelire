using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tirelire.Models
{
    public class Produit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Nom du Tirelire")]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? FabricantId { get; set; }
        [ForeignKey("FabricantId")]
        [ValidateNever]
        public Fabricant? Fabricant { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public int Prix { get; set; }
        [Required]
        [DisplayName("largeur")]
        public int Width { get; set; }
        [Required]
        [DisplayName("Hauteur")]
        public int Height { get; set; }
        [Required]
        public double Poids { get; set; }
        [Required]
        public string? Couleur { get; set; }
        [Required]
        public int Capacite { get; set; }
        [Required]
        public int Longueur { get; set; }


    }
}
