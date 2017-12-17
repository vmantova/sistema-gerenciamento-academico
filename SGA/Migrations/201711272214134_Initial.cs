namespace SGA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        AlunoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 30),
                        Sobrenome = c.String(maxLength: 100),
                        Idade = c.Int(),
                        Cpf = c.String(maxLength: 11),
                        DtNascimento = c.DateTime(nullable: false),
                        DtCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AlunoId);
            
            CreateTable(
                "dbo.Aula",
                c => new
                    {
                        AulaId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(maxLength: 30),
                        Descricao = c.String(maxLength: 140),
                        Horario = c.DateTime(nullable: false),
                        ProfessorId = c.Int(),
                    })
                .PrimaryKey(t => t.AulaId)
                .ForeignKey("dbo.Professor", t => t.ProfessorId)
                .Index(t => t.ProfessorId);
            
            CreateTable(
                "dbo.Ementa",
                c => new
                    {
                        EmentaId = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 800),
                        Bibliografia = c.String(),
                        AulaId = c.Int(),
                    })
                .PrimaryKey(t => t.EmentaId)
                .ForeignKey("dbo.Aula", t => t.EmentaId)
                .Index(t => t.EmentaId);
            
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        ProfessorId = c.Int(nullable: false, identity: true),
                        Grau = c.String(maxLength: 30),
                        AulaId = c.Int(),
                        Nome = c.String(maxLength: 30),
                        Sobrenome = c.String(maxLength: 100),
                        Idade = c.Int(),
                        Cpf = c.String(maxLength: 11),
                        DtNascimento = c.DateTime(nullable: false),
                        DtCadastro = c.DateTime(nullable: false),
                        Aula_AulaId = c.Int(),
                    })
                .PrimaryKey(t => t.ProfessorId)
                .ForeignKey("dbo.Aula", t => t.Aula_AulaId)
                .Index(t => t.Aula_AulaId);
            
            CreateTable(
                "dbo.Doacao",
                c => new
                    {
                        DoacaoId = c.Int(nullable: false, identity: true),
                        Item = c.String(maxLength: 50),
                        Quantidade = c.Int(),
                        Preco = c.Decimal(precision: 11, scale: 2),
                        Professor_ProfessorId = c.Int(),
                        Aluno_AlunoId = c.Int(),
                        Voluntario_VoluntarioId = c.Int(),
                    })
                .PrimaryKey(t => t.DoacaoId)
                .ForeignKey("dbo.Professor", t => t.Professor_ProfessorId)
                .ForeignKey("dbo.Aluno", t => t.Aluno_AlunoId)
                .ForeignKey("dbo.Voluntario", t => t.Voluntario_VoluntarioId)
                .Index(t => t.Professor_ProfessorId)
                .Index(t => t.Aluno_AlunoId)
                .Index(t => t.Voluntario_VoluntarioId);
            
            CreateTable(
                "dbo.Voluntario",
                c => new
                    {
                        VoluntarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 30),
                        Sobrenome = c.String(maxLength: 100),
                        Idade = c.Int(),
                        Cpf = c.String(maxLength: 11),
                        DtNascimento = c.DateTime(nullable: false),
                        DtCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VoluntarioId);
            
            CreateTable(
                "dbo.AulaAluno",
                c => new
                    {
                        Aula_AulaId = c.Int(nullable: false),
                        Aluno_AlunoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Aula_AulaId, t.Aluno_AlunoId })
                .ForeignKey("dbo.Aula", t => t.Aula_AulaId, cascadeDelete: true)
                .ForeignKey("dbo.Aluno", t => t.Aluno_AlunoId, cascadeDelete: true)
                .Index(t => t.Aula_AulaId)
                .Index(t => t.Aluno_AlunoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doacao", "Voluntario_VoluntarioId", "dbo.Voluntario");
            DropForeignKey("dbo.Doacao", "Aluno_AlunoId", "dbo.Aluno");
            DropForeignKey("dbo.Aula", "ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.Doacao", "Professor_ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.Professor", "Aula_AulaId", "dbo.Aula");
            DropForeignKey("dbo.Ementa", "EmentaId", "dbo.Aula");
            DropForeignKey("dbo.AulaAluno", "Aluno_AlunoId", "dbo.Aluno");
            DropForeignKey("dbo.AulaAluno", "Aula_AulaId", "dbo.Aula");
            DropIndex("dbo.AulaAluno", new[] { "Aluno_AlunoId" });
            DropIndex("dbo.AulaAluno", new[] { "Aula_AulaId" });
            DropIndex("dbo.Doacao", new[] { "Voluntario_VoluntarioId" });
            DropIndex("dbo.Doacao", new[] { "Aluno_AlunoId" });
            DropIndex("dbo.Doacao", new[] { "Professor_ProfessorId" });
            DropIndex("dbo.Professor", new[] { "Aula_AulaId" });
            DropIndex("dbo.Ementa", new[] { "EmentaId" });
            DropIndex("dbo.Aula", new[] { "ProfessorId" });
            DropTable("dbo.AulaAluno");
            DropTable("dbo.Voluntario");
            DropTable("dbo.Doacao");
            DropTable("dbo.Professor");
            DropTable("dbo.Ementa");
            DropTable("dbo.Aula");
            DropTable("dbo.Aluno");
        }
    }
}
