<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchSecurities.aspx.cs" Inherits="HKeInvestWebApplication.SearchSecurities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>Securities Searching</h2>

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

        <div class="form-group">
            <asp:Label runat="server" Text="Security Code: " AssociatedControlID="Scode" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="Scode" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Text="Security Name: " AssociatedControlID="Sname" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="Sname" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <hr />

        <asp:Panel ID="bondtable" runat="server" Visible="False">
            <asp:GridView ID="gvBond" runat="server"></asp:GridView>
        </asp:Panel>

        <asp:Panel ID="stocktable" runat="server" Visible="False">

        </asp:Panel>

        <asp:Panel ID="unittable" runat="server" Visible="False">

        </asp:Panel>

    </div>

</asp:Content>
