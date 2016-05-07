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
        HKeInvestCode myHKeInvestCode = new HKeInvestCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            bondtable.Visible = false;
            stocktable.Visible = false;
            unittable.Visible = false;
            lblerror.Visible = false;
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
                //jhbjhb
                if (code == "" && name == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesData(type);
                    if (searchresult == null)
                    {
                        lblerror.Text = "No machted security is found.";
                        lblerror.Visible = true;
                    }
                    else
                    {
                        ViewState["SortExpression"] = "name";
                        ViewState["SortDirection"] = "ASC";
                        gvBond.DataSource = searchresult;
                        gvBond.DataBind();
                        bondtable.Visible = true;
                    }
                }
                else if (name == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesByCode(type, code);
                    if(searchresult == null)
                    {
                        lblerror.Text = "No machted security is found.";
                        lblerror.Visible = true;
                    }
                    else
                    {
                        ViewState["SortExpression"] = "name";
                        ViewState["SortDirection"] = "ASC";
                        gvBond.DataSource = searchresult;
                        gvBond.DataBind();
                        bondtable.Visible = true;
                    }
                }
                else if (code == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesByName(type, name);
                    if (searchresult == null)
                    {
                        lblerror.Text = "No machted security is found.";
                        lblerror.Visible = true;
                    }
                    else
                    {
                        ViewState["SortExpression"] = "name";
                        ViewState["SortDirection"] = "ASC";
                        gvBond.DataSource = searchresult;
                        gvBond.DataBind();
                        bondtable.Visible = true;
                    }
                }
                else
                {
                    lblerror.Text = "Either one of security code or security name is allowed to input.";
                    lblerror.Visible = true;
                }
            }
            else if (Stype.SelectedValue == "stock")
            {
                bondtable.Visible = false;
                unittable.Visible = false;
                if (code == "" && name == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesData(type);
                    if (searchresult == null)
                    {
                        lblerror.Text = "No machted security is found.";
                        lblerror.Visible = true;
                    }
                    else
                    {
                        gvStock.DataSource = searchresult;
                        gvStock.DataBind();
                        stocktable.Visible = true;
                    }
                }
                else if (name == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesByCode(type, code);
                    if (searchresult == null)
                    {
                        lblerror.Text = "No machted security is found.";
                        lblerror.Visible = true;
                    }
                    else
                    {
                        gvStock.DataSource = searchresult;
                        gvStock.DataBind();
                        stocktable.Visible = true;
                    }
                }
                else if (code == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesByName(type, name);
                    if (searchresult == null)
                    {
                        lblerror.Text = "No machted security is found.";
                        lblerror.Visible = true;
                    }
                    else
                    {
                        gvStock.DataSource = searchresult;
                        gvStock.DataBind();
                        stocktable.Visible = true;
                    }
                }
                else
                {
                    lblerror.Text = "Either one of security code or security name is allowed to input.";
                    lblerror.Visible = true;
                }
            }
            else if (Stype.SelectedValue == "unit trust")
            {
                bondtable.Visible = false;
                stocktable.Visible = false;
                if (code == "" && name == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesData(type);
                    if (searchresult == null)
                    {
                        lblerror.Text = "No machted security is found.";
                        lblerror.Visible = true;
                    }
                    else
                    {
                        gvUnitTrust.DataSource = searchresult;
                        gvUnitTrust.DataBind();
                        unittable.Visible = true;
                    }
                }
                else if (name == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesByCode(type, code);
                    if (searchresult == null)
                    {
                        lblerror.Text = "No machted security is found.";
                        lblerror.Visible = true;
                    }
                    else
                    {
                        gvUnitTrust.DataSource = searchresult;
                        gvUnitTrust.DataBind();
                        unittable.Visible = true;
                    }
                }
                else if (code == "")
                {
                    searchresult = myExternalFunctions.getSecuritiesByName(type, name);
                    if (searchresult == null)
                    {
                        lblerror.Text = "No machted security is found.";
                        lblerror.Visible = true;
                    }
                    else
                    {
                        gvUnitTrust.DataSource = searchresult;
                        gvUnitTrust.DataBind();
                        unittable.Visible = true;
                    }
                }
                else
                {
                    lblerror.Text = "Either one of security code or security name is allowed to input.";
                    lblerror.Visible = true;
                }
            }
        }

        /*protected void gvSecurityHolding_Sorting(object sender, GridViewSortEventArgs e)
        {
            // Since a GridView cannot be sorted directly, it is first loaded into a DataTable using the helper method 'unloadGridView'.
            // Create a DataTable from the GridView.
            DataTable dtSecurityHolding = myHKeInvestCode.unloadGridView(gvSecurityHolding);

            // Set the sort expression in ViewState for correct toggling of sort direction,
            // Sort the DataTable and bind it to the GridView.
            string sortExpression = e.SortExpression.ToLower();
            ViewState["SortExpression"] = sortExpression;
            dtSecurityHolding.DefaultView.Sort = sortExpression + " " + myHKeInvestCode.getSortDirection(ViewState, e.SortExpression);
            dtSecurityHolding.AcceptChanges();

            // Bind the DataTable to the GridView.
            gvSecurityHolding.DataSource = dtSecurityHolding.DefaultView;
            gvSecurityHolding.DataBind();
        }*/

        protected void gvBond_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtBond = myHKeInvestCode.unloadGridView(gvBond);
            string sortExpression = e.SortExpression.ToLower();
            ViewState["SortExpression"] = sortExpression;
            dtBond.DefaultView.Sort = e.SortExpression + " " + myHKeInvestCode.getSortDirection(ViewState, e.SortExpression);
            dtBond.AcceptChanges();
            gvBond.DataSource = dtBond.DefaultView;
            gvBond.DataBind();
        }

        protected void gvStock_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtStock = myHKeInvestCode.unloadGridView(gvStock);
            string sortExpression = e.SortExpression.ToLower();
            ViewState["SortExpression"] = sortExpression;
            dtStock.DefaultView.Sort = e.SortExpression + " " + myHKeInvestCode.getSortDirection(ViewState, e.SortExpression);
            dtStock.AcceptChanges();
            gvStock.DataSource = dtStock.DefaultView;
            gvStock.DataBind();
        }

        protected void gvUnitTrust_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtUnitTrust = myHKeInvestCode.unloadGridView(gvUnitTrust);
            string sortExpression = e.SortExpression.ToLower();
            ViewState["SortExpression"] = sortExpression;
            dtUnitTrust.DefaultView.Sort = e.SortExpression + " " + myHKeInvestCode.getSortDirection(ViewState, e.SortExpression);
            dtUnitTrust.AcceptChanges();
            gvUnitTrust.DataSource = dtUnitTrust.DefaultView;
            gvUnitTrust.DataBind();
        }
    }
}