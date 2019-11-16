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
    [SerializeField] private InputField nomeAdm, emailAdm;
    [SerializeField] private GameObject erroRecuperar, erroEnviar, enviado;
    [SerializeField] private Text env;

    //SMTP
    public void SendSmtpMail()
    {
        bool aux = true;
        if (gameControl.Recuperar(nomeAdm.text, emailAdm.text))
        {
            var mail = new MailMessage();
            mail.From = new MailAddress("tcc.tbp2019@gmail.com");
            mail.To.Add(emailAdm.text);
            mail.Subject = "Recuperação de senha TatuBolinhaPuzzle";
            mail.Body = "Sua senha é: " + gameControl.GetSenhaAdmin();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587; //645 587
            smtpClient.Credentials = new NetworkCredential("tcc.tbp2019@gmail.com", "cc8p12gjmt");
            smtpClient.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = (x, y, z, w) => true;
            try
            {
                smtpClient.Send(mail);
            }
            catch (SmtpException smtpex)
            {
                erroEnviar.SetActive(true);
                enviado.SetActive(false);
                erroRecuperar.SetActive(false);
                aux = false;
            }
            if (aux)
            {
                erroEnviar.SetActive(false);
                enviado.SetActive(true);
                erroRecuperar.SetActive(false);
                nomeAdm.text = "";
                emailAdm.text = "";
            }
        }
        else
        {
            erroRecuperar.SetActive(true);
            enviado.SetActive(false);
            erroEnviar.SetActive(false);
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
