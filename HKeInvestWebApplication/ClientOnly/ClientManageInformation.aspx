<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientManageInformation.aspx.cs" Inherits="HKeInvestWebApplication.ManageInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
       <h2><%: Title %>Manage Account Information</h2>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" EnableClientScript="False" />

        <div class="form-group">
            
            <div class="col-md-4">   
                <asp:Label runat="server" Text="Account Type"  CssClass="control-label col-md-2"></asp:Label>
                <asp:Label ID="AccountType" runat="server" Text="" CssClass="control-label col-md-2"></asp:Label>

                <asp:Label runat="server" Text="Account Number"  CssClass="control-label col-md-2"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="" CssClass="control-label col-md-2"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
           
             </div>

            <div class="col-md-4">
                <asp:Label runat="server" Text="Account #" AssociatedControlID="AccountNumber" CssClass="control-label col-md-2"></asp:Label>

              </div>
        </div>
        <asp:Button ID="viewInfro" runat="server" Text="Refresh Information" OnClick="viewInfro_Click" />


</asp:Content>
