﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using HKeInvestWebApplication.Code_File;
using HKeInvestWebApplication.ExternalSystems.Code_File;

namespace HKeInvestWebApplication.Code_File
{
    class AccountInfro //for mass access toward table Client and Account
    {
        HKeInvestData myHKeInvestData = new HKeInvestData();
        HKeInvestCode myHKeInvestCode = new HKeInvestCode();
        ExternalFunctions myExternalFunctions = new ExternalFunctions();
        public string userName, accountNumber, accountType, firstName, lastName, dateOfBirth,
            building, street, district, homePhone, homeFax, businessPhone,
            mobile, citizenship, legalResidence, HKIDPassportNumber, passportCountryOfIssue,
            email, title, balance;
        public DataTable Account, Client;
        public Boolean accountExist;
        public AccountInfro(string loginName)
        {
            userName = loginName;
            updateTable();
        }
        public AccountInfro()
        {

        }

        public void updateTable() {

            Account = myHKeInvestData.getData("SELECT * FROM Account WHERE userName = '" + userName + "'");
            foreach (DataRow row in Account.Rows)
            {
                accountNumber = row["accountNumber"].ToString();
                accountType = row["accountType"].ToString();
                balance = row["balance"].ToString();


            }

            Client = myHKeInvestData.getData("SELECT * FROM Client WHERE accountNumber = '" + accountNumber + "'");
            foreach (DataRow row in Client.Rows)
            {
                char[] delimiterChars = { ' ', '\t' };
                dateOfBirth = row["dateOfBirth"].ToString();
                string[] date = dateOfBirth.Split(delimiterChars);
                dateOfBirth = date[0];
                firstName = row["firstName"].ToString();
                lastName = row["lastName"].ToString();
                email = row["email"].ToString();
                HKIDPassportNumber = row["HKIDPassportNumber"].ToString();
                title = row["title"].ToString();
                building = row["building"].ToString();
                street = row["street"].ToString();
                district = row["district"].ToString();
                homePhone = row["homePhone"].ToString();
                homeFax = row["homePhone"].ToString();
                businessPhone = row["businessPhone"].ToString();
                mobile = row["mobile"].ToString();
                citizenship = row["citizenship"].ToString();
                legalResidence = row["legalResidence"].ToString();
                passportCountryOfIssue = row["passportCountryOfIssue"].ToString();

            }
        }

        public void updateTableWithAccountNumber()
        {

            Account = myHKeInvestData.getData("SELECT * FROM Account WHERE accountNumber = '" + accountNumber + "'");
            foreach (DataRow row in Account.Rows)
            {
                userName = row["userName"].ToString();
                accountType = row["accountType"].ToString();
                balance = row["balance"].ToString();


            }

            Client = myHKeInvestData.getData("SELECT * FROM Client WHERE accountNumber = '" + accountNumber + "'");
            foreach (DataRow row in Client.Rows)
            {
                char[] delimiterChars = { ' ', '\t' };
                dateOfBirth = row["dateOfBirth"].ToString();
                string[] date = dateOfBirth.Split(delimiterChars);
                dateOfBirth = date[0];
                firstName = row["firstName"].ToString();
                lastName = row["lastName"].ToString();
                email = row["email"].ToString();
                HKIDPassportNumber = row["HKIDPassportNumber"].ToString();
                title = row["title"].ToString();
                building = row["building"].ToString();
                street = row["street"].ToString();
                district = row["district"].ToString();
                homePhone = row["homePhone"].ToString();
                homeFax = row["homePhone"].ToString();
                businessPhone = row["businessPhone"].ToString();
                mobile = row["mobile"].ToString();
                citizenship = row["citizenship"].ToString();
                legalResidence = row["legalResidence"].ToString();
                passportCountryOfIssue = row["passportCountryOfIssue"].ToString();

            }
        }

        public void changeData(string toChange,string value,string AccountNumber)
        {

            SqlTransaction trans = myHKeInvestData.beginTransaction();
            if(String.Compare(toChange, "balance") == 0) 
            myHKeInvestData.setData("UPDATE Account SET " + toChange + " = '"+ value +
                "' WHERE accountNumber = '" + AccountNumber + "'", trans);
            else myHKeInvestData.setData("UPDATE Client SET " + toChange + " = '" + value +
                "' WHERE accountNumber = '" + AccountNumber + "'", trans);
            myHKeInvestData.commitTransaction(trans);

            //DataBinder.Eval(toChange, value);
        }

        public void changeData(string toChange, string value)
        {

            SqlTransaction trans = myHKeInvestData.beginTransaction();
            if (String.Compare(toChange, "balance") == 0)
                myHKeInvestData.setData("UPDATE Account SET " + toChange + " = '" + value +
                    "' WHERE accountNumber = '" + accountNumber + "'", trans);
            else myHKeInvestData.setData("UPDATE Client SET " + toChange + " = '" + value +
                "' WHERE accountNumber = '" + accountNumber + "'", trans);
            myHKeInvestData.commitTransaction(trans);

            //DataBinder.Eval(toChange, value);
        }

        public Boolean checkNameExist()
        {
            DataTable temp = myHKeInvestData.getData("SELECT accountNumber FROM Account WHERE userName = '" + userName + "'");
            foreach (DataRow row in temp.Rows)
            {
                if (row == null)
                {
                    accountExist = false;
                }
                else {
                    accountExist = true;
                }
            }


            return accountExist;
        }

        public Boolean checkAccountNumberExist()
        {
            DataTable temp = myHKeInvestData.getData("SELECT * FROM Account WHERE accountNumber = '" + accountNumber + "'");
            foreach (DataRow row in temp.Rows)
            {
                if (row == null)
                {
                    accountExist = false;
                }
                else {
                    accountExist = true;
                }
            }


            return accountExist;
        }

    }

    class accessDataBase //for single access for all table
    {
        HKeInvestData myHKeInvestData = new HKeInvestData();
        HKeInvestCode myHKeInvestCode = new HKeInvestCode();
        ExternalFunctions myExternalFunctions = new ExternalFunctions();
        public string getOneData(string toGetVar, string Table, string loginName)
        {
            
            string accountNumber = "";
            DataTable temp = myHKeInvestData.getData("SELECT accountNumber FROM Account WHERE userName = '" + loginName + "'");

            foreach (DataRow row in temp.Rows)
            {
                accountNumber = row["accountNumber"].ToString();
            }

            temp = myHKeInvestData.getData("SELECT " + toGetVar + " FROM " + Table +
                " WHERE accountNumber = '" + accountNumber + "'");

            foreach (DataRow row in temp.Rows)
            {
                return row[toGetVar].ToString();
            }

            return null;
        }

        public string getOneDatabyNO(string toGetVar, string Table, string accountNumber)
        {

            DataTable temp = myHKeInvestData.getData("SELECT " + toGetVar + " FROM " + Table +
                " WHERE accountNumber = '" + accountNumber + "'");

            foreach (DataRow row in temp.Rows)
            {
                return row[toGetVar].ToString();
            }

            return null;
        }

        public void setOneData(string toChangeVar, string Table, string value, string loginName)
        {
            string accountNumber = "";
            DataTable temp = myHKeInvestData.getData("SELECT accountNumber FROM Account WHERE userName = '" + loginName + "'");

            foreach (DataRow row in temp.Rows)
            {
                accountNumber = row["accountNumber"].ToString();
            }
            SqlTransaction trans = myHKeInvestData.beginTransaction();
            myHKeInvestData.setData("UPDATE "+ Table + " SET " + toChangeVar + " = '" + value +
                "' WHERE accountNumber = '" + accountNumber + "'", trans);
            myHKeInvestData.commitTransaction(trans);
        }

        public void setOneDatabyNO(string toChangeVar, string Table, string value, string accountNumber)
        {
            SqlTransaction trans = myHKeInvestData.beginTransaction();
            myHKeInvestData.setData("UPDATE " + Table + " SET " + toChangeVar + " = '" + value +
                "' WHERE accountNumber = '" + accountNumber + "'", trans);
            myHKeInvestData.commitTransaction(trans);
        }
    }

}
