using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tirelire.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

    }
}
