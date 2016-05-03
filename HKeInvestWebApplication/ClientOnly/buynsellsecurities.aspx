<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="buynsellsecurities.aspx.cs" Inherits="HKeInvestWebApplication.buynsellsecurities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Buy and Sell Securities</h2>

     <div class="form-horizontal">

         <asp:Label ID="error" runat="server" CssClass="text-danger"></asp:Label>
         <hr />

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


        <%--Security Code Textbox--%>
            <div class="form-group">
             <asp:Label runat="server" Text="Security Code: " AssociatedControlID="Scode" CssClass="control-label col-md-3"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="Scode" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Scode" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Security code is required." Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>




         <%--Stock Order Type Panel: dropdownlist--%>
            <asp:Panel ID="stocktypePanel" runat="server" Visible="False">
            <div class="form-group">
                <asp:Label runat="server" Text="Stock Order Type:" AssociatedControlID="stockorderdd" CssClass="control-label col-md-3"></asp:Label>
                <div class="col-md-4"><asp:DropDownList ID="stockorderdd" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="stockorder">
                <asp:ListItem Value="">Stock Order Type</asp:ListItem>
                <asp:ListItem Value="market">Market</asp:ListItem>
                <asp:ListItem Value="limit">Limit</asp:ListItem>
                <asp:ListItem Value="stop">Stop</asp:ListItem>
                <asp:ListItem Value="stoplimit">Stop limit</asp:ListItem>
                </asp:DropDownList>
                </div>
            </div>
             </asp:Panel>

                
        <%--Stock buy Panel--%>
        <asp:Panel ID="stockbuyPanel" runat="server" Visible="False">
                 <div class="form-group">
                  <asp:Label runat="server" Text="High Price:" AssociatedControlID="highPrice" CssClass="control-label col-md-3"></asp:Label>
                  <div class="col-md-4">
                      <asp:TextBox ID="highPrice" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  </div>
            <div class="form-group">
            <asp:Label runat="server" Text="Stop Price:" AssociatedControlID="stopPrice" CssClass="control-label col-md-3"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="stopPrice" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="All or none:" AssociatedControlID="allornonecheck" CssClass="control-label col-md-3"></asp:Label>
                <div class="col-md-4"><asp:DropDownList ID="allornonecheck" runat="server" CssClass="form-control" AutoPostBack="true">
                    <asp:ListItem Value="">All or none</asp:ListItem>
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                    <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

        </asp:Panel>

        <%--Expiry Date dropdownlist--%>
        <asp:Panel ID="expdatePanel" runat="server" Visible="False">
            <div class="form-group">
                    <asp:Label runat="server" Text="Expiry Date (days after)" AssociatedControlID="expdate" CssClass="control-label col-md-3"></asp:Label>
                    <div class="col-md-4"><asp:DropDownList ID="expdate" runat="server" CssClass="form-control" AutoPostBack="true">
                    <asp:ListItem Value="">Expiry Date</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="expdate" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Expiry date is required." Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>

        </asp:Panel>

        <%--Panel for unit trust buy--%>
         <asp:Panel ID="utbuyPanel" runat="server">
            <div class="form-group">
            <asp:Label runat="server" Text="Amount to buy (HKD): " AssociatedControlID="amtofut" CssClass="control-label col-md-3"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="amtofut" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            </div>
         </asp:Panel>
       
        <%-- Panel for bond buy amount--%>
       <asp:Panel ID="bondamountPanel" runat="server" Visible="False">
            <div class ="form-group">
             <asp:Label runat="server" Text="Amount to buy (HKD): " AssociatedControlID="amtofBond" CssClass="control-label col-md-3"></asp:Label>
             <div class="col-md-4"><asp:TextBox ID="amtofbond" runat="server" CssClass="form-control"></asp:TextBox>
             </div>
            </div>
       </asp:Panel>

        <%--Quantity of Shares to buy stock shares Panel: textbox--%>
        <div class="form-group">
            <asp:Panel ID="qofsharesPanel" runat="server" Visible="False">
            <asp:Label runat="server" Text="Quantity of Shares to buy: " AssociatedControlID="qofshares" CssClass="control-label col-md-3"></asp:Label>
            <div class="col-md-4"><asp:TextBox ID="qofshares" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            </asp:Panel>
        </div>

         <%--Panel for sell bond--%>
         <div class="form-group">
             <asp:Panel ID="sellbondPanel" runat="server" Visible="false">
                 <asp:Label runat="server" Text="Number of Shares to sell: " AssociatedControlID="numofshares" CssClass="control-label col-md-3"></asp:Label>
                 <div class="col-md-4"><asp:TextBox ID="numofshares" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
             </asp:Panel>

         </div>

         <%--Panel for sell stock--%>
         <asp:Panel ID="sellstockPanel" runat="server" Visible="false">
             <div class="form-group">
                <asp:Label runat="server" Text="Number of Shares to sell: " AssociatedControlID="numofsellshares" CssClass="control-label col-md-3"></asp:Label>
                <div class="col-md-4"><asp:TextBox ID="numofsellshares" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
             </div>
             <div class="form-group">
                  <asp:Label runat="server" Text="Low Price:" AssociatedControlID="lowPrice" CssClass="control-label col-md-3"></asp:Label>
                  <div class="col-md-4">
                      <asp:TextBox ID="lowPrice" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  </div>
            <div class="form-group">
            <asp:Label runat="server" Text="Stop Price:" AssociatedControlID="sellstopPrice" CssClass="control-label col-md-3"></asp:Label>
            <div class="col-md-4">
                <asp:TextBox ID="sellstopPrice" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="All or none:" AssociatedControlID="sellallornonecheck" CssClass="control-label col-md-3"></asp:Label>
                <div class="col-md-4"><asp:DropDownList ID="sellallornonecheck" runat="server" CssClass="form-control" AutoPostBack="true">
                    <asp:ListItem Value="">All or none</asp:ListItem>
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                    <asp:ListItem Value="N">No</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
         </asp:Panel>


         <%--Panel for sell unitTrust--%>
         <asp:Panel ID="sellunitTrust" runat="server" Visible="false">
             <div class="form-group">
             <asp:Label runat="server" Text="Number of shares to sell:" AssociatedControlID="numofutshares" CssClass="control-label col-md-3"></asp:Label>
            <div class="col-md-4">
            <asp:TextBox ID="numofutshares" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
             </div>
        </asp:Panel>

        


        <div class="col-md-offset-2 col-md-4">
            <asp:Button ID="proceed" runat="server" CssClass="form-control" Text="Proceed" OnClick="totalcheck" />
        </div>

    </div>

</asp:Content>
