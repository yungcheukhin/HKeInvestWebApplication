using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HKeInvestWebApplication
{
    public partial class RegistrationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cvAccountNumber_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (AccountNumber.Text!=null && LastName.Text!=null) {
                string accountnumber = AccountNumber.Text;
                string lastname = LastName.Text.ToUpper();
                Int32 test;
                if (accountnumber.Length == 10)
                {
                    if ((!Int32.TryParse(accountnumber.Substring(2), out test)))
                    {
                        args.IsValid = false;
                        cvAccountNumber.ErrorMessage = "The format of account number is not correct.";
                    }
                }
                else
                    args.IsValid = false;
                if (lastname.Length == 1) {
                    if (accountnumber[0] != lastname[0])
                    {
                        args.IsValid = false;
                    }
                    if (accountnumber[1] != lastname[0])
                    {
                        args.IsValid = false;
                    }
                    if (args.IsValid == false)
                    {
                        cvAccountNumber.ErrorMessage = "The account number does not match the client's last name.";
                    }
                }
                else if (lastname.Length > 1)
                {
                    if (accountnumber[0] != lastname[0])
                    {
                        args.IsValid = false;
                    }
                    if (accountnumber[1] != lastname[1])
                    {
                        args.IsValid = false;
                    }
                    if (args.IsValid == false)
                    {
                        cvAccountNumber.ErrorMessage = "The account number does not match the client's last name.";
                    }
                }
            }
        }
    }
}