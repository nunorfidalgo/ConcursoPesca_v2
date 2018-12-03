namespace ConcursoPesca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Concursos",
                c => new
                    {
                        ConcursoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        Localizacao = c.String(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.ConcursoId);
            
            CreateTable(
                "dbo.Pescadores",
                c => new
                    {
                        PescadorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Morada = c.String(),
                        BI = c.Int(nullable: false),
                        NIF = c.Int(nullable: false),
                        DataNascimento = c.String(),
                        NLicencaPesca = c.String(),
                        Categoria = c.Int(),
                    })
                .PrimaryKey(t => t.PescadorId);
            
            CreateTable(
                "dbo.Pescarias",
                c => new
                    {
                        ConcursoId = c.Int(nullable: false),
                        PescadorId = c.Int(nullable: false),
                        PeixeId = c.Int(nullable: false),
                        Gramas = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.ConcursoId, t.PescadorId, t.PeixeId })
                .ForeignKey("dbo.Concursos", t => t.ConcursoId, cascadeDelete: true)
                .ForeignKey("dbo.Peixes", t => t.PeixeId, cascadeDelete: true)
                .ForeignKey("dbo.Pescadores", t => t.PescadorId, cascadeDelete: true)
                .Index(t => t.ConcursoId)
                .Index(t => t.PescadorId)
                .Index(t => t.PeixeId);
            
            CreateTable(
                "dbo.Peixes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PontuacoesPeixes",
                c => new
                    {
                        PeixeId = c.Int(nullable: false),
                        ConcursoId = c.Int(nullable: false),
                        Pontuacao = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.PeixeId, t.ConcursoId })
                .ForeignKey("dbo.Concursos", t => t.ConcursoId, cascadeDelete: true)
                .ForeignKey("dbo.Peixes", t => t.PeixeId, cascadeDelete: true)
                .Index(t => t.PeixeId)
                .Index(t => t.ConcursoId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PescadorConcursoes",
                c => new
                    {
                        Pescador_PescadorId = c.Int(nullable: false),
                        Concurso_ConcursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pescador_PescadorId, t.Concurso_ConcursoId })
                .ForeignKey("dbo.Pescadores", t => t.Pescador_PescadorId, cascadeDelete: true)
                .ForeignKey("dbo.Concursos", t => t.Concurso_ConcursoId, cascadeDelete: true)
                .Index(t => t.Pescador_PescadorId)
                .Index(t => t.Concurso_ConcursoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PontuacoesPeixes", "PeixeId", "dbo.Peixes");
            DropForeignKey("dbo.PontuacoesPeixes", "ConcursoId", "dbo.Concursos");
            DropForeignKey("dbo.Pescarias", "PescadorId", "dbo.Pescadores");
            DropForeignKey("dbo.Pescarias", "PeixeId", "dbo.Peixes");
            DropForeignKey("dbo.Pescarias", "ConcursoId", "dbo.Concursos");
            DropForeignKey("dbo.PescadorConcursoes", "Concurso_ConcursoId", "dbo.Concursos");
            DropForeignKey("dbo.PescadorConcursoes", "Pescador_PescadorId", "dbo.Pescadores");
            DropIndex("dbo.PescadorConcursoes", new[] { "Concurso_ConcursoId" });
            DropIndex("dbo.PescadorConcursoes", new[] { "Pescador_PescadorId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PontuacoesPeixes", new[] { "ConcursoId" });
            DropIndex("dbo.PontuacoesPeixes", new[] { "PeixeId" });
            DropIndex("dbo.Pescarias", new[] { "PeixeId" });
            DropIndex("dbo.Pescarias", new[] { "PescadorId" });
            DropIndex("dbo.Pescarias", new[] { "ConcursoId" });
            DropTable("dbo.PescadorConcursoes");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PontuacoesPeixes");
            DropTable("dbo.Peixes");
            DropTable("dbo.Pescarias");
            DropTable("dbo.Pescadores");
            DropTable("dbo.Concursos");
        }
    }
}
