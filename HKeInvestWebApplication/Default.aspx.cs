using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace HKeInvestWebApplication
{
    public partial class _Default : Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            PDF_download.Click += new EventHandler(this.Button1_Click);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            FileInfo fileInfo = new FileInfo(MapPath("~/application_form.pdf"));
            failLabel.Visible = false;
            if (fileInfo.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.Flush();
                Response.TransmitFile(fileInfo.FullName);
                Response.End();
            }
            else
            {
                failLabel.Visible = true;
            }
        }
    }


}