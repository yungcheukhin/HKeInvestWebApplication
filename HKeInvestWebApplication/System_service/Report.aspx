<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="HKeInvestWebApplication.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Report</h2>

    <div>
        <asp:Label ID="lblAccountNumber" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblClientName" runat="server" Visible="False"></asp:Label>
        &nbsp;<asp:DropDownList ID="ddlReportType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged">
            <asp:ListItem Value="0">Report Type</asp:ListItem>
            <asp:ListItem Value="summary">Summary</asp:ListItem>
            <asp:ListItem Value="detail">Detail List</asp:ListItem>
            <asp:ListItem Value="status">Status List</asp:ListItem>
            <asp:ListItem Value="history">History List</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>

        <h4>Summary of Overall Security Holdings </h4>
        <asp:GridView ID="gvSummary" runat="server" AutoGenerateColumns="False" Visible="False">
            <Columns>
                <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="True" SortExpression="accountNumber" />
                <asp:BoundField DataField="firstName" HeaderText="First Name" ReadOnly="True" SortExpression="firstName" />
                <asp:BoundField DataField="lastName" HeaderText="Last Name" ReadOnly="True" SortExpression="lastName" />
                <asp:BoundField DataField="monetaryTotal" DataFormatString="{0:n2} " HeaderText="Total Monetary Value (HKD)" ReadOnly="True" SortExpression="monetaryTotal" />
                <asp:BoundField DataField="balance" DataFormatString="{0:n2} " HeaderText="Free Balance" ReadOnly="True" SortExpression="balance" />
                <asp:BoundField DataField="monetaryBond" DataFormatString="{0:n2} " HeaderText="Monetary Value (Bond)" ReadOnly="True" SortExpression="monetaryBond" />
                <asp:BoundField DataField="monetaryTrust" DataFormatString="{0:n2} " HeaderText="Monetary Value (Unit Trust)" ReadOnly="True" SortExpression="monetaryTrust" />
                <asp:BoundField DataField="monetaryStock" DataFormatString="{0:n2} " HeaderText="Monetary Value (Stock)" ReadOnly="True" SortExpression="monetaryStock" />
                <asp:BoundField DataField="date" HeaderText="Submission Date (Last Order)" ReadOnly="True" SortExpression="date" />
                <asp:BoundField DataField="monetaryLast" DataFormatString="{0:n2} " HeaderText="Monetary Value (Last Order)" ReadOnly="True" SortExpression="monetaryLast" />
            </Columns>
        </asp:GridView>

    </div>

    <div>

        <br />
        <h4>Details of Stocks </h4>
        <asp:GridView ID="gvDetailStock" runat="server" AutoGenerateColumns="False" Visible="False">
            <Columns>
                <asp:BoundField DataField="code" HeaderText="Code" ReadOnly="True" SortExpression="code" />
                <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" SortExpression="name" />
                <asp:BoundField DataField="shares" DataFormatString="{0:n2}" HeaderText="Shares" ReadOnly="True" SortExpression="shares" />
                <asp:BoundField DataField="base" HeaderText="Base" ReadOnly="True" SortExpression="base" />
                <asp:BoundField DataField="price" DataFormatString="{0:n2} " HeaderText="Price" ReadOnly="True" SortExpression="price" />
                <asp:BoundField DataField="monetary" DataFormatString="{0:n2}" HeaderText="Total Monetary Value" ReadOnly="True" SortExpression="monetary" />
                <asp:BoundField />
            </Columns>
        </asp:GridView>

    </div>

    <div>

        <br />
        <h4>Details of Bonds </h4>
        <asp:GridView ID="gvDetailBond" runat="server" AutoGenerateColumns="False" Visible="False">
            <Columns>
                <asp:BoundField DataField="code" HeaderText="Code" ReadOnly="True" SortExpression="code" />
                <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" SortExpression="name" />
                <asp:BoundField DataField="shares" DataFormatString="{0:n2}" HeaderText="Shares" ReadOnly="True" SortExpression="shares" />
                <asp:BoundField DataField="base" HeaderText="Base" ReadOnly="True" SortExpression="base" />
                <asp:BoundField DataField="price" DataFormatString="{0:n2} " HeaderText="Price" ReadOnly="True" SortExpression="price" />
                <asp:BoundField DataField="monetary" DataFormatString="{0:n2}" HeaderText="Total Monetary Value" ReadOnly="True" SortExpression="monetary" />
                <asp:BoundField />
            </Columns>
        </asp:GridView>

    </div>

    <div>

        <br />
        <h4>Details of Unit Trust </h4>
        <asp:GridView ID="gvDetailTrust" runat="server" AutoGenerateColumns="False" Visible="False">
            <Columns>
                <asp:BoundField DataField="code" HeaderText="Code" ReadOnly="True" SortExpression="code" />
                <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" SortExpression="name" />
                <asp:BoundField DataField="shares" DataFormatString="{0:n2}" HeaderText="Shares" ReadOnly="True" SortExpression="shares" />
                <asp:BoundField DataField="base" HeaderText="Base" ReadOnly="True" SortExpression="base" />
                <asp:BoundField DataField="price" DataFormatString="{0:n2} " HeaderText="Price" ReadOnly="True" SortExpression="price" />
                <asp:BoundField DataField="monetary" DataFormatString="{0:n2}" HeaderText="Total Monetary Value" ReadOnly="True" SortExpression="monetary" />
                <asp:BoundField />
            </Columns>
        </asp:GridView>

    </div>

    <div>

        <br />
        <h4>Status of Active Order(s) (Bond/Unit Trust)</h4>
        <p>
            <asp:GridView ID="gvStatusBond" runat="server" AutoGenerateColumns="False" Visible="False">
                <Columns>
                    <asp:BoundField DataField="reference" HeaderText="Reference Number" ReadOnly="True" SortExpression="reference" />
                    <asp:BoundField DataField="order" HeaderText="Order" ReadOnly="True" SortExpression="order" />
                    <asp:BoundField DataField="type" HeaderText="Type" ReadOnly="True" SortExpression="type" />
                    <asp:BoundField DataField="code" HeaderText="Code" ReadOnly="True" SortExpression="code" />
                    <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" SortExpression="name" />
                    <asp:BoundField DataField="date" HeaderText="Date" ReadOnly="True" SortExpression="date" />
                    <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True" SortExpression="status" />
                    <asp:BoundField DataField="dollarAmount" DataFormatString="{0:n2} " HeaderText="Dollar Amount (Buy)" ReadOnly="True" SortExpression="dollarAmount" />
                    <asp:BoundField DataField="shares" HeaderText="Shares (Sell)" ReadOnly="True" SortExpression="shares" />
                </Columns>
            </asp:GridView>
        </p>

    </div>

    <div>

        <br />
        <h4>Status of Active Order(s) (Stocks)</h4>
        <p>
            <asp:GridView ID="gvStatusStock" runat="server" AutoGenerateColumns="False" Visible="False">
                <Columns>
                    <asp:BoundField DataField="reference" HeaderText="Reference Number" ReadOnly="True" SortExpression="reference" />
                    <asp:BoundField DataField="order" HeaderText="Order" ReadOnly="True" SortExpression="order" />
                    <asp:BoundField DataField="type" HeaderText="Type" ReadOnly="True" SortExpression="type" />
                    <asp:BoundField DataField="code" HeaderText="Code" ReadOnly="True" SortExpression="code" />
                    <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" SortExpression="name" />
                    <asp:BoundField DataField="date" HeaderText="Date" ReadOnly="True" SortExpression="date" />
                    <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True" SortExpression="status" />
                    <asp:BoundField DataField="shares" HeaderText="Shares" ReadOnly="True" SortExpression="shares" />
                    <asp:BoundField DataField="price" DataFormatString="{0:n2}" HeaderText="Highest Buying Price/Lowest Selling Price (Limit Order)" ReadOnly="True" SortExpression="price" />
                    <asp:BoundField />
                    <asp:BoundField DataField="stopPrice" DataFormatString="{0:n2}" HeaderText="Stop Price (Stop Order)" ReadOnly="True" SortExpression="stopPrice" />
                    <asp:BoundField DataField="expiryDate" HeaderText="Expiry Date" ReadOnly="True" SortExpression="expiryDate" />
                </Columns>
            </asp:GridView>
        </p>

    </div>

     <div>

        <br />
        <h4>Order History</h4>
         <p>
             <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="False" Visible="False">
                 <Columns>
                     <asp:BoundField DataField="referenceNumber" HeaderText="Reference Number" ReadOnly="True" SortExpression="referenceNumber" />
                     <asp:BoundField DataField="buyOrSell" HeaderText="Order" ReadOnly="True" SortExpression="buyOrSell" />
                     <asp:BoundField DataField="securityType" HeaderText="Type" ReadOnly="True" SortExpression="securityType" />
                     <asp:BoundField DataField="securityCode" HeaderText="Code" ReadOnly="True" SortExpression="securityCode" />
                     <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" SortExpression="name" />
                     <asp:BoundField DataField="dateSubmitted" HeaderText="Date" ReadOnly="True" SortExpression="dateSubmitted" />
                     <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True" SortExpression="status" />
                     <asp:BoundField DataField="shares" HeaderText="Shares" ReadOnly="True" SortExpression="shares" />
                     <asp:BoundField DataField="amount" DataFormatString="{0:n2}" HeaderText="Dollar Amount" ReadOnly="True" SortExpression="amount" />
                     <asp:BoundField DataField="fees" DataFormatString="{0:n2}" HeaderText="Fees" ReadOnly="True" SortExpression="fees" />
                     <asp:BoundField DataField="transactionNumber" DataFormatString="{0:n2}" HeaderText="Transaction Number" ReadOnly="True" SortExpression="transactionNumber" />
                     <asp:BoundField DataField="shares" HeaderText="Shares" ReadOnly="True" SortExpression="shares" />

                     <asp:BoundField DataField="priceShare" DataFormatString="{0:n2}" HeaderText="Price Per Share " ReadOnly="True" SortExpression="priceShare" />

                 </Columns>
             </asp:GridView>
         </p>
       
    </div>

</asp:Content>
