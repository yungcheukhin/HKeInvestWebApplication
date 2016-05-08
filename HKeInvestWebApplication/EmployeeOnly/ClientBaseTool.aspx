<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientBaseTool.aspx.cs" Inherits="HKeInvestWebApplication.EmployeeOnly.ClientBaseTool" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>Use Client Service</h2>

    <div class="form-horizontal">
       
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
