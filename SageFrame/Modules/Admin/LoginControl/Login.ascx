<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="SageFrame.Modules.Admin.LoginControl.Login" %>
<%@ Register Src="../../../Controls/LoginStatus.ascx" TagName="LoginStatus" TagPrefix="uc1" %>

<script type="text/javascript">
    var elementId = '#<%=UserName.ClientID%>';
    $(function() {
        $(elementId).focus();

    });    
</script>

<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
        <div class="sfLogin">
            <div class="sfLogininside">
                <h2>
                    <asp:Label ID="lblAdminLogin" runat="server" Text="Login" meta:resourcekey="lblAdminLoginResource1"></asp:Label>
                </h2>
                <p>
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="sfFormlabel"
                        meta:resourcekey="UserNameLabelResource1">User Name:</asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="UserName" runat="server" meta:resourcekey="UserNameResource1" CssClass="sfInputbox"
                        autofocus="autofocus"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1"
                        CssClass="sfError" meta:resourcekey="UserNameRequiredResource1">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="sfFormlabel"
                        meta:resourcekey="PasswordLabelResource1">Password:</asp:Label>
                </p>
                <p>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" meta:resourcekey="PasswordResource1"
                        CssClass="sfInputbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1"
                        CssClass="sfError" meta:resourcekey="PasswordRequiredResource1">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:CheckBox ID="chkRememberMe" runat="server" CssClass="sfCheckBox" meta:resourcekey="RememberMeResource1" />
                        <asp:Label ID="lblrmnt" runat="server" Text="Remember me." CssClass="sfFormlabel"
                            meta:resourcekey="lblrmntResource1"></asp:Label>
                </p>
                <p>
                    <span class="cssClassForgetPass">
                        <asp:HyperLink ID="hypForgetPassword" runat="server" Text="Forgot Password?" meta:resourcekey="hypForgetPasswordResource1"></asp:HyperLink>
                    </span>
                </p>
                <div class="sfButtonwrapper">
                    <span><span>
                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Sign In" CssClass="sfBtn"
                            ValidationGroup="Login1" OnClick="LoginButton_Click" meta:resourcekey="LoginButtonResource1" />
                    </span></span>
                </div>
                <p>
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False" meta:resourcekey="FailureTextResource1"></asp:Literal>
                </p>
            </div>
        </div>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <uc1:LoginStatus ID="LoginStatus1" runat="server" />
    </asp:View>
</asp:MultiView>
