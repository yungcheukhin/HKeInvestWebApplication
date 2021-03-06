﻿using System;
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
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;
using System.Net.Mail;

namespace HKeInvestWebApplication
{
    public class Global : HttpApplication
    {
        HKeInvestData myHKeInvestData = new HKeInvestData();
        ExternalFunctions myExternalFunctions = new ExternalFunctions();
        accessDataBase myData = new accessDataBase();

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Thread mythread = new Thread(PeriodicTask);
            mythread.IsBackground = true;
            mythread.Start();
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


        private void PeriodicTask()
        {
            do
            {
                /*

                 FOR BUY &  SELL PERIODIC TASK

                */
                string status = "";
                string refnum = "";
                decimal fee = 0;
                decimal cost = fee;

                //get datatable where email has not yet sent out //another approach: condition: where status != completed --> still needa checkout
                DataTable statustable = myHKeInvestData.getData("SELECT referenceNumber FROM TransactionRecord WHERE emailsent = 0");
                foreach (DataRow rows in statustable.Rows)
                {
                    //get referencenumber
                    refnum = rows["referenceNumber"].ToString();
                    //for each emailsent=0;
                    status = myExternalFunctions.getOrderStatus(refnum);
                    //if status is completed
                    if (String.Compare(status, "completed", true) == 0)
                    {
                        decimal accountNumber = myHKeInvestData.getAggregateValue("SELECT accountNumber FROM TransactionRecord WHERE referenceNumber = refnum");
                        string actnum = accountNumber.ToString();
                        string buyorsell = myData.getOneDatabyNO("buyOrSell", "TransactionRecord", actnum);
                        string date = DateTime.Now.ToString("yyyy-MM-dd");
                        decimal shares = myHKeInvestData.getAggregateValue("SELECT shares FROM TransactionRecord WHERE referenceNumber = refnum");
                        string strshares = shares.ToString();
                        string code = myData.getOneDatabyNO("securityCode", "TransactionRecord", actnum);
                        string username = myData.getOneDatabyNO("userName", "TransactionRecord", actnum);
                        decimal pricepshare = myHKeInvestData.getAggregateValue("SELECT executePrice FROM TransactionRecord WHERE referenceNumber = refnum");
                        string type = myData.getOneDatabyNO("securityType", "TransactionRecord", actnum);
                        string sname = myData.getOneDatabyNO("name", "TransactionRecord", actnum);
                        string sbase = myData.getOneDatabyNO("base", "TransactionRecord", actnum);
                        cost = shares * pricepshare;
                        string strcost = cost.ToString();
                        //get order transaction                      
                        DataTable ordertrans = myExternalFunctions.getOrderTransaction(refnum);
                        string exedate = "";
                        string exeshares = "";
                        string exeprice = "";
                        string transnum = "";
                        //string executeDate = "";
                        //string executeShares = "";

                        // DataTable temp = myHKeInvestData.getData("SELECT executeDate FROM ordertrans WHERE transactionNumber = '" + refnum + "'");
                        foreach (DataRow row in ordertrans.Rows)
                        {
                            transnum = row["transactionNumber"].ToString();
                            exedate = row["executeDate"].ToString();
                            exeshares = row["executeShares"].ToString();
                            exeprice = row["executePrice"].ToString();
                        }

                        //calcaulta transaction fee
                        fee = 0;
                        //modify account balance
                        SqlTransaction trans = myHKeInvestData.beginTransaction();
                        //set acct balance
                        myHKeInvestData.setData("UPDATE Account SET balance = (balance - '" + cost + "'-'" + fee + "' WHERE accountNumber = '" + accountNumber + "'", trans);
                        //set email sent =1
                        myHKeInvestData.setData("UPDATE TransactionRecord SET emailsent = 1  WHERE accountNumber ='" + accountNumber + "'", trans);
                        //update TransactionRecord to match the order status the rest of records
                        myHKeInvestData.setData("UPDATE TransactionRecord SET status = completed", trans);
                        myHKeInvestData.setData("UPDATE TransactionRecord SET transactionNumber ='" + transnum + "' WHERE accountNumber ='" + accountNumber + "'", trans);
                        myHKeInvestData.setData("UPDATE TransactionRecord SET executeDate ='" + exedate + "' WHERE accountNumber ='" + accountNumber + "'", trans);
                        myHKeInvestData.setData("UPDATE TransactionRecord SET executePrice ='" + exeprice + "' WHERE accountNumber ='" + accountNumber + "'", trans);
                        myHKeInvestData.setData("UPDATE TransactionRecord SET executeShares ='" + exeshares + "' WHERE accountNumber ='" + accountNumber + "'", trans);
                        myHKeInvestData.commitTransaction(trans);
                        //update security holding

                        SqlTransaction addsecurity = myHKeInvestData.beginTransaction();
                        //check if same bond n code exist
                        DataTable check = myHKeInvestData.getData("SELECT accountNumber, type, code FROM SecurityHolding WHERE accountNumber = '" + actnum + "'");
                        foreach (DataRow row in check.Rows)
                        {
                            string checktype = row["type"].ToString();
                            if (String.Compare(checktype, type, true) == 0)
                            {
                                if (String.Compare(row["code"].ToString(), code, true) == 0)
                                {
                                    if (String.Compare(buyorsell, "buy", true) == 0)
                                    {
                                        myHKeInvestData.setData("UPDATE SecurityHolding SET shares = shares + '" + shares + "' WHERE accountNumber = '" + actnum + "' AND type = '" + type + "' AND code = '" + code + "'", addsecurity);
                                    }
                                    else if (String.Compare(buyorsell, "sell", true) == 0)
                                    {
                                        myHKeInvestData.setData("UPDATE SecurityHolding SET shares = shares - '" + shares + "' WHERE accountNumber = '" + actnum + "' AND type = '" + type + "' AND code = '" + code + "'", addsecurity);
                                    }
                                }
                                else
                                {
                                    myHKeInvestData.setData("INSERT INTO SecurityHolding (accountNumber, type, code, name, shares, base) VALUES ('" + accountNumber + "','" + type + "','" + sname + "','" + strshares + "','" + sbase + "')'", addsecurity);
                                }
                            }
                            else
                            {
                                myHKeInvestData.setData("INSERT INTO SecurityHolding (accountNumber, type, code, name, shares, base) VALUES ('" + accountNumber + "','" + type + "','" + sname + "','" + strshares + "','" + sbase + "')'", addsecurity);
                            }
                        }
                        //myHKeInvestData.setData("INSERT INTO SecurityHolding (accountNumber, type, code, name, shares, base) VALUES ('" + accountNumber + "','" + type + "','" + sname + "','" + strshares + "','" + sbase + "')'", addsecurity);
                        myHKeInvestData.commitTransaction(addsecurity);
                        //myHKeInvestData.setData("UPDATE Account SET balance = (balance - cost) + value +"' WHERE accountNumber = '" + AccountNumber + "'", trans);

                        //gen invoice
                        // protected string generateInvoiceMsg(string user, string actnum, string orderrefnum, string buyorsell, string code, 
                        //string sname, string stocktype, string date, string amt, string cost, 
                        //string transnum, string dateExe, string numexe, string price)
                        string msg = generateInvoiceMsg(username, actnum, refnum, buyorsell, code, sname, type, date, strshares, strcost, refnum, exedate, exeshares, exeprice);
                        //send email
                        sendemail(username, msg);

                        //Update email flag
                        SqlTransaction emailflag = myHKeInvestData.beginTransaction();
                        myHKeInvestData.setData("UPDATE TransactionRecord SET emailsent = 1 WHERE accountNumber ='" + accountNumber + "'", emailflag);
                        myHKeInvestData.commitTransaction(emailflag);

                    }

                    //check if email sent

                }
                /*

                END OF PERIODIC TASK OF BUY & SELL

                */


                // Place the method call for the periodic task here.
                //if price in external table reach the value set in alert table, send email
                //add a attribute "lastsent" to indicate if today had sent
                //alert high, low save in table
                //foreach compare wilth external
                //HKeInvestData myHKeInvestData = new HKeInvestData();
                //ExternalFunctions myExternalFunctions = new ExternalFunctions();
                DataTable alerts = myHKeInvestData.getData("SELECT * FROM Alert");
                foreach (DataRow row in alerts.Rows)
                {
                    string id = "" + row["accountNumber"];
                    string type = "" + row["type"].ToString().Trim();
                    string code = "" + row["code"].ToString().Trim();
                    //string high = "" + row["high"];
                    decimal high = System.Convert.ToDecimal(row["highValue"]);
                    decimal low = System.Convert.ToDecimal(row["lowValue"]);
                    decimal current = myExternalFunctions.getSecuritiesPrice(type, code);

                    string date = "";
                    DataTable searchdate = myHKeInvestData.getData("SELECT lastsent FROM Alert WHERE accountNumber='" + id + "' AND code='" + code + "' AND type = '" + type + "'");
                    foreach (DataRow rows in searchdate.Rows)
                    {
                        date = date + rows["lastsent"];
                    }
                    if (date == DateTime.Now.ToString("yyyy-MM-dd"))
                    { }
                    else
                    {
                        string email = "";
                        DataTable searchemail = myHKeInvestData.getData("SELECT email FROM Client WHERE accountNumber='" + id + "'");
                        foreach (DataRow rows in searchemail.Rows)
                        {
                            email = email + rows["email"];
                        }
                        string name = "";
                        DataTable security = myExternalFunctions.getSecuritiesByCode(type, code);
                        foreach (DataRow rows in security.Rows)
                        {
                            name = name + rows["name"];
                        }

                        if (high <= myExternalFunctions.getSecuritiesPrice(type, code))
                        {
                            SqlTransaction updatedate = myHKeInvestData.beginTransaction();
                            myHKeInvestData.setData("UPDATE alert SET lastsent='" + DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE accountNumber='" + id + "' AND code='" + code + "' AND type = '" + type + "'", updatedate);
                            myHKeInvestData.commitTransaction(updatedate);

                            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                            mail.To.Add(email);
                            mail.From = new MailAddress("comp3111_team120@cse.ust.hk", "HKeInvest", System.Text.Encoding.UTF8);
                            mail.Subject = "Alert Triggered!";
                            mail.SubjectEncoding = System.Text.Encoding.UTF8;
                            mail.Body = "The high value alert for your " + type + " security, code: " + code + " name: " + name + " had been triggered. The current price of the security is " + current + ". The high alert value you set is " + high + ".";
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
                        else if (low >= myExternalFunctions.getSecuritiesPrice(type, code))
                        {
                            SqlTransaction updatedate = myHKeInvestData.beginTransaction();
                            myHKeInvestData.setData("UPDATE alert SET lastsent='" + DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE accountNumber='" + id + "' AND code='" + code + "' AND type = '" + type + "'", updatedate);
                            myHKeInvestData.commitTransaction(updatedate);

                            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                            mail.To.Add(email);
                            mail.From = new MailAddress("comp3111_team120@cse.ust.hk", "HKeInvest", System.Text.Encoding.UTF8);
                            mail.Subject = "Alert Triggered!";
                            mail.SubjectEncoding = System.Text.Encoding.UTF8;
                            mail.Body = "The low value alert for your " + type + " security, code: " + code + " name: " + name + " had been triggered. The current price of the security is " + current + ". The low alert value you set is " + low + ".";
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
                    }
                }
                Thread.Sleep(10000);
            } while (true);
        }
    }
}