using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGiay.Models;

using PagedList;
using PagedList.Mvc;
namespace WebGiay.Controllers
{
    public class ShopGiayController : Controller
    {
        dbQLBanGiayDataContext data = new dbQLBanGiayDataContext();
        // GET: ShopGiay
        private List<GIAY> Laygiaymoi(int count)
        {
            return data.GIAYs.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();

        }
        public ActionResult Index(int ? page)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);

            var giaymoi = Laygiaymoi(15);
            return View(giaymoi.ToPagedList(pageNum,pageSize));
        }
        public ActionResult Loaigiay()
        {
            var loaigiay = from lg in data.LOAIGIAYs select lg;
            return PartialView(loaigiay);
        }
        public ActionResult Congty()
        {
            var congty = from ct in data.CONGTies select ct;
            return PartialView(congty);
        }
        public ActionResult SPTheoloaigiay(int id)
        {
            var giay = from g in data.GIAYs where g.MaLG == id select g;
            return View(giay);
        }
        public ActionResult SPTheoCT(int id)
        {
            var giay = from g in data.GIAYs where g.MaCT == id select g;
            return View(giay);
        }
        //public ActionResult SPTheoCT(int? page)
        //{
        //    int pageSize = 5;
        //    int pageNum = (page ?? 1);

        //    var giaymoi = Laygiaymoi(15);
        //    return View(giaymoi.ToPagedList(pageNum, pageSize));
        //}
        public ActionResult Details(int id)
        {
            var giay = from g in data.GIAYs where g.Magiay == id select g;
            return View(giay.Single());
            
        }

    }
}