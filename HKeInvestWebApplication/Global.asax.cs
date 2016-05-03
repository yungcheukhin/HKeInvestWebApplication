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
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Thread mythread = new Thread(PeriodicTask);
            mythread.IsBackground = true;
            mythread.Start();
        }
        private void PeriodicTask()
        {
            do
            {
                // Place the method call for the periodic task here.
                //if price in external table reach the value set in alert table, send email
                //add a attribute "lastsent" to indicate if today had sent
                //alert high, low save in table
                //foreach compare wilth external
                HKeInvestData myHKeInvestData = new HKeInvestData();
                ExternalFunctions myExternalFunctions = new ExternalFunctions();
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

                    string email = "";
                    string date = "";
                    DataTable searchemail = myHKeInvestData.getData("SELECT email FROM Client WHERE accountNumber='" +id+ "'");
                    foreach(DataRow rows in searchemail.Rows)
                    {
                        email = email + rows["email"];
                    }
                    
                    if (high<=myExternalFunctions.getSecuritiesPrice(type, code)||low>= myExternalFunctions.getSecuritiesPrice(type, code))
                    {
                        /*if (date == null)
                        {
                            SqlTransaction adddate = myHKeInvestData.beginTransaction();
                            myHKeInvestData.setData("INSERT INTO alert (lastsent) VALUE ('" + DateTime.Now.ToString("yyyy-MM-dd") + "')", adddate);
                            myHKeInvestData.commitTransaction(adddate);
                        }
                        else
                        {
                            SqlTransaction updatedate = myHKeInvestData.beginTransaction();
                            myHKeInvestData.setData("UPDATE alert SET lastsent='" + DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE accountNumber='" +id+ "' AND code='" +code+ "' AND type = '" +type+ "'", updatedate);
                            my*/

                        SqlTransaction updatedate = myHKeInvestData.beginTransaction();
                        myHKeInvestData.setData("UPDATE alert SET lastsent='" + DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE accountNumber='" + id + "' AND code='" + code + "' AND type = '" + type + "'", updatedate);
                        myHKeInvestData.commitTransaction(updatedate);

                        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                        mail.To.Add(email);
                        mail.From = new MailAddress("comp3111_team120@cse.ust.hk", "HKeInvest", System.Text.Encoding.UTF8);
                        mail.Subject = "Alert";
                        mail.SubjectEncoding = System.Text.Encoding.UTF8;
                        mail.Body = "Alert testing, high"+high+"low"+low+"current"+ myExternalFunctions.getSecuritiesPrice(type, code)+code+type+current;
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
                Thread.Sleep(10000);
            } while (true);
        }
    }
}