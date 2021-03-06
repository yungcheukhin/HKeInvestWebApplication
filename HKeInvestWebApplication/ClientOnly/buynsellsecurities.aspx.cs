﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using HKeInvestWebApplication.Code_File;
using HKeInvestWebApplication.ExternalSystems.Code_File;
using Microsoft.AspNet.Identity;
using System.Net.Mail;

namespace HKeInvestWebApplication
{
    public partial class buynsellsecurities : System.Web.UI.Page
    {
        ExternalFunctions myExternalFunctions = new ExternalFunctions();
        HKeInvestCode myHKeInvestCode = new HKeInvestCode();
        HKeInvestData myHKeInvestData = new HKeInvestData();
        accessDataBase myData = new accessDataBase();

        protected void Page_Load(object sender, EventArgs e)
        {
            error.Visible = false;
            qofsharesPanel.Visible = false;
            stockbuyPanel.Visible = false;
            expdatePanel.Visible = false;
            bondamountPanel.Visible = false;
            utbuyPanel.Visible = false;
            sellstockPanel.Visible = false;
            sellbondPanel.Visible = false;
            sellunitTrust.Visible = false;
        }

        //unuseful function
        protected void stockorder(object sender, EventArgs e)
        {
            string stockorder = stockorderdd.SelectedValue;

            
        }

        protected void buysellcheck(object sender, EventArgs e){
            string operation = opdd.SelectedValue;
            //string type = Stype.SelectedValue;
            if(string.Compare(opdd.SelectedValue, "Buy", true) == 0){
                if(string.Compare(Stype.SelectedValue, "stock", true) == 0){
                    qofsharesPanel.Visible = true;
                    stockbuyPanel.Visible = true;
                    expdatePanel.Visible = true;
                    bondamountPanel.Visible = false;
                    utbuyPanel.Visible = false;
                    sellstockPanel.Visible = false;
                    sellbondPanel.Visible = false;
                    sellunitTrust.Visible = false;

                }
                if (string.Compare(Stype.SelectedValue, "bond", true) == 0){
                    expdatePanel.Visible = true;
                    stockbuyPanel.Visible = false;
                    bondamountPanel.Visible = true;
                    utbuyPanel.Visible = false;
                    sellstockPanel.Visible = false;
                    sellbondPanel.Visible = false;
                    sellunitTrust.Visible = false;
                    qofsharesPanel.Visible = false;

                }
                if (string.Compare(Stype.SelectedValue, "unitTrust", true) == 0){
                    expdatePanel.Visible = true;
                    utbuyPanel.Visible = true;
                    qofsharesPanel.Visible = false;
                    stockbuyPanel.Visible = false;
                    bondamountPanel.Visible = false;
                    sellstockPanel.Visible = false;
                    sellbondPanel.Visible = false;
                    sellunitTrust.Visible = false;

                }

            }
           if (string.Compare(opdd.SelectedValue, "Sell", true)==0){
                if(string.Compare(Stype.SelectedValue, "stock", true) == 0){
                    expdatePanel.Visible = true;
                    sellstockPanel.Visible = true; 

                    sellbondPanel.Visible = false;
                    utbuyPanel.Visible = false;
                    qofsharesPanel.Visible = false;
                    stockbuyPanel.Visible = false;
                    bondamountPanel.Visible = false;
                    sellunitTrust.Visible = false;
                }
                if (string.Compare(Stype.SelectedValue, "bond", true) == 0){
                    sellbondPanel.Visible = true;
                    expdatePanel.Visible = true;

                    sellstockPanel.Visible = false;
                    //expdatePanel.Visible = false;
                    utbuyPanel.Visible = false;
                    qofsharesPanel.Visible = false;
                    stockbuyPanel.Visible = false;
                    bondamountPanel.Visible = false;
                    sellunitTrust.Visible = false;

                }
                if (string.Compare(Stype.SelectedValue, "unitTrust", true) == 0){
                    sellunitTrust.Visible = true;
                    utbuyPanel.Visible = false;
                    expdatePanel.Visible = true;

                    sellbondPanel.Visible = false;
                    sellstockPanel.Visible = false;
                    //expdatePanel.Visible = ;
                    qofsharesPanel.Visible = false;
                    stockbuyPanel.Visible = false;
                    bondamountPanel.Visible = false;

                }
            }
        }

        protected void buy(string sql)
        {
            SqlTransaction trans = myHKeInvestData.beginTransaction();
            myHKeInvestData.setData(sql, trans);
            myHKeInvestData.commitTransaction(trans);

        }

            /*
private string submitOrder(string sql)
{
    SqlTransaction trans = myExternalData.beginTransaction();
    myExternalData.setData(sql, trans);
    string referenceNumber = myExternalData.getOrderReferenceNumber("select max([referenceNumber]) from [Order]", trans);
    myExternalData.commitTransaction(trans);
    return referenceNumber;
}

            */




        //Generate Invoice Msg
        protected string generateInvoiceMsg(string user, string actnum, string orderrefnum, string buyorsell, string code, string sname, string stocktype, string date, string amt, string cost, string transnum, string dateExe, string numexe, string price)
        {
            string head = "Dear " + user + ",\n";
            string body1 = "Invoice: \n";
            string body2 = "Order Details: \nAccount number number:" + actnum + "\n Order reference number: " + orderrefnum + "\nBuy or sell:" + buyorsell + "\nSecurity Code: " + code + "\nSecurity Name:" + sname + "\nStock Type:" + stocktype + "\nDate of Order Submitted: " + date + "\nNumber of Shares Traded: " + amt + "\n\nTotal amount executed (HKD): " + cost + "\nTransaction Number: " + transnum + "\nDate Executed: " + dateExe + "\nNumberof Shares Executed: " + numexe + "\nPrice per Share: " + price + "\n\n";
            string end = "\nBest Regards, \nHong Kong Electronic Investments LLC";
            string message = head + body1 + body2 + end;
            return message;
        }


        //Send email
        protected void sendemail(string user, string msg)
        {
            //accessDataBase myData = new accessDataBase();
            //string username = Context.User.Identity.GetUserName();
            string actnum = myData.getOneData("accountNumber", "Account", user);
            string email = myData.getOneData("email", "Client", actnum);
            /*
            DataTable searchemail = myHKeInvestData.getData("SELECT email FROM Client WHERE accountNumber='" + actnum + "'");
            foreach (DataRow rows in searchemail.Rows)
            {
                email = email + rows["email"];
            }
            */
            string name = "";
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("comp3111_team120@cse.ust.hk", "HKeInvest", System.Text.Encoding.UTF8);
            mail.Subject = "Invoice";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = msg;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("comp3111_team120", "team120#");
            client.Port = 587;
            client.Host = "smtp.cse.ust.hk";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
                //Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                //Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
        }


        //The proceed button
        protected void totalcheck(object sender, EventArgs s){
            if (Page.IsValid) {
                //GET BASIC DETAILS
                accessDataBase myData = new accessDataBase();
                //string username = Context.User.Identity.GetUserName();
                string username = Context.User.Identity.GetUserName();
                string actnum = myData.getOneData("accountNumber", "Account", username);
                string email = myData.getOneData("email", "Client", actnum);
                string balance = myData.getOneData("balance", "Account", username);
                DateTime thisDay = DateTime.Today;
                string date = thisDay.ToString("d");

                //Buy order
                if (string.Compare(opdd.SelectedValue, "buy", true) == 0)
                {
                    //Buy Stock
                    if(string.Compare(Stype.SelectedValue, "stock", true) == 0)
                    {
                        //Get data from text boxes
                        //anInteger = Convert.ToInt32(textBox1.Text);
                        string stockcode = Scode.Text.Trim();
                        string numofshares = qofshares.Text.Trim();
                        int numshares = Convert.ToInt32(qofshares.Text.Trim());
                        decimal curprice = myExternalFunctions.getSecuritiesPrice("stock", stockcode);
                        string expday = expdate.SelectedValue;
                        string highp = highPrice.Text.Trim();
                        string stopp = stopPrice.Text.Trim();
                        string ordertype = stockorderdd.SelectedValue;
                        string allornone = allornonecheck.SelectedValue;
                        decimal cost = numshares * curprice;
                        string c = Convert.ToString(cost);
                        string p = Convert.ToString(curprice);
                        string sqll="";
                        string sql2 = "";

                        if (cost > (myHKeInvestData.getAggregateValue("select balance FROM Account WHERE userName = '" + username + "'"))){
                            error.Text = "Account balance smaller then total amount to buy. Not enough balance. '"+ username + "'";
                            error.Visible = true;
                            return;
                        }
                        string result = myExternalFunctions.submitStockBuyOrder(stockcode, numofshares, ordertype ,expday, allornone, highp, stopp);
                        //update balance, update transactionrecord
                        sqll = "update [Account] set [balance] = [balance] - '" + cost + "' WHERE [userName] = '" + username + "'";
                        sql2 = "update [TransactionRecord] set ";

                        //CHECK STATUS
                        string status = myExternalFunctions.getOrderStatus(result);

                        //if (String.Compare(status, "completed", true)==0)
                        //{
                        //    //BUY STOCK && UPDATE TABLE 
                        //    SqlTransaction trans = myHKeInvestData.beginTransaction();
                        //    myHKeInvestData.setData(sqll, trans);
                        //    myHKeInvestData.setData(sql2, trans);
                        //    myHKeInvestData.commitTransaction(trans);
                        //}
                        return;
                    }

                    //Buy bond
                    if (string.Compare(Stype.SelectedValue, "bond", true) == 0)
                    {
                        //Bond code and amount
                        decimal amt = Convert.ToDecimal(amtofbond.Text.Trim());
                        string code = Scode.Text.Trim();
                        string sname = "";
                        DataTable checkname = myExternalFunctions.getSecuritiesByCode("bond", code);
                        foreach (DataRow row in checkname.Rows)
                        {
                            sname = row["name"].ToString();
                        }
                        decimal curprice = myExternalFunctions.getSecuritiesPrice("bond", code);
                        decimal cost = amt * curprice;
                        string strcost = cost.ToString();
                        //string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                        string user = Context.User.Identity.GetUserName();
                        string sqll;
                        string updatetranssql = "";
                        if (amt > (myHKeInvestData.getAggregateValue("select balance FROM Account WHERE userName = '" + user + "'")))
                        {
                            error.Text = "Account balance smaller then total amount to buy. Not enough balance.";
                            error.Visible = true;
                            return;
                        }
                        string result = myExternalFunctions.submitBondBuyOrder(Scode.Text.Trim(), amtofbond.Text.Trim());

                        //Check Record
                        string status = myExternalFunctions.getOrderStatus(result);

                        if (result != null)
                        {
                            //save record in transactionRecord
                            SqlTransaction saverecord = myHKeInvestData.beginTransaction();
                            myHKeInvestData.setData("INSERT INTO TransactionRecord (accountNumber, transactionNumber, referenceNumber, userName, emailsent, buyOrSell, securityType, securityCode, name, shares, amount, base, dateSubmitted) VALUES ('" + actnum + "',' "+ result + "', '" + status + "', '" + username + "', 0 , 'buy', 'bond', '" + code + "', '" + sname + "', '" + amtofbond.Text.Trim() + "', '" + strcost + "',  'HKD',  '" +  date + "')'", saverecord);
                            myHKeInvestData.commitTransaction(saverecord);
                            error.Text = "Order successfully submitted. Order reference no:" + result + "Confirmation email will be sent to you when order is completed";
                            error.Visible = true;
                            return;
                        }
                        else
                        {
                            error.Text = "Errors occured. Order not submitted";
                            error.Visible = true;
                            return;
                        }

                        return;
                    }
                        ////Check if order completed
                        //if(String.Compare(status, "completed", true) == 0)
                        //{
                        //    //Get Order Transactions
                        //    DataTable Transactions = myExternalFunctions.getOrderTransaction(result);


                        //    //Save record
                        //    SqlTransaction updatedate = myHKeInvestData.beginTransaction();
                        //    myHKeInvestData.setData("UPDATE TransactionRecord SET dateSubmitted='" + DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE accountNumber='" + actnum + "' AND securityCode='" + code + "' AND securityType = '" + "bond" + "' AND buyOrSell = buy AND status = completed AND executeDate ='" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND executeShares = '" + amt + "'AND executePrice ='", updatedate);
                        //    myHKeInvestData.commitTransaction(updatedate);
                        //    //Generate invoice
                        //}

                        //Save order in record
                        //if (result != null)
                        //{
                        //    //Order 
                        //}
                        //sqll = "update [Account] set [balance] = [balance] - '" + amt + "' WHERE [userName] = '" + user + "'";
                        //updatetranssql = "update [TransactionRecord] set ";
                        //if(result!= null)
                        //{
                        //    //KEEP TRANS RECORD IN TABLE 
                        //    SqlTransaction trans = myHKeInvestData.beginTransaction();
                        //    myHKeInvestData.setData(sqll, trans);
                        //    myHKeInvestData.setData(updatetranssql, trans);
                        //    myHKeInvestData.commitTransaction(trans);
                        //}
                        //return;
                        //Save in own record

                    
                    //Buy unitTrust
                    if(string.Compare(Stype.SelectedValue, "unitTrust", true) == 0)
                    {
                        //unit trust's code and amount
                        decimal amt = Convert.ToDecimal(amtofut.Text.Trim());
                        string code = Scode.Text.Trim();
                        string sname = "";
                        DataTable checkname = myExternalFunctions.getSecuritiesByCode("unit", code);
                        foreach (DataRow row in checkname.Rows)
                        {
                            sname = row["name"].ToString();
                        }
                        decimal curprice = myExternalFunctions.getSecuritiesPrice("unit trust", code);
                        decimal cost = amt * curprice;
                        string strcost = cost.ToString();
                        //string username = Context.User.Identity.GetUserName();
                        decimal bal = myHKeInvestData.getAggregateValue("select [balance] FROM [Account] WHERE [userName] = '" + username + "'");
                        if (amt > (myHKeInvestData.getAggregateValue("select [balance] FROM [Account] WHERE [userName] = '" + username + "'")))
                        {
                            error.Text = username + bal + "Account balance smaller then total amount to buy. Not enough balance.";
                            error.Visible = true;
                            return;
                        }
                        else
                        {
                            error.Text = username + bal + "Proceed";
                            error.Visible = true;
                        }
                        string result = myExternalFunctions.submitUnitTrustBuyOrder(Scode.Text.Trim(), amtofut.Text.Trim());

                        string status = myExternalFunctions.getOrderStatus(result);

                        if (result != null)
                        {
                            //save record in transactionRecord
                            SqlTransaction saverecord = myHKeInvestData.beginTransaction();
                            myHKeInvestData.setData("INSERT INTO TransactionRecord (accountNumber, transactionNumber, referenceNumber, userName, emailsent, buyOrSell, securityType, securityCode, name, shares, amount, base, dateSubmitted) VALUES ('" + actnum + "',' " + result + "', '" + status + "', '" + username + "', 0 , 'buy', 'unit trust', '" + code + "', '" + sname + "', '" + amtofut.Text.Trim() + "', '" + strcost + "',  'HKD',  '" + date + "')'", saverecord);
                            myHKeInvestData.commitTransaction(saverecord);
                            error.Text = "Order successfully submitted. Order reference no:" + result + "Confirmation email will be sent to you when order is completed";
                            error.Visible = true;
                            return;
                        }
                        else
                        {
                            error.Text = "Errors occured. Order not submitted";
                            error.Visible = true;
                            return;
                        }

                        return;
                        //ham chut lai
                    }

                }
                //Sell order
                if(String.Compare(opdd.SelectedValue, "sell", true) == 0)
                {

                    if(string.Compare(Stype.SelectedValue, "bond", true) == 0)
                    {
                        //Check security owns
                        string bondcode = Scode.Text.Trim();
                        string sname = "";
                        string sbase = "";
                        DataTable checkname = myExternalFunctions.getSecuritiesByCode("bond", bondcode);
                        foreach (DataRow row in checkname.Rows)
                        {
                            sname = row["name"].ToString();
                            sbase = row["base"].ToString();
                        }
                        string searchshares = "SELECT [shares] FROM [SecurityHolding] WHERE [accountNumber] = '" + actnum + "' AND [type] = '" + Stype.SelectedValue + "' AND [code] = '" + bondcode + "'";
                        decimal secamount = myHKeInvestData.getAggregateValue(searchshares);
                        string strsecamt = secamount.ToString();
                        //decimal secamount = Convert.ToDecimal(searchshares);
                        decimal sellamount = Convert.ToDecimal(numofshares.Text.Trim());
                        string amt = numofshares.Text.Trim();

                        //CHECK IF HAVE SECURITY && AMOUNT
                        if (secamount == 0 )
                        {
                            error.Text = "Selected security not in account or amount equal to zero. Order will not be proceeded.";
                            error.Visible = true;
                            return;
                        }
                        
                        //CHECK SECURITY AMONT
                        if(secamount < sellamount)
                        {
                            error.Text = username + "Securities in Account less than securities to sell. Order will not be proceeded.";
                            error.Visible = true;
                            return;
                        }
                        
                        string result = myExternalFunctions.submitBondSellOrder(Scode.Text.Trim(), numofshares.Text.Trim());

                        string status = myExternalFunctions.getOrderStatus(result);

                        if (result != null)
                        {
                            //save record in transactionRecord
                            SqlTransaction saverecord = myHKeInvestData.beginTransaction();
                            myHKeInvestData.setData("INSERT INTO TransactionRecord (accountNumber, transactionNumber, referenceNumber, userName, emailsent, buyOrSell, securityType, securityCode, name, shares, amount, base, dateSubmitted) VALUES ('" + actnum + "',' " + result + "', '" + status + "', '" + username + "', 0 , 'sell', 'bond', '" + bondcode + "', '" + sname + "', '" + strsecamt + "', '" + amt + "',  '" + sbase + "',  '" + date + "')'", saverecord);
                            myHKeInvestData.commitTransaction(saverecord);
                            error.Text = "Order successfully submitted. Order reference no:" + result + "Confirmation email will be sent to you when order is completed";
                            error.Visible = true;
                            return;
                        }
                        else
                        {
                            error.Text = "Errors occured. Order not submitted";
                            error.Visible = true;
                            return;
                        }
                    }
                    if(string.Compare(Stype.SelectedValue, "stock", true) == 0)
                    {
                        //stock's code, shares, orderType, expiryday, allornone, lowprice, stopPrice
                        string code = Scode.Text.Trim();
                        string shares = numofsellshares.Text.Trim();
                        string orderType = stockorderdd.SelectedValue;
                        string expday = expdate.SelectedValue;
                        string allornone = sellallornonecheck.SelectedValue;
                        string lowprice = lowPrice.Text.Trim();
                        string stopPrice = sellstopPrice.Text.Trim();

                        string searchshares = "SELECT shares FROM SecurityHolding WHERE accountNumber = '" + actnum + "' AND type = '" + "stock" + "' AND code = '" + code + "'";
                        decimal secamount = myHKeInvestData.getAggregateValue(searchshares);
                        decimal sellamount = Convert.ToDecimal(sellstockamt.Text.Trim());

                        //CHECK IF SECURITY EXIST
                        if(secamount == 0)
                        {
                            error.Text = "Selected security not in account or amount equal to zero. Order will not be proceeded.";
                            error.Visible = true;
                            return;
                        }

                        //CHECK SECURITY AMONT
                        if (secamount < sellamount)
                        {
                            error.Text = "Securities in Account less than securities to sell. Order will not be proceeded.";
                            error.Visible = true;
                            return;
                        }
                        string result = myExternalFunctions.submitStockSellOrder(code, shares, orderType, expday, allornone, lowprice, stopPrice);

                    }
                    if (string.Compare(Stype.SelectedValue, "unitTrust", true) == 0)
                    {
                        //unit trust's code, shares
                        string utcode = Scode.Text.Trim();
                        string sname = "";
                        string sbase = "";
                        DataTable checkname = myExternalFunctions.getSecuritiesByCode("bond", utcode);
                        foreach (DataRow row in checkname.Rows)
                        {
                            sname = row["name"].ToString();
                            sbase = row["base"].ToString();
                        }
                        string searchshares = "SELECT shares FROM SecurityHolding WHERE accountNumber = '" + actnum + "' AND type = '" + "unit trust" + "' AND code = '" + utcode + "'";

                        decimal secamount = myHKeInvestData.getAggregateValue(searchshares);
                        string stramt = secamount.ToString();
                        decimal sellamount = Convert.ToDecimal(numofutshares.Text.Trim());
                        string numofshares = numofutshares.Text.Trim();


                        //CHECK IF SECURITY EXIST
                        if (secamount == 0)
                        {
                            error.Text = "Selected security not in account or amount equal to zero. Order will not be proceeded.";
                            error.Visible = true;
                            return;
                        }

                        //CHECK SECURITY AMONT
                        if (secamount < sellamount)
                        {
                            //gfhgfhgfhg
                            error.Text = "Securities in Account less than securities to sell. Order will not be proceeded.";
                            error.Visible = true;
                            return;
                        }
                        //sdfsdf

                        string result = myExternalFunctions.submitUnitTrustSellOrder(Scode.Text.Trim(), numofutshares.Text.Trim());

                        string status = myExternalFunctions.getOrderStatus(result);

                        if (result != null)
                        {
                            //save record in transactionRecord
                            SqlTransaction saverecord = myHKeInvestData.beginTransaction();
                            myHKeInvestData.setData("INSERT INTO TransactionRecord (accountNumber, transactionNumber, referenceNumber, userName, emailsent, buyOrSell, securityType, securityCode, name, shares, amount, base, dateSubmitted) VALUES ('" + actnum + "',' " + result + "', '" + status + "', '" + username + "', 0 , 'sell', 'unit trust', '" + utcode + "', '" + sname + "', '" + numofshares + "', '" + stramt + "',  '" + sbase + "',  '" + date + "')'", saverecord);
                            myHKeInvestData.commitTransaction(saverecord);
                            error.Text = "Order successfully submitted. Order reference no:" + result + "Confirmation email will be sent to you when order is completed";
                            error.Visible = true;
                            return;
                        }
                        else
                        {
                            error.Text = "Errors occured. Order not submitted";
                            error.Visible = true;
                            return;
                        }
                    }

                }
            }
        }
    }
}