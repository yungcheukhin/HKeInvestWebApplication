<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Graph.aspx.cs" Inherits="HKeInvestWebApplication.System_service.Graph" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Graph</h2>

    <div class="form-horizontal">

        <div class="form-group">
            <asp:Label ID="securitySearch" runat="server" Text="Type security code (which you hold) to view " class="col-md-8"></asp:Label>
            <asp:TextBox ID="securitySearchBox" runat="server" class="col-md-4"></asp:TextBox>        
        </div>

        <div class="form-group">
            <asp:Label ID="securityTypeSearch" runat="server" Text="Choose security type" class="col-md-8"></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlsecurityType" runat="server" CssClass="form-control">
                <asp:ListItem Value="bond">Bond</asp:ListItem>
                <asp:ListItem Value="stock">Stock</asp:ListItem>
                <asp:ListItem Value="unit trust">Unit Trust</asp:ListItem>
            </asp:DropDownList>
                    </div>
            </div>

        <div class="form-group">
            <asp:Button ID="securitySearchBtn" runat="server" Text="Generate 7-Day Graph" class="btn-default col-md-3" OnClick="userNameSearchBtn_Click"/>
            <asp:Button ID="securitySearchBtn2" runat="server" Text="Generate 30-Day Graph" class="btn-default col-md-3" OnClick="securitySearchBtn2_Click" Visible="False" />
        </div>
        <div class="form-group">
        <asp:Label ID="securityExist" runat="server"  Text="If no graph shows, please check the correctness of the Security Type or Security Code you type in." Font-Bold="True" Font-Size="Large" ></asp:Label>
        </div>
        <asp:Panel ID="graph30" runat="server" Visible="False">
            <div class="form-group">
                <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" >
                    <Series>
                        <asp:Series Name="Series1" ChartType="Line" XValueMember="Day" YValueMembers="price"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HKeInvestConnectionString %>" SelectCommand="SELECT * FROM [PriceRecord] WHERE (([code] = @code) AND ([type] = @type) AND ([Day] &lt;= @Day)) ORDER BY [Day]">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="securitySearchBox" Name="code" PropertyName="Text" Type="String" DefaultValue="0" />
                        <asp:ControlParameter ControlID="ddlsecurityType" Name="type" PropertyName="SelectedValue" Type="String" DefaultValue="null" />
                        <asp:Parameter DefaultValue="30" Name="Day" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </asp:Panel>

        <asp:Panel ID="graph7" runat="server" Visible="False">
        <div class="form-group">
        <asp:Label ID="titleOfGraph" runat="server"  Text="Trend of price flow within 7-day" Font-Bold="True"  CssClass="col-md-6"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2">
                <Series>
                    <asp:Series Name="Series1" ChartType="Line" XValueMember="Day" YValueMembers="price"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HKeInvestConnectionString %>" SelectCommand="SELECT * FROM [PriceRecord] WHERE (([code] = @code) AND ([type] = @type) AND ([Day] &lt;= @Day)) ORDER BY [Day]">
            <SelectParameters>
                <asp:ControlParameter ControlID="securitySearchBox" Name="code" PropertyName="Text" Type="String" DefaultValue="0" />
                <asp:ControlParameter ControlID="ddlsecurityType" Name="type" PropertyName="SelectedValue" Type="String" DefaultValue="null" />
                <asp:Parameter DefaultValue="7" Name="Day" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        </div>

        <div class="form-group">
        <asp:Label ID="baseXOfGraph" runat="server"  Text="x-axis : number of days ago" Font-Bold="True"  CssClass="col-md-6"></asp:Label>
        </div>
        <div class="form-group">
        <asp:Label ID="baseYOfGraph" runat="server"  Text="y-axis : Market Price of the security" Font-Bold="True"  CssClass="col-md-6"></asp:Label>
        </div>
        </asp:Panel>

    </div>
</asp:Content>
