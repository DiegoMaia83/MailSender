using MailSender.Models;
using System;
using System.Web.Mvc;

namespace MailSender.Controllers
{
    public class MailController : Controller
    {
        public ActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(Contato contato)
        {
            try
            {
                Mail.EnviarEmail(contato, Request.ServerVariables["REMOTE_ADDR"]);

                ViewBag.Message = "Email enviado!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Erro ao enviar o e-mail ( " + ex.Message + " )";
            }

            return View();
        }
    }
}