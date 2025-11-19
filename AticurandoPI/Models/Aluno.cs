namespace AticurandoPI.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }
    }
}
