using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectf22.Models;

namespace projectf22.Pages
{
    public class MakePaymentModel : PageModel
    {
        Payment P=new Payment();
        private readonly DB Data;
        int EVID;
        int TotalPrice;

        public MakePaymentModel(DB db)
        {
            Data = db;
        }
        public void OnGet()
        {
        }

        public void OnPostPay() 
        {
            int.TryParse(HttpContext.Session.GetString("EID"), out EVID);
            int.TryParse(HttpContext.Session.GetString("Total"), out TotalPrice);
            P.PaymentDate;
            P.EventID;
            P.PaymentMethod;
            P.PaymentAmount;

            Data.AddPayment(P);
        }

    }
}
