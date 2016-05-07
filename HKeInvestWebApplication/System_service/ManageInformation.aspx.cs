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
        string userName;
        string clientAccountNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }
            userName = Context.User.Identity.GetUserName();
            clientAccount = new AccountInfro(userName);
            if (String.Compare(userName, "employee") != 0)  //Client account
            {
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
                passportCountryOfIssueBox.Visible = false;
                passportCountryOfIssueBtn.Visible = false;
                updatePage();

            }
            else if (String.Compare(userName, "employee") == 0)
            {
                enterUserName.Visible = true;
                manageInfro.Visible = false;
            }

            titleBtn.Click += new EventHandler(this.titleBtn_Click);

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
        }

        protected void firstNameBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("firstName", firstNameBox.Text, accountNumberLabel.Text);
        }

        protected void lastNameBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("lastName", lastNameBox.Text, accountNumberLabel.Text);
        }

        protected void emailBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("email", emailBox.Text, accountNumberLabel.Text);
        }

        protected void buildingBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("building", buildingBox.Text, accountNumberLabel.Text);
        }

        protected void streetBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("street", streetBox.Text, accountNumberLabel.Text);
        }

        protected void districtBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("district", districtBox.Text, accountNumberLabel.Text);
        }

        protected void homePhoneBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("homePhone", homePhoneBox.Text, accountNumberLabel.Text);
        }

        protected void homeFaxBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("homeFax", homeFaxBox.Text, accountNumberLabel.Text);
        }

        protected void businessPhoneBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("businessPhone", businessPhoneBox.Text, accountNumberLabel.Text);
        }

        protected void mobileBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("mobile", mobileBox.Text, accountNumberLabel.Text);
        }

        protected void citizenshipBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("citizenship", citizenshipBox.Text, accountNumberLabel.Text);
        }

        protected void legalResidenceBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("legalResidence", legalResidenceBox.Text, accountNumberLabel.Text);
        }

        protected void passportCountryOfIssueBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData("passportCountryOfIssue", passportCountryOfIssueBox.Text, accountNumberLabel.Text);
        }

        protected void confirmBtn_Click(object sender, EventArgs e)
        {
            string code = IdentityHelper.GetCodeFromRequest(Request);
            if (code != null)
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindByName(clientAccount.userName);
                var result = manager.ResetPassword(user.Id, code, passwordBox.Text);
            }
        }


    }
}