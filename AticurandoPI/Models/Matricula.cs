using AticurandoPI.Models.Enumeracoes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AticurandoPI.Models
{
    public class Matricula
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;
        public float Frequencia { get; set; } = 0;
        public StatusMatricula Status { get; set; } = StatusMatricula.PENDENTE;

        [ValidateNever]
        public String? MotivoCancelamento { get; set; } = null;


        public int AlunoId { get; set; }

        [ValidateNever]
        public Aluno Aluno { get; set; }

        public int TurmaId { get; set; }

        [ValidateNever]
        public Turma Turma { get; set; }

    }
}
