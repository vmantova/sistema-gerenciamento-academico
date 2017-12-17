namespace SGA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExcludeEmenta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ementa", "Aula_AulaId", "dbo.Aula");
            DropForeignKey("dbo.Aula", "EmentaId", "dbo.Ementa");
            DropIndex("dbo.Aula", new[] { "EmentaId" });
            DropIndex("dbo.Ementa", new[] { "Aula_AulaId" });
            DropTable("dbo.Ementa");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ementa",
                c => new
                    {
                        EmentaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 800),
                        Bibliografia = c.String(),
                        Status = c.String(maxLength: 1),
                        DtCadastro = c.DateTime(nullable: false),
                        AulaId = c.Int(),
                        Aula_AulaId = c.Int(),
                    })
                .PrimaryKey(t => t.EmentaId);
            
            CreateIndex("dbo.Ementa", "Aula_AulaId");
            CreateIndex("dbo.Aula", "EmentaId");
            AddForeignKey("dbo.Aula", "EmentaId", "dbo.Ementa", "EmentaId");
            AddForeignKey("dbo.Ementa", "Aula_AulaId", "dbo.Aula", "AulaId");
        }
    }
}
