<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="buynsellsecurities.aspx.cs" Inherits="HKeInvestWebApplication.buynsellsecurities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Buy and Sell Securities</h2>

     <div class="form-horizontal">

        <div class="form-group">
          <%--try for pdf--%>
<%--            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="..\..\01Introduction.pdf">PDF</asp:HyperLink>--%>
            <asp:Label runat="server" Text="Security Type: " AssociatedControlID="Stype" CssClass="control-label col-md-3"></asp:Label>
            <div class="col-md-4"><asp:DropDownList ID="Stype" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="cvStocktype_Validate" OnTextChanged="cvStocktype_Validate">
                <asp:ListItem Value="">Security Type</asp:ListItem>
                <asp:ListItem Value="bond">Bond</asp:ListItem>
                <asp:ListItem Value="stock">Stock</asp:ListItem>
                <asp:ListItem Value="unitTrust">Unit Trust</asp:ListItem>
            </asp:DropDownList></div>
            <asp:CustomValidator ID="cvstocktype" runat="server" ErrorMessage="Please choose one security type." ControlToValidate="Stype" CssClass="text-danger" OnServerValidate="cvStocktype_Validate"></asp:CustomValidator>

        </div>
            <div class="form-group">
            <asp:Panel ID="stockt" runat="server" Visible="False">
                <asp:Label runat="server" Text="Stock Order Type: " AssociatedControlID="stockorderdd" CssClass="control-label col-md-3"></asp:Label>

                <div class="col-md-4"><asp:DropDownList ID="stockorderdd" runat="server" CssClass="form-control" OnSelectedIndexChanged="stockorder">
                <asp:ListItem Value="">Stock Order Type</asp:ListItem>
                <asp:ListItem Value="market">Market</asp:ListItem>
                <asp:ListItem Value="limit">Limit</asp:ListItem>
                <asp:ListItem Value="stop">Stop</asp:ListItem>
                <asp:ListItem Value="stoplimit">Stop limit</asp:ListItem>
            </asp:DropDownList>
                </div>
             </asp:Panel>
            </div>
                



       
            <div class="form-group">
             <asp:Label runat="server" Text="Security Code: " AssociatedControlID="Scode" CssClass="control-label col-md-3"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="Scode" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Scode" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Security code is required." Display="Dynamic"></asp:RequiredFieldValidator>
                
            </div>
        </div>

       
        <%--Buy Sell operation dropdown list--%>
        <div class="form-group">
            <asp:Label runat="server" Text="Operation: " AssociatedControlID="Stype" CssClass="control-label col-md-3"></asp:Label>
            <div class="col-md-4"><asp:DropDownList ID="opdd" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="buysellcheck">
                <asp:ListItem Value="">Operation Type</asp:ListItem>
                <asp:ListItem Value="buy">BUY</asp:ListItem>
                <asp:ListItem Value="sell">SELL</asp:ListItem>

            </asp:DropDownList>
            </div>
        </div>

        <%--Quantity of Shares to buy textbox--%>
        <div class="form-group">
            <asp:Panel ID="qofshares_panel" runat="server" Visible="False">
            <asp:Label runat="server" Text="Quantity of Shares to buy: " AssociatedControlID="qofshares" CssClass="control-label col-md-3"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="qofshares" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            </asp:Panel>
        </div>

        <%--Expiry Date Textbox--%>
        <div class="form-group">
             <asp:Label runat="server" Text="Expiry Date " AssociatedControlID="expdate" CssClass="control-label col-md-3"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="expdate" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator runat="server" ControlToValidate="expdate" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Expiry date is not valid." ValidationExpression="^([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$" Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="expdate" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Expiry date is required." Display="Dynamic"></asp:RequiredFieldValidator>

            </div>
        </div>


        <div class="form-group">
            <asp:Button ID="proceed" runat="server" Text="Proceed" />


        </div>

    </div>

</asp:Content>
