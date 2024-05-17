using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using projectf22.Models;
using System;
using System.Collections.Generic;

namespace projectf22.Pages.Admin_Page
{
    public class A_PaymentsModel : PageModel
    {
        private readonly ILogger<A_PaymentsModel> _logger;
        private DB db { get; set; }
        public List<Payment> PaymentsList { get; set; } = new List<Payment>();

        public A_PaymentsModel(ILogger<A_PaymentsModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            var dt = db.ReadTable("PAYMENT");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var payment = new Payment();
                payment.PaymentID = (int)dt.Rows[i]["PaymentID"];
                payment.PaymentDate = (DateTime)dt.Rows[i]["PaymentDate"];
                payment.PaymentAmount = (decimal)dt.Rows[i]["PaymentAmount"];
                payment.PaymentMethod = (string)dt.Rows[i]["PaymentMethod"];
                payment.EventID = (int)dt.Rows[i]["EventID"];

                PaymentsList.Add(payment);
            }
        }
    }
}
