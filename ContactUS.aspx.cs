using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EliteFamilyDental
{
    public partial class ContactUS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            // string msg = SendHtmlFormattedEmail("ashokarehab@gmail.com", "Ashoka Rehab : Make an Appointment " + DateTime.Now, txtName.Text);

            string Subject = "Ashoka Rehab Contact Form:" + txtname.Value + " Phone: " + txtPhone.Value + " " + DateTime.Now;
            string Body = this.PopulateBody(txtname.Value, txtPhone.Value, txtemail.Value, DateTime.Now.ToString(), txtmessage.Value);
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
        private string PopulateBody(string Name, string Mobile, string Email, string ContactDate, string Message)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("TemplateContactus.htmL")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{Name}", Name);
            body = body.Replace("{Mobile}", Mobile);
            body = body.Replace("{Email}", Email);
            body = body.Replace("{ContactDate}", ContactDate);
            body = body.Replace("{Message}", Message);
            return body;
        }
        private string SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            string result = "Message Sent Successfully..!!";
            try
            {
                using (System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage())
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
                result = "Error sending email.!!!" + ex.Message;
            }
            return result;
        }

    }
}