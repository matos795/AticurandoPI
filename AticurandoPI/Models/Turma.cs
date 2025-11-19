using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AticurandoPI.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public int Capacidade { get; set; } = 35;
        public string Turno { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataFim { get; set; }

        public int CursoId { get; set; }

        [ValidateNever]
        public Curso Curso { get; set; }
    }
}
