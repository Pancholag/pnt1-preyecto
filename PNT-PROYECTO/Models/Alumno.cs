namespace PNT_PROYECTO.Models
{
    public class Alumno : Persona
    {

        public ICollection<Examen>? ExamenesList { get; set; }


       
    }
}
