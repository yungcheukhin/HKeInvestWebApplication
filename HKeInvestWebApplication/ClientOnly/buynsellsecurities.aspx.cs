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

namespace HKeInvestWebApplication
{
    public partial class buynsellsecurities : System.Web.UI.Page
    {
        ExternalFunctions myExternalFunctions = new ExternalFunctions();
        HKeInvestCode myHKeInvestCode = new HKeInvestCode();
        HKeInvestData myHKeInvestData = new HKeInvestData();

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

        protected void cvStocktype_Validate(object sender, EventArgs e)
        {
            /*
            string stocktype = Stype.SelectedValue; 
            
            if (string.Compare(stocktype, "Stock", true)==0){
                stocktypePanel.Visible = true;
            }
            else{
                stocktypePanel.Visible = false;
            }
            */
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
                //qofsharesPanel.Visible = true;

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



        protected void totalcheck(object sender, EventArgs s){
            if (Page.IsValid) {
                //ExternalFunctions myExternalFunctions = new ExternalFunctions();
                //HKeInvestData myHKeInvestData = new HKeInvestData();
                //Buy order
                if(string.Compare(opdd.SelectedValue, "Buy", true) == 0)
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
                        string sqll="";
                        string sql2 = "";
                        //INSERT INTO Customers (CustomerName, ContactName, Address, City, PostalCode, Country)
                        //VALUES('Cardinal', 'Tom B. Erichsen', 'Skagen 21', 'Stavanger', '4006', 'Norway');
                        string username = Context.User.Identity.GetUserName();
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
                            SqlTransaction trans = myHKeInvestData.beginTransaction();
                            myHKeInvestData.setData(sqll, trans);
                            myHKeInvestData.setData(sql2, trans);
                            myHKeInvestData.commitTransaction(trans);
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
                            SqlTransaction trans = myHKeInvestData.beginTransaction();
                            myHKeInvestData.setData(sqll, trans);
                            myHKeInvestData.setData(updatetranssql, trans);
                            myHKeInvestData.commitTransaction(trans);
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
                        string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
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
                        if(result!= null)
                        {

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
                        //bond's code and amount
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