using System.ComponentModel.DataAnnotations;

namespace PNT_PROYECTO.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }
        public string? Link { get; set; }
        public string? Texto { get; set; }
        public string? Titulo { get; set; }
        
        //public List<String> Imagenes { get; set; }
        //necesita key??
        //public Material()
        //{
        //    Imagenes = new List<string>();
        //}
    }
}
