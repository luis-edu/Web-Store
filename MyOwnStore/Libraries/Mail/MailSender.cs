using Microsoft.Extensions.Configuration;
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
        SmtpClient _smtp;
        IConfiguration _config;
        public MailSender(SmtpClient smtp, IConfiguration config)
        {
            _smtp = smtp;
            _config = config;
        }
        public void SendNewsletter(NewsletterMail contato)
        {
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
            mensagem.From = new MailAddress(_config.GetValue<string>("Email:EmailCredential"));
            mensagem.To.Add(contato.Email);
            mensagem.Subject = "Contato - Registro Newsletter" + contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            //Enviar Mensagem via SMTP
            _smtp.Send(mensagem);
        }
        public void SendPassword(string Email, string Password)
        {
            string corpoMsg = string.Format("" +
                "" +
                "<h2>Mensagem referente a senha de acesso ao sistema de colaboradores</h2>" +
                "<br />" +
                "<p>Sua senha de acesso é: <strong>{0}</strong></p>" +
                "<br/>" +
                "<p>Acesse o site <a>Aqui<a/> e faça o seu login</p>", Password);
            /*
             * MailMessage -> Construir a mensagem
             */
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress(_config.GetValue<string>("Email:EmailCredential"));
            mensagem.To.Add(Email);
            mensagem.Subject = "Contato - Senha de Acesso " + Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            //Enviar Mensagem via SMTP
            _smtp.Send(mensagem);
        }
    }
}
