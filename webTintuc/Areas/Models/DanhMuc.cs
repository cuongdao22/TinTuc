using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webTintuc.Areas.Models
{
    public class DanhMuc
    {
        private int id;
        private string ten;
        private int danhMucCha;
        private string tenDanhMucCha;
        private string metaTitle;
        private Boolean hienThi;
        public DanhMuc()
        {
          
        }

        public DanhMuc(int id, string ten, int danhMucCha, string tenDanhMucCha, string metaTitle, bool hienThi)
        {
            this.id = id;
            this.ten = ten;
            this.danhMucCha = danhMucCha;
            this.tenDanhMucCha = tenDanhMucCha;
            this.metaTitle = metaTitle;
            this.hienThi = hienThi;
        }

        public int Id { get => id; set => id = value; }
        public string Ten { get => ten; set => ten = value; }
        public int DanhMucCha { get => danhMucCha; set => danhMucCha = value; }
        public string TenDanhMucCha { get => tenDanhMucCha; set => tenDanhMucCha = value; }
        public string MetaTitle { get => metaTitle; set => metaTitle = value; }
        public bool HienThi { get => hienThi; set => hienThi = value; }
    }
}