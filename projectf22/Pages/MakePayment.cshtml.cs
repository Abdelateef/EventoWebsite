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
        public Payment P=new Payment();
        private readonly DB Data;
        public int EVID;
        [BindProperty]
        public decimal TotalPrice { get; set; }
        public string Method;
        public decimal Discount;
        [BindProperty]
        public string Code { get; set; }

        public MakePaymentModel(DB db)
        {
            Data = db;
        }
        public void OnGet()
        {
            decimal.TryParse(HttpContext.Session.GetString("Total"), out decimal T);
            TotalPrice = T;
        }

        public IActionResult OnPostPay() 
        {
            Method = Request.Form["Method"];
            int.TryParse(HttpContext.Session.GetString("EID"), out EVID);
            decimal.TryParse(HttpContext.Session.GetString("Total"), out decimal T);
            TotalPrice = T;

            P.PaymentDate=DateTime.Now; 
            P.EventID=EVID;
            P.PaymentMethod=Method;
            P.PaymentAmount=TotalPrice;

            Data.AddPayment(P);
            return RedirectToPage("/Done");
        }

        public void OnPostPromot()
        {
            Discount = Data.GetDiscountAmount(Code);
            decimal.TryParse(HttpContext.Session.GetString("Total"), out decimal T);
            TotalPrice = T;
            TotalPrice = (1 - Discount/100) * TotalPrice;


        }

    }
}
