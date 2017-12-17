using SGA.Models;
using System.Data.Entity.ModelConfiguration;

namespace SGA.EntitiesConfig
{
    public class AulaConfig : EntityTypeConfiguration<Aula>
    {
        public AulaConfig()
        {
            Property(t => t.Titulo).HasMaxLength(30);
            Property(t => t.Descricao).HasMaxLength(140);

          
           HasOptional(a => a.Professor).WithMany().HasForeignKey(a => a.ProfessorId);
           HasOptional(a => a.Ementa).WithMany().HasForeignKey(a => a.EmentaId);
        }
    }
}