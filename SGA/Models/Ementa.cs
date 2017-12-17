using System;
using System.ComponentModel.DataAnnotations;

namespace SGA.Models
{
    public class Ementa
    {
        public int EmentaId { get; set; }
        public string Descricao { get; set; }
        public string Bibliografia { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        public DateTime DtCadastro { get; set; }
        public int? AulaId { get; set; }
        public virtual Aula Aula { get; set; }
    }
}