namespace PNT_PROYECTO.Models
{
    public class Profesor : Persona
    {
        public DateTime FechaInicio { get; set; }
        public string? Descripcion { get; set; }
        public Rol? Tipo { get; set; }

        public enum Rol
        {
            JTP, ATP, ADJUNTO, TITULAR
        }



    }
}
