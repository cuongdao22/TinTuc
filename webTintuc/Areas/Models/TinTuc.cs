using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webTintuc.Areas.Models
{
    public class TinTuc
    {
        private int Id;
        private string TieuDe;
        private string Tag;
        private string NoiDung;
        private DateTime NgayDang;
        private DateTime NgayTao;
        private Boolean HienThi;
        private string TuKhoa;
        private int DanhMuc;
        private string Anh;
        private string MetaTitle;
        private string TacGia;
        private Boolean Hot;
       
        public TinTuc()
        {

        }
        public TinTuc(int id, string tieuDe, string tag, string noiDung, DateTime ngayDang, DateTime ngayTao, Boolean hienThi, string tuKhoa, int danhMuc, string anh, string metaTitle, string tacGia, Boolean hot)
        {
            Id = id;
            TieuDe = tieuDe;
            Tag = tag;
            NoiDung = noiDung;
            NgayDang = ngayDang;
            NgayTao = ngayTao;
            HienThi = hienThi;
            TuKhoa = tuKhoa;
            DanhMuc = danhMuc;
            Anh = anh;
            MetaTitle = metaTitle;
            TacGia = tacGia;
            Hot = hot;
        }

        public int Id1 { get => Id; set => Id = value; }
        public string TieuDe1 { get => TieuDe; set => TieuDe = value; }
        public string Tag1 { get => Tag; set => Tag = value; }
        public string NoiDung1 { get => NoiDung; set => NoiDung = value; }
        public DateTime NgayDang1 { get => NgayDang; set => NgayDang = value; }
        public DateTime NgayTao1 { get => NgayTao; set => NgayTao = value; }
        public Boolean HienThi1 { get => HienThi; set => HienThi = value; }
        public string TuKhoa1 { get => TuKhoa; set => TuKhoa = value; }
        public int DanhMuc1 { get => DanhMuc; set => DanhMuc = value; }
        public string Anh1 { get => Anh; set => Anh = value; }
        public string MetaTitle1 { get => MetaTitle; set => MetaTitle = value; }
        public string TacGia1 { get => TacGia; set => TacGia = value; }
        public Boolean Hot1 { get => Hot; set => Hot = value; }

    }
}