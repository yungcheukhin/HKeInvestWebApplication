<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HKeInvestWebApplication.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>Register User Log-in Account</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new client account</h4>
        <asp:ValidationSummary runat="server" CssClass="text-danger" EnableClientScript="False" />

        <asp:Label ID="lbltestemail1" runat="server" CssClass="text-danger"></asp:Label>
        <asp:Label ID="lbltestemail2" runat="server" CssClass="text-danger"></asp:Label>

        <div class="form-group">
            <asp:Label ID="lbltest" runat="server" CssClass="text-danger"></asp:Label>
        </div>

         <div class="form-group">
            <asp:Label runat="server" Text="Account #" AssociatedControlID="AccountNumber" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="AccountNumber" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                <asp:CustomValidator ID="cvAccountNumber" runat="server" ErrorMessage="The account number does not match the client's last name." ControlToValidate="AccountNumber" CssClass="text-danger" EnableClientScript="False" ValidateEmptyText="True" Display="Dynamic" OnServerValidate="cvAccountNumber_ServerValidate">*</asp:CustomValidator>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="AccountNumber" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Account # is required." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
            
            <asp:Label runat="server" Text="HKID/Passport#" AssociatedControlID="HKID" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="HKID" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="HKID" CssClass="text-danger" EnableClientScript="False" ErrorMessage="A HKID or Passport number is required." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <hr />

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
            <asp:Label runat="server" Text="User Name" AssociatedControlID="UserName" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="UserName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="UserName" CssClass="text-danger" EnableClientScript="False" ErrorMessage="User Name must contain at least 6 characters." ValidationExpression="^.{6,10}$" Display="Dynamic">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="UserName" CssClass="text-danger" EnableClientScript="False" ErrorMessage="User Name must contain only letters and digits." ValidationExpression="^[a-zA-Z0-9]+$" Display="Dynamic">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="text-danger" EnableClientScript="False" ErrorMessage="User Name is required." Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Text="Password" AssociatedControlID="Password" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Password is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Password" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Password must contain at least 8 characters." ValidationExpression="^(.{8,15})$" Display="Dynamic">*</asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Password" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Password must contain at least 2 nonalphanumeric characters. " ValidationExpression="^(?=.*(\W.*){2,}).*$" Display="Dynamic">*</asp:RegularExpressionValidator>
            </div>
        
            <asp:Label runat="server" Text="Confirm Password" AssociatedControlID="ConfirmPassword" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Confirm Password is required." Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Password and Confirm Password do not match." Display="Dynamic">*</asp:CompareValidator>
            </div>
        </div>

        <hr />

        <asp:Label runat="server" ID="lbltest1"></asp:Label>
        <asp:Label runat="server" ID="lbltest2"></asp:Label>
        <asp:Label runat="server" ID="lbltest3"></asp:Label>
        <asp:Label runat="server" ID="lbltest31"></asp:Label>
        <asp:Label runat="server" ID="lbltest4"></asp:Label>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>

    </div>
</asp:Content>
