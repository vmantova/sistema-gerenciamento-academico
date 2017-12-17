using System;
using System.ComponentModel.DataAnnotations;

namespace SGA.Models
{
    public class Doacao
    {
        public int DoacaoId { get; set; }
        public string Item { get; set; }
        public int? Quantidade { get; set; }
        public decimal? Preco { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}