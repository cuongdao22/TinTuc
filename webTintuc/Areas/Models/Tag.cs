using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webTintuc.Areas.Models
{
    public class Tag
    {
        private string tag;
        private string url;

        public string TenTag { get => tag; set => tag = value; }
        public string Url { get => url; set => url = value; }
    }
}