using SGA.Models;
using System.Data.Entity.ModelConfiguration;

namespace SGA.EntitiesConfig
{
    public class EmentaConfig : EntityTypeConfiguration<Ementa>
    {
        public EmentaConfig()
        {
            HasKey(t => t.EmentaId);
            Property(t => t.Descricao).HasMaxLength(500);
            Property(t => t.Descricao).HasMaxLength(800);
        }
    }
}