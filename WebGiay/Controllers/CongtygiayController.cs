using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGiay.Models;


namespace WebGiay.Controllers
{
    public class CongtygiayController : Controller
    {
        // GET: Congtygiay
        dbQLBanGiayDataContext data = new dbQLBanGiayDataContext();

        public ActionResult Index()
        {
            return View(data.CONGTies.ToList());
        }
        public ActionResult Detail(int id)
        {

            CONGTY CONGTY = data.CONGTies.SingleOrDefault(p => p.MaCT == id);
            return View(CONGTY);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //{   if (Session["Taikhoanadmin"] == null)
            //        return RedirectToAction("Login", "Admin");
            //    else
            return View();
        }
        [HttpPost]
        public ActionResult Create(CONGTY congty)
        {

            //{   if (Session["Taikhoanadmin"] == null)
            //        return RedirectToAction("Login", "Admin");
            //    else
            {
                data.CONGTies.Add(congty);
                data.SaveChanges();
                return RedirectToAction("Index", "Congtygiay");

            }
        }
        [HttpGet]
        public ActionResult Delete(int id)

        {
            dbQLBanGiayDataContext data = new dbQLBanGiayDataContext();

            //{   if (Session["Taikhoanadmin"] == null)
            //        return RedirectToAction("Login", "Admin");
            // else
            {
                var congty = from c in data.CONGTies where c.MaCT == id select c;
                return View(congty.SingleOrDefault());
            }
        }
        [HttpPost, ActionName("Delete")]

        public ActionResult Xacnhanxoa(int id)
        {

            //{   if (Session["Taikhoanadmin"] == null)
            //        return RedirectToAction("Login", "Admin");
            // else
            {
                CONGTY congty = data.CONGTies.SingleOrDefault(n => n.MaCT == id);
                data.CONGTies.Remove(congty);
                data.SaveChanges();
                //rồi đó thay con nua thay oi cho nay ne
                return RedirectToAction("Index", "Congtygiay");
            }
        }
        public ActionResult Edit(int id)
        {
            //{   if (Session["Taikhoanadmin"] == null)
            //        return RedirectToAction("Login", "Admin");
            // else
            {
                var loai = from l in data.CONGTies where l.MaCT == id select l;
                return View(loai.SingleOrDefault());
            }
        }
        [HttpPost, ActionName("Edit")]
        public ActionResult Capnhat(int id)
        {
            CONGTY congty = data.CONGTies.Where(n => n.MaCT == id).SingleOrDefault();
            UpdateModel(congty);
            data.SaveChanges();
            return RedirectToAction("Index", "Congtygiay");
        }
    }
}