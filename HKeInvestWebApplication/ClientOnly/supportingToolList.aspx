<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="supportingToolList.aspx.cs" Inherits="HKeInvestWebApplication.Cover_page.ClientSupportingTool" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>Choose Your Service</h2>

    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label ID="manageInfroLabel" runat="server" Text="Manage your account information" class="control-label col-md-4"></asp:Label>
            <asp:Button ID="manageInfroBtn" runat="server" Text="Manage Information" class="btn-default col-md-4" OnClick="manageInfroBtn_Click" />
        </div>

        <div class="form-group">
            <asp:Label ID="profitLossLabel" runat="server" Text="Track your profit-loss" class="control-label col-md-4"></asp:Label>
            <asp:Button ID="profitLossBtn" runat="server" Text="Profit/Loss Tracking" class="btn-default col-md-4" OnClick="profitLossBtn_Click"  />
        </div>

        <div class="form-group">
            <asp:Label ID="alertLabel" runat="server" Text="Set alert for your securities" class="control-label col-md-4"></asp:Label>
            <asp:Button ID="alertBtn" runat="server" Text="Set Alert" class="btn-default col-md-4" OnClick="alertBtn_Click" />
        </div>

        <div class="form-group">
            <asp:Label ID="reportLabel" runat="server" Text="Generate a report about your account" class="control-label col-md-4"></asp:Label>
            <asp:Button ID="reportBtn" runat="server" Text="Generate Report" class="btn-default col-md-4" OnClick="reportBtn_Click"  />
        </div>

        <div class="form-group">
            <asp:Label ID="additionFeatureLabel" runat="server" Text="Generate securities trend graph" class="control-label col-md-4"></asp:Label>
            <asp:Button ID="additionFeatureBtn" runat="server" Text="Generate Graph" class="btn-default col-md-4" OnClick="additionFeatureBtn_Click"   />
        </div>

    </div>
</asp:Content>
