using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Websitebanhang.Models
{
    public class VatTu
    {
        [Key]
        public int id { get; set; }
        public string TenVatTu { get; set; }
        public int DonGia { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public virtual ICollection<NhapXuatTon> NhapXuatTons { get; set; }

   
    }
}