﻿using System;
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
    public partial class Report : System.Web.UI.Page
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

        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvSummary.Visible = false;
            gvStatus.Visible = false;
            gvOrder.Visible = false;

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
            string reportType = "";
            reportType = ddlReportType.SelectedValue;

            // No action when the first item in the DropDownList is selected.
            if (reportType == "0") { return; }

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

            DataTable dtReport = null;

            if (reportType == "summary")
            {
                string sql3 = "SELECT A1.firstName,A1.lastName,A1.accountNumber,A2.monetaryTotal,A2.balance,A2.monetaryBond,A2.monetaryTrust,A2.monetaryStock,A2.date,A2.monetaryLast FROM Client A1,Record A2 WHERE A1.accountNumber = '" + accountNumber + "' AND  A1.accountNumber = A2.accountNumber";

                dtReport = myHKeInvestData.getData(sql3);

                gvSummary.DataSource = dtReport;
                gvSummary.DataBind();

                gvSummary.Visible = true;
            }

            if (reportType == "history")
            {
                string sql3 = " SELECT A1.referenceNumber, A1.buyOrSell, A1.securityType, A1.securityCode, A1.dateSubmitted, A1.status, A1.shares, A1.amount, A1.name, A2.fees, A1.transactionNumber, A1.shares, (A1.amount/A1.shares) AS priceShare FROM  TransactionRecord A1, Record A2 WHERE A1.accountNumber = '" + accountNumber + "' AND A1.accountNumber = A2.accountNumber";

                dtReport = myHKeInvestData.getData(sql3);

                gvOrder.DataSource = dtReport;
                gvOrder.DataBind();

                gvOrder.Visible = true;
            }
            if(reportType == "status")
            {
                string sql3 = "SELECT A1.referenceNumber, A1.buyOrSell, A1.securityType, A1.securityCode, A1.name, A1.dateSubmitted, A1.status, A1.amount, A1.shares, A1.limitPrice, A1.stopPrice, A1.expiryDay FROM TransactionRecord A1 WHERE A1.accountNumber = '" + accountNumber + "'";

                dtReport = myHKeInvestData.getData(sql3);

                gvStatus.DataSource = dtReport;
                gvStatus.DataBind();

                gvStatus.Visible = true;

            }
            if (reportType == "detail")
            {
                string sql3 = "SELECT securityCode, securityType, name, shares, base, monetary, (amount/shares) AS priceShare FROM TransactionRecord WHERE accountNumber = '" + accountNumber + "'";

                dtReport = myHKeInvestData.getData(sql3);

                gvDetail.DataSource = dtReport;
                gvDetail.DataBind();

                gvDetail.Visible = true;

            }
        }
    }
}