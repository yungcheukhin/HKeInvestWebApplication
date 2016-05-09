using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HKeInvestWebApplication.System_service
{
    public partial class Graph : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void userNameSearchBtn_Click(object sender, EventArgs e)
        {

            graph7.Visible = true;
            graph30.Visible = false;
            securitySearchBtn2.Visible = true;
        }

        protected void securitySearchBtn2_Click(object sender, EventArgs e)
        {
            graph7.Visible = false;
            graph30.Visible = true;
        }

        protected void checkHold()
        {

        }

    }
}