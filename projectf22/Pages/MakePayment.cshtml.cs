using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using projectf22.Models;
using System.Data;

namespace projectf22.Pages
{
    public class MakePaymentModel : PageModel
    {
        Payment P=new Payment();
        private readonly DB Data;
        int EVID;
        Decimal TotalPrice;
        string Method;

        public MakePaymentModel(DB db)
        {
            Data = db;
        }
        public void OnGet()
        {
        }

        public void OnPostPay() 
        {
            Method = Request.Form["Method"];
            int.TryParse(HttpContext.Session.GetString("EID"), out EVID);
            Decimal.TryParse(HttpContext.Session.GetString("Total"), out TotalPrice);

            P.PaymentDate=DateTime.Now; 
            P.EventID=EVID;
            P.PaymentMethod=Method;
            P.PaymentAmount=TotalPrice;

            Data.AddPayment(P);
        }

    }
}
