using SGA.Models;
using System.Data.Entity.ModelConfiguration;
using System.Web;

namespace SGA.EntitiesConfig
{
    public class VoluntarioConfig : EntityTypeConfiguration<Voluntario>
    {
        public VoluntarioConfig()
        {
            HasKey(v => v.VoluntarioId);
           // Map(t => t.MapInheritedProperties().ToTable("Voluntario"));
            Property(t => t.Cpf).HasMaxLength(11);
            Property(t => t.Nome).HasMaxLength(30);
            Property(t => t.Sobrenome).HasMaxLength(100);
        }
    }
}