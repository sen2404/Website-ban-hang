using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Websitebanhang.Models
{
    public class ChiTietDDH
    {
        [Key]
        public int id { get; set; }
        public int DDH_id { get; set; }
        [ForeignKey("DDH_id")]
        public DDH DDH { get; set; }
        public int VatTu_id { get; set; }
        [ForeignKey("VatTu_id")]
        public VatTu VatTu { get; set; }
       
        public int SoLuongMua { get; set; }
        public int DonGia { get; set; }
    }
}