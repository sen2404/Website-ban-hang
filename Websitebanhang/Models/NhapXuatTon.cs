using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Websitebanhang.Models
{
    public class NhapXuatTon
    {
        [Key]
        public int id { get; set; }
        public int Nhap { get; set; }
        public int Xuat { get; set; }
        public int Ton { get; set; }
        public int VatTu_id { get; set; }
        [ForeignKey("VatTu_id")]
        public VatTu VatTu { get; set; }

    }
}