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

namespace HKeInvestWebApplication.ClientOnly
{
    public partial class ProfitLossTracking : System.Web.UI.Page
    {
        HKeInvestData myHKeInvestData = new HKeInvestData();
        HKeInvestCode myHKeInvestCode = new HKeInvestCode();
        ExternalFunctions myExternalFunctions = new ExternalFunctions();

        protected void Page_Load(object sender, EventArgs e)
        {
            string loggedinuser = Context.User.Identity.GetUserName();
            /*lbltest.Text = loggedinuser;
            lbltest.Visible = true;*/
            string sql = "SELECT accountNumber FROM Account WHERE userName = '" + loggedinuser + "'";
            string loggedinuserid = "";
            //execute sql command in database
            DataTable loginuserid = myHKeInvestData.getData(sql);
            foreach (DataRow row in loginuserid.Rows)
            {
                loggedinuserid = loggedinuserid + row["accountNumber"];
            }
            lblAccountNumber.Text = loggedinuserid;
            lblAccountNumber.Visible = true;

        }
        protected void ddlSecurityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset visbility of controls and initialize values.
            lblResultMessage.Visible = false;
            gvSecurityHolding.Visible = false;

            //find logged in user id
            string sql = "";
            string loggedinuser = Context.User.Identity.GetUserName();
            string sql2 = "SELECT accountNumber FROM Account WHERE userName = '" + loggedinuser + "'";
            string loggedinuserid = "";
            DataTable loginuserid = myHKeInvestData.getData(sql2);
            foreach (DataRow row in loginuserid.Rows)
            {
                loggedinuserid = loggedinuserid + row["accountNumber"];
            }
            //end finding logged in user id

            string accountNumber = "";
            accountNumber = loggedinuserid; // Set the account number from a web form control!
            string securityType = "";
            securityType = ddlSecurityType.SelectedValue; // Set the securityType from a web form control!

            // No action when the first item in the DropDownList is selected.
            if (securityType == "0") { return; }

            //retrieve the first and last name of the client(s)
            sql = "SELECT firstName, lastName FROM Client WHERE Client.accountNumber='" + accountNumber + "'";

            DataTable dtClient = myHKeInvestData.getData(sql);
            if (dtClient == null) { return; } // If the DataSet is null, a SQL error occurred.

            // Show the client name(s) on the web page.
            string clientName = "Client(s): ";
            int i = 1;
            foreach (DataRow row in dtClient.Rows)
            {
                clientName = clientName + row["lastName"] + ", " + row["firstName"];
                if (dtClient.Rows.Count != i)
                {
                    clientName = clientName + "and ";
                }
                i = i + 1;
            }
            lblClientName.Text = clientName;
            lblClientName.Visible = true;

        }
        protected void gvProfitLossTracking_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
    }
}