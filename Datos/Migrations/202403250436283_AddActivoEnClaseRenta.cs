namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActivoEnClaseRenta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Renta", "Activo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Renta", "Activo");
        }
    }
}
