namespace SGA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredTest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Voluntario", "Nome", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voluntario", "Nome", c => c.String(maxLength: 30));
        }
    }
}
