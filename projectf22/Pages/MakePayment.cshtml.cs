using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using projectf22.Models;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace projectf22.Pages
{
    public class MakePaymentModel : PageModel
    {
        public Payment P=new Payment();
        private readonly DB Data;
        public int TickID;
        public int EVID;
        public int UserId;
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
            int.TryParse(HttpContext.Session.GetString("UsID"), out UserId);
            TickID = (int)Data.GetTicketFromEventId(EVID).Rows[0][0];
            TotalPrice = T;

            P.PaymentDate=DateTime.Now; 
            P.EventID=EVID;
            P.PaymentMethod=Method;
            P.PaymentAmount=TotalPrice;

            Data.AddPayment(P);
            Data.UPdateUserInfo2(UserId, TickID, P.PaymentID);
            return RedirectToPage("/Done");
        }

        public void OnPostPromot()
        {
            int.TryParse(HttpContext.Session.GetString("UsID"), out UserId);
            Discount = Data.GetDiscountAmount(Code);
            decimal.TryParse(HttpContext.Session.GetString("Total"), out decimal T);
            Data.UPdateUserInfo3(UserId, Data.GetProID(Code)); 
            TotalPrice = T;
            TotalPrice = (1 - Discount/100) * TotalPrice;


        }

    }
}
