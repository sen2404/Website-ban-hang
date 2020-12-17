namespace Websitebanhang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table_gh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NgayDH = c.DateTime(nullable: false),
                        KhachHang_id = c.Int(nullable: false),
                        ThongTinGH = c.String(),
                        DienThoai = c.String(nullable: false, maxLength: 15),
                        DiaChiNH = c.String(),
                        EmailNH = c.String(),
                        TrangThai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.KhachHangs", t => t.KhachHang_id, cascadeDelete: true)
                .Index(t => t.KhachHang_id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        VatTu_id = c.Int(nullable: false),
                        Order_id = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Orders", t => t.Order_id, cascadeDelete: true)
                .ForeignKey("dbo.VatTus", t => t.VatTu_id, cascadeDelete: true)
                .Index(t => t.VatTu_id)
                .Index(t => t.Order_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "VatTu_id", "dbo.VatTus");
            DropForeignKey("dbo.OrderDetails", "Order_id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "KhachHang_id", "dbo.KhachHangs");
            DropIndex("dbo.OrderDetails", new[] { "Order_id" });
            DropIndex("dbo.OrderDetails", new[] { "VatTu_id" });
            DropIndex("dbo.Orders", new[] { "KhachHang_id" });
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
        }
    }
}
