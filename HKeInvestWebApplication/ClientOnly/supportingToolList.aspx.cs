using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HKeInvestWebApplication.Cover_page
{
    public partial class ClientSupportingTool : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void manageInfroBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/System_service/ManageInformation.aspx");
        }

        protected void profitLossBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ClientOnly/ProfitLossTracking.aspx");
        }

        protected void alertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ClientOnly/setAlert.aspx");
        }

        protected void reportBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/System_service/Report.aspx");
        }

        protected void additionFeatureBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/System_service/Graph.aspx");
        }
    }
}