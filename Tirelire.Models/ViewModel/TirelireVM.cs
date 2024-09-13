using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tirelire.Models.ViewModel
{
    public class TirelireVM
    {
        public Produit Tirelire { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? FabricantList { get; set; }
    }
}
