using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Findergers1._0.Models
{
    public partial class Desaparecido
    {

        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string? Nombre { get; set; }
        public int? Edad { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Description")]
        public string? Descripcion { get; set; }
        [Display(Name = "Date")]
        public DateTime? FechaDesaparicion { get; set; }
        public byte[]? Imagen { get; set; }
    }
}
