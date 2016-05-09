﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data;
using HKeInvestWebApplication.Code_File;
using HKeInvestWebApplication.ExternalSystems.Code_File;
using System.Globalization;

namespace HKeInvestWebApplication.Code_File
{
    //**********************************************************
    //*  THE CODE IN THIS CLASS CAN BE MODIFIED AND ADDED TO.  *
    //**********************************************************
    public class HKeInvestCode
    {

        /*public void addSessionVariable()
        {
            ExternalFunctions myExternalFunctions = new ExternalFunctions();
            DataTable dtCurrency = myExternalFunctions.getCurrencyData();
        }*/

        public void addSessionVariable(System.Web.SessionState.HttpSessionState Session)
        {
            ExternalFunctions myExternalFunctions = new ExternalFunctions();
            DataTable dtCurrency = myExternalFunctions.getCurrencyData();
            Session["CurrencyData"] = myExternalFunctions.getCurrencyData();

            foreach (DataRow row in dtCurrency.Rows)
            {
                string targetCurr = row["currency"].ToString().Trim();
                Session[targetCurr] = row["rate"].ToString().Trim();
            }
        }

        public string getDataType(string value)
        {
            // Returns the data type of value. Tests for more types can be added if needed.
            if (value != null)
            {
                /*int n; */
                decimal d; DateTime dt; Int64 b;/* DateTime month;*/
                //if (int.TryParse(value, out n)) { return "System.Int32"; }
                if (Int64.TryParse(value, out b)) { return "System.Int64"; }
                else if (decimal.TryParse(value, out d)) { return "System.Decimal"; }
                else if (DateTime.TryParse(value, out dt)) { return "System.DateTime"; }
                //else if (DateTime.TryParseExact(value, "MMM-yy", out month)) { return "System.DateTime"; }
                //else if (DateTime.ParseExact(value, "MMM-yy", CultureInfo.InvariantCulture, out month)) { return "System.DateTime"; }
                //else if (DateTime.TryParseExact(value, "MMM-yy", ))
            }
            return "System.String";
        }

        public string getSortDirection(System.Web.UI.StateBag viewState, string sortExpression)
        {
            // If the GridView is sorted for the first time or sorting is being done on a new column, 
            // then set the sort direction to "ASC" in ViewState.
            if (viewState["SortDirection"] == null || viewState["SortExpression"].ToString() != sortExpression)
            {
                viewState["SortDirection"] = "ASC";
            }
            // Othewise if the same column is clicked for sorting more than once, then toggle its SortDirection.
            else if (viewState["SortDirection"].ToString() == "ASC")
            {
                viewState["SortDirection"] = "DESC";
            }
            else if (viewState["SortDirection"].ToString() == "DESC")
            {
                viewState["SortDirection"] = "ASC";
            }
            return viewState["SortDirection"].ToString();
        }

        public DataTable unloadGridView(GridView gv)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < gv.Columns.Count; i++)
            {
                dt.Columns.Add(((BoundField)gv.Columns[i]).DataField);
            }

            // For correct sorting, set the data type of each DataTable column based on the values in the GridView.
            gv.SelectedIndex = 0;
            for (int i = 0; i < gv.Columns.Count; i++)
            {
                string temp = getDataType(gv.SelectedRow.Cells[i].Text);
                dt.Columns[i].DataType = Type.GetType(temp);
            }

            // Load the GridView data into the DataTable.
            foreach (GridViewRow row in gv.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < gv.Columns.Count;   j++)
                {
                    dr[((BoundField)gv.Columns[j]).DataField.ToString().Trim()] = row.Cells[j].Text;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public int getColumnIndexByName(GridView gv, string columnName)
        {
            // Helper method to get GridView column index by a column's DataField name.
            for (int i = 0; i < gv.Columns.Count; i++)
            {
                if (((BoundField)gv.Columns[i]).DataField.ToString().Trim() == columnName.Trim())
                { return i; }
            }
            MessageBox.Show("Column '" + columnName + "' was not found \n in the GridView '" + gv.ID.ToString() + "'.");
            return -1;
        }

        public decimal convertCurrency(string fromCurrency, string fromCurrencyRate, string toCurrency, string toCurrencyRate, decimal value)
        {
            if(fromCurrency == toCurrency)
            {
                return value;
            }
            else
            {
                return Math.Round(Convert.ToDecimal(fromCurrencyRate) / Convert.ToDecimal(toCurrencyRate) * value - (decimal).005, 2);
            }
        }
    }
}