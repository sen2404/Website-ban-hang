namespace Websitebanhang.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBConnect : DbContext
    {
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<VatTu> VatTus { get; set; }
        public virtual DbSet<DDH> DDHs { get; set; }
        public virtual DbSet<ChiTietDDH> ChiTietDDHs { get; set; }
        public virtual DbSet<NhapXuatTon> NhapXuatTons { get; set; }
        public virtual DbSet<NVGiaoHang> NVGiaoHangs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public DBConnect()
            : base("name=DBConnect")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
