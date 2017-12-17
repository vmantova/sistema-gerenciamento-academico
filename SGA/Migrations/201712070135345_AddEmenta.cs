namespace SGA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmenta : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.EmentaId)
                .ForeignKey("dbo.Aula", t => t.Aula_AulaId)
                .Index(t => t.Aula_AulaId);
            
            CreateIndex("dbo.Aula", "EmentaId");
            AddForeignKey("dbo.Aula", "EmentaId", "dbo.Ementa", "EmentaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aula", "EmentaId", "dbo.Ementa");
            DropForeignKey("dbo.Ementa", "Aula_AulaId", "dbo.Aula");
            DropIndex("dbo.Ementa", new[] { "Aula_AulaId" });
            DropIndex("dbo.Aula", new[] { "EmentaId" });
            DropTable("dbo.Ementa");
        }
    }
}
