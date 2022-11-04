using Microsoft.Build.Framework;

namespace PNT_PROYECTO.Models
{
    public class Profesor : Persona
    {
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required] 
        public string? Descripcion { get; set; }
        [Required]
        public Rol? Tipo { get; set; }
        
        
        public ICollection<Material>? Materiales { get; set; }
        public ICollection<Examen>? Examenes { get; set; }
        
        public enum Rol
        {
            JTP, ATP, ADJUNTO, TITULAR
        }



    }
}
