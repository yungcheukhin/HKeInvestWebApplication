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
            stocktypePanel.Visible = false;
            bondamountPanel.Visible = false;
        }

        protected void cvStocktype_Validate(object sender, EventArgs e)
        {
            string stocktype = Stype.SelectedValue; 
            
            if (string.Compare(stocktype, "Stock", true)==0){
                stocktypePanel.Visible = true;
            }
            else{
                stocktypePanel.Visible = false;
            }
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
                    utbuyPanel.Visible = true;

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

        }
    }
}