<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Graph.aspx.cs" Inherits="HKeInvestWebApplication.System_service.Graph" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Graph</h2>

    <div class="form-horizontal">

        <div class="form-group">
            <asp:Label ID="userNameSearch" runat="server" Text="Type security code (which you hold) to view " class="col-md-8"></asp:Label>
        </div>

        <div class="form-group">
            <asp:TextBox ID="userNameSearchBox" runat="server" class="col-md-4"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Button ID="userNameSearchBtn" runat="server" Text="Generate Graph" class="btn-default col-md-3" OnClick="userNameSearchBtn_Click"/>
        </div>

        <div class="form-group">
            <asp:Panel ID="graphTable" runat="server" Visible="False">



            </asp:Panel>
        </div>

    </div>
</asp:Content>
