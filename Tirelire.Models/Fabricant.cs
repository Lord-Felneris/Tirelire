using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tirelire.Models
{
    //class fabricant
    public class Fabricant
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Veuillez saisir le {0} !")]
        [MaxLength(70)]
        [DisplayName("Nom du fabricant")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Veuillez saisir le {0} !")]
        [DisplayName("Pays du fabricant")]
        public string? Pays { get; set; }
    }
}
