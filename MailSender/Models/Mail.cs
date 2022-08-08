using System;
using System.Configuration;

namespace MailSender.Models
{
    public class Contato
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
    }

    public class Mail
    {
        public static void EnviarEmail(Contato contato, string ip)
        {
            var body = "<html>" +
               "<body>" +
               "<h3>Contato do Site - " + ConfigurationManager.AppSettings["SiteName"] + "</h3>" +
               "<p><b>Nome:</b> " + contato.Nome + "</p>" +
               "<p><b>E-mail:</b> " + contato.Email + "</p>" +
               "<p><b>Mensagem:</b> <br/>" + contato.Mensagem + " </p>" +
               "<p>&nbsp;</p>" +
               "<p>&nbsp;</p>" +
               "<p>Atenciosamente, <br/></p>" +
               "<p>" + ConfigurationManager.AppSettings["SiteName"] + "</p>" +               
               "<p>Origem da operação: " + ip + " " + DateTime.Now + "</p>" +
               "</body>" +
               "</html>";
            string[] anexos = { };

            Mailer.Send(contato.Email, contato.Email, "Contato do Site", body, "", new string[0]);

        }
    }
}