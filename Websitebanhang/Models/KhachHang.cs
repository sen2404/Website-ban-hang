using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Websitebanhang.Models
{
    public class KhachHang
    {
        [Key]
        public int id { get; set; }
        [Required,MaxLength(30)]
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string Role { get; set; }
        [Required,MinLength(8),MaxLength(15)]
        public string DienThoai { get; set; }
        [Required,EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("password")]

        public string confirm_password { get; set; }
    }
}