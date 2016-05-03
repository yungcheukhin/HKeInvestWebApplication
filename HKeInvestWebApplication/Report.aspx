<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="HKeInvestWebApplication.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Report</h2>

    <div>
        <asp:Label ID="lblAccountNumber" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblClientName" runat="server" Visible="False"></asp:Label>
    </div>
    <div>

        <h4>Summary of Overall Security Holdings </h4>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="accountNumber" HeaderText="Account Number" ReadOnly="True" SortExpression="accountNumber" />
                <asp:BoundField DataField="firstName" HeaderText="First Name" ReadOnly="True" SortExpression="firstName" />
                <asp:BoundField DataField="lastName" HeaderText="Last Name" ReadOnly="True" SortExpression="lastName" />
                <asp:BoundField DataField="monetary" DataFormatString="{0:n2} " HeaderText="Total Monetary Value (HKD)" ReadOnly="True" SortExpression="monetary" />
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
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
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
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False">
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
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False">
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
            <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False">
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
            <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False">
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
             <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="False">
                 <Columns>
                     <asp:BoundField DataField="reference" HeaderText="Reference Number" ReadOnly="True" SortExpression="reference" />
                     <asp:BoundField DataField="order" HeaderText="Order" ReadOnly="True" SortExpression="order" />
                     <asp:BoundField DataField="type" HeaderText="Type" ReadOnly="True" SortExpression="type" />
                     <asp:BoundField DataField="code" HeaderText="Code" ReadOnly="True" SortExpression="code" />
                     <asp:BoundField DataField="name" HeaderText="Name" ReadOnly="True" SortExpression="name" />
                     <asp:BoundField DataField="date" HeaderText="Date" ReadOnly="True" SortExpression="date" />
                     <asp:BoundField DataField="status" HeaderText="Status" ReadOnly="True" SortExpression="status" />
                     <asp:BoundField DataField="shares" HeaderText="Shares" ReadOnly="True" SortExpression="shares" />
                     <asp:BoundField DataField="dollarAmount" DataFormatString="{0:n2}" HeaderText="Dollar Amount" ReadOnly="True" SortExpression="dollarAmount" />
                     <asp:BoundField DataField="fees" DataFormatString="{0:n2}" HeaderText="Fees" ReadOnly="True" SortExpression="fees" />
                     <asp:BoundField DataField="transaction" DataFormatString="{0:n2}" HeaderText="Transaction Number" ReadOnly="True" SortExpression="transaction" />
                     <asp:BoundField DataField="shares" HeaderText="Shares" ReadOnly="True" SortExpression="shares" />

                     <asp:BoundField DataField="priceShare" DataFormatString="{0:n2}" HeaderText="Price Per Share " ReadOnly="True" SortExpression="priceShare" />

                 </Columns>
             </asp:GridView>
         </p>
       
    </div>

</asp:Content>
