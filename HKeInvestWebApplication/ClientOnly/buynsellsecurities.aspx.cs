using System;
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
                    expdatePanel.Visible = false;
                    stockbuyPanel.Visible = false;
                    bondamountPanel.Visible = true;
                    utbuyPanel.Visible = false;
                    sellstockPanel.Visible = false;
                    sellbondPanel.Visible = false;
                    sellunitTrust.Visible = false;
                    qofsharesPanel.Visible = false;

                }
                if (string.Compare(Stype.SelectedValue, "unitTrust", true) == 0){
                    expdatePanel.Visible = false;
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

                    sellstockPanel.Visible = false;
                    expdatePanel.Visible = false;
                    utbuyPanel.Visible = false;
                    qofsharesPanel.Visible = false;
                    stockbuyPanel.Visible = false;
                    bondamountPanel.Visible = false;
                    sellunitTrust.Visible = false;

                }
                if (string.Compare(Stype.SelectedValue, "unitTrust", true) == 0){
                    sellunitTrust.Visible = true;
                    utbuyPanel.Visible = false;

                    sellbondPanel.Visible = false;
                    sellstockPanel.Visible = false;
                    expdatePanel.Visible = false;
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

        protected void waitexecutebuy(string sql, decimal cost , string result){

            if (string.Compare("pending", myExternalFunctions.getOrderStatus(result), false) == 0)
            {
                string sql1 = "update";
            }


        }

        protected void showsecuritydetails(string type, string code)
        {
            DataTable security;
            if (String.Compare(type, "unitTrust", true) == 0)
            {
                type = "unit trust";
            }
            security = myExternalFunctions.getSecuritiesByCode(type, code);

        }


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
                //GET ACCOUNT NUMBER
                //GET USERNAME
                accessDataBase myData = new accessDataBase();
                //string username = Context.User.Identity.GetUserName();
                string username = Context.User.Identity.GetUserName();
                string actnum = myData.getOneData("accountNumber", "Account", username);
                string email = myData.getOneData("email", "Client", actnum);
                string balance = myData.getOneData("balance", "Account", username);
                DateTime thisDay = DateTime.Today;
                string date = thisDay.ToString("d");


                //ExternalFunctions myExternalFunctions = new ExternalFunctions();
                //HKeInvestData myHKeInvestData = new HKeInvestData();
                //Buy order
                if (string.Compare(opdd.SelectedValue, "Buy", true) == 0)
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
                        //INSERT INTO Customers (CustomerName, ContactName, Address, City, PostalCode, Country)
                        //VALUES('Cardinal', 'Tom B. Erichsen', 'Skagen 21', 'Stavanger', '4006', 'Norway');
                        if (cost > (myHKeInvestData.getAggregateValue("select balance FROM Account WHERE userName = '" + username + "'"))){
                            error.Text = "Account balance smaller then total amount to buy. Not enough balance. '"+ username + "'";
                            error.Visible = true;
                            return;
                        }
                        string result = myExternalFunctions.submitStockBuyOrder(stockcode, numofshares, ordertype ,expday, allornone, highp, stopp);
                        //minus account balance
                        //update balance, update transactionrecord
                        sqll = "update [Account] set [balance] = [balance] - '" + cost + "' WHERE [userName] = '" + username + "'";
                        sql2 = "update [TransactionRecord] set ";
                        //if (string.Compare("pending", myExternalFunctions.getOrderStatus(result), false) == 0)
                        if(result!= null)
                        {
                            //string sql1 = "update";

                            //BUY STOCK && UPDATE TABLE 
                            SqlTransaction trans = myHKeInvestData.beginTransaction();
                            myHKeInvestData.setData(sqll, trans);
                            myHKeInvestData.setData(sql2, trans);
                            myHKeInvestData.commitTransaction(trans);
                            //generateInvoiceMsg(username, actnum, result, opdd.SelectedValue, stockcode, "===Stock name===", ordertype, date, numofshares, c,  );
                            //generateInvoiceMsg(string user, string actnum, string orderrefnum, 
                            //string buyorsell, string code, string sname, string stocktype, 
                            //string date, string amt, string cost, string transnum, string dateExe, 
                            //string numexe, string price)
                        }

                        return;

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


                    }
                    //Buy bond
                    if (string.Compare(Stype.SelectedValue, "bond", true) == 0)
                    {
                        //Bond code and amount
                        decimal amt = Convert.ToDecimal(amtofbond.Text.Trim());
                        string code = Scode.Text.Trim();
                        decimal curprice = myExternalFunctions.getSecuritiesPrice("bond", code);
                        decimal cost = amt * curprice;
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
                        sqll = "update [Account] set [balance] = [balance] - '" + amt + "' WHERE [userName] = '" + user + "'";
                        updatetranssql = "update [TransactionRecord] set ";
                        if(result!= null)
                        {
                            //KEEP TRANS RECORD IN TABLE 
                            SqlTransaction trans = myHKeInvestData.beginTransaction();
                            myHKeInvestData.setData(sqll, trans);
                            myHKeInvestData.setData(updatetranssql, trans);
                            myHKeInvestData.commitTransaction(trans);
                            //sendemail(user, result, "stock", "5/3/2016", amtofbond.Text.Trim(), c, p);

                        }
                        return;
                        //Save in own record
                        //minus balance
                        //
                    }
                    //Buy unitTrust
                    if(string.Compare(Stype.SelectedValue, "unitTrust", true) == 0)
                    {
                        //unit trust's code and amount
                        decimal amt = Convert.ToDecimal(amtofut.Text.Trim());
                        string code = Scode.Text.Trim();
                        decimal curprice = myExternalFunctions.getSecuritiesPrice("unitTrust", code);
                        decimal cost = amt * curprice;
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
                        //save record and minus balance
                        string sqll= "update[Account] set[balance] = [balance] - '" + amt + "' WHERE[userName] = '" + username + "'";
                        string updatetranssql="";
                        if(result!= null)
                        {
                            SqlTransaction trans = myHKeInvestData.beginTransaction();
                            myHKeInvestData.setData(sqll, trans);
                            myHKeInvestData.setData(updatetranssql, trans);
                            myHKeInvestData.commitTransaction(trans);
                        }
                        return;
                        //
                    }

                }
                //Sell order
                if(String.Compare(opdd.SelectedValue, "Sell", true) == 0)
                {

                    if(string.Compare(Stype.SelectedValue, "bond", true) == 0)
                    {
                        //Check security owns
                        string securityamount = myData.getOneData("securityamount", "SecurityHolding", username);
                        decimal secamount = Convert.ToDecimal(securityamount);
                        decimal sellamount = Convert.ToDecimal(amtofbond.Text.Trim());
                        //bond's code and amount
                        if(secamount < sellamount)
                        {
                            error.Text = username + securityamount + "Security Holding in account less then total amount to sell. Order will not be proceeded.";
                            error.Visible = true;
                            return;
                        }
                        
                        string result = myExternalFunctions.submitBondSellOrder(Scode.Text.Trim(), numofshares.Text.Trim());
                        //
                        //
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
                        string result = myExternalFunctions.submitStockSellOrder(code, shares, orderType, expday, allornone, lowprice, stopPrice);
                    }
                    if (string.Compare(Stype.SelectedValue, "unitTrust", true) == 0)
                    {
                        //unit trust's code, shares
                        string result = myExternalFunctions.submitUnitTrustSellOrder(Scode.Text.Trim(), numofutshares.Text.Trim());
                    }

                }
            }
        }
    }
}