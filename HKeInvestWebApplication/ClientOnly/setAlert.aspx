<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="setAlert.aspx.cs" Inherits="HKeInvestWebApplication.ClientOnly.setAlert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>Set Alert</h2>

    <div class="form-horizontal">

        <div class="form-group">
            <asp:Label runat="server" Text="High Value: " AssociatedControlID="highValue" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3">
            <asp:TextBox ID="highValue" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Text="Low Value: " AssociatedControlID="lowValue" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="lowValue" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Set" CssClass="btn btn-default" OnClick="setAlertValue" />
            </div>
        </div>

    </div>

</asp:Content>
