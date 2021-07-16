using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebGiay.Models;


namespace WebGiay.Controllers
{

    public class HangController : Controller
    {

        dbQLBanGiayDataContext data = new dbQLBanGiayDataContext();

        public ActionResult Index()
        {
            //{   if (Session["Taikhoanadmin"] == null)
            //        return RedirectToAction("Login", "Admin");
            //    else
            return View(data.LOAIGIAYs.ToList());
        }
        public ActionResult Detail(int id)
        {
            //viet cai nao 1 cai thoi sao lon xon vay
           // var loai = from l in data.LOAIGIAYs where l.MaLG == id select l;

            LOAIGIAY lOAIGIAY = data.LOAIGIAYs.SingleOrDefault(p => p.MaLG == id);
            return View(lOAIGIAY);
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
        public ActionResult Create(LOAIGIAY loaigiay)
        {

            //{   if (Session["Taikhoanadmin"] == null)
            //        return RedirectToAction("Login", "Admin");
            //    else
            {
                data.LOAIGIAYs.Add(loaigiay);
                data.SaveChanges();
                return RedirectToAction("Index", "Hang");

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
                var loai = from l in data.LOAIGIAYs where l.MaLG == id select l;
                return View(loai.SingleOrDefault());
            }
        }
        [HttpPost, ActionName("Delete")]

        public ActionResult Xacnhanxoa(int id)
        {

            //{   if (Session["Taikhoanadmin"] == null)
            //        return RedirectToAction("Login", "Admin");
            // else
            {
                LOAIGIAY loaigiay = data.LOAIGIAYs.SingleOrDefault(n => n.MaLG == id);
                data.LOAIGIAYs.Remove(loaigiay);
                data.SaveChanges();
                //rồi đó thay con nua thay oi cho nay ne
                return RedirectToAction("Index", "Hang");
            }
        }

        public ActionResult Edit(int id)
        {
            //{   if (Session["Taikhoanadmin"] == null)
            //        return RedirectToAction("Login", "Admin");
            // else
            {
                var loai = from l in data.LOAIGIAYs where l.MaLG == id select l;
                return View(loai.SingleOrDefault());
            }
        }
        [HttpPost,ActionName("Edit")]
        public ActionResult Capnhat(int id)
        {
            LOAIGIAY loaigiay = data.LOAIGIAYs.Where(n => n.MaLG == id).SingleOrDefault();
            UpdateModel(loaigiay);
            data.SaveChanges();
            return RedirectToAction("Index", "Hang");
        }
        //public ActionResult Delete(int id)
        //{
        //    return View(data.GIAYs.Where(s => s.MaLG == id).FirstOrDefault());

        //}

        //// POST: Product/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, LOAIGIAY pro)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        pro = data.LOAIGIAYs.Where(s => s.MaLG == id).FirstOrDefault();
        //        data.GIAYs.Remove(pro);
        //        data.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
    }
}






