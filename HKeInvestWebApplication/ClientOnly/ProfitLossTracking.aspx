<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProfitLossTracking.aspx.cs" Inherits="HKeInvestWebApplication.ClientOnly.ProfitLossTracking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Profit/Loss Tracking</h2>
        
        <div>
            <div>
                <asp:Label runat="server" AssociatedControlID="txtStockCode" Text="Stock Code:"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtStockCode" runat="server"></asp:TextBox>
            &nbsp;
                <asp:DropDownList ID="ddlSecurityType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSecurityType_SelectedIndexChanged">
                    <asp:ListItem Value="0">Security Type</asp:ListItem>
                    <asp:ListItem Value="all">All</asp:ListItem>
                    <asp:ListItem Value="bond">Bond</asp:ListItem>
                    <asp:ListItem Value="stock">Stock</asp:ListItem>
                    <asp:ListItem Value="unit trust">Unit Trust</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                </asp:Label>
                <asp:Label ID="lblAccountNumber" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblClientName" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblResultMessage" runat="server" Visible="False"></asp:Label>
            </div>
            <div>
                <asp:GridView ID="gvProfitLossTracking" runat="server" Visible="False" AutoGenerateColumns="False" OnSelectedIndexChanged="gvProfitLossTracking_Sorting">
                    <Columns>
                        <asp:BoundField DataField="type" HeaderText="Type" ReadOnly="True" SortExpression="type" />
                        <asp:BoundField DataField="code" HeaderText="Code" ReadOnly="True" SortExpression="code" />
                        <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" SortExpression="name" />
                        <asp:BoundField DataField="shares" DataFormatString="{0:n2} " HeaderText="Shares" ReadOnly="True" SortExpression="shares" />
                        <asp:BoundField DataField="buy" DataFormatString="{0:n2} " HeaderText="Dollar Amount (Buy)" ReadOnly="True" SortExpression="buy" />
                        <asp:BoundField DataField="sell" DataFormatString="{0:n2} " HeaderText="Dollar Amount (Sell)" ReadOnly="True" SortExpression="sell" />
                        <asp:BoundField DataField="fee" DataFormatString="{0:n2} " HeaderText="Fees" ReadOnly="True" SortExpression="fee" />
                        <asp:BoundField DataField="profitloss" HeaderText="Profit/Loss" ReadOnly="True" SortExpression="profitloss" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
</asp:Content>
