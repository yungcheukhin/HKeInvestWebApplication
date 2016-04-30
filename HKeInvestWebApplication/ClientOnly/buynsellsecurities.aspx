<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="buynsellsecurities.aspx.cs" Inherits="HKeInvestWebApplication.buynsellsecurities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Buy and Sell Securities</h2>

     <div class="form-horizontal">
        <div class="form-group">
            <asp:Label runat="server" Text="Security Type: " AssociatedControlID="Stype" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3"><asp:DropDownList ID="Stype" runat="server" CssClass="form-control">
                <asp:ListItem Value="">Security Type</asp:ListItem>
                <asp:ListItem Value="bond">Bond</asp:ListItem>
                <asp:ListItem Value="stock">Stock</asp:ListItem>
                <asp:ListItem Value="unitTrust">Unit Trust</asp:ListItem>
            </asp:DropDownList></div>
        </div>

        <div class="form-horizontal">


        </div>

         <div class="form-horizontal">


        </div>





</asp:Content>
