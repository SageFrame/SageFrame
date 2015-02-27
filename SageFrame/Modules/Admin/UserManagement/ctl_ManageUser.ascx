<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctl_ManageUser.ascx.cs"
    Inherits="SageFrame.Modules.Admin.UserManagement.ctl_ManageUser" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<script language="javascript" type="text/javascript">
    $(document).ready(function() {
        var btnSave = '<%=btnSave.ClientID%>';
        $('#' + btnSave).live("click", function() {
            ValidationRules();
        });

    });
    function ValidationRules() {
        $("#form1").validate({
            ignore: ':hidden',
            rules: {
                '<%=txtFName.UniqueID %>': { required: true },
                '<%=txtLName.UniqueID %>': { required: true },
                '<%=txtEmail1.UniqueID %>': { required: true, email: true },
                '<%=txtEmail2.UniqueID %>': { email: true },
                '<%=txtEmail3.UniqueID %>': { email: true }

            },
            messages: {
                '<%=txtFName.UniqueID %>': "<br/>First Name should not be blank.",
                '<%=txtLName.UniqueID %>': "<br/>Last Name should not be blank.",
                '<%=txtEmail1.UniqueID %>': "<br/>Email should not be blank and must be in a correct format.",
                '<%=txtEmail2.UniqueID %>': "<br/>Email must be in a correct format.",
                '<%=txtEmail3.UniqueID %>': "<br/>Email must be in a correct format."

            }

        });
    }


    function ValidateCheckBoxSelection(obj) {
        var valid = false;

        var gv = '#' + '<%=gdvUser.ClientID%>' + ' tr';
        $.each($(gv), function() {
            if ($(this).find("td:eq(0) input[type='checkbox']").attr("checked")) {
                valid = true;
            }
        });
        if (!valid)
            return ConfirmDialog(obj, 'message', 'Please select at least one user.');
        else {
            return ConfirmDialog(obj, 'Confirmation', 'Are you sure you want to delete the users?');
        }

        return valid;

    }

    $(function() {

        $('#' + '<%=txtFrom.ClientID%>').attr('readOnly', 'true');
        $('#' + '<%=txtTo.ClientID%>').attr('readOnly', 'true');

        $('#' + '<%=txtFrom.ClientID%>').datepicker({ dateFormat: 'yy-mm-dd' });
        $('#' + '<%=txtTo.ClientID%>').datepicker({ dateFormat: 'yy-mm-dd' });

        var pwdID = '#' + '<%=txtPassword.ClientID%>';
        $(pwdID).val('');
        $(pwdID).live("change", function() {
            var len = $(this).val().length;

            if (len < 4 && len != 0) {

                $('#pwdlblmsg').show().text("Password must be at least 4 chars long");
            }
            else {
                $('#pwdlblmsg').text('');
            }
        });

        var rolesID = '#' + '<%=lstAvailableRoles.ClientID%>';
        $(rolesID).live("change", function() {
            if ($(this).val() == null || $(this).val() == "") {
                $('#lblValidationmsg1').text("At least a role must be selected");
            }
        });

        $('.password').pstrength({ minchar: 4 });

        var newPwd = '#' + '<%=txtNewPassword.ClientID%>';
        var newPwdRetype = '#' + '<%=txtRetypeNewPassword.ClientID%>';
        $(newPwdRetype).live("change", function() {
            if ($(newPwd).val() != $(this).val()) {
                $('#lblChangepwdval').text("Passwords don't match");
            }
            else {
                $('#lblChangepwdval').text("");
            }
        });
        $(newPwd).live("change", function() {
            if ($(newPwdRetype).val() != $(this).val() && $(newPwdRetype).val() != "") {
                $('#lblChangepwdval').text("Passwords don't match");
            }
            else {
                $('#lblChangepwdval').text("");
            }
        });


        var userGrid = '#' + '<%=gdvUser.ClientID%>';
        $(userGrid).find("tr:first th.sfCheckbox input").bind("click", function() {
            if ($(this).attr("checked")) {
                $(userGrid).find("tr input.sfSelectall").attr("checked", true);
            }
            else {
                $(userGrid).find("tr input.sfSelectall").attr("checked", false);
            }
        });
        $(userGrid).find("tr:first th.sfIsactive input").bind("click", function() {
            if ($(this).attr("checked")) {
                $(userGrid).find("tr input.sfIsactive").attr("checked", true);
            }
            else {
                $(userGrid).find("tr input.sfIsactive").attr("checked", false);
            }
        });
    });

    function pageLoad(sender, args) {
        if (args.get_isPartialLoad()) {
            $('.password').pstrength({ minchar: 4 });
        }
    }
            
            
            
            
            
     

</script>

<h1>
    <asp:Label ID="lblUserManagement" runat="server" Text="User Management" 
        meta:resourcekey="lblUserManagementResource1"></asp:Label>
</h1>
<asp:Panel ID="pnlManageUser" runat="server" CssClass="sfFormwrapper sfPadding" 
    meta:resourcekey="pnlManageUserResource1">
    <asp:HiddenField ID="hdnEditUsername" runat="server" />
    <asp:HiddenField ID="hdnEditUserID" runat="server" />
    <asp:HiddenField ID="hdnCurrentEmail" runat="server" />
    <ajax:TabContainer ID="TabContainerManageUser" runat="server" 
        ActiveTabIndex="0" meta:resourcekey="TabContainerManageUserResource1">
        <ajax:TabPanel ID="tabUserInfo" runat="server" 
            meta:resourcekey="tabUserInfoResource1">
            <HeaderTemplate>
                <asp:Label ID="lblUIH" runat="server" Text="User Information" 
                    meta:resourcekey="lblUIHResource1"></asp:Label>
            </HeaderTemplate>
            <ContentTemplate>
                <div class="sfFormwrapper">
                    <table id="tblUserInformationSettings" runat="server" cellpadding="0" cellspacing="0"
                        border="0" width="100%">
                        <tr runat="server">
                            <td runat="server">
                                <asp:Label ID="lblManageUsername" runat="server" CssClass="sfFormlabel" Text="Username"></asp:Label>
                            </td>
                            <td width="30px" align="center" runat="server">
                                :
                            </td>
                            <td runat="server">
                                <asp:Label ID="txtManageUsername" runat="server"></asp:Label>
                            </td>
                            <td runat="server">
                                <asp:Label ID="lblCreatedDate" runat="server" CssClass="sfFormlabel" Text="Created Date"></asp:Label>
                            </td>
                            <td width="30px" align="center" runat="server">
                                :
                            </td>
                            <td runat="server">
                                <asp:Label ID="txtCreatedDate" runat="server" Text="Created Date"></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server">
                                <asp:Label ID="lblManageFirstName" runat="server" CssClass="sfFormlabel" Text="First Name"></asp:Label>
                            </td>
                            <td runat="server">
                                :
                            </td>
                            <td runat="server">
                                <asp:TextBox ID="txtManageFirstName" runat="server" CssClass="sfInputbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="sfRequired" runat="server"
                                    ControlToValidate="txtManageFirstName" ErrorMessage="First name is required"
                                    ValidationGroup="vgManageUserInfo"></asp:RequiredFieldValidator>
                            </td>
                            <td runat="server">
                                <asp:Label ID="lblLastLoginDate" runat="server" CssClass="sfFormlabel" Text="Last Login Date"></asp:Label>
                            </td>
                            <td runat="server">
                                :
                            </td>
                            <td runat="server">
                                <asp:Label ID="txtLastLoginDate" runat="server" Text="Last Login Date"></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server">
                                <asp:Label ID="lblManageLastName" runat="server" CssClass="sfFormlabel" Text="Last Name"></asp:Label>
                            </td>
                            <td runat="server">
                                :
                            </td>
                            <td runat="server">
                                <asp:TextBox ID="txtManageLastName" runat="server" CssClass="sfInputbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="sfRequired" runat="server"
                                    ControlToValidate="txtManageLastName" ErrorMessage="Last name is required" ValidationGroup="vgManageUserInfo"></asp:RequiredFieldValidator>
                            </td>
                            <td runat="server">
                                <asp:Label ID="lblLastActivity" runat="server" CssClass="sfFormlabel" Text="Last Activity"></asp:Label>
                            </td>
                            <td runat="server">
                                :
                            </td>
                            <td runat="server">
                                <asp:Label ID="txtLastActivity" runat="server" Text="Last Activity"></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server">
                                <asp:Label ID="lblManageEmail" runat="server" CssClass="sfFormlabel" Text="Email"></asp:Label>
                            </td>
                            <td runat="server">
                                :
                            </td>
                            <td runat="server">
                                <asp:TextBox ID="txtManageEmail" runat="server" CssClass="sfInputbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="sfRequired" runat="server"
                                    ControlToValidate="txtManageEmail" ErrorMessage="Email is required" ValidationGroup="vgManageUserInfo"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtManageEmail"
                                    ErrorMessage="Enter valid email." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="vgManageUserInfo"></asp:RegularExpressionValidator>
                            </td>
                            <td runat="server">
                                <asp:Label ID="lblLastPasswordChanged" runat="server" CssClass="sfFormlabel" Text="Last Password Changed"></asp:Label>
                            </td>
                            <td runat="server">
                                :
                            </td>
                            <td runat="server">
                                <asp:Label ID="txtLastPasswordChanged" runat="server" Text="Last Password Changed"></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server">
                                <asp:Label ID="lblIsUserActive" runat="server" CssClass="sfFormlabel" Text="Is Active"></asp:Label>
                            </td>
                            <td runat="server">
                                :
                            </td>
                            <td runat="server">
                                <asp:CheckBox ID="chkIsActive" runat="server" />
                            </td>
                            <td colspan="3" runat="server">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sfButtonwrapper">
                    <asp:ImageButton ID="imgUserInfoSave" runat="server" OnClick="imgUserInfoSave_Click"
                        ToolTip="Update" ValidationGroup="vgManageUserInfo" 
                        meta:resourcekey="imgUserInfoSaveResource1" />
                    <asp:Label ID="lblUserInfoSave" runat="server" Text="Update" AssociatedControlID="imgUserInfoSave"
                        Style="cursor: pointer;" ValidationGroup="vgManageUserInfo" 
                        meta:resourcekey="lblUserInfoSaveResource1"></asp:Label>
                </div>
            </ContentTemplate>
        </ajax:TabPanel>
        <ajax:TabPanel ID="tabUserRoles" runat="server" 
            meta:resourcekey="tabUserRolesResource1">
            <HeaderTemplate>
                <asp:Label ID="lblURH" runat="server" Text="User Roles" 
                    meta:resourcekey="lblURHResource1"></asp:Label>
            </HeaderTemplate>
            <ContentTemplate>
                <div class="sfFormwrapper">
                    <table id="tblUserRolesSettings" runat="server" cellpadding="0" cellspacing="0" border="0">
                        <tr runat="server">
                            <td width="18%" runat="server">
                                <asp:Label ID="lblUnselected" runat="server" CssClass="sfFormlabel" Text="Unselected"></asp:Label>
                            </td>
                            <td width="1%" runat="server">
                            </td>
                            <td runat="server">
                                <asp:Label ID="lblSelected" runat="server" CssClass="sfFormlabel" Text="Selected"></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td valign="top" runat="server">
                                <asp:ListBox ID="lstUnselectedRoles" runat="server" SelectionMode="Multiple" CssClass="sfListmenubig">
                                </asp:ListBox>
                            </td>
                            <td class="sfSelectleftright" runat="server">
                                <asp:Button ID="btnAddAllRole" runat="server" CausesValidation="False" OnClick="btnAddAllRole_Click"
                                    CssClass="sfSelectallright" Text="&gt;&gt;" />
                                <asp:Button ID="btnAddRole" runat="server" CausesValidation="False" OnClick="btnAddRole_Click"
                                    CssClass="sfSelectoneright" Text=" &gt; " />
                                <asp:Button ID="btnRemoveRole" runat="server" CausesValidation="False" OnClick="btnRemoveRole_Click"
                                    CssClass="sfSelectoneleft" Text=" &lt; " />
                                <asp:Button ID="btnRemoveAllRole" runat="server" CausesValidation="False" OnClick="btnRemoveAllRole_Click"
                                    Text="&lt;&lt;" CssClass="sfSelectallleft" />
                            </td>
                            <td valign="top" runat="server">
                                <asp:ListBox ID="lstSelectedRoles" runat="server" SelectionMode="Multiple" CssClass="sfListmenubig">
                                </asp:ListBox>
                            </td>
                        </tr>
                    </table>
                    <div class="sfButtonwrapper">
                        <asp:ImageButton ID="imgManageRoleSave" runat="server" 
                            OnClick="imgManageRoleSave_Click" 
                            meta:resourcekey="imgManageRoleSaveResource1" />
                        <asp:Label ID="lblManageRoleSave" runat="server" Text="Update" 
                            AssociatedControlID="imgManageRoleSave" 
                            meta:resourcekey="lblManageRoleSaveResource1"></asp:Label>
                    </div>
                    <div>
                        &nbsp;</div>
                </div>
            </ContentTemplate>
        </ajax:TabPanel>
        <ajax:TabPanel ID="tabUserPassword" runat="server" 
            meta:resourcekey="tabUserPasswordResource1">
            <HeaderTemplate>
                <asp:Label ID="lblCPH" runat="server" Text="Change Password" 
                    meta:resourcekey="lblCPHResource1"></asp:Label>
            </HeaderTemplate>
            <ContentTemplate>
                <p class="sfNote">
                    <asp:Label ID="lblCPM" runat="server" Text="To change a password for this user enter the new password and confirm the entry
                    by typing it again." meta:resourcekey="lblCPMResource1"></asp:Label>
                </p>
                <div class="sfFormwrapper">
                    <table id="tblChangePasswordSettings" runat="server" width="100%" cellpadding="0"
                        cellspacing="0" border="0">
                        <tr runat="server">
                            <td width="20%" runat="server">
                                <asp:Label ID="lblNewPassword" runat="server" CssClass="sfFormlabel" Text="New Password"></asp:Label>
                            </td>
                            <td width="30" runat="server">
                                :
                            </td>
                            <td runat="server">
                                <div class="sfPassword">
                                    <asp:TextBox ID="txtNewPassword" runat="server" MaxLength="20" CssClass="sfInputbox password"
                                        TextMode="Password" ValidationGroup="vgManagePassword"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewPassword"
                                        ErrorMessage="Password is required." CssClass="sfRequired" ValidationGroup="vgManagePassword"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server">
                                <asp:Label ID="lblRetypeNewPassword" runat="server" CssClass="sfFormlabel" Text="Retype New Password"></asp:Label>
                            </td>
                            <td width="30" runat="server">
                                :
                            </td>
                            <td runat="server">
                                <asp:TextBox ID="txtRetypeNewPassword" runat="server" MaxLength="20" CssClass="sfInputbox"
                                    TextMode="Password" ValidationGroup="vgManagePassword"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRetypeNewPassword"
                                    ErrorMessage="Type password again." CssClass="sfRequired" ValidationGroup="vgManagePassword"></asp:RequiredFieldValidator>
                                <label id="lblValidationmsg" class="sfRequired">
                                </label>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server">
                                &nbsp;
                            </td>
                            <td runat="server">
                                &nbsp;
                            </td>
                            <td runat="server">
                                <div class="sfButtonwrapper">
                                    <asp:Button ID="btnManagePasswordSave" runat="server" ValidationGroup="vgManagePassword"
                                        CssClass="sfBtn" Text="Change" OnClick="btnManagePasswordSave_Click" />
                                </div>
                                <div class="sfValidationsummary">
                                    <label id="lblChangepwdval" class="sfError">
                                    </label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </ajax:TabPanel>
        <ajax:TabPanel ID="tabUserProfile" runat="server" 
            meta:resourcekey="tabUserProfileResource1">
            <HeaderTemplate>
                <asp:Label ID="lblUP" runat="server" Text="User Profile" 
                    meta:resourcekey="lblUPResource1"></asp:Label>
            </HeaderTemplate>
            <ContentTemplate>
                <div class="sfFormwrapper sfUserprofile clearfix">
                    <div class="sfViewprofile">
                        <table id="tblEditProfile" width="100%" cellpadding="0" cellspacing="0" runat="server">
                            <tr runat="server">
                                <td runat="server" colspan="4">
                                    <h2>
                                        User Info</h2>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                    <asp:Label ID="lblImage" runat="server" CssClass="sfFormlabel" Text="Image"></asp:Label>
                                </td>
                                <td runat="server" width="30">
                                    :
                                </td>
                                <td runat="server">
                                    <asp:FileUpload ID="fuImage" runat="server" />
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                    <asp:Label ID="Label8" runat="server" CssClass="sfFormlabel" Text="User Name"></asp:Label>
                                </td>
                                <td runat="server" width="30">
                                    :
                                </td>
                                <td runat="server">
                                    <asp:Label ID="lblDisplayUserName" runat="server" CssClass="sfFormlabel"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                    <asp:Label ID="Label9" runat="server" CssClass="sfFormlabel" Text="First Name"></asp:Label>
                                </td>
                                <td runat="server" width="30">
                                    :
                                </td>
                                <td runat="server">
                                    <asp:TextBox ID="txtFName" runat="server" CssClass="sfInputbox" Name="txtFName"></asp:TextBox>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                    <asp:Label ID="Label17" runat="server" CssClass="sfFormlabel" Text="LastName"></asp:Label>
                                </td>
                                <td runat="server" width="30">
                                    :
                                </td>
                                <td runat="server">
                                    <asp:TextBox ID="txtLName" runat="server" CssClass="sfInputbox" Name="txtLName"></asp:TextBox>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                    <asp:Label ID="lblFullName" runat="server" CssClass="sfFormlabel" 
                                        Text="FullName"></asp:Label>
                                </td>
                                <td runat="server" width="30">
                                    :
                                </td>
                                <td runat="server">
                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="sfInputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                    <asp:Label ID="lblLocation" runat="server" CssClass="sfFormlabel" 
                                        Text="Location"></asp:Label>
                                </td>
                                <td runat="server" width="30">
                                    :
                                </td>
                                <td runat="server">
                                    <asp:TextBox ID="txtLocation" runat="server" CssClass="sfInputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                    <asp:Label ID="lblAboutYou" runat="server" CssClass="sfFormlabel" 
                                        Text="About You"></asp:Label>
                                </td>
                                <td runat="server" width="30">
                                    :
                                </td>
                                <td runat="server">
                                    <asp:TextBox ID="txtAboutYou" runat="server" CssClass="sfTextarea" 
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server" colspan="3">
                                    <h3>
                                        Contacts</h3>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                    <asp:Label ID="Label18" runat="server" CssClass="sfFormlabel" Text="Email:"></asp:Label>
                                </td>
                                <td runat="server" width="30">
                                    :
                                </td>
                                <td runat="server">
                                    <asp:TextBox ID="txtEmail1" runat="server" CssClass="sfInputbox" 
                                        Name="txtEmail1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                </td>
                                <td runat="server" width="30">
                                </td>
                                <td runat="server">
                                    <asp:TextBox ID="txtEmail2" runat="server" CssClass="sfInputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                </td>
                                <td runat="server" width="30">
                                </td>
                                <td runat="server">
                                    <asp:TextBox ID="txtEmail3" runat="server" CssClass="sfInputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                    <asp:Label ID="lblResPhone" runat="server" CssClass="sfFormlabel" 
                                        Text="Res. Phone:"></asp:Label>
                                </td>
                                <td runat="server" width="30">
                                    :
                                </td>
                                <td runat="server">
                                    <asp:TextBox ID="txtResPhone" runat="server" CssClass="sfInputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                    <asp:Label ID="lblMobilePhone" runat="server" CssClass="sfFormlabel" 
                                        Text="Mobile"></asp:Label>
                                </td>
                                <td runat="server" width="30">
                                    :
                                </td>
                                <td runat="server">
                                    <asp:TextBox ID="txtMobile" runat="server" CssClass="sfInputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                    <asp:Label ID="lblOthers" runat="server" CssClass="sfFormlabel" Text="Others"></asp:Label>
                                </td>
                                <td runat="server" width="30">
                                    :
                                </td>
                                <td runat="server">
                                    <asp:TextBox ID="txtOthers" runat="server" CssClass="sfInputbox" 
                                        OnTextChanged="txtOthers_TextChanged" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server">
                                    <div class="sfButtonwrapper">
                                        <asp:Button ID="btnSave" runat="server" CssClass="sfBtn" 
                                            OnClick="btnSave_Click" Text="Save" ValidationGroup="rfvUserProfile" />
                                        <asp:Button ID="btnCancelProfile" runat="server" CssClass="sfBtn" 
                                            OnClick="btnCancelProfile_Click" Text="Cancel" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="sfProfileimage" runat="server" id="imgProfileEdit">
                        <asp:Image ID="imgUser" runat="server" AlternateText="Image" 
                            Style="max-height: 100px" meta:resourcekey="imgUserResource1" />
                        <asp:ImageButton ID="btnDeleteProfilePic" runat="server" 
                            OnClick="btnDeleteProfilePic_Click" 
                            meta:resourcekey="btnDeleteProfilePicResource1" />
                    </div>
                    <div class="clearfix">
                        <div class="sfViewprofile">
                            <table id="tblViewProfile" cellpadding="0" cellspacing="0" width="100%" runat="server">
                                <tr runat="server">
                                    <td runat="server" colspan="4">
                                        <h2>
                                            User Info</h2>
                                    </td>
                                </tr>
                                <tr runat="server" class="sfOdd">
                                    <td runat="server" width="15%">
                                        <asp:Label ID="Label19" runat="server" CssClass="sfFormlabel" Text="User Name"></asp:Label>
                                    </td>
                                    <td runat="server" width="30">
                                        :
                                    </td>
                                    <td runat="server">
                                        <asp:Label ID="lblViewUserName" runat="server" CssClass="sfFormlabel"></asp:Label>
                                    </td>
                                    <td runat="server">
                                    </td>
                                </tr>
                                <tr runat="server" class="sfEven">
                                    <td runat="server">
                                        <asp:Label ID="Label20" runat="server" CssClass="sfFormlabel" Text="First Name"></asp:Label>
                                    </td>
                                    <td runat="server" width="30">
                                        :
                                    </td>
                                    <td runat="server" colspan="2">
                                        <asp:Label ID="lblViewFirstName" runat="server" CssClass="sfFormlabel"></asp:Label>
                                    </td>
                                </tr>
                                <tr runat="server" class="sfOdd">
                                    <td runat="server">
                                        <asp:Label ID="Label22" runat="server" CssClass="sfFormlabel" Text="LastName"></asp:Label>
                                    </td>
                                    <td runat="server" width="30">
                                        :
                                    </td>
                                    <td runat="server" colspan="2">
                                        <asp:Label ID="lblViewLastName" runat="server" CssClass="sfFormlabel"></asp:Label>
                                    </td>
                                </tr>
                                <tr ID="trviewFullName" runat="server" class="sfEven">
                                    <td runat="server">
                                        <asp:Label ID="Label26" runat="server" CssClass="sfFormlabel" Text="FullName"></asp:Label>
                                    </td>
                                    <td runat="server" width="30">
                                        :
                                    </td>
                                    <td runat="server" colspan="2">
                                        <asp:Label ID="lblviewFullName" runat="server" CssClass="sfFormlabel"></asp:Label>
                                    </td>
                                </tr>
                                <tr ID="trViewLocation" runat="server" class="sfOdd">
                                    <td runat="server">
                                        <asp:Label ID="Label27" runat="server" CssClass="sfFormlabel" Text="Location"></asp:Label>
                                    </td>
                                    <td runat="server" width="30">
                                        :
                                    </td>
                                    <td runat="server" colspan="2">
                                        <asp:Label ID="lblViewLocation" runat="server" CssClass="sfFormlabel"></asp:Label>
                                    </td>
                                </tr>
                                <tr ID="trViewAboutYou" runat="server" class="sfEven">
                                    <td runat="server">
                                        <asp:Label ID="Label28" runat="server" CssClass="sfFormlabel" Text="About You"></asp:Label>
                                    </td>
                                    <td runat="server" width="30">
                                        :
                                    </td>
                                    <td runat="server" colspan="2">
                                        <asp:Label ID="lblViewAboutYou" runat="server" CssClass="sfFormlabel"></asp:Label>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server" colspan="4">
                                        <h2>
                                            Contacts</h2>
                                    </td>
                                </tr>
                                <tr ID="trViewEmail" runat="server" class="sfOdd">
                                    <td runat="server">
                                        <asp:Label ID="Label29" runat="server" CssClass="sfFormlabel" Text="Email"></asp:Label>
                                    </td>
                                    <td runat="server" width="30">
                                        :
                                    </td>
                                    <td runat="server" colspan="2">
                                        <asp:Label ID="lblViewEmail1" runat="server" CssClass="sfFormlabel"></asp:Label>
                                        <asp:Label ID="lblViewEmail2" runat="server" CssClass="sfFormlabel"></asp:Label>
                                        <asp:Label ID="lblViewEmail3" runat="server" CssClass="sfFormlabel"></asp:Label>
                                    </td>
                                </tr>
                                <tr ID="trViewResPhone" runat="server" class="sfEven">
                                    <td runat="server">
                                        <asp:Label ID="Label30" runat="server" CssClass="sfFormlabel" Text="Res. Phone"></asp:Label>
                                    </td>
                                    <td runat="server" width="30">
                                        :
                                    </td>
                                    <td runat="server" colspan="2">
                                        <asp:Label ID="lblViewResPhone" runat="server" CssClass="sfInputbox"></asp:Label>
                                    </td>
                                </tr>
                                <tr ID="trViewMobile" runat="server" class="sfOdd">
                                    <td runat="server">
                                        <asp:Label ID="Label31" runat="server" CssClass="sfFormlabel" Text="Mobile"></asp:Label>
                                    </td>
                                    <td runat="server" width="30">
                                        :
                                    </td>
                                    <td runat="server" colspan="2">
                                        <asp:Label ID="lblViewMobile" runat="server" CssClass="sfFormlabel"></asp:Label>
                                    </td>
                                </tr>
                                <tr ID="trViewOthers" runat="server" class="sfEven">
                                    <td runat="server">
                                        <asp:Label ID="Label32" runat="server" CssClass="sfFormlabel" Text="Others"></asp:Label>
                                    </td>
                                    <td runat="server" width="30">
                                        :
                                    </td>
                                    <td runat="server" colspan="2">
                                        <asp:Label ID="lblViewOthers" runat="server" CssClass="sfFormlabel"></asp:Label>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <div class="sfButtonwrapper">
                                            <asp:Button ID="btnEdit" runat="server" CssClass="sfBtn" 
                                                OnClick="btnEdit_Click" Text="Edit" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="sfProfileimage" runat="server" id="imgProfileView">
                            <asp:Image ID="imgViewImage" runat="server" AlternateText="Image" 
                                Style="max-height: 100px" meta:resourcekey="imgViewImageResource1" />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </ajax:TabPanel>
    </ajax:TabContainer>
    <div class="sfButtonwrapper">
        <asp:ImageButton ID="imgBack" runat="server" OnClick="imgBack_Click" ToolTip="Go Back"
            CausesValidation="False" meta:resourcekey="imgBackResource1" />
        <asp:Label ID="lblBack" runat="server" Text="Cancel" AssociatedControlID="imgBack"
            Style="cursor: pointer;" meta:resourcekey="lblBackResource1"></asp:Label>
    </div>
</asp:Panel>
<asp:Panel ID="pnlUser" runat="server" meta:resourcekey="pnlUserResource1">
    <div class="sfFormwrapper sfPadding">
        <h2>
            <asp:Label ID="lblAddUserHeading" runat="server" Text="Add User" 
                meta:resourcekey="lblAddUserHeadingResource1"></asp:Label>
        </h2>
        <p>
            all <span class="sfRequired">* </span>are required fields</p>
        <table cellspacing="0" cellpadding="0" border="0" width="100%">
            <tr>
                <td width="15%">
                    <asp:Label ID="lblUsername" runat="server" CssClass="sfFormlabel" 
                        Text="Username" meta:resourcekey="lblUsernameResource1"></asp:Label>
                    <span class="sfRequired">*</span>
                </td>
                <td width="2%" align="center">
                    <asp:Label ID="Label2" runat="server" Text=":" 
                        meta:resourcekey="Label2Resource1"></asp:Label>
                </td>
                <td width="30%">
                    <asp:TextBox ID="txtUserName" EnableViewState="False" runat="server" 
                        CssClass="sfInputbox" meta:resourcekey="txtUserNameResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUserName"
                        Display="Dynamic" ErrorMessage="Username is required" CssClass="sfRequired"
                        ValidationGroup="CreateUser" meta:resourcekey="rfvUsernameResource1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmail" runat="server" CssClass="sfFormlabel" Text="Email" 
                        meta:resourcekey="lblEmailResource1"></asp:Label>
                    <span class="sfRequired">*</span>
                </td>
                <td width="2%">
                    <asp:Label ID="Label14" runat="server" Text=":" 
                        meta:resourcekey="Label14Resource1"></asp:Label>
                </td>
                <td width="40%">
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" CssClass="sfInputbox" 
                        meta:resourcekey="txtEmailResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="Email is required." CssClass="sfRequired"
                        ValidationGroup="CreateUser" meta:resourcekey="rfvEmailResource1"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="Enter valid email." CssClass="sfRequired" Text="Enter valid email."
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ValidationGroup="CreateUser" meta:resourcekey="revEmailResource1"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFirstName" runat="server" CssClass="sfFormlabel" 
                        Text="First Name" meta:resourcekey="lblFirstNameResource1"></asp:Label>
                    <span class="sfRequired">*</span>
                </td>
                <td>
                    <asp:Label ID="Label10" runat="server" Text=":" 
                        meta:resourcekey="Label10Resource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="sfInputbox" 
                        meta:resourcekey="txtFirstNameResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                        Display="Dynamic" ErrorMessage="First name is required" 
                        CssClass="sfRequired" ValidationGroup="CreateUser" 
                        meta:resourcekey="rfvFirstNameResource1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLastName" runat="server" CssClass="sfFormlabel" 
                        Text="Last Name" meta:resourcekey="lblLastNameResource1"></asp:Label>
                    <span class="sfRequired">*</span>
                </td>
                <td>
                    <asp:Label ID="Label11" runat="server" Text=":" 
                        meta:resourcekey="Label11Resource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="sfInputbox" 
                        meta:resourcekey="txtLastNameResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtLastName"
                        Display="Dynamic" ErrorMessage="Last name is required" 
                        CssClass="sfRequired" ValidationGroup="CreateUser" 
                        meta:resourcekey="RequiredFieldValidator6Resource1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="hdnPassword" runat="server" />
                    <asp:Label ID="lblPassword" runat="server" CssClass="sfFormlabel" 
                        Text="Password (min 4 chars)" meta:resourcekey="lblPasswordResource1"></asp:Label>
                    <span class="sfRequired">*</span>
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" Text=":" 
                        meta:resourcekey="Label12Resource1"></asp:Label>
                </td>
                <td>
                    <div class="sfPassword">
                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" CssClass="sfInputbox password"
                            TextMode="Password" meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                            Display="Dynamic" ErrorMessage="Password is required" CssClass="sfRequired"
                            ValidationGroup="CreateUser" meta:resourcekey="rfvPasswordResource1"></asp:RequiredFieldValidator>
                        <span id="pwdlblmsg" class="sfRequired"></span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblRetypePassword" runat="server" CssClass="sfFormlabel" 
                        Text="Re-type Password" meta:resourcekey="lblRetypePasswordResource1"></asp:Label>
                    <span class="sfRequired">*</span>
                </td>
                <td>
                    <asp:Label ID="Label13" runat="server" Text=":" 
                        meta:resourcekey="Label13Resource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRetypePassword" MaxLength="20" runat="server" CssClass="sfInputbox"
                        TextMode="Password" meta:resourcekey="txtRetypePasswordResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRetypePassword" CssClass="sfRequired" runat="server"
                        Display="Dynamic" ControlToValidate="txtRetypePassword" 
                        ErrorMessage="Re-type password is required" ValidationGroup="CreateUser" 
                        meta:resourcekey="rfvRetypePasswordResource1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvRetypePassword" runat="server" ControlToCompare="txtPassword"
                        Display="Dynamic" ControlToValidate="txtRetypePassword" ErrorMessage="Retyped password doesnot match."
                        ValidationGroup="CreateUser" meta:resourcekey="cvRetypePasswordResource1"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSecurityQuestion" runat="server" CssClass="sfFormlabel" 
                        Text="Security Question" meta:resourcekey="lblSecurityQuestionResource1"></asp:Label>
                    <span class="sfRequired">*</span>
                </td>
                <td>
                    <asp:Label ID="Label15" runat="server" Text=":" 
                        meta:resourcekey="Label15Resource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSecurityQuestion" runat="server" CssClass="sfInputbox" 
                        meta:resourcekey="txtSecurityQuestionResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSecurityQuestion" runat="server" ControlToValidate="txtSecurityQuestion"
                        Display="Dynamic" ErrorMessage="Security question is required" 
                        CssClass="sfRequired" ValidationGroup="CreateUser" 
                        meta:resourcekey="rfvSecurityQuestionResource1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSecurityAnswer" runat="server" CssClass="sfFormlabel" 
                        Text="Security Answer" meta:resourcekey="lblSecurityAnswerResource1"></asp:Label>
                    <span class="sfRequired">*</span>
                </td>
                <td>
                    <asp:Label ID="Label16" runat="server" Text=":" 
                        meta:resourcekey="Label16Resource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSecurityAnswer" runat="server" CssClass="sfInputbox" 
                        meta:resourcekey="txtSecurityAnswerResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSecurityAnswer" runat="server" ControlToValidate="txtSecurityAnswer"
                        Display="Dynamic" ErrorMessage="Security answer is required" 
                        CssClass="sfRequired" ValidationGroup="CreateUser" 
                        meta:resourcekey="rfvSecurityAnswerResource1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSLM" runat="server" Text="Select Roles" 
                        CssClass="sfFormlabel" meta:resourcekey="lblSLMResource1"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text=":" 
                        meta:resourcekey="Label6Resource1"></asp:Label>
                </td>
                <td class="sfMiddle">
                    <asp:ListBox ID="lstAvailableRoles" CssClass="sfListmenu" runat="server" SelectionMode="Multiple"
                        Rows="10" meta:resourcekey="lstAvailableRolesResource1"></asp:ListBox>
                    <label id="lblValidationmsg1" class="sfRequired">
                    </label>
                </td>
            </tr>
        </table>
    </div>
    <div class="sfButtonwrapper">
        <asp:ImageButton ID="imbCreateUser" ValidationGroup="CreateUser"
            runat="server" ToolTip="Add Users" OnClick="imbCreateUser_Click" 
            meta:resourcekey="imbCreateUserResource1" />
        <asp:Label ID="lblCreateUser" runat="server" Text="Create User" AssociatedControlID="imbCreateUser"
            Style="cursor: pointer;" meta:resourcekey="lblCreateUserResource1"></asp:Label>
        <asp:ImageButton ID="imbBackinfo" runat="server" OnClick="imgBack_Click" 
            ToolTip="Back" meta:resourcekey="imbBackinfoResource1" />
        <asp:Label ID="lblBackinfo" runat="server" Text="Back" 
            AssociatedControlID="imbBackinfo" meta:resourcekey="lblBackinfoResource1"></asp:Label>
    </div>
</asp:Panel>
<asp:Panel ID="pnlUserList" runat="server" 
    meta:resourcekey="pnlUserListResource1">
    <div class="sfButtonwrapper sfPadding">
        <asp:ImageButton ID="imgAddUser" runat="server" OnClick="imgAddUser_Click" 
            ToolTip="Add User" meta:resourcekey="imgAddUserResource1" />
        <asp:Label ID="lblAddUser" runat="server" Text="Add User" AssociatedControlID="imgAddUser"
            Style="cursor: pointer;" meta:resourcekey="lblAddUserResource1"></asp:Label>
        <asp:ImageButton ID="imgBtnDeleteSelected" runat="server" OnClientClick="return ValidateCheckBoxSelection(this)"
            OnClick="imgBtnDeleteSelected_Click" ToolTip="Delete all seleted" 
            meta:resourcekey="imgBtnDeleteSelectedResource1" />
        <asp:Label ID="lblManageCategories" runat="server" Text="Delete all seleted" AssociatedControlID="imgBtnDeleteSelected"
            Style="cursor: pointer;" meta:resourcekey="lblManageCategoriesResource1"></asp:Label>
        <asp:ImageButton ID="imgBtnSaveChanges" runat="server" OnClick="imgBtnSaveChanges_Click"
            ToolTip="Update changes" 
            OnClientClick="return ConfirmDialog(this, 'Confirmation', 'Are you sure you want to save the changes?');" 
            meta:resourcekey="imgBtnSaveChangesResource1" />
        <asp:Label ID="Label5" runat="server" Text="Update changes" AssociatedControlID="imgBtnSaveChanges"
            Style="cursor: pointer;" meta:resourcekey="Label5Resource1"></asp:Label>
        <asp:ImageButton ID="imgBtnSettings" runat="server" ToolTip="UserSettings" 
            OnClick="imgBtnSettings_Click" meta:resourcekey="imgBtnSettingsResource1" />
        <asp:Label ID="lblSettings" runat="server" Text="UserSettings" AssociatedControlID="imgBtnSettings"
            Style="cursor: pointer;" meta:resourcekey="lblSettingsResource1"></asp:Label>
    </div>
    <div class="sfFormwrapper sfUsersearch">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td>
                    <asp:Label ID="lblSearchUserRole" runat="server" CssClass="sfFormlabel" 
                        Text="Select Role" meta:resourcekey="lblSearchUserRoleResource1"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSearchRole" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSearchRole_SelectedIndexChanged"
                        CssClass="sfListmenu" meta:resourcekey="ddlSearchRoleResource1">
                    </asp:DropDownList>
                </td>
                <td width="80">
                    <asp:Label ID="lblSearchUser" runat="server" CssClass="sfFormlabel" 
                        Text="Search User" meta:resourcekey="lblSearchUserResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSearchText" runat="server" OnTextChanged="txtSearchText_TextChanged"
                        CssClass="sfInputbox" MaxLength="50" 
                        meta:resourcekey="txtSearchTextResource1"></asp:TextBox>
                    <ajax:AutoCompleteExtender runat="server" ID="aceSearchText" TargetControlID="txtSearchText"
                        ServicePath="~/SageFrameWebService.asmx" ServiceMethod="GetUsernameList" MinimumPrefixLength="1"
                        DelimiterCharacters="" Enabled="True" />
                </td>
                <td>
                    <label class="sfFormlabel">
                        From</label>
                </td>
                <td>
                    <asp:TextBox ID="txtFrom" runat="server" CssClass="sfInputbox sfInputdate" 
                        meta:resourcekey="txtFromResource1"></asp:TextBox>
                </td>
                <td>
                    <label class="sfFormlabel">
                        To</label>
                </td>
                <td>
                    <asp:TextBox ID="txtTo" runat="server" CssClass="sfInputbox sfInputdate" 
                        meta:resourcekey="txtToResource1"></asp:TextBox>
                </td>
                <td>
                    <div class="sfButtonwrapper">
                        <asp:ImageButton ID="imgSearch" runat="server" OnClick="imgSearch_Click" 
                            ToolTip="Search" meta:resourcekey="imgSearchResource1" />
                        <asp:Label ID="lblSearch" runat="server" Text="Search" AssociatedControlID="imgSearch"
                            Style="cursor: pointer;" CssClass="sfFormlabel" 
                            meta:resourcekey="lblSearchResource1"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="70">
                    <asp:Label ID="lblShowMode" runat="server" Text="Filter Mode" 
                        CssClass="sfFormlabel" meta:resourcekey="lblShowModeResource1"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rbFilterMode" CssClass="sfRadiobutton" RepeatDirection="Horizontal"
                        runat="server" AutoPostBack="True" 
                        OnSelectedIndexChanged="rbFilterMode_SelectedIndexChanged" 
                        meta:resourcekey="rbFilterModeResource1">
                        <asp:ListItem Text="All" Selected="True" Value="0" 
                            meta:resourcekey="ListItemResource1"></asp:ListItem>
                        <asp:ListItem Text="Approved" Value="1" meta:resourcekey="ListItemResource2"></asp:ListItem>
                        <asp:ListItem Text="UnApproved" Value="2" meta:resourcekey="ListItemResource3"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td width="80">
                    <asp:Label ID="lblSRow" runat="server" Text="Show rows" CssClass="sfFormlabel" 
                        meta:resourcekey="lblSRowResource1"></asp:Label>
                </td>
                <td width="70">
                    <asp:DropDownList ID="ddlRecordsPerPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged"
                        CssClass="sfListmenu sfAuto" meta:resourcekey="ddlRecordsPerPageResource1">
                        <asp:ListItem Value="10" meta:resourcekey="ListItemResource4">10</asp:ListItem>
                        <asp:ListItem Value="25" meta:resourcekey="ListItemResource5">25</asp:ListItem>
                        <asp:ListItem Value="50" meta:resourcekey="ListItemResource6">50</asp:ListItem>
                        <asp:ListItem Value="100" meta:resourcekey="ListItemResource7">100</asp:ListItem>
                        <asp:ListItem Value="150" meta:resourcekey="ListItemResource8">150</asp:ListItem>
                        <asp:ListItem Value="200" meta:resourcekey="ListItemResource9">200</asp:ListItem>
                        <asp:ListItem Value="250" meta:resourcekey="ListItemResource10">250</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <div class="sfGridwrapper">
        <asp:GridView ID="gdvUser" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvUser_RowCommand"
            AllowPaging="True" AllowSorting="True" GridLines="None" OnRowDataBound="gdvUser_RowDataBound"
            Width="100%" EmptyDataText="User not found" DataKeyNames="UserId,Username" 
            OnPageIndexChanging="gdvUser_PageIndexChanging" 
            meta:resourcekey="gdvUserResource1">
            <Columns>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                    <ItemTemplate>
                        <input id="chkBoxItem" runat="server" class="sfSelectall" type="checkbox" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <input ID="chkBoxHeader" runat="server" type="checkbox"></input>
                    </HeaderTemplate>
                    <HeaderStyle CssClass="sfCheckbox"></HeaderStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="S.N" meta:resourcekey="TemplateFieldResource2">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource3">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkUsername" runat="server" CommandArgument='<%# Container.DataItemIndex %>'
                            CommandName="EditUser" Text='<%# Eval("Username") %>' 
                            meta:resourcekey="lnkUsernameResource1"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblUsername" runat="server" 
                            meta:resourcekey="lblUsernameResource2" Text="Username"></asp:Label>
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource4">
                    <ItemTemplate>
                        <%# Eval("FirstName")%>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblFirstName" runat="server" 
                            meta:resourcekey="lblFirstNameResource2" Text="First name"></asp:Label>
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource5">
                    <ItemTemplate>
                        <%# Eval("LastName")%>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblLastName" runat="server" 
                            meta:resourcekey="lblLastNameResource2" Text="Last name"></asp:Label>
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource6">
                    <ItemTemplate>
                        <%# Eval("Email")%>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:Label ID="lblEmail" runat="server" meta:resourcekey="lblEmailResource2" 
                            Text="Email"></asp:Label>
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource7">
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnIsActive" runat="server" Value='<%# Eval("IsActive") %>' />
                        <input id="chkBoxIsActiveItem" class="sfIsactive" runat="server" type="checkbox" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <input ID="chkBoxIsActiveHeader" runat="server" type="checkbox"></input>
                        <asp:Label ID="lblIsActive" runat="server" 
                            meta:resourcekey="lblIsActiveResource1" Text="Is Active"></asp:Label>
                    </HeaderTemplate>
                    <HeaderStyle CssClass="sfIsactive" />
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource8">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" CausesValidation="False" CommandArgument='<%# Container.DataItemIndex %>'
                            CommandName="EditUser" ImageUrl='<%# GetTemplateImageUrl("imgedit.png", true) %>'
                            ToolTip="Edit User" meta:resourcekey="imgEditResource1" />
                    </ItemTemplate>
                    <HeaderStyle CssClass="sfEdit" />
                </asp:TemplateField>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource9">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="False" CommandArgument='<%# Container.DataItemIndex %>'
                            CommandName="DeleteUser" OnClientClick="return ConfirmDialog(this, 'Confirmation', 'Are you sure you delete the user?');"
                            ImageUrl='<%# GetTemplateImageUrl("imgdelete.png", true) %>' 
                            ToolTip="Delete User" meta:resourcekey="imgDeleteResource1" />
                    </ItemTemplate>
                    <HeaderStyle CssClass="sfDelete" />
                </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle CssClass="sfOdd" />
            <EmptyDataRowStyle CssClass="sfEmptyrow" />
            <PagerStyle CssClass="sfPagination" />
            <RowStyle CssClass="sfOdd" />
        </asp:GridView>
    </div>
</asp:Panel>
<asp:Panel ID="pnlSettings" runat="server" 
    meta:resourcekey="pnlSettingsResource1">
    <div class="sfFormwrapper sfPadding">
        <h2>
            <asp:Label ID="Label7" runat="server" Text="User Settings" 
                meta:resourcekey="Label7Resource1"></asp:Label>
        </h2>
        <table border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr style="display: none">
                            <td>
                                <asp:Label runat="server" ID="lblDupNames" CssClass="sfFormlabel" 
                                    meta:resourcekey="lblDupNamesResource1">Allow Duplicate UserNames Across Portals:</asp:Label>
                            </td>
                            <td width="30">
                                :
                            </td>
                            <td>
                                <asp:CheckBox ID="chkEnableDupNames" runat="server" 
                                    meta:resourcekey="chkEnableDupNamesResource1" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblDupEmail" CssClass="sfFormlabel" 
                                    meta:resourcekey="lblDupEmailResource1">Allow Duplicate Email:</asp:Label>
                            </td>
                            <td width="30">
                                :
                            </td>
                            <td>
                                <asp:CheckBox ID="chkEnableDupEmail" runat="server" 
                                    meta:resourcekey="chkEnableDupEmailResource1" />
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td>
                                <asp:Label runat="server" ID="lblDupRoles" CssClass="sfFormlabel" 
                                    meta:resourcekey="lblDupRolesResource1">Enable Duplicate Roles Across Portals:</asp:Label>
                            </td>
                            <td width="30">
                                :
                            </td>
                            <td>
                                <asp:CheckBox ID="chkEnableDupRole" runat="server" 
                                    meta:resourcekey="chkEnableDupRoleResource1" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblEnableCaptcha" CssClass="sfFormlabel" 
                                    meta:resourcekey="lblEnableCaptchaResource1">Enable Captcha For User Registration:</asp:Label>
                            </td>
                            <td width="30">
                                :
                            </td>
                            <td>
                                <asp:CheckBox ID="chkEnableCaptcha" runat="server" 
                                    meta:resourcekey="chkEnableCaptchaResource1" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <asp:Panel ID="pnlPasswordEncTypes" runat="server" GroupingText="Password Storage Mode"
                        CssClass="sfPasswordstorage" 
                        meta:resourcekey="pnlPasswordEncTypesResource1">
                        <asp:RadioButtonList ID="rdbLst" runat="server" 
                            meta:resourcekey="rdbLstResource1">
                            <asp:ListItem Value="2" meta:resourcekey="ListItemResource11">One Way Hashed</asp:ListItem>
                            <asp:ListItem Value="3" meta:resourcekey="ListItemResource12">Encrypted</asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <div class="sfButtonwrapper">
            <asp:ImageButton ID="btnSaveSetting" runat="server" OnClick="btnSaveSetting_Click"
                ToolTip="Save" meta:resourcekey="btnSaveSettingResource1" />
            <asp:Label ID="Label1" runat="server" Text="Save" 
                AssociatedControlID="btnSaveSetting" meta:resourcekey="Label1Resource1"></asp:Label>
            <asp:ImageButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" 
                ToolTip="Cancel" meta:resourcekey="btnCancelResource1" />
            <asp:Label ID="Label3" runat="server" Text="Cancel" 
                AssociatedControlID="btnCancel" meta:resourcekey="Label3Resource1"></asp:Label>
        </div>
    </div>
</asp:Panel>
