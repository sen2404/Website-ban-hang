namespace Websitebanhang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietDDHs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DDH_id = c.Int(nullable: false),
                        VatTu_id = c.Int(nullable: false),
                        SoLuongMua = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.DDHs", t => t.DDH_id, cascadeDelete: true)
                .ForeignKey("dbo.VatTus", t => t.VatTu_id, cascadeDelete: true)
                .Index(t => t.DDH_id)
                .Index(t => t.VatTu_id);
            
            CreateTable(
                "dbo.DDHs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        KhachHang_id = c.Int(nullable: false),
                        NVGiaoHang_id = c.Int(nullable: false),
                        NgayDH = c.DateTime(nullable: false),
                        TongGia = c.Int(nullable: false),
                        NoiNhan = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.KhachHangs", t => t.KhachHang_id, cascadeDelete: true)
                .ForeignKey("dbo.NVGiaoHangs", t => t.NVGiaoHang_id, cascadeDelete: true)
                .Index(t => t.KhachHang_id)
                .Index(t => t.NVGiaoHang_id);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TenKhachHang = c.String(nullable: false, maxLength: 30),
                        DiaChi = c.String(),
                        DienThoai = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.NVGiaoHangs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TenNVGH = c.String(),
                        SoDienThoai = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.VatTus",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TenVatTu = c.String(),
                        DonGia = c.Int(nullable: false),
                        DonViTinh = c.String(),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.NhapXuatTons",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nhap = c.Int(nullable: false),
                        Xuat = c.Int(nullable: false),
                        Ton = c.Int(nullable: false),
                        VatTu_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.VatTus", t => t.VatTu_id, cascadeDelete: true)
                .Index(t => t.VatTu_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietDDHs", "VatTu_id", "dbo.VatTus");
            DropForeignKey("dbo.NhapXuatTons", "VatTu_id", "dbo.VatTus");
            DropForeignKey("dbo.ChiTietDDHs", "DDH_id", "dbo.DDHs");
            DropForeignKey("dbo.DDHs", "NVGiaoHang_id", "dbo.NVGiaoHangs");
            DropForeignKey("dbo.DDHs", "KhachHang_id", "dbo.KhachHangs");
            DropIndex("dbo.NhapXuatTons", new[] { "VatTu_id" });
            DropIndex("dbo.DDHs", new[] { "NVGiaoHang_id" });
            DropIndex("dbo.DDHs", new[] { "KhachHang_id" });
            DropIndex("dbo.ChiTietDDHs", new[] { "VatTu_id" });
            DropIndex("dbo.ChiTietDDHs", new[] { "DDH_id" });
            DropTable("dbo.NhapXuatTons");
            DropTable("dbo.VatTus");
            DropTable("dbo.NVGiaoHangs");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.DDHs");
            DropTable("dbo.ChiTietDDHs");
        }
    }
}
