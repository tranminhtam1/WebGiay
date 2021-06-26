using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGiay.Models;

namespace WebGiay.Controllers
{
    public class NguoidungController : Controller
    {
        dbQLBanGiayDataContext data = new dbQLBanGiayDataContext();



        // GET: Nguoidung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collection, KHACHHANG kh)
        {
            var hoten = collection["HotenKH"];
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            var nhaplaimatkhau = collection["Nhaplaimatkhau"];
            var diachi = collection["Diachi"];
            var email = collection["Email"];
            var dienthoai = collection["Dienthoai"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên khách hàng không được để trống";

            }
            else if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Phải nhập tên đăng nhập ";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Phải nhập mật khẩu ";
            }
            else if (String.IsNullOrEmpty(nhaplaimatkhau))
            {
                ViewData["Loi4"] = "Phải nhập lại mật khẩu  ";
            }
            if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = " Email không được bỏ trống ";
            }
            if (String.IsNullOrEmpty(diachi))
            {
                ViewData["Loi6"] = " Địa chỉ không được bỏ trống ";
            }
            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi7"] = "Phải nhập điện thoại  ";
            }
            else
            {
                kh.HoTen = hoten;
                kh.Taikhoan = tendn;
                kh.Matkhau = matkhau;
                kh.Email = email;
                kh.DiachiKH = diachi;
                kh.DienthoaiKH = dienthoai;
                kh.Ngaysinh = DateTime.Parse(ngaysinh);


                data.KHACHHANGs.InsertOnSubmit(kh);
                data.SubmitChanges();
                return RedirectToAction("Dangnhap");
            }
            return this.Dangky();

        }
        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var tendn = collection["username"];
            var matkhau = collection["password"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu ";
            }
            else
            {
                KHACHHANG ad = data.KHACHHANGs.SingleOrDefault(n => n.Taikhoan == tendn && n.Matkhau == matkhau);
                if (ad != null)
                {
                    Session["Taikhoan"] = ad;
                    return RedirectToAction("Index", "Shopgiay");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        //public ActionResult Dangnhap()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Dangnhap(FormCollection collection)
        //{
        //    var tendn = collection["TenDN"];
        //    var matkhau = collection["Maukhau"];
        //    if (String.IsNullOrEmpty(tendn))
        //    {
        //        ViewData["Loi1"] = "Phải nhập tên đăng nhập";
        //    }
        //    else if (String.IsNullOrEmpty(matkhau))
        //    {
        //        ViewData["Loi2"] = "Phải nhập mật khẩu";
        //    }
        //    else
        //    {
        //        KHACHHANG kh = data.KHACHHANGs.SingleOrDefault(n => n.Taikhoan == tendn && n.Matkhau == matkhau);
        //        if (kh != null)
        //        {
        //            ViewBag.Thongbao = "Đăng nhập thành công";
        //            Session["Taikhoan"] = kh;

        //        }
        //        else

        //            ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng ";

        //    }
        //    return View();

        //}
    }
}