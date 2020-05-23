using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EliteFamilyDental
{
    public partial class MakeanAppointment3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // string msg = SendHtmlFormattedEmail("ashokarehab@gmail.com", "Ashoka Rehab : Make an Appointment " + DateTime.Now, txtName.Text);

            string Subject = "Ashoka Rehab Appointment Name:" + txtName.Text + " Phone: " + txtphonenumber.Text + " " + DateTime.Now;
            string Body = this.PopulateBody(txtName.Text, txtphonenumber.Text,txtemail.Text, txtDate.Text, txtmsg.Text);
            string msg = this.SendHtmlFormattedEmail(ConfigurationManager.AppSettings["Email"], Subject, Body);

         lblmsg.Font.Bold = true;
         if (msg.Contains("Message Sent Successfully..!!"))
         {
             lblmsg.ForeColor = System.Drawing.Color.Green;
         }
         else
         {
             lblmsg.ForeColor = System.Drawing.Color.Red;
           
         }
             lblmsg.Text = msg;
        }

    
        private string SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            string result = "Message Sent Successfully..!!";
            try
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["Email"]);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress(recepientEmail));
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["Host"];
                    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
                    NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                    smtp.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                result = "Error sending email.!!!" +ex.Message;
            }
            return result;
        }


        //protected void SendEmail()
        //{
        //    string Subject = "Ashoka Rehab:Make an Appointment  Name:" + txtName.Text + " Phone: " + txtphonenumber.Text + " " + DateTime.Now;
        //    string Body = this.PopulateBody(txtName.Text,txtphonenumber.Text,txtDate.Text,txtmsg.Text );
        //    this.SendHtmlFormattedEmail(ConfigurationManager.AppSettings["Email"], Subject, Body);
        //}

        private string PopulateBody(string Name, string Mobile, string Email, string AppDate, string Description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("TemplateAppointment.htmL")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{Name}", Name);
            body = body.Replace("{Mobile}", Mobile);
            body = body.Replace("{Email}", Email);
            body = body.Replace("{AppDate}", AppDate);
            body = body.Replace("{Description}", Description);
            return body;
        }



           //public string SendEmail(string toAddress, string subject, string body)
           //{
           //  string result = "Message Sent Successfully..!!";
           //  string senderID = "ashokarehab@gmail.com";// use sender’s email id here..
           //  const string senderPassword = "ashokarehab1"; // sender password here…
           //      try
           //      {
           //        SmtpClient smtp = new SmtpClient
           //        {
           //          Host = "smtp.gmail.com", // smtp server address here…
           //          Port = 587,
           //          EnableSsl = true,
           //          DeliveryMethod = SmtpDeliveryMethod.Network,
           //          Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
           //          Timeout = 30000,
           //        };
           //        MailMessage message = new MailMessage(senderID, toAddress, subject, body);
           //        //smtp.Send(message);
           //      }
           //      catch (Exception ex)
           //      {
           //        result = "Error sending email.!!!";
           //      }
           //  return result;
           //}
    }
}