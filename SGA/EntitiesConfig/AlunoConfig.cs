using SGA.Models;
using System.Data.Entity.ModelConfiguration;

namespace SGA.EntitiesConfig
{
    public class AlunoConfig : EntityTypeConfiguration<Aluno>
    {
        public AlunoConfig()
        {
            HasKey(a => a.AlunoId);
            // Map(t => t.MapInheritedProperties().ToTable("Aluno"));
            Property(t => t.Cpf).HasMaxLength(11);
            Property(t => t.Nome).HasMaxLength(30);
            Property(t => t.Sobrenome).HasMaxLength(100);

            Property(t => t.Endereco).HasMaxLength(100);
            Property(t => t.Numero).HasMaxLength(8);
            Property(t => t.Cidade).HasMaxLength(100);
            Property(t => t.Estado).HasMaxLength(2);
            Property(t => t.Cep).HasMaxLength(8);


        }
    }
}