using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webTintuc.Areas.Models
{
    public class PhongBan
    {
        private int id;
        private int idDM;
        private string tenDM;
        private int idQL;
        private string tenQL;
        private string email;

        public int Id { get => id; set => id = value; }
        public int IdDM { get => idDM; set => idDM = value; }
        public string TenDM { get => tenDM; set => tenDM = value; }
        public int IdQL { get => idQL; set => idQL = value; }
        public string TenQL { get => tenQL; set => tenQL = value; }
        public string Email { get => email; set => email = value; }
    }
}