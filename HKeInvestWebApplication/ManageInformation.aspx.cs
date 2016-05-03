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
        AccountInfro clientAccount;
        string userName;
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
            }
            updatePage();

        }

        protected void updatePage()
        {
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
            accountNumberLabel.Text = clientAccount.accountNumber;
            dateOfBirthLabel.Text = clientAccount.dateOfBirth;
            HKIDPassportNumberLabel.Text = clientAccount.HKIDPassportNumber;
            userNameLabel.Text = clientAccount.userName;

        }
        protected void titleBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData(clientAccount.title, ddlTitle.SelectedValue);
        }

        protected void firstNameBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData(clientAccount.firstName, firstNameBox.Text);
        }

        protected void lastNameBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData(clientAccount.lastName, lastNameBox.Text);
        }

        protected void emailBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData(clientAccount.email, emailBox.Text);
        }

        protected void buildingBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData(clientAccount.building, buildingBox.Text);
        }

        protected void streetBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData(clientAccount.street, streetBox.Text);
        }

        protected void districtBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData(clientAccount.district, districtBox.Text);
        }

        protected void homePhoneBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData(clientAccount.homePhone, homePhoneBox.Text);
        }

        protected void homeFaxBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData(clientAccount.homeFax, homeFaxBox.Text);
        }

        protected void businessPhoneBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData(clientAccount.businessPhone, businessPhoneBox.Text);
        }

        protected void mobileBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData(clientAccount.mobile, mobileBox.Text);
        }

        protected void citizenshipBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData(clientAccount.citizenship, citizenshipBox.Text);
        }

        protected void legalResidenceBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData(clientAccount.legalResidence, legalResidenceBox.Text);
        }

        protected void passportCountryOfIssueBtn_Click(object sender, EventArgs e)
        {
            clientAccount.changeData(clientAccount.passportCountryOfIssue, passportCountryOfIssueBox.Text);
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