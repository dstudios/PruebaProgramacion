namespace TestCoppel.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentario",
                c => new
                    {
                        ComentarioID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 50),
                        UsuarioId = c.Int(nullable: false),
                        Estatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ComentarioID)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Clave = c.String(maxLength: 3),
                        Nombre = c.String(maxLength: 20),
                        Apellido = c.String(maxLength: 20),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Estatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        ProductoID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 20),
                        Estatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoID);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        ProveedorID = c.Int(nullable: false, identity: true),
                        RFC = c.String(maxLength: 13),
                        Nombre = c.String(maxLength: 20),
                        Estatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProveedorID);
            
            CreateTable(
                "dbo.ProveedorProducto",
                c => new
                    {
                        ProductoID = c.Int(nullable: false),
                        ProveedorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductoID, t.ProveedorID })
                .ForeignKey("dbo.Proveedor", t => t.ProductoID, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.ProveedorID, cascadeDelete: true)
                .Index(t => t.ProductoID)
                .Index(t => t.ProveedorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProveedorProducto", "ProveedorID", "dbo.Producto");
            DropForeignKey("dbo.ProveedorProducto", "ProductoID", "dbo.Proveedor");
            DropForeignKey("dbo.Comentario", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.ProveedorProducto", new[] { "ProveedorID" });
            DropIndex("dbo.ProveedorProducto", new[] { "ProductoID" });
            DropIndex("dbo.Comentario", new[] { "UsuarioId" });
            DropTable("dbo.ProveedorProducto");
            DropTable("dbo.Proveedor");
            DropTable("dbo.Producto");
            DropTable("dbo.Usuario");
            DropTable("dbo.Comentario");
        }
    }
}
