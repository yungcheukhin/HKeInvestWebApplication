<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="buynsellsecurities.aspx.cs" Inherits="HKeInvestWebApplication.buynsellsecurities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Buy and Sell Securities</h2>

     <div class="form-horizontal">
        <div class="form-group">
            <asp:Label runat="server" Text="Security Type: " AssociatedControlID="Stype" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3"><asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True">
                <asp:ListItem Value="">Security Type</asp:ListItem>
                <asp:ListItem Value="bond">Bond</asp:ListItem>
                <asp:ListItem Value="stock">Stock</asp:ListItem>
                <asp:ListItem Value="unitTrust">Unit Trust</asp:ListItem>
            </asp:DropDownList></div>
             <asp:Panel ID="Panel1" runat="server">
                <div class="col-md-3"><asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                <asp:ListItem Value="">Stock Order Type</asp:ListItem>
                <asp:ListItem Value="market">Market</asp:ListItem>
                <asp:ListItem Value="limit">Limit</asp:ListItem>
                <asp:ListItem Value="stop">Stop</asp:ListItem>
                <asp:ListItem Value="stoplimit">Stop limit</asp:ListItem>
            </asp:DropDownList></div>


             </asp:Panel>


        </div>

        <div class="form-horizontal">
             <asp:Label runat="server" Text="Security Code: " AssociatedControlID="Scode" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="Scode" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Scode" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Security code is required." Display="Dynamic"></asp:RequiredFieldValidator>
                
            </div>

        </div>

         <div class="form-horizontal">
            
            <div class="col-md-3"><asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" AutoPostBack="True">
                <asp:ListItem Value="">Stock Order Type</asp:ListItem>
                <asp:ListItem Value="market">Market</asp:ListItem>
                <asp:ListItem Value="limit">Limit</asp:ListItem>
                <asp:ListItem Value="stop">Stop</asp:ListItem>
                <asp:ListItem Value="stoplimit">Stop limit</asp:ListItem>
            </asp:DropDownList></div>

        </div>

        <div class ="form-horizontal">
            <asp:Button ID="Button1" runat="server" Text="Buy" />
            <asp:Button ID="Button2" runat="server" Text="Sell" />
        </div>

</asp:Content>
