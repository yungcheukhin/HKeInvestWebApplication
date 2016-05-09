<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountApplication.aspx.cs" Inherits="HKeInvestWebApplication.AccountApplication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>Account Application</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new client account</h4>
        <hr />
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" EnableClientScript="False" />
        <asp:Label runat="server" ID="lblnotmatch"></asp:Label>

        <h4>Account Type</h4>
        <div class="form-group">
            <asp:Label runat="server" Text="Account Type" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3"><asp:DropDownList ID="ddlAccType" runat="server" CssClass="form-control">
                <asp:ListItem Value="">Account Type</asp:ListItem>
                <asp:ListItem Value="individual">Individual</asp:ListItem>
                <asp:ListItem Value="survivorship">Survivorship</asp:ListItem>
                <asp:ListItem Value="common">Common</asp:ListItem>
              </asp:DropDownList>
              <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAccType" CssClass="text-danger" EnableClientScript="False" ErrorMessage="User Account does not exist." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Co-Account Holder" CssClass="control-label col-md-2"></asp:Label>
            <asp:CheckBox ID="ifCoAc" runat="server" AutoPostBack="True" OnCheckedChanged="ifCoAc_CheckedChanged" CssClass="control-label col-md-1" />
        </div>

        <hr />

        <h4>Client Information</h4>
        <div class="form-group">
            <asp:Label runat="server" Text="Title" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-2"><asp:DropDownList ID="ddlTitle" runat="server" CssClass="form-control">
                <asp:ListItem Value="">Title</asp:ListItem>
                <asp:ListItem Value="Mr">Mr.</asp:ListItem>
                <asp:ListItem Value="Mrs">Mrs.</asp:ListItem>
                <asp:ListItem Value="Ms">Ms.</asp:ListItem>
                <asp:ListItem Value="Dr">Dr.</asp:ListItem>
              </asp:DropDownList>
              <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTitle" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Title is required.">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
           <asp:Label runat="server" Text="Last Name" CssClass="control-label col-md-2" AssociatedControlID="LastName"></asp:Label>
             <div class="col-md-4"><asp:TextBox runat="server" CssClass="form-control" MaxLength="35" ID="LastName"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Last Name is required." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>

            <asp:Label runat="server" Text="First Name" CssClass="control-label col-md-2" AssociatedControlID="FirstName"></asp:Label>
           <div class="col-md-4"><asp:TextBox runat="server" CssClass="form-control" MaxLength="35" CausesValidation="False" ID="FirstName"></asp:TextBox>
               <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName" CssClass="text-danger" EnableClientScript="False" ErrorMessage="First Name is required." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <hr />

        <div class="form-group">
            <asp:Label runat="server" Text="Date Of Birth (mm/dd/yyyy)" AssociatedControlID="DateOfBirth" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="DateOfBirth" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="DateOfBirth" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Date of birth is not valid." ValidationExpression="^([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$" Display="Dynamic">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DateOfBirth" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Date of birth is required." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>

            <asp:Label runat="server" Text="Email" AssociatedControlID="Email" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="Email" runat="server" TextMode="Email" CssClass="form-control" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Email address is required." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <hr />

        <div class="form-group">
            <asp:Label runat="server" Text="Building" AssociatedControlID="Building" MaxLength="50" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="Building" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox></div>
            <asp:Label runat="server" Text="Street" AssociatedControlID="Street" MaxLength="35" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="Street" runat="server" CssClass="form-control" MaxLength="35"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Street" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Address street is required." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Text="District" AssociatedControlID="District" MaxLength="19" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="District" runat="server" CssClass="form-control" MaxLength="19"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="District" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Address district is required." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <hr />

        <div class="form-group">
            <asp:Label runat="server" Text="Home Phone" AssociatedControlID="HomePhone" MaxLength="8" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="HomePhone" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="HomePhone" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Home phone number is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvHomePhone" runat="server" ControlToValidate="HomePhone" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Not a valid phone number." ValidateEmptyText="True">*</asp:CustomValidator>
            </div>
            <asp:Label runat="server" Text="Home Fax" AssociatedControlID="HomeFax" MaxLength="8" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="HomeFax" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Text="Business Phone" AssociatedControlID="BusinessPhone" MaxLength="8" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="BusinessPhone" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="BusinessPhone" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Business phone number is required." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
            <asp:Label runat="server" Text="Mobile Phone" AssociatedControlID="MobilePhone" MaxLength="8" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="MobilePhone" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="MobilePhone" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Mobile phone number is required." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <hr />

        <div class="form-group">
            <asp:Label runat="server" Text="Country of Citizenship" AssociatedControlID="Citizenship" MaxLength="70" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="Citizenship" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Citizenship" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Citizenship is required." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
            <asp:Label runat="server" Text="Country of legal residence" AssociatedControlID="Residence" MaxLength="70" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="Residence" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Residence" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Country of legal residence is required." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" Text="HKID/Passport#" AssociatedControlID="HKID" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="HKID" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="HKID" CssClass="text-danger" EnableClientScript="False" ErrorMessage="A HKID or Passport number is required." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Text="Passport country of issue" AssociatedControlID="PassportCountry" MaxLength="70" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="PassportCountry" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PassportCountry" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Passport country of issue is required." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <hr />
        <hr />

        <h4>Employment Information</h4>
        <div class="form-group">
            <asp:Label runat="server" Text="Employment Status: " CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlEmployed" runat="server" CssClass="form-control">
                    <asp:ListItem Value="">Employment Status</asp:ListItem>
                    <asp:ListItem Value="employed">Employed</asp:ListItem>
                    <asp:ListItem Value="selfEmployed">Self-employed</asp:ListItem>
                    <asp:ListItem Value="retired">Retired</asp:ListItem>
                    <asp:ListItem Value="student">Student</asp:ListItem>
                    <asp:ListItem Value="notEmployed">Not Employed</asp:ListItem>
                    <asp:ListItem Value="homemaker">Homemaker</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlEmployed" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Employment status is required.">*</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Specific occupation" AssociatedControlID="specificOccupation" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="specificOccupation" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                <asp:CustomValidator ID="cvemploy1" runat="server" ControlToValidate="specificOccupation" ErrorMessage="Please input Specific occupation." CssClass="text-danger" EnableClientScript="False" ValidateEmptyText="True" Display="Dynamic"  OnServerValidate="cvemploy1_ServerValidate">*</asp:CustomValidator>
            </div>
            <asp:Label runat="server" Text="Years with employer" AssociatedControlID="yearEmploy" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="yearEmploy" runat="server" CssClass="form-control" MaxLength="25"></asp:TextBox>
                <asp:CustomValidator ID="cvemploy2" runat="server" ControlToValidate="yearEmploy" ErrorMessage="Please input Years with employer." CssClass="text-danger" EnableClientScript="False" ValidateEmptyText="True" Display="Dynamic"  OnServerValidate="cvemploy2_ServerValidate">*</asp:CustomValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Employer name" AssociatedControlID="employerName" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="employerName" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                <asp:CustomValidator ID="cvemploy3" runat="server" ControlToValidate="employerName" ErrorMessage="Please input Employer name." CssClass="text-danger" EnableClientScript="False" ValidateEmptyText="True" Display="Dynamic"  OnServerValidate="cvemploy3_ServerValidate">*</asp:CustomValidator>
            </div>
            <asp:Label runat="server" Text="Employer phone" AssociatedControlID="employerPhone" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="employerPhone" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                <asp:CustomValidator ID="cvemploy4" runat="server" ControlToValidate="employerPhone" ErrorMessage="Please input Employer phone." CssClass="text-danger" EnableClientScript="False" ValidateEmptyText="True" Display="Dynamic"  OnServerValidate="cvemploy4_ServerValidate">*</asp:CustomValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Nature of Business" AssociatedControlID="busiNature" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="busiNature" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                <asp:CustomValidator ID="cvemploy5" runat="server" ControlToValidate="busiNature" ErrorMessage="Please input Nature of Business." CssClass="text-danger" EnableClientScript="False" ValidateEmptyText="True" Display="Dynamic"  OnServerValidate="cvemploy5_ServerValidate">*</asp:CustomValidator>
            </div>
        </div>

        <hr />
        <hr />

        <h4>Disclosures and Regulatory Information</h4>
        <div class="form-group">
            <asp:Label runat="server" Text="Employed by a registered securities broker/dealer, investment advisor, bank or other financial insitution" CssClass="control-label col-md-8"></asp:Label>
            <div class="col-md-4"><asp:DropDownList ID="ddlemployedByFinancialInstitution" runat="server" CssClass="form-control">
                <asp:ListItem Value="">(Yes/No)</asp:ListItem>
                <asp:ListItem Value="no">No</asp:ListItem>
                <asp:ListItem Value="yes">Yes</asp:ListItem>
              </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlemployedByFinancialInstitution" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Disclosures and Regulatory Information is required.">*</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Directer, 10% shareholder or policy-making officer of a public traded company" CssClass="control-label col-md-8"></asp:Label>
            <div class="col-md-4"><asp:DropDownList ID="ddlDirector" runat="server" CssClass="form-control">
                <asp:ListItem Value="">(Yes/No)</asp:ListItem>
                <asp:ListItem Value="no">No</asp:ListItem>
                <asp:ListItem Value="yes">Yes</asp:ListItem>
              </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlDirector" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Disclosures and Regulatory Information is required.">*</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Primary Source of Funds deposited to this Account" CssClass="control-label col-md-8"></asp:Label>
            <div class="col-md-4"><asp:DropDownList ID="ddlPrimarySource" runat="server" CssClass="form-control">
                <asp:ListItem Value="">Primary Source</asp:ListItem>
                <asp:ListItem Value="savings">salary/wages/savings</asp:ListItem>
                <asp:ListItem Value="investment">investment/capital gains</asp:ListItem>
                <asp:ListItem Value="family">family/relatives/inheritance</asp:ListItem>
                <asp:ListItem Value="others">Others</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlPrimarySource" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Disclosures and Regulatory Information is required.">*</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Other" AssociatedControlID="otherPrimarySource" CssClass="control-label col-md-8"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="otherPrimarySource" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                <asp:CustomValidator ID="cvothersPrimarySource"  runat="server" ErrorMessage="Others description is required." ControlToValidate="otherPrimarySource" CssClass="text-danger" EnableClientScript="False" ValidateEmptyText="True" Display="Dynamic"  OnServerValidate="cvothersPrimarySource_ServerValidate"></asp:CustomValidator>
            </div>
        </div>

        <hr />
        <hr />

        <h4>Investment Profile</h4>
        <div class="form-group">
            <asp:Label runat="server" Text="Investment objective* for this account" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:DropDownList ID="ddlInvestmentObjective" runat="server" CssClass="form-control">
                <asp:ListItem Value="">Investment Objective</asp:ListItem>
                <asp:ListItem Value="capitalPreservation">Capital Preservation</asp:ListItem>
                <asp:ListItem Value="income">Income</asp:ListItem>
                <asp:ListItem Value="growth">Growth</asp:ListItem>
                <asp:ListItem Value="speculation">Speculation</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlInvestmentObjective" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Investment Objective field is required.">*</asp:RequiredFieldValidator>
            </div>
            <asp:Label runat="server" Text="Investment knowledge" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:DropDownList ID="ddlInvestmentKnowledge" runat="server" CssClass="form-control">
                <asp:ListItem Value="">Investment Knowledge</asp:ListItem>
                <asp:ListItem Value="none">None</asp:ListItem>
                <asp:ListItem Value="limited">Limited</asp:ListItem>
                <asp:ListItem Value="good">Good</asp:ListItem>
                <asp:ListItem Value="extensive">Extensive</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlInvestmentKnowledge" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Investment Knowledge field is required.">*</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Investment experience" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:DropDownList ID="ddlInvestmentExperience" runat="server" CssClass="form-control">
                <asp:ListItem Value="">Investment experience</asp:ListItem>
                <asp:ListItem Value="none">None</asp:ListItem>
                <asp:ListItem Value="limited">Limited</asp:ListItem>
                <asp:ListItem Value="good">Good</asp:ListItem>
                <asp:ListItem Value="extensive">Extensive</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlInvestmentExperience" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Investment Experience field is required.">*</asp:RequiredFieldValidator>
            </div>
            <asp:Label runat="server" Text="Annual income" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:DropDownList ID="ddlAnnualIncome" runat="server" CssClass="form-control">
                <asp:ListItem Value="">Annual income</asp:ListItem>
                <asp:ListItem Value="<20000">Under HK$20,000</asp:ListItem>
                <asp:ListItem Value="20001-200000">HK$20,001 - HK$200,000</asp:ListItem>
                <asp:ListItem Value="200001-2000000">HK$200,001 - HK$2,000,000</asp:ListItem>
                <asp:ListItem Value=">2000000">More than HK$2,000,000</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlAnnualIncome" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Annual Income field is required.">*</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" Text="Approximate liquid net worth (cash and securities)" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:DropDownList ID="ddlNetWorth" runat="server" CssClass="form-control">
                <asp:ListItem Value="">Approximate liquid net worth</asp:ListItem>
                <asp:ListItem Value="<100000">Under HK$100,000</asp:ListItem>
                <asp:ListItem Value="100001-1000000">HK$100,001 - HK$1,000,000</asp:ListItem>
                <asp:ListItem Value="1000001-10000000">HK$1,000,001 - HK$10,000,000</asp:ListItem>
                <asp:ListItem Value=">10000000">More than HK$10,000,000</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlNetWorth" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Approximate liquid net worth is required.">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <hr />
        <hr />

        <h4>Account Feature</h4>
        <div class="form-group">
            <asp:Label runat="server" Text="Sweep my Free Credit Balance into the Fund." CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:DropDownList ID="ddlsweep" runat="server" CssClass="form-control">
                <asp:ListItem Value="">(Yes/No)</asp:ListItem>
                <asp:ListItem Value="yes">Yes</asp:ListItem>
                <asp:ListItem Value="no">No</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlsweep" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Account Feature field is required.">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <hr />
        <hr />

        <h4>Initial Account Deposit</h4>
        <div class="form-group">
            <asp:Label runat="server" Text="Payment Method" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:DropDownList ID="ddlpaymentMethod" runat="server" CssClass="form-control">
                <asp:ListItem Value="">PaymentMethod</asp:ListItem>
                <asp:ListItem Value="cheque">Cheque</asp:ListItem>
                <asp:ListItem Value="transfer">Transfer</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlpaymentMethod" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Payment Method is required.">*</asp:RequiredFieldValidator>
            </div>
            <asp:Label runat="server" Text="Initial Account Deposit" AssociatedControlID="deposit" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="deposit" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox></div>
        </div>

        <hr />
        <hr />

        <asp:Panel ID="ifCoAcc" runat="server" Visible="False">

            <h3>Co-Account Holder Information</h3>

            <hr />

            <h4>Client Information</h4>
            <div class="form-group">
                <asp:Label runat="server" Text="Title" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-2"><asp:DropDownList ID="ddlTitle2" runat="server" CssClass="form-control">
                    <asp:ListItem Value="">Title</asp:ListItem>
                    <asp:ListItem Value="Mr">Mr.</asp:ListItem>
                    <asp:ListItem Value="Mrs">Mrs.</asp:ListItem>
                    <asp:ListItem Value="Ms">Ms.</asp:ListItem>
                    <asp:ListItem Value="Dr">Dr.</asp:ListItem>
                  </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTitle2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Title is required.">*</asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
               <asp:Label runat="server" Text="Last Name" CssClass="control-label col-md-2" AssociatedControlID="LastName2"></asp:Label>
                 <div class="col-md-4"><asp:TextBox runat="server" CssClass="form-control" MaxLength="35" ID="LastName2"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Last Name is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                 </div>

                <asp:Label runat="server" Text="First Name" CssClass="control-label col-md-2" AssociatedControlID="FirstName2"></asp:Label>
               <div class="col-md-4"><asp:TextBox runat="server" CssClass="form-control" MaxLength="35" CausesValidation="False" ID="FirstName2"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="First Name is required." Display="Dynamic">*</asp:RequiredFieldValidator>
               </div>
            </div>

            <hr />

            <div class="form-group">
                <asp:Label runat="server" Text="Date Of Birth" AssociatedControlID="DOB2" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="DOB2" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="DOB2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Date of birth is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="DOB2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Date of birth is not valid." ValidationExpression="^([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$" Display="Dynamic">*</asp:RegularExpressionValidator>
               </div>

                <asp:Label runat="server" Text="Email" AssociatedControlID="Email2" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="Email2" runat="server" TextMode="Email" CssClass="form-control" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Email address is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
            </div>

            <hr />

            <div class="form-group">
                <asp:Label runat="server" Text="Building" AssociatedControlID="Building2" MaxLength="50" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="Building2" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox></div>
                <asp:Label runat="server" Text="Street" AssociatedControlID="Street2" MaxLength="35" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="Street2" runat="server" CssClass="form-control" MaxLength="35"></asp:TextBox>
                  <asp:RequiredFieldValidator runat="server" ControlToValidate="Street2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Address street is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" Text="District2" AssociatedControlID="District" MaxLength="19" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="District2" runat="server" CssClass="form-control" MaxLength="19"></asp:TextBox>
                  <asp:RequiredFieldValidator runat="server" ControlToValidate="District2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Address district is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
            </div>

            <hr />

            <div class="form-group">
                <asp:Label runat="server" Text="Home Phone" AssociatedControlID="HomePhone2" MaxLength="8" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="HomePhone2" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="HomePhone2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Home phone is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
                <asp:Label runat="server" Text="Home Fax" AssociatedControlID="HomeFax2" MaxLength="8" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="HomeFax2" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" Text="Business Phone" AssociatedControlID="BusinessPhone2" MaxLength="8" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="BusinessPhone2" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                  <asp:RequiredFieldValidator runat="server" ControlToValidate="BusinessPhone2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Business phone is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
                <asp:Label runat="server" Text="Mobile Phone" AssociatedControlID="MobilePhone2" MaxLength="8" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="MobilePhone2" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                   <asp:RequiredFieldValidator runat="server" ControlToValidate="MobilePhone2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Mobile phone is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
            </div>

            <hr />

            <div class="form-group">
                <asp:Label runat="server" Text="Country of Citizenship" AssociatedControlID="Citizenship2" MaxLength="70" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="Citizenship2" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="Citizenship2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Country of citizen is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
                <asp:Label runat="server" Text="Country of legal residence" AssociatedControlID="Residence2" MaxLength="70" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="Residence2" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="Residence2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Country of legal residence is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
            </div>

             <div class="form-group">
                <asp:Label runat="server" Text="HKID/Passport#" AssociatedControlID="HKID2" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="HKID2" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="HKID2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="HKID/passport number is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" Text="Passport country of issue" AssociatedControlID="PassportCountry2" MaxLength="70" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="PassportCountry2" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                  <asp:RequiredFieldValidator runat="server" ControlToValidate="PassportCountry2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Passport country of issue is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
            </div>

            <hr />
            <hr />

            <h4>Employment Information</h4>
            <div class="form-group">
                <asp:Label runat="server" Text="Employment Status: " CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlemploy2" runat="server" CssClass="form-control">
                        <asp:ListItem Value="">Employment Status</asp:ListItem>
                        <asp:ListItem Value="employed">Employed</asp:ListItem>
                        <asp:ListItem Value="selfEmployed">Self-employed</asp:ListItem>
                        <asp:ListItem Value="retired">Retired</asp:ListItem>
                        <asp:ListItem Value="student">Student</asp:ListItem>
                        <asp:ListItem Value="notEmployed">Not Employed</asp:ListItem>
                        <asp:ListItem Value="homemaker">Homemaker</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlemploy2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Employment status is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Specific occupation" AssociatedControlID="specificOccupation2" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="specificOccupation2" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                </div>
                <asp:Label runat="server" Text="Years with employer" AssociatedControlID="yearEmploy2" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="yearEmploy2" runat="server" CssClass="form-control" MaxLength="25"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Employer name" AssociatedControlID="employerName2" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="employerName2" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                </div>
                <asp:Label runat="server" Text="Employer phone" AssociatedControlID="employerPhone2" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="employerPhone2" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Nature of Business" AssociatedControlID="busiNature2" CssClass="control-label col-md-2"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="busiNature2" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                </div>
            </div>

            <hr />
            <hr />

            <h4>Disclosures and Regulatory Information</h4>
            <div class="form-group">
                <asp:Label runat="server" Text="Employed by a registered securities broker/dealer, investment advisor, bank or other financial insitution" CssClass="control-label col-md-8"></asp:Label>
                <div class="col-md-4"><asp:DropDownList ID="ddlFI2" runat="server" CssClass="form-control">
                    <asp:ListItem Value="">(Yes/No)</asp:ListItem>
                    <asp:ListItem Value="no">No</asp:ListItem>
                    <asp:ListItem Value="yes">Yes</asp:ListItem>
                  </asp:DropDownList>
                   <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlFI2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Financial employment status is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                 </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Directer, 10% shareholder or policy-making officer of a public traded company" CssClass="control-label col-md-8"></asp:Label>
                <div class="col-md-4"><asp:DropDownList ID="ddlPT2" runat="server" CssClass="form-control">
                    <asp:ListItem Value="">(Yes/No)</asp:ListItem>
                    <asp:ListItem Value="no">No</asp:ListItem>
                    <asp:ListItem Value="yes">Yes</asp:ListItem>
                  </asp:DropDownList>
                     <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlPT2" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Company officer status is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Primary Source of Funds deposited to this Account" CssClass="control-label col-md-8"></asp:Label>
                <div class="col-md-4"><asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control">
                    <asp:ListItem Value="">Primary Source</asp:ListItem>
                    <asp:ListItem Value="savings">salary/wages/savings</asp:ListItem>
                    <asp:ListItem Value="investment">investment/capital gains</asp:ListItem>
                    <asp:ListItem Value="family">family/relatives/inheritance</asp:ListItem>
                    <asp:ListItem Value="others">Others</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Other" AssociatedControlID="otherPrimarySource" CssClass="control-label col-md-8"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="TextBox21" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                </div>
            </div>

            <hr />
            <hr />

        </asp:Panel>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Register" CssClass="btn btn-default" OnClick="CreateAccount" />
            </div>
        </div>
        
    </div>

</asp:Content>
