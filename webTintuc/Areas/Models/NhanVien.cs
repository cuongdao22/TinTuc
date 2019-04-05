using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webTintuc.Areas.Models
{
    public class NhanVien
    {
        int id;
        string ten;
        DateTime ngaySinh;
        string email;
        Boolean admin;
        DateTime ngayThem;
        int idDM;
        string tenDM;
        string matKhau;
        public int Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string Email { get => email; set => email = value; }
        public bool Admin { get => admin; set => admin = value; }
        [NotMapped]
        public DateTime NgayThem { get => ngayThem; set => ngayThem = value; }
        [NotMapped]
        public string TenDM { get => tenDM; set => tenDM = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int IdDM { get => idDM; set => idDM = value; }
    }
}