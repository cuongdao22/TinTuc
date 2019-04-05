using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webTintuc.Areas.Models
{
    public class TongBienTap
    {
        private int id; 
        private int mnv;
        private int tenNV;
        private DateTime ngayThem;

        public int Id { get => id; set => id = value; }
        public int Mnv { get => mnv; set => mnv = value; }
        public int TenNV { get => tenNV; set => tenNV = value; }
        public DateTime NgayThem { get => ngayThem; set => ngayThem = value; }
    }
}