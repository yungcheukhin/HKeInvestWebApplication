<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="buynsellsecurities.aspx.cs" Inherits="HKeInvestWebApplication.buynsellsecurities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Buy and Sell Securities</h2>

     <div class="form-horizontal">

         <div class="form-group">
            <asp:Label runat="server" Text="Operation: " AssociatedControlID="Stype" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3"><asp:DropDownList ID="buynselldd" runat="server" CssClass="form-control" AutoPostBack="true">

                </asp:DropDownList>
            </div>


         </div>





        <div class="form-group">
          <%--try for pdf--%>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="..\..\01Introduction.pdf">PDF</asp:HyperLink>
            <asp:Label runat="server" Text="Security Type: " AssociatedControlID="Stype" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3"><asp:DropDownList ID="Stype" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="cvStocktype_Validate" OnTextChanged="cvStocktype_Validate">
                <asp:ListItem Value="">Security Type</asp:ListItem>
                <asp:ListItem Value="bond">Bond</asp:ListItem>
                <asp:ListItem Value="stock">Stock</asp:ListItem>
                <asp:ListItem Value="unitTrust">Unit Trust</asp:ListItem>
            </asp:DropDownList></div>
            <asp:CustomValidator ID="cvstocktype" runat="server" ErrorMessage="Please choose one security type." ControlToValidate="Stype" CssClass="text-danger" OnServerValidate="cvStocktype_Validate"></asp:CustomValidator>

                <asp:Panel ID="stockt" runat="server" Visible="False">
                <div class="form-group">
                <div class="col-md-3"><asp:DropDownList ID="stockorderdd" runat="server" CssClass="form-control" OnSelectedIndexChanged="stockorder">
                <asp:ListItem Value="">Stock Order Type</asp:ListItem>
                <asp:ListItem Value="market">Market</asp:ListItem>
                <asp:ListItem Value="limit">Limit</asp:ListItem>
                <asp:ListItem Value="stop">Stop</asp:ListItem>
                <asp:ListItem Value="stoplimit">Stop limit</asp:ListItem>
            </asp:DropDownList>
                </div>
                </div>

             </asp:Panel>
        </div>


        <div class="form-horizontal">
            <div class="form-group">
             <asp:Label runat="server" Text="Security Code: " AssociatedControlID="Scode" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3">
                <asp:TextBox ID="Scode" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Scode" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Security code is required." Display="Dynamic"></asp:RequiredFieldValidator>
                
            </div>

        </div>
        </div>

         <div class="form-horizontal">


        </div>

        <div class ="form-horizontal">
            <div class="form-group">
            <asp:Label runat="server" Text="Operation: " AssociatedControlID="Stype" CssClass="control-label col-md-2"></asp:Label>
            <div class="col-md-3"><asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged>
                <asp:ListItem Value="">Operation Type</asp:ListItem>
                <asp:ListItem Value="buy">Buy</asp:ListItem>
                <asp:ListItem Value="sell">Sell</asp:ListItem>

            </asp:DropDownList>
            </div>
        </div>
        </div>

    </div>

</asp:Content>
