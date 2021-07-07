﻿using System;
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

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(GIAY pro, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add update logic here
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
                data.Entry(pro).State =EntityState.Modified;
                data.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
           return View(data.GIAYs.Where(s => s.Magiay == id).FirstOrDefault());

        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, GIAY pro)
        {
            try
            {
                // TODO: Add delete logic here
            pro= data.GIAYs.Where(s => s.Magiay == id).FirstOrDefault();
                data.GIAYs.Remove(pro);
                data.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}