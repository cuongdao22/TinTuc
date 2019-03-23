using System;
using System.Collections.Generic;
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
        Boolean mod;
        PhongBan phongBan;

        public int Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string Email { get => email; set => email = value; }
        public bool Admin { get => admin; set => admin = value; }
        public bool Mod { get => mod; set => mod = value; }
        public PhongBan PhongBan { get => phongBan; set => phongBan = value; }
    }
}