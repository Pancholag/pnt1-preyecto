using System.ComponentModel.DataAnnotations;
using static System.Net.WebRequestMethods;

namespace PNT_PROYECTO.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }
        [Url]
        public string? Link { get; set; }
        [Required]
        public string? Texto { get; set; }
        [Required]
        public string? Titulo { get; set; }
        public ICollection<Examen>? Examenes { get; set; }
        public Profesor? Profe { get; set; }
        [Required]
        public int ProfeId { get; set; }
        public int VecesVisto { get; set; }
        public int VecesDescargado { get; set; }
        //necesita key??
        //public Material()
        //{
        //    Imagenes = new IOCollection<string>();
        //}
    }
}
