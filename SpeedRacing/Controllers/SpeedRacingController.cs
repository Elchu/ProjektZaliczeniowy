using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using SpeedRacing.HelpersClass;

namespace SpeedRacing.Controllers
{
    public class SpeedRacingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string imie, string email, string telefon, string temat, string wiadomosc)
        {
            try
            {
                GMailer.GmailUsername = ConfigurationManager.AppSettings["From"];
                GMailer.GmailPassword = ConfigurationManager.AppSettings["Pass"];
                
                GMailer mailer = new GMailer();
                mailer.ToEmail = email;
                mailer.Subject = temat;
                mailer.Body = string.Format("Witam <br /> Imię i nazwisko: <b>{0}</b>,<br /> Numer telefonu: <b>{1}</b>,<br />Temat: <b>{2}<b/><br /> Treść wiadomości: {3}", imie, telefon, temat, wiadomosc);
                mailer.IsHtml = true;
                mailer.Send();
            }
            catch (Exception ex)
            {
                Response.Write("Nie można wysłać wiadomośći - wystąpił błąd: " + ex.Message);
            }
            return View();
        }

        public ActionResult Ofirmie()
        {
            return View();
        }
        public ActionResult Myjnia()
        {
            return View();
        }
        public ActionResult Oferta()
        {
            return View();
        }
    }
}