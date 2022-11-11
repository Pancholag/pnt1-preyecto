using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PNT_PROYECTO.Models
{
    public class ExamenViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string? Titulo { get; set; }
        public SelectList? Materiales { get; set; }
        public Profesor? Profe { get; set; }
        [Required]
        public int ProfeId { get; set; }

        public List<Int32>? MaterialesSeleccionados { get; set; }

    }
}
