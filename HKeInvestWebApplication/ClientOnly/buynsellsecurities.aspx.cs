using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HKeInvestWebApplication
{
    public partial class buynsellsecurities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            stockt.Visible = false;
        }

        protected void cvStocktype_Validate(object sender, EventArgs e)
        {
            string stocktype = Stype.SelectedValue; 
            
            if (string.Compare(stocktype, "Stock", true)==0)
            {
                stockt.Visible = true;

            }
            else
            {
                stockt.Visible = false;
            }
        }

        protected void stockorder(object sender, EventArgs e)
        {
            string stockorder = stockorderdd.SelectedValue;
            
        }

    }
}