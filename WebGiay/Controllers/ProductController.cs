using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using WebGiay.Models;
using System.Data.Entity.Migrations;
using System.Data.Entity;

namespace WebGiay.Controllers
{
    public class ProductController : Controller
    {
        dbQLBanGiayDataContext data = new dbQLBanGiayDataContext();
        // GET: Product
        public ActionResult Index()
        {
            return View(data.GIAYs.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(data.GIAYs.Where(s=>s.Magiay==id).FirstOrDefault());
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
          
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(GIAY pro, HttpPostedFileBase file)

        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("/images/"), _FileName);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                        file.SaveAs(path);
                    }
                    else
                    {
                        file.SaveAs(path);
                    }
                    pro.Anhbia = _FileName;
                }

                data.GIAYs.AddOrUpdate(pro);
               // data.GIAYs.Add(pro);
               //chon 1 trong 2 kieu Add, cai nao cung duoc
                data.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            //edit có laasys data đâu???????????
            GIAY gIAY = data.GIAYs.SingleOrDefault(p => p.Magiay == id);
            return View(gIAY);
        }

        //POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(GIAY giay,HttpPostedFileBase file)
        {
            GIAY giayUpdate = data.GIAYs.SingleOrDefault(p => p.Magiay == giay.Magiay);
            if(giayUpdate != null)
            {
                if (file != null || file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("/images/"), _FileName);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                        file.SaveAs(path);
                    }
                    else
                    {
                        file.SaveAs(path);
                    }

                    giayUpdate.Anhbia = _FileName;
                }

                giayUpdate.Tengiay = giay.Tengiay;
                //may cot con lai tu viet o day

                data.GIAYs.AddOrUpdate(giayUpdate);
                data.SaveChanges();
            }
           
            
            return RedirectToAction("Index");
        }

        //[HttpPost]
        ////public ActionResult UploadMultipleImage(HttpPostedFileBase[] files)
        ////{
        ////    foreach (HttpPostedFileBase file in files)
        ////    {
        ////        if(file != null || file.ContentLength > 0 )
        ////        {
        ////            string _FileName = Path.GetFileName(file.FileName);
        ////            string path = Path.Combine(Server.MapPath("/images/"), _FileName);
        ////            if (System.IO.File.Exists(path))
        ////            {
        ////                System.IO.File.Delete(path);
        ////                file.SaveAs(path);
        ////            }
        ////            else
        ////            {
        ////                file.SaveAs(path);
        ////            }

        ////        }
        ////    }
        ////    return RedirectToAction("Index");
        ////}
        //// GET: Product/Delete/5
        //public ActionResult Delete(int id)
        //{
        //   return View(data.GIAYs.Where(s => s.Magiay == id).FirstOrDefault());

        //}

        //// POST: Product/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, GIAY pro)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //    pro= data.GIAYs.Where(s => s.Magiay == id).FirstOrDefault();
        //        data.GIAYs.Remove(pro);
        //        data.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Delete(int id)

        {
            dbQLBanGiayDataContext data = new dbQLBanGiayDataContext();

            //{   if (Session["Taikhoanadmin"] == null)
            //        return RedirectToAction("Login", "Admin");
            // else
            {
                var giay = from l in data.GIAYs where l.Magiay == id select l;
                return View(giay.SingleOrDefault());
            }
        }
        [HttpPost, ActionName("Delete")]

        public ActionResult Xacnhanxoa(int id)
        {

            //{   if (Session["Taikhoanadmin"] == null)
            //        return RedirectToAction("Login", "Admin");
            // else
            {
                GIAY giay = data.GIAYs.SingleOrDefault(n => n.Magiay == id);
                data.GIAYs.Remove(giay);
                data.SaveChanges();
                //rồi đó thay con nua thay oi cho nay ne
                return RedirectToAction("Index", "Hang");
            }
        }
    }
}
