using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using HKeInvestWebApplication.Models;
using System.Data;
using System.Data.SqlClient;
using HKeInvestWebApplication.Code_File;
using HKeInvestWebApplication.ExternalSystems.Code_File;

namespace HKeInvestWebApplication.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                HKeInvestData myHKeInvestData = new HKeInvestData();
                string idnum = HKID.Text.Trim();
                string mail = Email.Text.Trim();
                
                //check if HKIDPassportNumber is really stored in the database
                DataTable curHKID = myHKeInvestData.getData("SELECT HKIDPassportNumber FROM Client WHERE HKIDPassportNumber = '" + idnum + "'");
                if (curHKID.Rows.Count == 0)
                {
                    ErrorMessage.Text = "The input data does not match the client data.";
                    return;
                }

                //check if input data matches the one in database
                DataTable checkdata = myHKeInvestData.getData("SELECT email, accountNumber, lastName, firstName, dateOfBirth FROM Client WHERE HKIDPassportNumber = '" + idnum + "'");
                DataTable checkdate = myHKeInvestData.getData("SELECT Convert(varchar(10),CONVERT(date,dateOfBirth,106),103) AS DOB FROM Client WHERE HKIDPassportNumber = '" + idnum + "'");

                string checkemail = "";
                string checkAccNum = "";
                string checklastname = "";
                string checkfirstname = "";
                string checkDOB = "";
                
                foreach (DataRow row in checkdata.Rows)
                {
                    checkemail = checkemail + row["email"];
                    checkAccNum = checkAccNum + row["accountNumber"];
                    checklastname = checklastname + row["lastName"];
                    checkfirstname = checkfirstname + row["firstName"];
                }

                foreach (DataRow row in checkdate.Rows)
                {
                    checkDOB = checkDOB + row["DOB"];
                }

                int emailcheck = checkemail.CompareTo(Email.Text.Trim());
                Console.WriteLine(emailcheck);
                int accNumCheck = checkAccNum.CompareTo(AccountNumber.Text.Trim());
                Console.WriteLine(accNumCheck);
                int lastNameCheck = checklastname.CompareTo(LastName.Text.Trim());
                Console.WriteLine(lastNameCheck);
                int firstNameCheck = checkfirstname.CompareTo(FirstName.Text.Trim());
                Console.WriteLine(firstNameCheck);
                int DOBcheck = checkDOB.CompareTo(DateOfBirth.Text.ToString());
                Console.WriteLine(DOBcheck);

                if (emailcheck == -1 || accNumCheck == -1 || lastNameCheck == -1 || firstNameCheck == -1 || DOBcheck == -1)
                {
                    ErrorMessage.Text = "The input data does not match the client data.";
                    return;
                }
                

                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var user = new ApplicationUser() { UserName = UserName.Text, Email = Email.Text };
                IdentityResult result = manager.Create(user, Password.Text);
                if (result.Succeeded)
                {
                    //assign to role client
                    IdentityResult roleResult = manager.AddToRole(user.Id, "Client");

                    SqlTransaction trans = myHKeInvestData.beginTransaction();
                    myHKeInvestData.setData("update [Account] set [userName]='" + UserName.Text + "' WHERE [accountNumber] = '" + AccountNumber.Text + "'", trans);
                    myHKeInvestData.commitTransaction(trans);

                    if (!roleResult.Succeeded)
                    {
                        ErrorMessage.Text = roleResult.Errors.FirstOrDefault();
                    }

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    //string code = manager.GenerateEmailConfirmationToken(user.Id);
                    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    ErrorMessage.Text = result.Errors.FirstOrDefault();
                }
                /*SqlTransaction trans = myHKeInvestData.beginTransaction();
                myHKeInvestData.setData("update [Account] set [userName]='" + UserName.Text + "' WHERE [accountNumber] = '" + AccountNumber.Text + "'", trans);
                myHKeInvestData.commitTransaction(trans);*/
            }
        }

        protected void cvAccountNumber_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (AccountNumber.Text != null && LastName.Text != null)
            {
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
                if (lastname.Length == 1)
                {
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