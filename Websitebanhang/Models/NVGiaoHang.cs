using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Websitebanhang.Models
{
    public class NVGiaoHang
    {
        [Key]
        public int id { get; set; }
        public string TenNVGH { get; set; }
        public string SoDienThoai { get; set; }
    }
}