using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Websitebanhang.Models
{
    public class DDH
    {
        [Key]
        public int id { get; set; }
        public int KhachHang_id { get; set; }
        [ForeignKey("KhachHang_id")]
        public KhachHang KhachHang { get; set; }
        public int NVGiaoHang_id { get; set; }
        [ForeignKey("NVGiaoHang_id")]
        public NVGiaoHang NVGiaoHang { get; set; }
        public DateTime NgayDH { get; set; }
        public int TongGia { get; set; }
        public string NoiNhan { get; set; }
    }
}