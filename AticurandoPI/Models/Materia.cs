namespace AticurandoPI.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<Aula> Aulas { get; set; }
    }
}
