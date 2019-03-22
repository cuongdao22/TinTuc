using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webTintuc.Areas.Front.Models
{
    public class DanhMuc
    {
        private int Id;
        private string Ten;
        private int DanhMucCha;
        private string MetaTitle;
        private Boolean HienThi;
        public DanhMuc()
        {
          
        }
        public DanhMuc(int id, string ten, int danhMucCha, string metaTitle, bool hienThi)
        {
            Id = id;
            Ten = ten;
            DanhMucCha = danhMucCha;
            MetaTitle = metaTitle;
            HienThi = hienThi;
        }

        public int Id1 { get => Id; set => Id = value; }
        public string Ten1 { get => Ten; set => Ten = value; }
        public int DanhMucCha1 { get => DanhMucCha; set => DanhMucCha = value; }
        public string MetaTitle1 { get => MetaTitle; set => MetaTitle = value; }
        public bool HienThi1 { get => HienThi; set => HienThi = value; }
    }
}