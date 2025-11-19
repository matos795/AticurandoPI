namespace AticurandoPI.Models
{
    public class Presenca
    {
        public int Id { get; set; }
        public bool Presente { get; set; }
        public DateTime Data { get; set; }

        public int MatriculaId { get; set; }
        public Matricula Matricula { get; set; }

        public int AulaId { get; set; }
        public Aula Aula { get; set; }
    }
}
