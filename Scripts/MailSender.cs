using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class MailSender : MonoBehaviour
{
    GameControl gameControl;
    public InputField nomeAdm, emailAdm;
    public GameObject erroRecuperar, enviado;
    public Text env;

    //SMTP
    public void SendSmtpMail()
    {
        if (gameControl.Recuperar(nomeAdm.text, emailAdm.text))
        {
            /*
            var mail = new MailMessage();
            mail.From = new MailAddress("tcc.tbp2019@gmail.com");
            mail.To.Add(emailAdm.text);
            mail.Subject = "Recuperação de senha TatuBolinhaPuzzle";
            mail.Body = "Sua senha é: " + gameControl.GetSenhaAdmin();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587; //645 587
            smtpClient.Credentials = new NetworkCredential("tcc.tbp2019@gmail.com", "cc8p12gtmj");
            smtpClient.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = (x, y, z, w) => true;
            smtpClient.Send(mail);
            */
            enviado.SetActive(true);
            erroRecuperar.SetActive(false);
            env.text = "Sua senha é: " + gameControl.GetSenhaAdmin();
            nomeAdm.text = "";
            emailAdm.text = "";
        }
        else
        {
            erroRecuperar.SetActive(true);
            enviado.SetActive(false);
        }
    }

    //Default
    public void SendEmail()
    {
        if (gameControl.Recuperar(nomeAdm.text, emailAdm.text))
        {
            string email = "tcc.tbp2019@gmail.com";
            string subject = MyEscapeURL(emailAdm.text);
            string body = MyEscapeURL("Sua senha é:" + gameControl.GetSenhaAdmin());
            Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);

            enviado.SetActive(true);
            erroRecuperar.SetActive(false);
            nomeAdm.text = "";
            emailAdm.text = "";
        }
        else
        {
            erroRecuperar.SetActive(true);
            enviado.SetActive(false);
        }
    }
    string MyEscapeURL(string URL)
    {
        return WWW.EscapeURL(URL).Replace("+", "%20");
    }

    void Start()
    {
        gameControl = GameControl.gameControl; //Seta o gameControl
    }
}
