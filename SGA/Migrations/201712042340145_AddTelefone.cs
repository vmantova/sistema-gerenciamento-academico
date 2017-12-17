namespace SGA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTelefone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "TelefoneContato", c => c.String(maxLength: 9));
            AddColumn("dbo.Professor", "TelefoneContato", c => c.String(maxLength: 9));
            AddColumn("dbo.Voluntario", "TelefoneContato", c => c.String(maxLength: 9));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Voluntario", "TelefoneContato");
            DropColumn("dbo.Professor", "TelefoneContato");
            DropColumn("dbo.Aluno", "TelefoneContato");
        }
    }
}
