using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.AspNet.Identity;
using HKeInvestWebApplication.Code_File;
using HKeInvestWebApplication.ExternalSystems.Code_File;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using HKeInvestWebApplication.Models;



namespace HKeInvestWebApplication
{


    public partial class ManageInformation : System.Web.UI.Page
    {
            AccountInfro clientAccount = new AccountInfro();
            string clientName;
            string clientAccountNumber;
            string important1 = GlobalVal.ImportantData;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }
            clientName = Context.User.Identity.GetUserName();
            if (String.Compare(clientName, "employee") != 0)  //Client account
            {
                clientAccount.userName = clientName;
                enterUserName.Visible = false;
                manageInfro.Visible = true;
                firstNameBox.Visible = false;
                firstNameBtn.Visible = false;
                lastNameBox.Visible = false;
                lastNameBtn.Visible = false;
                citizenshipBox.Visible = false;
                citizenshipBtn.Visible = false;
                legalResidenceBox.Visible = false;
                legalResidenceBtn.Visible = false;
                refreshBtn.Visible = false;
                passportCountryOfIssueBox.Visible = false;
                passportCountryOfIssueBtn.Visible = false;
                updatePage();

            }
            else if ((String.Compare(clientName, "employee") == 0 && important1 == null) || (userNameSearchBox.Text == null && important1 != null))
            {
                refreshBtn.Visible = true;
                enterUserName.Visible = true;
                manageInfro.Visible = false;

            }
            else if(userNameSearchBox.Text != null )
            {
                if (userNameSearchBox.Text != "")
                {
                    clientAccount.userName = userNameSearchBox.Text;
                    updatePage();
                }
                else
                {
                    refreshBtn.Visible = true;
                    enterUserName.Visible = true;
                    manageInfro.Visible = false;
                }

            }
            else
            {
                refreshBtn.Visible = true;
                enterUserName.Visible = true;
                manageInfro.Visible = false;
            }

            if (important1 == null)
            {
                important1 = DateTime.Now.ToString();
                GlobalVal.ImportantData = important1;
            }
            if (String.Compare(clientName, "employee") != 0) GlobalVal.reset();
        }

        protected void userNameBtn_Click(object sender, EventArgs e)
        {
            clientAccount.userName = userNameSearchBox.Text;
            if (clientAccount.checkNameExist()) {

                nameExist.Visible = false;
                enterUserName.Visible = false;
                manageInfro.Visible = true;
                updatePage();

            }
            else
            {
                enterUserName.Visible = true;
                manageInfro.Visible = false;
                nameExist.Visible = true;
            }

        }

        protected void updatePage()
        {
            clientAccount.updateTable();
            titleLabel.Text = clientAccount.title;
            firstNameLabel.Text = clientAccount.firstName;
            lastNameLabel.Text = clientAccount.lastName;
            emailLabel.Text = clientAccount.email;
            buildingLabel.Text = clientAccount.building;
            streetLabel.Text = clientAccount.street;
            districtLabel.Text = clientAccount.district;
            homePhoneLabel.Text = clientAccount.homePhone;
            homeFaxLabel.Text = clientAccount.homeFax;
            businessPhoneLabel.Text = clientAccount.businessPhone;
            mobileLabel.Text = clientAccount.mobile;
            citizenshipLabel.Text = clientAccount.citizenship;
            legalResidenceLabel.Text = clientAccount.legalResidence;
            passportCountryOfIssueLabel.Text = clientAccount.passportCountryOfIssue;
            accountTypeLabel.Text = clientAccount.accountType;
            clientAccountNumber = clientAccount.accountNumber;
            accountNumberLabel.Text = clientAccount.accountNumber;
            dateOfBirthLabel.Text = clientAccount.dateOfBirth;
            HKIDPassportNumberLabel.Text = clientAccount.HKIDPassportNumber;
            userNameLabel.Text = clientAccount.userName;

        }
        protected void titleBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("title", ddlTitle.SelectedValue, accountNumberLabel.Text);
            updatePage();
        }

        protected void firstNameBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("firstName", firstNameBox.Text, accountNumberLabel.Text);
            updatePage();
        }

        protected void lastNameBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("lastName", lastNameBox.Text, accountNumberLabel.Text);
            updatePage();
        }

        protected void emailBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("email", emailBox.Text, accountNumberLabel.Text);
            updatePage();
        }

        protected void buildingBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("building", buildingBox.Text, accountNumberLabel.Text);
            updatePage();
        }

        protected void streetBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("street", streetBox.Text, accountNumberLabel.Text);
            updatePage();
        }

        protected void districtBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("district", districtBox.Text, accountNumberLabel.Text);
            updatePage();
        }

        protected void homePhoneBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("homePhone", homePhoneBox.Text, accountNumberLabel.Text);
            updatePage();
        }

        protected void homeFaxBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("homeFax", homeFaxBox.Text, accountNumberLabel.Text);
            updatePage();
        }

        protected void businessPhoneBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("businessPhone", businessPhoneBox.Text, accountNumberLabel.Text);
            updatePage();
        }

        protected void mobileBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("mobile", mobileBox.Text, accountNumberLabel.Text);
            updatePage();
        }

        protected void citizenshipBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("citizenship", citizenshipBox.Text, accountNumberLabel.Text);
            updatePage();
        }

        protected void legalResidenceBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("legalResidence", legalResidenceBox.Text, accountNumberLabel.Text);
            updatePage();
        }

        protected void passportCountryOfIssueBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("passportCountryOfIssue", passportCountryOfIssueBox.Text, accountNumberLabel.Text);
            updatePage();
        }

        protected void refreshBtn_Click(object sender, EventArgs e)
        {
            GlobalVal.reset();
            Response.Redirect("~/System_service/ManageInformation.aspx");
        }

        //protected void confirmBtn_Click(object sender, EventArgs e)
        //{
        //    string code = IdentityHelper.GetCodeFromRequest(Request);
        //    if (code != null)
        //    {
        //        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //        var user = manager.FindByName(clientAccount.userName);
        //        var result = manager.ResetPassword(user.Id, code, passwordBox.Text);
        //    }
        //    updatePage();
        //}

    }
}