<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="HKeInvestWebApplication.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>Additional feature</h2>
    <h3>The description of our additional feature.</h3>
    <p>This feature is to provide a function for user of our system to view the history
         of the selected security. For every security, our system will record the closing
         price of security in the market. That is, the system will record the security
         price in the stock market every weekday at 5:00pm and store into the system table.
         There are two kind of graphs, the 7-day graph and the 30-day graph.
         For 7-day graph, it shows the trend of price growth or decline for a security for the last 7 day.
         For 30-day graph, it shows the trend of price growth or decline for a security for the last month.
         The graph provide a reference for you to estimate the short term and long term growth or decline
         trend for a security. You can combine the graph and the report to have a thorough decision
         for further security trading.
         Due to the limit of the server storage, only records, which current clients have owned,
         of security are exist. Further record will be made for other security when any of our new or old clients
        ownd it.  
    </p>
</asp:Content>
