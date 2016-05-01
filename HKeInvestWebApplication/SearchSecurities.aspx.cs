using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HKeInvestWebApplication.Code_File;
using HKeInvestWebApplication.ExternalSystems.Code_File;

namespace HKeInvestWebApplication
{
    public partial class SearchSecurities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /*protected void Stype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = Stype.SelectedValue;
            string code = Scode.Text.Trim();
            string name = Sname.Text.Trim();
            DataTable searchresult;
            ExternalFunctions myExternalFunctions = new ExternalFunctions();
            if (Stype.SelectedValue == "bond")
            {
                if (code != null && name != null)
                {

                }
                else if (code != null && name == null)
                {
                    //getSecuritiesByCode(type, code)
                    searchresult = myExternalFunctions.getSecuritiesByCode(type, code);
                }
                else if (code == null && name != null)
                {
                    searchresult = myExternalFunctions.getSecuritiesByName(type, name);
                }
                else
                {

                }
                bondtable.Visible = true;
            }
            else if (Stype.SelectedValue == "stock")
            {
                stocktable.Visible = true;
            }
            else if (Stype.SelectedValue == "unitTrust")
            {
                unittable.Visible = true;
            }
        }*/
        
        protected void doSearch(object sender, EventArgs e)
        {
            string type = Stype.SelectedValue;
            string code = Scode.Text.Trim();
            string name = Sname.Text.Trim();
            DataTable searchresult;
            ExternalFunctions myExternalFunctions = new ExternalFunctions();
            if (Stype.SelectedValue == "bond")
            {
                stocktable.Visible = false;
                unittable.Visible = false;
                if (code == "" && name == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesData(type);
                    gvBond.DataSource = searchresult;
                    gvBond.DataBind();
                    bondtable.Visible = true;
                }
                else if (name == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesByCode(type, code);
                    gvBond.DataSource = searchresult;
                    gvBond.DataBind();
                    bondtable.Visible = true;
                }
                else if (code == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesByName(type, name);
                    gvBond.DataSource = searchresult;
                    gvBond.DataBind();
                    bondtable.Visible = true;
                }
            }
            else if (Stype.SelectedValue == "stock")
            {
                bondtable.Visible = false;
                unittable.Visible = false;
                if (code == "" && name == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesData(type);
                    gvStock.DataSource = searchresult;
                    gvStock.DataBind();
                    stocktable.Visible = true;
                }
                else if (name == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesByCode(type, code);
                    gvStock.DataSource = searchresult;
                    gvStock.DataBind();
                    stocktable.Visible = true;
                }
                else if (code == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesByName(type, name);
                    gvStock.DataSource = searchresult;
                    gvStock.DataBind();
                    stocktable.Visible = true;
                }
            }
            else if (Stype.SelectedValue == "unit trust")
            {
                bondtable.Visible = false;
                stocktable.Visible = false;
                if (code == "" && name == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesData(type);
                    gvUnitTrust.DataSource = searchresult;
                    gvUnitTrust.DataBind();
                    unittable.Visible = true;
                }
                else if (name == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesByCode(type, code);
                    gvUnitTrust.DataSource = searchresult;
                    gvUnitTrust.DataBind();
                    unittable.Visible = true;
                }
                else if (code == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesByName(type, name);
                    gvUnitTrust.DataSource = searchresult;
                    gvUnitTrust.DataBind();
                    unittable.Visible = true;
                }
            }
            //changed
        }
    }
}