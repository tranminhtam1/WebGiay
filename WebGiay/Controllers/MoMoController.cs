using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGiay.MoMo;

namespace WebGiay.Controllers
{
    public class MoMoController : Controller
    {
        // GET: MoMo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Payment()
        {
            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMORQLA20210722";
            string accessKey = "2NKwsrRJzltQwBeC";
            string serectkey = "k5vapxciBuauSH0Gq09jk5WAW9D4oroq";
            string orderInfo = "Số tiền thanh toán";
            string returnUrl = "https://localhost:44344/MoMo/ConfirmPaymentClient";
            string notifyurl = "http://ba1adf48beba.ngrok.io/Home/SavePayment";

            string amount = "10000";
            string orderid = DateTime.Now.Ticks.ToString();
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return Redirect(jmessage.GetValue("payUrl").ToString());
        }

        public ActionResult ConfirmPaymentClient()
        {
            //hi?n th? thông báo cho ngu?i dùng
            return View();
        }

        [HttpPost]
        public void SavePayment()
        {
            //c?p nh?t d? li?u vào db
        }
    }
}