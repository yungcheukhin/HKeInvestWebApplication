<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="setAlert.aspx.cs" Inherits="HKeInvestWebApplication.ClientOnly.setAlert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>Set Alert</h2>

    <div class="form-horizontal">

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />

        <asp:Label ID="Label1" runat="server" CssClass="text-danger"></asp:Label>
        <asp:Label ID="Label2" runat="server"></asp:Label>

        <div class="form-group">
            <asp:Label runat="server" Text="Choose the Security you want to set alert on: " CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3"><asp:DropDownList ID="Stype" runat="server" CssClass="form-control" OnSelectedIndexChanged="Stype_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Value="">Security Type</asp:ListItem>
                <asp:ListItem Value="bond">Bond</asp:ListItem>
                <asp:ListItem Value="stock">Stock</asp:ListItem>
                <asp:ListItem Value="unit trust">Unit Trust</asp:ListItem>
            </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Stype" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Security type is required." Display="Dynamic" Text="*">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Text="" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3"><asp:DropDownList ID="Snamecode" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="Snamecode_SelectedIndexChanged">
            </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Snamecode" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Security name and code is required." Display="Dynamic" Text="*">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Text="High Value: " AssociatedControlID="highValue" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3">
            <asp:TextBox ID="highValue" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:CustomValidator ID="cvhigh" runat="server" ErrorMessage="At least one value should be inputed." OnServerValidate="cvhigh_ServerValidate" CssClass="text-danger">*</asp:CustomValidator>
                <asp:CustomValidator ID="cv1" runat="server" ErrorMessage="The high value must not lower or equal to the low value." OnServerValidate="cv1_ServerValidate" CssClass="text-danger">*</asp:CustomValidator>
                <asp:CustomValidator ID="cv2" runat="server" ErrorMessage="The high value must not higher or equal to the current price." OnServerValidate="cv2_ServerValidate" CssClass="text-danger">*</asp:CustomValidator>
            </div>
            <asp:Label runat="server" Text="Current Value: " CssClass="control-label col-md-2"></asp:Label>
            <asp:Label ID="curhigh" runat="server" CssClass="control-label col-md-1"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Text="Low Value: " AssociatedControlID="lowValue" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="lowValue" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:CustomValidator ID="cv3" runat="server" ErrorMessage="The low value must not lower or equal to the current price." OnServerValidate="cv3_ServerValidate" CssClass="text-danger">*</asp:CustomValidator>
            </div>
            <asp:Label runat="server" Text="Current Value: " CssClass="control-label col-md-2"></asp:Label>
            <asp:Label ID="curlow" runat="server" CssClass="control-label col-md-1"></asp:Label>
        </div>

        

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Set" CssClass="btn btn-default" OnClick="setAlertValue" />
            </div>
        </div>

    </div>

</asp:Content>
