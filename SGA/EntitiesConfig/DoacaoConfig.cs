using SGA.Models;
using System.Data.Entity.ModelConfiguration;

namespace SGA.EntitiesConfig
{
    public class DoacaoConfig : EntityTypeConfiguration<Doacao>
    {
        public DoacaoConfig()
        {
            Property(t => t.Item).HasMaxLength(50);
            Property(t => t.Preco).HasPrecision(11, 2);
        }
    }
}