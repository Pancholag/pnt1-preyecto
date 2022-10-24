namespace PNT_PROYECTO.Models
{
    public class Alumno : Persona
    {

        public List<Examen> ExamenesList { get; set; }


        public Alumno()
        {
            ExamenesList = new List<Examen>();
        }
    }
}
