using System.ComponentModel.DataAnnotations;

namespace PNT_PROYECTO.Models
{
    public class MaterialViewModel
    {
        [Required]
        public IFormFile? Archivo { get; set; }
        [Required]
        public string? Texto { get; set; }
        [Required]
        public string? Titulo { get; set; }
        public Profesor? Profe { get; set; }
        [Required]
        public int ProfeId { get; set; }
        public int VecesVisto { get; set; }
        public int VecesDescargado { get; set; }
    }
}
