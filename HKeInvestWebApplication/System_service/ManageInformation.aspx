<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageInformation.aspx.cs" Inherits="HKeInvestWebApplication.ManageInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
    
       <h2><%: Title %>Manage Account Information</h2>

       <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" EnableClientScript="False" />


    <asp:Panel ID="enterUserName" runat="server" Visible="False">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:Label ID="userNameSearch" runat="server" Text="Please input a user name to edit" class="control-label col-md-4"></asp:Label>
                    <asp:TextBox ID="userNameSearchBox" runat="server" ></asp:TextBox>

                </div>
                <div class="col-md-offset-2 col-md-6">
                    <asp:Button ID="userNameSearchBtn" runat="server" Text="Search User Name" class="btn-default col-md-6" OnClick="userNameBtn_Click"  />
                    <asp:Label ID="nameExist" runat="server" CssClass="text-danger" Text="No account exist with this user name" ForeColor="Red" Visible="False"></asp:Label>
                </div>
        </div>

    </asp:Panel>

    <asp:Panel ID="manageInfro" runat="server" Visible="False">

    <div class="form-horizontal">
        <div class="form-group">
            <div class="col-md-6">   
                <asp:Label runat="server" Text="Account Type: " class="control-label col-md-4" ></asp:Label>
                <asp:Label ID="accountTypeLabel" runat="server" Text=" " class="control-label col-md-3" ></asp:Label>
            </div>

            <div class="col-md-6">  
                <asp:Label runat="server" Text="Account Number: " class="control-label col-md-4" ></asp:Label>
                <asp:Label ID="accountNumberLabel" runat="server" Text=" "  class="control-label col-md-3"></asp:Label>


            </div>
        </div>

        <div class="form-group">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Title: "  class="control-label col-md-4"></asp:Label>
                <asp:Label ID="titleLabel" runat="server" Text=" " class="control-label col-md-3"></asp:Label>
                <div class="col-md-3"><asp:DropDownList ID="ddlTitle" runat="server" CssClass="form-control">
                <asp:ListItem Value="Mr">Mr.</asp:ListItem>
                <asp:ListItem Value="Mrs">Mrs.</asp:ListItem>
                <asp:ListItem Value="Ms">Ms.</asp:ListItem>
                <asp:ListItem Value="Dr">Dr.</asp:ListItem>
            </asp:DropDownList>
                    </div>
                <asp:Button ID="titleBtn" runat="server" Text="Edit" class="btn-default col-md-2" OnClick="titleBtn_Click" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTitle" CssClass="text-danger" EnableClientScript="False" ErrorMessage="Title is required.">*</asp:RequiredFieldValidator>
            </div>

            <div class="col-md-6">
                <asp:Label runat="server" Text="First Name: "  class="control-label col-md-4"></asp:Label>
                <asp:Label ID="firstNameLabel" runat="server" Text=" " class="control-label col-md-3" ></asp:Label>
                <asp:TextBox ID="firstNameBox" runat="server" class="col-md-3"></asp:TextBox>
                <asp:Button ID="firstNameBtn" runat="server" Text="Edit" class="btn-default col-md-2" OnClick="firstNameBtn_Click" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Last Name: " class="control-label col-md-4" ></asp:Label>
                <asp:Label ID="lastNameLabel" runat="server" Text=" " class="control-label col-md-3"></asp:Label>
                <asp:TextBox ID="lastNameBox" runat="server" class="col-md-3"></asp:TextBox>
                <asp:Button ID="lastNameBtn" runat="server" Text="Edit" class="btn-default col-md-2" OnClick="lastNameBtn_Click" />
            </div>

            <div class="col-md-6">
                <asp:Label runat="server" Text="Date of birth(dd/mm/yyyy): " class="control-label col-md-4"></asp:Label>
                <asp:Label ID="dateOfBirthLabel" runat="server" Text=" " class="control-label col-md-3"></asp:Label>              
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-6">
                <asp:Label runat="server" Text="HKID/passport number: " class="control-label col-md-4" ></asp:Label>
                <asp:Label ID="HKIDPassportNumberLabel" runat="server" Text=" " class="control-label col-md-3"></asp:Label>              
            </div>
            
            <div class="col-md-6">
                <asp:Label runat="server" Text="Email: "  class="control-label col-md-4"></asp:Label>
                <asp:Label ID="emailLabel" runat="server" Text=" " class="control-label col-md-3"></asp:Label>
                <asp:TextBox ID="emailBox" runat="server" class="col-md-3"></asp:TextBox> 
                <asp:Button ID="emailBtn" runat="server" Text="Edit" class="btn-default col-md-2" OnClick="emailBtn_Click" />               
            </div>
        </div>
            
        <div class="form-group">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Building: "  class="control-label col-md-4"></asp:Label>
                <asp:Label ID="buildingLabel" runat="server" Text=" " class="control-label col-md-3"></asp:Label>
                <asp:TextBox ID="buildingBox" runat="server" class="col-md-3"></asp:TextBox>           
                <asp:Button ID="buildingBtn" runat="server" Text="Edit" class="btn-default col-md-2" OnClick="buildingBtn_Click" />     
            </div>

            <div class="col-md-6">
                <asp:Label runat="server" Text="Street: "  class="control-label col-md-4"></asp:Label>
                <asp:Label ID="streetLabel" runat="server" Text=" " class="control-label col-md-3"></asp:Label>
                <asp:TextBox ID="streetBox" runat="server" class="col-md-3"></asp:TextBox>           
                <asp:Button ID="streetBtn" runat="server" Text="Edit" class="btn-default col-md-2" OnClick="streetBtn_Click" />     
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-6">
                <asp:Label runat="server" Text="District: "  class="control-label col-md-4"></asp:Label>
                <asp:Label ID="districtLabel" runat="server" Text=" " class="control-label col-md-3"></asp:Label>
                <asp:TextBox ID="districtBox" runat="server" class="col-md-3"></asp:TextBox>      
                <asp:Button ID="districtBtn" runat="server" Text="Edit" class="btn-default col-md-2" OnClick="districtBtn_Click" />          
            </div>

            <div class="col-md-6">
                <asp:Label runat="server" Text="Home phone: "  class="control-label col-md-4"></asp:Label>
                <asp:Label ID="homePhoneLabel" runat="server" Text=" " class="control-label col-md-3"></asp:Label>
                <asp:TextBox ID="homePhoneBox" runat="server" class="col-md-3"></asp:TextBox>   
                <asp:Button ID="homePhoneBtn" runat="server" Text="Edit" class="btn-default col-md-2" OnClick="homePhoneBtn_Click" />             
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Home fax: "  class="control-label col-md-4"></asp:Label>
                <asp:Label ID="homeFaxLabel" runat="server" Text=" " class="control-label col-md-3"></asp:Label>
                <asp:TextBox ID="homeFaxBox" runat="server" class="col-md-3"></asp:TextBox>    
                <asp:Button ID="homeFaxBtn" runat="server" Text="Edit" class="btn-default col-md-2" OnClick="homeFaxBtn_Click" />            
            </div>

            <div class="col-md-6">
                <asp:Label runat="server" Text="Business phone: "  class="control-label col-md-4"></asp:Label>
                <asp:Label ID="businessPhoneLabel" runat="server" Text=" " class="control-label col-md-3"></asp:Label>
                <asp:TextBox ID="businessPhoneBox" runat="server" class="col-md-3"></asp:TextBox>    
                <asp:Button ID="businessPhoneBtn" runat="server" Text="Edit" class="btn-default col-md-2" OnClick="businessPhoneBtn_Click" />            
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Mobil phone: " class="control-label col-md-4" ></asp:Label>
                <asp:Label ID="mobileLabel" runat="server" Text=" " class="control-label col-md-3"></asp:Label>
                <asp:TextBox ID="mobileBox" runat="server" class="col-md-3"></asp:TextBox>  
                <asp:Button ID="mobileBtn" runat="server" Text="Edit" class="btn-default col-md-2" OnClick="mobileBtn_Click" />              
            </div>

            <div class="col-md-6">
                <asp:Label runat="server" Text="Country of citizenship: " class="control-label col-md-4" ></asp:Label>
                <asp:Label ID="citizenshipLabel" runat="server" Text=":" class="control-label col-md-3"></asp:Label>
                <asp:TextBox ID="citizenshipBox" runat="server" class="col-md-3"></asp:TextBox>     
                <asp:Button ID="citizenshipBtn" runat="server" Text="Edit" class="btn-default col-md-2" OnClick="citizenshipBtn_Click" />           
            </div>
        </div>
            
        <div class="form-group">
            <div class="col-md-6">
                <asp:Label runat="server" Text="Country of legal residence: " class="control-label col-md-4" ></asp:Label>
                <asp:Label ID="legalResidenceLabel" runat="server" Text=" " class="control-label col-md-3"></asp:Label>
                <asp:TextBox ID="legalResidenceBox" runat="server" class="col-md-3"></asp:TextBox>   
                <asp:Button ID="legalResidenceBtn" runat="server" Text="Edit" class="btn-default col-md-2" OnClick="legalResidenceBtn_Click" />             
            </div>

            <div class="col-md-6">
                <asp:Label runat="server" Text="Passport country of issue: " class="control-label col-md-4" ></asp:Label>
                <asp:Label ID="passportCountryOfIssueLabel" runat="server" Text=" " class="control-label col-md-3"></asp:Label>
                <asp:TextBox ID="passportCountryOfIssueBox" runat="server" class="col-md-3"></asp:TextBox>    
                <asp:Button ID="passportCountryOfIssueBtn" runat="server" Text="Edit" class="btn-default col-md-2" OnClick="passportCountryOfIssueBtn_Click" />            
            </div>
        </div>
            
        <div class="form-group">
            <div class="col-md-6">
                <asp:Label runat="server" Text="User name: " class="control-label col-md-4" ></asp:Label>
                <asp:Label ID="userNameLabel" runat="server" Text=" " class="control-label col-md-3"></asp:Label>
            </div>
<%--            <div class="col-md-6">
            <asp:Button ID="refreshBtn" runat="server" Text="Choose user account again" OnClick="refreshBtn_Click" class="btn-default col-md-6"/>
            </div>--%>
        </div>

<%--        <div class="form-group">
            <div class="col-md-6">
                <asp:Label runat="server" Text="New Password: " class="control-label col-md-4" ></asp:Label>
                <asp:Label ID="empty1" runat="server" Text=" " class="control-label col-md-3"></asp:Label>
                <asp:TextBox ID="passwordBox" runat="server" class="col-md-5"></asp:TextBox>         
                
            </div>
            <div class="col-md-6">
                <asp:Label runat="server" Text="Confirm Password: " class="control-label col-md-4" ></asp:Label>
                <asp:TextBox ID="confirmBox" runat="server" class="col-md-4"></asp:TextBox>    
                <asp:Button ID="confirmBtn" runat="server" Text="Confirm Edit Password" class="btn-default col-md-4" OnClick="confirmBtn_Click" />

            </div>

        </div>--%>



        </div>
    </asp:Panel>



</asp:Content>


