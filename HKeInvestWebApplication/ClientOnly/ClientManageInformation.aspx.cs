using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.AspNet.Identity;
using HKeInvestWebApplication.Code_File;
using HKeInvestWebApplication.ExternalSystems.Code_File;

namespace HKeInvestWebApplication
{
    public partial class ManageInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AccountInfro clientAccount = new AccountInfro(Context.User.Identity.GetUserName());
            viewInfro.Click += new EventHandler(this.viewInfro_Click);
        }

        protected void viewInfro_Click(object sender, EventArgs e)
        {

        }
    }
}