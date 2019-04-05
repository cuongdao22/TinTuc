using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webTintuc.Areas.Models
{
    public class Duyet
    {
        int id;
        int tintuc;
        string tieuDe;
        int trangthai;
        string phanHoi;
        DateTime ngayCapNhat;

        public int Id { get => id; set => id = value; }
        public int Tintuc { get => tintuc; set => tintuc = value; }
        public int Trangthai { get => trangthai; set => trangthai = value; }
        public string PhanHoi { get => phanHoi; set => phanHoi = value; }
        public DateTime NgayCapNhat { get => ngayCapNhat; set => ngayCapNhat = value; }
        public string TieuDe { get => tieuDe; set => tieuDe = value; }
    }
}