namespace AplicacionWebColegio.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HerenciaPersona : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profesores", "Nombres", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Profesores", "Apellidos", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Profesores", "FechaNacimiento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profesores", "FechaNacimiento");
            DropColumn("dbo.Profesores", "Apellidos");
            DropColumn("dbo.Profesores", "Nombres");
        }
    }
}
