using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Websitebanhang.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }

        public DateTime NgayDH { get; set; }
        public int KhachHang_id { get; set; }
        [ForeignKey("KhachHang_id")]
        public KhachHang KhachHang { get; set; }
        public string ThongTinGH { get; set; }
        [Required, MinLength(8), MaxLength(15)]
        public string DienThoai { get; set; }
        public string DiaChiNH { get; set; }
        public string EmailNH { get; set; }
        public int TrangThai { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}