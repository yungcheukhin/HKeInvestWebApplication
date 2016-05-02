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
using HKeInvestWebApplication.ExternalSystems.Code_File;

namespace HKeInvestWebApplication.ClientOnly
{
    public partial class setAlert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //alert table: accNum, security, high, low (primary key: accNum+security)
            //load the dropdown list with only the security the client holds
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
                string inputhigh = high = highValue.Text.Trim();
                string inputlow = lowValue.Text.Trim();
                if (highValue.Text.Trim() != "")
                {
                    high = highValue.Text.Trim();
                }
                if (lowValue.Text.Trim() != "")
                {
                    low = lowValue.Text.Trim();
                }

                //verify if alert had been set
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
                    if (inputhigh !="" && inputlow != "")
                    {
                        myHKeInvestData.setData("UPDATE Alert SET highValue = '" + high + "', lowValue = '" + low + "' WHERE accountNumber = '" + loginuserid + "' AND Alert.type = '" + choosentype + "' AND Alert.code = '" + choosencode + "'", modifyalertdata);
                        myHKeInvestData.commitTransaction(modifyalertdata);
                        Label1.Text = "Your alert value had been updated.";
                    }
                    else if (inputhigh == "" && inputlow != "")
                    {
                        myHKeInvestData.setData("UPDATE Alert SET lowValue = '" + low + "' WHERE accountNumber = '" + loginuserid + "' AND Alert.type = '" + choosentype + "' AND Alert.code = '" + choosencode + "'", modifyalertdata);
                        myHKeInvestData.commitTransaction(modifyalertdata);
                        Label1.Text = "Your alert value had been updated.";
                    }
                    else if (inputhigh != "" && inputlow == "")
                    {
                        myHKeInvestData.setData("UPDATE Alert SET highValue = '" + high + "' WHERE accountNumber = '" + loginuserid + "' AND Alert.type = '" + choosentype + "' AND Alert.code = '" + choosencode + "'", modifyalertdata);
                        myHKeInvestData.commitTransaction(modifyalertdata);
                        Label1.Text = "Your alert value had been updated.";
                    }
                    Label1.Visible = true;
                }

                string curhighv = "";
                string curlowv = "";
                DataTable curalert = myHKeInvestData.getData("SELECT * FROM Alert WHERE accountNumber = '" + loginuserid + "' AND Alert.type = '" + choosentype + "' AND Alert.code = '" + choosencode + "'");
                if (curalert.Rows.Count == 0) 
                {
                }
                else
                {
                    foreach(DataRow row in curalert.Rows)
                    {
                        curhighv = curhighv + row["highValue"];
                        curlowv = curlowv + row["lowValue"];
                    }
                    curhigh.Text = curhighv;
                    curlow.Text = curlowv;
                }
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
                Snamecode.Items.Add(new ListItem("Name (Code)", ""));
                DataTable heldsecurity = myHKeInvestData.getData("SELECT code, name FROM SecurityHolding WHERE SecurityHolding.accountNumber = '" + loginuserid + "' AND  SecurityHolding.type = '" +Stype.SelectedValue+ "'");
                foreach (DataRow row in heldsecurity.Rows)
                {
                    //Snamecode.Items.Add(New ListItem(row["name"].ToString().Trim() + " (code: " + row["code"].ToString().Trim() + ")", row["code"].ToString().Trim()));
                    //Snamecode.Items.Add(row["name"].ToString().Trim()+" (code: "+row["code"].ToString().Trim()+")");
                    Snamecode.Items.Add(new ListItem(row["name"].ToString().Trim() + " (code: " + row["code"].ToString().Trim() + ")", row["code"].ToString().Trim()));
                }
            }
        }

        protected void Snamecode_SelectedIndexChanged(object sender, EventArgs e)
        {
            HKeInvestData myHKeInvestData = new HKeInvestData();
            string loginuser = Context.User.Identity.GetUserName();
            DataTable idsearch = myHKeInvestData.getData("SELECT accountNumber FROM Account WHERE userName = '" + loginuser + "'");
            string loginuserid = "";
            foreach (DataRow row in idsearch.Rows)
            {
                loginuserid = loginuserid + row["accountNumber"];
            }
            string choosencode = Snamecode.SelectedValue.Trim();
            string choosentype = Stype.SelectedValue.Trim();
            string curhighv = "";
            string curlowv = "";
            DataTable curalert = myHKeInvestData.getData("SELECT * FROM Alert WHERE accountNumber = '" + loginuserid + "' AND Alert.type = '" + choosentype + "' AND Alert.code = '" + choosencode + "'");
            if (curalert.Rows.Count == 0)
            {
            }
            else
            {
                foreach (DataRow row in curalert.Rows)
                {
                    curhighv = curhighv + row["highValue"];
                    curlowv = curlowv + row["lowValue"];
                }
                curhigh.Text = curhighv;
                curlow.Text = curlowv;
            }
        }

        protected void cvhigh_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (highValue.Text.Trim() == "" && lowValue.Text.Trim() == "")
            {
                args.IsValid = false;
                cvhigh.ErrorMessage = "At least one value should be inputed.";
            }
        }

        protected void cv1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (highValue.Text != "" && lowValue.Text != "")
            {
                if (System.Convert.ToDecimal(highValue.Text) <= System.Convert.ToDecimal(lowValue.Text))
                {
                    args.IsValid = false;
                    cv1.ErrorMessage = "The high value must not lower or equal to the low value.";
                }
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void cv2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ExternalFunctions myExternalFunctions = new ExternalFunctions();
            decimal curprice = myExternalFunctions.getSecuritiesPrice(Stype.SelectedValue, Snamecode.SelectedValue);
            if (highValue.Text != "")
            {
                if (System.Convert.ToDecimal(highValue.Text) <= curprice)
                {
                    args.IsValid = false;
                    cv1.ErrorMessage = "The high value must not lower or equal to the current price.";
                }
            }
        }

        protected void cv3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ExternalFunctions myExternalFunctions = new ExternalFunctions();
            decimal curprice = myExternalFunctions.getSecuritiesPrice(Stype.SelectedValue, Snamecode.SelectedValue);
            if (lowValue.Text != "")
            {
                if (System.Convert.ToDecimal(lowValue.Text) >= curprice)
                {
                    args.IsValid = false;
                    cv1.ErrorMessage = "The low value must not higher or equal to the current price.";
                }
            }
        }
    }
}