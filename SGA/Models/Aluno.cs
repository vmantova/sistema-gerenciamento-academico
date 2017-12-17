using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGA.Models
{
    public class Aluno
    {
        [Key]
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int? Idade { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DtNascimento { get; set; }
        public DateTime DtCadastro { get; set; } 
        [MaxLength(9)]
        public string TelefoneContato { get; set; }
        public ICollection<Doacao> Doacoes { get; set; }

        public virtual ICollection<Aula> Aulas { get; set; }
    }
}