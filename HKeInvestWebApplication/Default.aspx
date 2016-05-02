<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HKeInvestWebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2 style="font-weight: bold">Hong Kong Electronic Investments LLC</h2>
        <p> &nbsp;&nbsp;</p>
        <h3>Security Portfolio Management System </h3>
        <p> &nbsp;&nbsp;</p>
        <h4>This system provide a user friendly interface for vistor to search for different securities. For our clients, we provide various
            supporting tool to convience the trading of securities.</h4>
        <h4>To regisier as our client and enjoy further servies, please download the application form below. When you complete the form,
             either taken to or mail to HKeInvest's office for processing. If the application is success, we will inform you an unique account number for creating 
            login account.
        </h4>
        <p> &nbsp;&nbsp;</p>
        <asp:Button ID="PDF_download" runat="server" OnClick="Button1_Click" Text="Download Application Form" BackColor="#336699" BorderColor="#669999" Font-Bold="True" Font-Size="Large" ForeColor="Black" />
        <asp:Label ID="failLabel" runat="server" Visible="false" Text="Download Fail, Please Try Again!" />
    </div>

</asp:Content>
