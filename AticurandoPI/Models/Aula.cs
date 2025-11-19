namespace AticurandoPI.Models
{
    public class Aula
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Conteudo { get; set; }

        public int MateriaId { get; set; }
        public Materia Materia { get; set; }

        public int TurmaId { get; set; }
        public Turma Turma { get; set; }

        public int? ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public ICollection<Presenca> Presencas { get; set; }
    }
}
