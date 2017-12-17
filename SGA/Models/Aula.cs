using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGA.Models
{
    public class Aula
    {
        public int AulaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Horario { get; set; }
        public int? ProfessorId { get; set; }
        public int? EmentaId { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        public DateTime? DtCadastro { get; set; }

        public virtual Ementa Ementa { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}