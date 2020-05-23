using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AshokaRehab
{
    public partial class MakeanAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSendmsg_Click(object sender, EventArgs e)
        {
            lblmsg.Text = "Thanks for Showing Interset, we Will callback to you";
        }
    }
}