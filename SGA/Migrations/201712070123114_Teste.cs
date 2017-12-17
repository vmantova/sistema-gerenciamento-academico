namespace SGA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ementa", "EmentaId", "dbo.Aula");
            DropIndex("dbo.Ementa", new[] { "EmentaId" });
            DropPrimaryKey("dbo.Ementa");
            AddColumn("dbo.Aula", "EmentaId", c => c.Int());
            AddColumn("dbo.Ementa", "Aula_AulaId", c => c.Int());
            AlterColumn("dbo.Ementa", "EmentaId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Ementa", "EmentaId");
            CreateIndex("dbo.Aula", "EmentaId");
            CreateIndex("dbo.Ementa", "Aula_AulaId");
            AddForeignKey("dbo.Ementa", "Aula_AulaId", "dbo.Aula", "AulaId");
            AddForeignKey("dbo.Aula", "EmentaId", "dbo.Ementa", "EmentaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aula", "EmentaId", "dbo.Ementa");
            DropForeignKey("dbo.Ementa", "Aula_AulaId", "dbo.Aula");
            DropIndex("dbo.Ementa", new[] { "Aula_AulaId" });
            DropIndex("dbo.Aula", new[] { "EmentaId" });
            DropPrimaryKey("dbo.Ementa");
            AlterColumn("dbo.Ementa", "EmentaId", c => c.Int(nullable: false));
            DropColumn("dbo.Ementa", "Aula_AulaId");
            DropColumn("dbo.Aula", "EmentaId");
            AddPrimaryKey("dbo.Ementa", "EmentaId");
            CreateIndex("dbo.Ementa", "EmentaId");
            AddForeignKey("dbo.Ementa", "EmentaId", "dbo.Aula", "AulaId");
        }
    }
}
