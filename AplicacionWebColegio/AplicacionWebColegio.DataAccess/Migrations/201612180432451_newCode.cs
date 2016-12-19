namespace AplicacionWebColegio.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newCode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matricula = c.String(nullable: false, maxLength: 10),
                        Observaciones = c.String(maxLength: 800),
                        FechaMatriculacion = c.DateTime(nullable: false),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        Apellidos = c.String(nullable: false, maxLength: 50),
                        FechaNacimiento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 80),
                        Area = c.String(maxLength: 80),
                        Horas = c.Int(nullable: false),
                        Activa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profesores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Observaciones = c.String(maxLength: 800),
                        Activo = c.Boolean(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Secciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfesorId = c.Int(nullable: false),
                        MateriaId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 80),
                        Ubicacion = c.String(nullable: false, maxLength: 120),
                        MaximoEstudiantes = c.Int(),
                        Activa = c.Boolean(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        Observaciones = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materias", t => t.MateriaId, cascadeDelete: true)
                .ForeignKey("dbo.Profesores", t => t.ProfesorId, cascadeDelete: true)
                .Index(t => t.ProfesorId)
                .Index(t => t.MateriaId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(nullable: false, maxLength: 50),
                        Nivel = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Secciones", "ProfesorId", "dbo.Profesores");
            DropForeignKey("dbo.Secciones", "MateriaId", "dbo.Materias");
            DropIndex("dbo.Secciones", new[] { "MateriaId" });
            DropIndex("dbo.Secciones", new[] { "ProfesorId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Secciones");
            DropTable("dbo.Profesores");
            DropTable("dbo.Materias");
            DropTable("dbo.Estudiantes");
        }
    }
}
