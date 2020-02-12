using MyOwnStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MyOwnStore.Libraries.Mail
{
    public class MailSender
    {
        public static void SendMessage(NewsletterMail contato)
        {
            /*
             * SMTP -> Servidor que vai enviar a mensagem.
             */
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("motogshit@gmail.com", "mnbvvbnm");
            smtp.EnableSsl = true;

            string corpoMsg = string.Format("<h2>Contato - LojaVirtual</h2>" +
                "<b>E-mail: </b> {0} <br />" +
                "<p>Você foi inscrito na nossa Newsletter com sucesso! <br/> A partir de agora você ira receber emails com promoções sobre a nossa loja!</p>"+
                "<br /> E-mail enviado automaticamente do site LojaVirtual.",
                contato.Email
            );


            /*
             * MailMessage -> Construir a mensagem
             */
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("motogshit@gmail.com");
            mensagem.To.Add(contato.Email);
            mensagem.Subject = "Contato - LojaVirtual - E-mail: " + contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            //Enviar Mensagem via SMTP
            smtp.Send(mensagem);
        }
    }
}
