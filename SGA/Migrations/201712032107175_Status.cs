namespace SGA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "Status", c => c.String(maxLength: 1));
            AddColumn("dbo.Aula", "Status", c => c.String(maxLength: 1));
            AddColumn("dbo.Ementa", "Status", c => c.String(maxLength: 1));
            AddColumn("dbo.Professor", "Status", c => c.String(maxLength: 1));
            AddColumn("dbo.Doacao", "Status", c => c.String(maxLength: 1));
            AddColumn("dbo.Voluntario", "Status", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Voluntario", "Status");
            DropColumn("dbo.Doacao", "Status");
            DropColumn("dbo.Professor", "Status");
            DropColumn("dbo.Ementa", "Status");
            DropColumn("dbo.Aula", "Status");
            DropColumn("dbo.Aluno", "Status");
        }
    }
}
