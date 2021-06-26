using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGiay.Models;
using WebGiay.Controllers;
using WebGiay;

namespace WebGiay.Models
{

    public class Giohang
    {

        dbQLBanGiayDataContext data = new dbQLBanGiayDataContext();

        public int iMagiay { set; get; }
        public string sTengiay { set; get; }
        public string sAnhbia { set; get; }
        public Double dDongia { set; get; }
     
        public int iSoluong { set; get; }
        public Double dThanhtien
        {
            get { return iSoluong * dDongia; }
        }
        public Giohang (int Magiay)

        {
            iMagiay = Magiay;
            GIAY giay = data.GIAYs.Single(n => n.Magiay == iMagiay);
            sTengiay = giay.Tengiay;
            sAnhbia = giay.Anhbia;
            dDongia = double.Parse(giay.Giaban.ToString());
            iSoluong = 1;
        }
    }
}