<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="HKeInvestWebApplication.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>Additional feature</h2>
    <h3>The description of our additional feature.</h3>
    <p>This feature is to provide a function for user of the web to view the history
         of the selected security. For every security, the system will record the closing
         price of security in the market. That is, the system will record the security
         price in the stock market every weekday at 5:00pm and store into the system table.
         While due to the huge amount of existing security, the record of the security will
         be clear every month in order to release memory for further record. The system will 
        periodically query the the price record and create a broken line graph of price against 
        day for every security. There are two kind of graphs, the 7-day graph and the 30-day graph.
         For 7-day graph, the system refresh everyday. The 7-day graph show the trend of price growth
         or decline for a security for the last 7 day. For 30-day graph, the system refresh monthly.
         The 30-day graph show the trend of price growth or decline for a security for the last month.
         The graph provide a reference for user to estimate the short term and long term growth or decline
         trend for a security. Client can combine the graph and the report to have a thorough decision
         for further security trading. Employee can only manually refresh graph if a client has made a request.</p>
</asp:Content>
