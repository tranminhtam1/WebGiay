using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGiay
{ 
using System;
using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Product
    {
        public Product()
        {
            Anhbia = "~/images/add.png";
        }
        public int Magiay { get; set; }
        public string Tengiay { get; set; }
        public Nullable<decimal> Giaban { get; set; }
        public string Mota { get; set; }

        public string Anhbia { get; set; }
        public Nullable<System.DateTime> Ngaycapnhat { get; set; }

        public int Soluong { get; set; }

        public Nullable<decimal> MaLG { get; set; }

        public Nullable<decimal> MaCT { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }









    }
}