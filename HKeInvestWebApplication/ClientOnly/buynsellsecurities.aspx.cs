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

namespace HKeInvestWebApplication
{
    public partial class buynsellsecurities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //stockt.Visible = false;
            //stocktypePanel.Visible = false;
            //bondamountPanel.Visible = false;
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


        protected void totalcheck(object sender, EventArgs s){
            if (Page.IsValid) {
                ExternalFunctions myExternalFunctions = new ExternalFunctions();
                HKeInvestData myHKeInvestData = new HKeInvestData();
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
                        //Context.User.Identity.GetUserName();
                        string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                        if (cost > (myHKeInvestData.getAggregateValue("select balance FROM Account WHERE userName = '" + username + "'")){
                           // s.IsValid = false;
                           //show error msg
                        }
                        string result = myExternalFunctions.submitStockBuyOrder(stockcode, numofshares, ordertype ,expday, allornone, highp, stopp);
                        
                    }
                    //Buy bond
                    if(string.Compare(Stype.SelectedValue, "bond", true) == 0)
                    {
                        //Bond code and amount
                        string result = myExternalFunctions.submitBondBuyOrder(Scode.Text.Trim(), amtofbond.Text.Trim());
                        //Save in own record
                        //minus balance
                        //
                    }
                    //Buy unitTrust
                    if(string.Compare(Stype.SelectedValue, "unitTrust", true) == 0)
                    {
                        //unit trust's code and amount
                        string result = myExternalFunctions.submitUnitTrustBuyOrder(Scode.Text.Trim(), amtofut.Text.Trim());
                        //save record and minus balance
                        //
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