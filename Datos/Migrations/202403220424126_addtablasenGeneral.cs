namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtablasenGeneral : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        clienteId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 75),
                        Apellidos = c.String(nullable: false, maxLength: 75),
                        FechaIngreso = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.clienteId);
            
            CreateTable(
                "dbo.Peliculas",
                c => new
                    {
                        PeliculasId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 75),
                        Genero = c.String(nullable: false, maxLength: 30),
                        Autores = c.String(nullable: false, maxLength: 75),
                        Existencia = c.Int(nullable: false),
                        PrecioRenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PeliculasId);
            
            CreateTable(
                "dbo.Renta",
                c => new
                    {
                        RentaId = c.Int(nullable: false, identity: true),
                        clienteId = c.Int(nullable: false),
                        PeliculasId = c.Int(nullable: false),
                        FechaRenta = c.DateTime(nullable: false),
                        FechaRetorno = c.DateTime(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioRenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RentaId)
                .ForeignKey("dbo.Clientes", t => t.clienteId)
                .ForeignKey("dbo.Peliculas", t => t.PeliculasId)
                .Index(t => t.clienteId)
                .Index(t => t.PeliculasId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Renta", "PeliculasId", "dbo.Peliculas");
            DropForeignKey("dbo.Renta", "clienteId", "dbo.Clientes");
            DropIndex("dbo.Renta", new[] { "PeliculasId" });
            DropIndex("dbo.Renta", new[] { "clienteId" });
            DropTable("dbo.Renta");
            DropTable("dbo.Peliculas");
            DropTable("dbo.Clientes");
        }
    }
}
