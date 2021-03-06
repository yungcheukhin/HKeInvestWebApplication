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
using System.Data.SqlClient;

namespace HKeInvestWebApplication
{
    public partial class RegistrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cvAccountNumber_ServerValidate(object source, ServerValidateEventArgs args)
        {


            if (AccountNumber.Text!=null && LastName.Text!=null) {
                string accountnumber = AccountNumber.Text;
                string lastname = LastName.Text.ToUpper();
                Int32 test;
                string sql = "SELECT userName FROM Account WHERE accountNumber = '" + accountnumber + "'";
                HKeInvestData myHKeInvestData = new HKeInvestData();
                DataTable dtClient = myHKeInvestData.getData(sql);

                foreach (DataRow row in dtClient.Rows)
                {
                    if (row != null)
                    {
                        args.IsValid = false;
                        cvAccountNumber.ErrorMessage = "This account number has already been used to create an account.";
                    }
                    
                }

                if (accountnumber.Length == 10)
                {
                    if ((!Int32.TryParse(accountnumber.Substring(2), out test)))
                    {
                        args.IsValid = false;
                        cvAccountNumber.ErrorMessage = "The format of account number is not correct.";
                    }
                }
                else
                    args.IsValid = false;


                if (lastname.Length == 1) {
                    if (accountnumber[0] != lastname[0])
                    {
                        args.IsValid = false;
                    }
                    if (accountnumber[1] != lastname[0])
                    {
                        args.IsValid = false;
                    }
                    if (args.IsValid == false)
                    {
                        cvAccountNumber.ErrorMessage = "The account number does not match the client's last name.";
                    }
                }
                if (lastname.Length > 1)
                {
                    if (accountnumber[0] != lastname[0])
                    {
                        args.IsValid = false;
                    }
                    if (accountnumber[1] != lastname[1])
                    {
                        args.IsValid = false;
                    }
                    if (args.IsValid == false)
                    {
                        cvAccountNumber.ErrorMessage = "The account number does not match the client's last name.";
                    }
                }


            }

        }

        protected void cvUserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string username = UserName.Text.Trim();
            string sql2 = "SELECT userName FROM Account WHERE userName = '" + username + "'";
            HKeInvestData myHKeInvestData2 = new HKeInvestData();
            DataTable dtUser = myHKeInvestData2.getData(sql2);

            foreach(DataRow row in dtUser.Rows)
            {
                if(row!=null)
                {
                     args.IsValid = false;
                     cvUserName.ErrorMessage = "The user name has been used.";
                }
               
            }


        }

        protected void Register_Click(object sender, EventArgs e)
        {


        }
    }
}