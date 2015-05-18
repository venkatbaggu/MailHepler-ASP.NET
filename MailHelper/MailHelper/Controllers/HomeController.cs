using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailHelper.Models;

namespace MailHelper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new LoginViewModel
            {
                Email = "aaaa",
                Password = "paa"
            };

            string body;
            //We can pass the model items to the tempalte file
            using (var sr = new StreamReader(@"\\App_Data\\Templates\\RegisterWelcome.html"))
            {
                body = sr.ReadToEnd();
            }
            try
            {
                //add email logic here to email the customer
                string sender = ConfigurationManager.AppSettings["EmailFromAddress"];
                var MailHelper = new MailHelper
                {
                    Sender = sender,
                    Recipient = "ReceiptentEmail",
                    RecipientCC = null,
                    Subject = @"Welcome to New Site.",
                    Body = string.Format(body, model.Email, model.Password)
                };
                MailHelper.Send();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}