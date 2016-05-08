using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HKeInvestWebApplication.EmployeeOnly
{
    public partial class ClientBaseTool : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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