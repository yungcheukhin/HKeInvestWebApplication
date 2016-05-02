using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using HKeInvestWebApplication.Code_File;
using Microsoft.AspNet.Identity;

namespace HKeInvestWebApplication.ClientOnly
{
    public partial class setAlert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //alert table: accNum, security, high, low (primary key: accNum+security)
            //load the dropdown list with only the security the client holds
            Snamecode.Visible = false;
            Label1.Visible = false;
            //Snamecode.Items.Clear();
        }

        protected void setAlertValue(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                HKeInvestData myHKeInvestData = new HKeInvestData();


                //get user id
                string loginuser = Context.User.Identity.GetUserName();
                DataTable idsearch = myHKeInvestData.getData("SELECT accountNumber FROM Account WHERE userName = '" + loginuser + "'");
                string loginuserid = "";
                foreach (DataRow row in idsearch.Rows)
                {
                    loginuserid = loginuserid + row["accountNumber"];
                }
                //************Now loginuserid stores the id**************

                string choosencode = Snamecode.SelectedValue.Trim();
                string choosentype = Stype.SelectedValue.Trim();
                string high = "NULL";
                string low = "NULL";
                if (highValue.Text.Trim() != "")
                {
                    high = highValue.Text.Trim();
                }
                if (lowValue.Text.Trim() != "")
                {
                    low = lowValue.Text.Trim();
                }

                //DataTable heldsecurity = myHKeInvestData.getData("SELECT * FROM SecurityHolding WHERE SecurityHolding.accountNumber = '" + loginuserid + "' AND ");
                //verify if alert had been set

                /*DataTable checkalert = myHKeInvestData.getData("SELECT * FROM Alert WHERE accountNumber = '" + loginuserid + "' AND type = '" + choosentype + "' AND code = '" + choosencode + "'");
                if (checkalert.Rows.Count==0)
                {
                    Label2.Text = "fucking null";
                }*/

                DataTable checkalert = myHKeInvestData.getData("SELECT * FROM Alert WHERE accountNumber = '" +loginuserid+ "' AND type = '" +choosentype+ "' AND code = '" +choosencode+ "'");
                if (checkalert.Rows.Count == 0)
                {
                    //add new alert data if doesnt exist
                    SqlTransaction addalertdata = myHKeInvestData.beginTransaction();
                    myHKeInvestData.setData("INSERT INTO Alert (accountNumber, type, code, highValue, lowValue) VALUES ('" + loginuserid + "', '" + choosentype + "', '" + choosencode + "', " + high + ", " + low + ")", addalertdata);
                    myHKeInvestData.commitTransaction(addalertdata);
                }
                else
                {
                    //update alert info  (cover old value)
                    SqlTransaction modifyalertdata = myHKeInvestData.beginTransaction();
                    myHKeInvestData.setData("UPDATE Alert SET highValue = '" +high+ "', lowValue = '" + low + "' WHERE accountNumber = '" +loginuserid+ "' AND Alert.type = '" + choosentype + "' AND Alert.code = '" + choosencode + "'", modifyalertdata);
                    myHKeInvestData.commitTransaction(modifyalertdata);
                    Label1.Text = "Your alert value had been updated.";
                    Label1.Visible = true;
                }

                DataTable curalert = myHKeInvestData.getData("SELECT * FROM Alert WHERE accountNumber = '" + loginuserid + "' AND Alert.type = '" + choosentype + "' AND Alert.code = '" + choosencode + "'");
                //gfdhdrhrtd
                DataTable haha = null;
            }
        }

        protected void Stype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Stype.SelectedValue != "")
            {
                HKeInvestData myHKeInvestData = new HKeInvestData();
                //get user id and security data
                string loginuser = Context.User.Identity.GetUserName();
                DataTable idsearch = myHKeInvestData.getData("SELECT accountNumber FROM Account WHERE userName = '" + loginuser + "'");
                string loginuserid = "";
                foreach (DataRow row in idsearch.Rows)
                {
                    loginuserid = loginuserid + row["accountNumber"];
                }
                //get data to be input in dropdown list
                Snamecode.Items.Clear();
                Snamecode.Items.Add(new ListItem("Name (Code)", "0"));
                DataTable heldsecurity = myHKeInvestData.getData("SELECT code, name FROM SecurityHolding WHERE SecurityHolding.accountNumber = '" + loginuserid + "' AND  SecurityHolding.type = '" +Stype.SelectedValue+ "'");
                foreach (DataRow row in heldsecurity.Rows)
                {
                    //Snamecode.Items.Add(New ListItem(row["name"].ToString().Trim() + " (code: " + row["code"].ToString().Trim() + ")", row["code"].ToString().Trim()));
                    //Snamecode.Items.Add(row["name"].ToString().Trim()+" (code: "+row["code"].ToString().Trim()+")");
                    Snamecode.Items.Add(new ListItem(row["name"].ToString().Trim() + " (code: " + row["code"].ToString().Trim() + ")", row["code"].ToString().Trim()));
                }
                Snamecode.Visible = true;
            }
        }
    }
}