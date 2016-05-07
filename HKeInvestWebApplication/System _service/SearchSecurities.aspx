<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchSecurities.aspx.cs" Inherits="HKeInvestWebApplication.SearchSecurities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %>Securities Searching</h2>

    <div class="form-horizontal">
        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" EnableClientScript="False" />
        
        <div class="form-group">
            <asp:Label runat="server" Text="Security Type: " AssociatedControlID="Stype" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3"><asp:DropDownList ID="Stype" runat="server" CssClass="form-control">
                <asp:ListItem Value="">Security Type</asp:ListItem>
                <asp:ListItem Value="bond">Bond</asp:ListItem>
                <asp:ListItem Value="stock">Stock</asp:ListItem>
                <asp:ListItem Value="unit trust">Unit Trust</asp:ListItem>
            </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Stype" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Security type is required." Display="Dynamic" Text="*">*</asp:RequiredFieldValidator>
            </div>
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

        <asp:Label ID="lblerror" runat="server" CssClass="text-danger"></asp:Label>

        <hr />

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Search" CssClass="btn btn-default" OnClick="doSearch" />
            </div>
        </div>
        
        <hr />

        <asp:Panel ID="bondtable" runat="server" Visible="False">
            <asp:GridView ID="gvBond" runat="server" AutoGenerateColumns="false" OnSorting="gvBond_Sorting" AllowSorting="true" EnableViewState="true">
                <Columns>
                    <asp:BoundField DataField="code" HeaderText="Code" ReadOnly="true" SortExpression="code" />
                    <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="true" SortExpression="name" />
                    <asp:BoundField DataField="launchDate" HeaderText="Launch Date" ReadOnly="true" SortExpression="launchDate" />
                    <asp:BoundField DataField="base" HeaderText="Base" ReadOnly="true" SortExpression="base" />
                    <asp:BoundField DataField="size" HeaderText="Size" ReadOnly="true" SortExpression="size" />
                    <asp:BoundField DataField="price" HeaderText="Current Price" ReadOnly="true" SortExpression="price" />
                    <asp:BoundField DataField="sixMonths" HeaderText="Six Months" ReadOnly="true" SortExpression="sixMonths" />
                    <asp:BoundField DataField="oneYear" HeaderText="One Year" ReadOnly="true" SortExpression="oneYear" />
                    <asp:BoundField DataField="threeYears" HeaderText="Three Years" ReadOnly="true" SortExpression="threeYears" />
                    <asp:BoundField DataField="sinceLaunch" HeaderText="Since Launch" ReadOnly="true" SortExpression="sinceLaunch" />
                </Columns>
            </asp:GridView>
        </asp:Panel>

        <asp:Panel ID="stocktable" runat="server" Visible="False">
            <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="false" OnSorting="gvStock_Sorting" AllowSorting="true" EnableViewState="true">
                <Columns>
                    <asp:BoundField DataField="code" HeaderText="Code" ReadOnly="true" SortExpression="code" />
                    <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="true" SortExpression="name" />
                    <asp:BoundField DataField="close" HeaderText="Price/share" ReadOnly="true" SortExpression="close" />
                    <asp:BoundField DataField="changeDollar" HeaderText="Change Dollar" ReadOnly="true" SortExpression="changeDollar" />
                    <asp:BoundField DataField="changePercent" HeaderText="Change Percent" ReadOnly="true" SortExpression="changePercent" />
                    <asp:BoundField DataField="volume" HeaderText="Volume" ReadOnly="true" SortExpression="volume" />
                    <asp:BoundField DataField="high" HeaderText="High" ReadOnly="true" SortExpression="high" />
                    <asp:BoundField DataField="low" HeaderText="Low" ReadOnly="true" SortExpression="low" />
                    <asp:BoundField DataField="peRatio" HeaderText="Price/Earnings Ratio" ReadOnly="true" SortExpression="peRatio" />
                    <asp:BoundField DataField="yield" HeaderText="Yield" ReadOnly="true" SortExpression="yield" />
                </Columns>
            </asp:GridView>
        </asp:Panel>

        <asp:Panel ID="unittable" runat="server" Visible="False">
            <asp:GridView ID="gvUnitTrust" runat="server" AutoGenerateColumns="false" OnSorting="gvUnitTrust_Sorting" AllowSorting="true" EnableViewState="true">
                <Columns>
                    <asp:BoundField DataField="code" HeaderText="Code" ReadOnly="true" SortExpression="code" />
                    <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="true" SortExpression="name" />
                    <asp:BoundField DataField="launchDate" HeaderText="Launch Date" ReadOnly="true" SortExpression="launchDate" />
                    <asp:BoundField DataField="base" HeaderText="Base" ReadOnly="true" SortExpression="base" />
                    <asp:BoundField DataField="size" HeaderText="Size" ReadOnly="true" SortExpression="size" />
                    <asp:BoundField DataField="price" HeaderText="Price" ReadOnly="true" SortExpression="price" />
                    <asp:BoundField DataField="riskReturn" HeaderText="Risk/Return Rating" ReadOnly="true" SortExpression="riskReturn" />
                    <asp:BoundField DataField="sixMonths" HeaderText="Six Months" ReadOnly="true" SortExpression="sixMonths" />
                    <asp:BoundField DataField="oneYear" HeaderText="One Year" ReadOnly="true" SortExpression="oneYear" />
                    <asp:BoundField DataField="threeYears" HeaderText="Three Years" ReadOnly="true" SortExpression="threeYears" />
                    <asp:BoundField DataField="sinceLaunch" HeaderText="Since Launch" ReadOnly="true" SortExpression="sinceLaunch" />
                </Columns>
            </asp:GridView>
        </asp:Panel>

    </div>

</asp:Content>
