namespace SGA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataCadastro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aula", "DtCadastro", c => c.DateTime());
            AddColumn("dbo.Ementa", "DtCadastro", c => c.DateTime(nullable: false));
            AddColumn("dbo.Doacao", "DtCadastro", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doacao", "DtCadastro");
            DropColumn("dbo.Ementa", "DtCadastro");
            DropColumn("dbo.Aula", "DtCadastro");
        }
    }
}
