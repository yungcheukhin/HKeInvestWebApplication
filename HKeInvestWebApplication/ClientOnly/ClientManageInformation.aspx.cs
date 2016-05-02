using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HKeInvestWebApplication
{
    public partial class ManageInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            viewInfro.Click += new EventHandler(this.viewInfro_Click);
        }

        protected void viewInfro_Click(object sender, EventArgs e)
        {

        }
    }
}