﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using HKeInvestWebApplication.Code_File;
using HKeInvestWebApplication.ExternalSystems.Code_File;

namespace HKeInvestWebApplication
{
    public partial class SearchSecurities : System.Web.UI.Page
    {
        HKeInvestCode myHKeInvestCode = new HKeInvestCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            /*bondtable.Visible = true;
            //bondtable.Visible = false;
            stocktable.Visible = false;
            unittable.Visible = false;*/
            lblerror.Visible = false;
        }

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
                    if (searchresult == null)
                    {
                        lblerror.Text = "No machted security is found.";
                        lblerror.Visible = true;
                    }
                    else
                    {
                        /*//searchresult.AcceptChanges();
                        //ViewState["SortExpression"] = "name";
                        //ViewState["SortDirection"] = "ASC";
                        gvBond.DataSource = searchresult;
                        gvBond.DataBind();
                        //gvActiveBond.Sort("datesubmitted", SortDirection.Descending);
                        //gvBond.Sort("name", SortDirection.Ascending);
                        bondtable.Visible = true;*/
                        foreach (DataRow row in searchresult.Rows)
                        {
                            foreach (DataColumn col in searchresult.Columns)
                            {
                                if (row[col] == DBNull.Value)
                                {
                                    row[col] = Convert.ToDecimal("0.00");
                                }
                            }
                        }
                        searchresult.AcceptChanges();
                        ViewState["SortExpression"] = "name";
                        ViewState["SortDirection"] = "DESC";
                        gvBond.DataSource = searchresult;
                        gvBond.DataBind();
                        gvBond.Sort("name", SortDirection.Descending);
                        bondtable.Visible = true;
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
                        foreach (DataRow row in searchresult.Rows)
                        {
                            foreach (DataColumn col in searchresult.Columns)
                            {
                                if (row[col] == DBNull.Value)
                                {
                                    row[col] = Convert.ToDecimal("0.00");
                                }
                            }
                        }
                        searchresult.AcceptChanges();
                        ViewState["SortExpression"] = "name";
                        ViewState["SortDirection"] = "DESC";
                        gvBond.DataSource = searchresult;
                        gvBond.DataBind();
                        gvBond.Sort("name", SortDirection.Descending);
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
                        foreach (DataRow row in searchresult.Rows)
                        {
                            foreach (DataColumn col in searchresult.Columns)
                            {
                                if (row[col] == DBNull.Value)
                                {
                                    row[col] = Convert.ToDecimal("0.00");
                                }
                            }
                        }
                        searchresult.AcceptChanges();
                        ViewState["SortExpression"] = "name";
                        ViewState["SortDirection"] = "DESC";
                        gvBond.DataSource = searchresult;
                        gvBond.DataBind();
                        gvBond.Sort("name", SortDirection.Descending);
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
                        foreach (DataRow row in searchresult.Rows)
                        {
                            foreach (DataColumn col in searchresult.Columns)
                            {
                                if (row[col] == DBNull.Value)
                                {
                                    row[col] = Convert.ToDecimal("0.00");
                                }
                            }
                        }
                        searchresult.AcceptChanges();
                        ViewState["SortExpression"] = "name";
                        ViewState["SortDirection"] = "DESC";
                        gvStock.DataSource = searchresult;
                        gvStock.DataBind();
                        gvStock.Sort("name", SortDirection.Descending);
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
                        foreach (DataRow row in searchresult.Rows)
                        {
                            foreach (DataColumn col in searchresult.Columns)
                            {
                                if (row[col] == DBNull.Value)
                                {
                                    row[col] = Convert.ToDecimal("0.00");
                                }
                            }
                        }
                        searchresult.AcceptChanges();
                        ViewState["SortExpression"] = "name";
                        ViewState["SortDirection"] = "DESC";
                        gvStock.DataSource = searchresult;
                        gvStock.DataBind();
                        gvStock.Sort("name", SortDirection.Descending);
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
                        foreach (DataRow row in searchresult.Rows)
                        {
                            foreach (DataColumn col in searchresult.Columns)
                            {
                                if (row[col] == DBNull.Value)
                                {
                                    row[col] = Convert.ToDecimal("0.00");
                                }
                            }
                        }
                        searchresult.AcceptChanges();
                        ViewState["SortExpression"] = "name";
                        ViewState["SortDirection"] = "DESC";
                        gvStock.DataSource = searchresult;
                        gvStock.DataBind();
                        gvStock.Sort("name", SortDirection.Descending);
                        stocktable.Visible = true;
                    }
                }
                else
                {
                    lblerror.Text = "Either one of security code or security name is allowed to input.";
                    lblerror.Visible = true;
                }
                ViewState["SortExpression"] = "name";
                ViewState["SortDirection"] = "ASC";
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
                        foreach (DataRow row in searchresult.Rows)
                        {
                            foreach (DataColumn col in searchresult.Columns)
                            {
                                if (row[col] == DBNull.Value)
                                {
                                    row[col] = Convert.ToDecimal("0.00");
                                }
                            }
                        }
                        searchresult.AcceptChanges();
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
                        foreach (DataRow row in searchresult.Rows)
                        {
                            foreach (DataColumn col in searchresult.Columns)
                            {
                                if (row[col] == DBNull.Value)
                                {
                                    row[col] = Convert.ToDecimal("0.00");
                                }
                            }
                        }
                        searchresult.AcceptChanges();
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
                        foreach (DataRow row in searchresult.Rows)
                        {
                            foreach (DataColumn col in searchresult.Columns)
                            {
                                if (row[col] == DBNull.Value)
                                {
                                    row[col] = Convert.ToDecimal("0.00");
                                }
                            }
                        }
                        searchresult.AcceptChanges();
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
            ViewState["SortExpression"] = "name";
            ViewState["SortDirection"] = "ASC";
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
            //dtBond.DefaultView.Sort = "name" + " " + "ASC";
            //dtBond.AcceptChanges();
            gvBond.DataSource = dtBond.DefaultView;
            gvBond.DataBind();
        }

        protected void gvStock_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtStock = myHKeInvestCode.unloadGridView(gvStock);
            string sortExpression = e.SortExpression.ToLower();
            ViewState["SortExpression"] = sortExpression;
            dtStock.DefaultView.Sort = e.SortExpression + " " + myHKeInvestCode.getSortDirection(ViewState, e.SortExpression);
            //dtStock.AcceptChanges();
            gvStock.DataSource = dtStock.DefaultView;
            gvStock.DataBind();
            //bondtable.Visible = true;
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