using SGA.EntitiesConfig;
using SGA.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SGA.Context
{
    public class AppContext : DbContext
    {
        public AppContext() : base ("AppContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new AlunoConfig());
            modelBuilder.Configurations.Add(new AulaConfig());
            modelBuilder.Configurations.Add(new DoacaoConfig());
            modelBuilder.Configurations.Add(new EmentaConfig());
            modelBuilder.Configurations.Add(new ProfessorConfig());
           // modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new VoluntarioConfig());
        }

       // public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Voluntario> Voluntarios { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Ementa> Ementas { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }
    }
}