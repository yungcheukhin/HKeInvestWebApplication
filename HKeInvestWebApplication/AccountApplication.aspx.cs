using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using HKeInvestWebApplication.Code_File;

namespace HKeInvestWebApplication
{
    public partial class AccountApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }
        protected void CreateAccount(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                HKeInvestData myHKeInvestData = new HKeInvestData();

                //AddAccountRecord
                string generateAccNum = "";
                //SELECT accountNumber FROM Account WHERE accountNumber LIKE 'AA%'
                string accEng = "";
                if (LastName.Text.Length == 1)
                {
                    accEng = accEng + LastName.Text.ToUpper() + LastName.Text.ToUpper();
                }
                else if (LastName.Text.Length > 1)
                {
                    accEng = accEng + LastName.Text.Substring(0, 2).ToUpper();
                }

                int acDigit = 1;
                //string accDigit = "";
                string precedingzeros = "";
                int precedzeros = 8 - acDigit.ToString().Length;
                DataTable samelastname = myHKeInvestData.getData("SELECT accountNumber FROM Account WHERE accountNumber LIKE '" + accEng + "%' ORDER BY accountNumber");
                if (samelastname.Rows.Count != 0)
                {
                    foreach (DataRow row in samelastname.Rows)
                    {
                        //for each accNum with same last name, compare the 8 digit and returns the one havn't used
                        int ifDigitEq = 0;
                        string accindatabase = "" + row["accountNumber"];
                        string compareAccDigit = accindatabase.Substring(2, 8);

                        string precedzero = "";
                        for (int i = 0; i < precedzeros; i++)
                        {
                            precedzero = precedzero + "0";
                        }

                        string comAccDigit = precedingzeros + acDigit.ToString();

                        ifDigitEq = compareAccDigit.CompareTo(comAccDigit);
                        Console.WriteLine(compareAccDigit);
                        if (ifDigitEq != 1 || ifDigitEq != -1)
                        {
                            acDigit = acDigit + 1;
                        }
                    }
                }

                for (int i = 0; i < precedzeros; i++)
                {
                    precedingzeros = precedingzeros + "0";
                }

                generateAccNum = accEng + precedingzeros + acDigit.ToString();

                //inserting data into table Account
                SqlTransaction tranAcc = myHKeInvestData.beginTransaction();
                myHKeInvestData.setData("INSERT INTO Account (accountNumber, accountType, balance, sweepFreeCredit) VALUES ('" + generateAccNum + "', '" + ddlAccType.SelectedValue + "', " + deposit.Text + ", '" + ddlsweep.SelectedValue + "')", tranAcc);
                myHKeInvestData.commitTransaction(tranAcc);

                //inserting data into table Client
                SqlTransaction tranCli = myHKeInvestData.beginTransaction();
                myHKeInvestData.setData("INSERT INTO Client (accountNumber, title, lastName, firstName, dateOfBirth, email, building, street, district, homePhone, homeFax, businessPhone, mobile, citizenship, legalResidence, HKIDPassportNumber, passportCountryOfIssue) VALUES ('" + generateAccNum + "', '" + ddlTitle.SelectedValue + "', '" + LastName.Text + "', '" + FirstName.Text + "', '" + DateOfBirth.Text + "', '" + Email.Text + "', '" + Building.Text + "', '" + Street.Text + "', '" + District.Text + "', " + HomePhone.Text + ", " + HomeFax.Text + ", " + BusinessPhone.Text + ", " + MobilePhone.Text + ", '" + Citizenship.Text + "', '" + Residence.Text + "', '" + HKID.Text + "', '" + PassportCountry.Text + "')", tranCli);
                myHKeInvestData.commitTransaction(tranCli);

                //inserting data into table Employment
                if (ddlEmployed.SelectedValue != "employed")
                {
                    SqlTransaction tranEmpl = myHKeInvestData.beginTransaction();
                    myHKeInvestData.setData("INSERT INTO Employment (accountNumber, status) VALUES ('" + generateAccNum + "', '" + ddlEmployed.SelectedValue + "')", tranEmpl);
                    myHKeInvestData.commitTransaction(tranEmpl);
                }
                else {
                    SqlTransaction tranEmpl = myHKeInvestData.beginTransaction();
                    myHKeInvestData.setData("INSERT INTO Employment (accountNumber, status, specificOccupation, yearsWithEmployer, employerName, employerPhone, businessNature) VALUES ('" + generateAccNum + "', '" + ddlEmployed.SelectedValue + "', '" + specificOccupation.Text + "', " + yearEmploy.Text + ", '" + employerName.Text + "', " + employerPhone.Text + ", '" + busiNature.Text + "')", tranEmpl);
                    myHKeInvestData.commitTransaction(tranEmpl);
                }

                //inserting data into table Investment
                SqlTransaction tranInv = myHKeInvestData.beginTransaction();
                myHKeInvestData.setData("INSERT INTO RegulatoryDisclosures (accountNumber, employedByFinancialInstitution, publiclyTradedCompany, primarySourceOfFunds, otherSource) VALUES ('" + generateAccNum + "', '" + ddlemployedByFinancialInstitution.SelectedValue + "', '" + ddlDirector.SelectedValue + "', '" + ddlPrimarySource.SelectedValue + "', '" + otherPrimarySource.Text + "')", tranInv);
                myHKeInvestData.commitTransaction(tranInv);

                //inserting data into table Regulatory Disclosures
                SqlTransaction tranReg = myHKeInvestData.beginTransaction();
                myHKeInvestData.setData("INSERT INTO Investment (accountNumber, objective, knowledge, experience, annualIncome, liquidNetWorth) VALUES ('" + generateAccNum + "', '" + ddlInvestmentObjective.SelectedValue + "', '" + ddlInvestmentKnowledge.SelectedValue + "', '" + ddlInvestmentExperience.SelectedValue + "', '" + ddlAnnualIncome.SelectedValue + "', '" + ddlNetWorth.SelectedValue + "')", tranReg);
                myHKeInvestData.commitTransaction(tranReg);

                //inserting data into table Security Holdings
                /*SqlTransaction tranSec = myHKeInvestData.beginTransaction();
                myHKeInvestData.setData("", tranSec);
                myHKeInvestData.commitTransaction(tranSec);*/

                //INSERT INTO Account (accountNumber, accountType, balance) VALUES ('HI00000001', 'individual', 1000)

                //generate a new account number for new added client
                /*string generateAccNum= "";
                SqlTransaction trans = myHKeInvestData.beginTransaction();
                myHKeInvestData.setData("update [Account] set [accountNumber]='" + generateAccNum + "' WHERE [HKIDPassportNumber] = '" + HKID.Text + "'", trans);
                myHKeInvestData.commitTransaction(trans);*/
                //}
            }
        }

        protected void cvothersPrimarySource_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string ifother = ddlPrimarySource.SelectedValue.Trim();
            if (ifother == "others")
            {
                if (otherPrimarySource.Text == "")
                {
                    cvothersPrimarySource.ErrorMessage = "Others description is required.";
                }
            }
        }

        protected void cvemploy1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string ifemploy = ddlEmployed.SelectedValue.Trim();
            if (ifemploy == "employed")
            {
                if (specificOccupation.Text == "")
                {
                    cvemploy1.ErrorMessage = "Please input Specific occupation.";
                }
            }
        }

        protected void cvemploy2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string ifemploy = ddlEmployed.SelectedValue.Trim();
            if (ifemploy == "employed")
            {
                if (yearEmploy.Text == "")
                {
                    cvemploy2.ErrorMessage = "Please input Years with employer.";
                }
            }
        }

        protected void cvemploy3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string ifemploy = ddlEmployed.SelectedValue.Trim();
            if (ifemploy == "employed")
            {
                if (employerName.Text == "")
                {
                    cvemploy3.ErrorMessage = "Please input Employer name.";
                }
            }
        }

        protected void cvemploy4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string ifemploy = ddlEmployed.SelectedValue.Trim();
            if (ifemploy == "employed")
            {
                if (employerPhone.Text == "")
                {
                    cvemploy4.ErrorMessage = "Please input Employer phone.";
                }
            }
        }

        protected void cvemploy5_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string ifemploy = ddlEmployed.SelectedValue.Trim();
            if (ifemploy == "employed")
            {
                if (busiNature.Text == "")
                {
                    cvemploy5.ErrorMessage = "Please input Nature of Business.";
                }
            }
        }

        protected void ifCoAc_CheckedChanged(object sender, EventArgs e)
        {
            ifCoAcc.Visible = ifCoAc.Checked;
        }
    }
}