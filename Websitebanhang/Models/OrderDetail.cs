using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Websitebanhang.Models
{
    public class OrderDetail
    {
        [Key]
        public int id { get; set; }
        public int VatTu_id { get; set; }
        [ForeignKey("VatTu_id")]
        public VatTu VatTu { get; set; }
        public int Order_id { get; set; }
        [ForeignKey("Order_id")]
        public Order Order { get; set; }
         public int SoLuong { get; set; }
        public int DonGia { get; set; }

    }
}