namespace SGA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Endereco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "Endereco", c => c.String(maxLength: 100));
            AddColumn("dbo.Aluno", "Numero", c => c.String(maxLength: 8));
            AddColumn("dbo.Aluno", "Cidade", c => c.String(maxLength: 100));
            AddColumn("dbo.Aluno", "Estado", c => c.String(maxLength: 2));
            AddColumn("dbo.Aluno", "Cep", c => c.String(maxLength: 8));
            AddColumn("dbo.Professor", "Endereco", c => c.String(maxLength: 100));
            AddColumn("dbo.Professor", "Numero", c => c.String(maxLength: 8));
            AddColumn("dbo.Professor", "Cidade", c => c.String(maxLength: 100));
            AddColumn("dbo.Professor", "Estado", c => c.String(maxLength: 2));
            AddColumn("dbo.Professor", "Cep", c => c.String(maxLength: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Professor", "Cep");
            DropColumn("dbo.Professor", "Estado");
            DropColumn("dbo.Professor", "Cidade");
            DropColumn("dbo.Professor", "Numero");
            DropColumn("dbo.Professor", "Endereco");
            DropColumn("dbo.Aluno", "Cep");
            DropColumn("dbo.Aluno", "Estado");
            DropColumn("dbo.Aluno", "Cidade");
            DropColumn("dbo.Aluno", "Numero");
            DropColumn("dbo.Aluno", "Endereco");
        }
    }
}
