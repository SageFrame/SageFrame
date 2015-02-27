<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InstallWizard.aspx.cs"
    Inherits="Install_InstallWizard" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<title></title>
 
<link href="css/install.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery-1.4.4.js"></script>
<script type="text/javascript">

    $(document).ready(function() {
        var flag;
        var check = "";
        var ExistingDatabasename = "<%=txtExistingDatabaseName.ClientID%>";
        var NewDatabasename = "<%=txtNewDataBaseName.ClientID%>";
        var btnInstall = "<%=btnInstall.ClientID%>";
        var txtServer = "<%=txtServer.ClientID%>";
        var txtUserId = "<%=txtUserId.ClientID%>";
        var txtPassword = "<%=txtPassword.ClientID%>";
        var chkIntegrated = "<%=chkIntegrated.ClientID %>";
        var txtDataBase = "<%=txtDataBase.ClientID %>";
        var btnTestPermission = "<%=btnTestPermission.ClientID %>";
        $('#' + ExistingDatabasename).attr('disabled', 'disabled');

        check = document.cookie.split(';');
        flag = check[0];
        if (flag == "rdbExistingDatabase") {
            $('#rdbExistingDatabase').attr("checked", true);
            $('#rdbCreateDatabase').attr("checked", false);
            $('#' + NewDatabasename).attr('disabled', 'true').addClass("sfInactive");
            $('#' + NewDatabasename).val('');
            $('#' + ExistingDatabasename).attr('disabled', false).removeClass("sfInactive");

        } if (flag == "rdbCreateDatabase") {
            $('#rdbExistingDatabase').attr("checked", false);
            $('#rdbCreateDatabase').attr("checked", true);
            $('#' + ExistingDatabasename).attr("disabled", "disabled").addClass("sfInactive");
            $('#' + ExistingDatabasename).val('');
            $('#' + NewDatabasename).attr('disabled', false).removeClass("sfInactive");

        }


        $('#' + btnTestPermission).bind("click", function(e) {
            if ($('#rdbCreateDatabase').attr("checked")) {
                document.cookie = $('#rdbCreateDatabase').attr("id");
                check = document.cookie.split(';');
                flag = check[0];
            } else {
                document.cookie = $('#rdbExistingDatabase').attr("id");
                check = document.cookie.split(';');
                flag = check[0];
            }

        });


        $('#' + btnInstall).bind("click", function() {

            if ($('#' + chkIntegrated).attr('checked')) {
                if ($('#' + txtServer).val() == "") {
                    $("#lblServerError").text("Please Enter a Server name");
                    return false;
                }
                if ($('#' + txtDataBase).val() == "") {
                    $("#lblDatabaseError").text("Please Enter a Database Name");
                    return false;
                }
            }
            else {
                var result = true;
                result = CheckValidation();
                return result;
            }

        });


        $('#rdbCreateDatabase').bind("click", function() {
            $('#' + ExistingDatabasename).attr("disabled", "disabled").addClass("sfInactive");
            $('#' + ExistingDatabasename).val('');
            $('#' + NewDatabasename).attr('disabled', false).removeClass("sfInactive");
            $('#lblExistingDatabaseError').html('');
            $('#lblNewDatabaseError').show();

        });
        $('#rdbExistingDatabase').bind("click", function() {
            $('#' + NewDatabasename).attr('disabled', 'true').addClass("sfInactive");
            $('#' + NewDatabasename).val('');
            $('#' + ExistingDatabasename).attr('disabled', false).removeClass("sfInactive");
            $('#lblNewDatabaseError').html('');
            $('#lblExistingDatabaseError').show();
        });

        $('#' + txtServer).keyup(function(e) {
            if ($(this).val().length > 0) {
                $('#lblServerError').html('').hide();
            }
        });
        $('#' + txtDataBase).keyup(function(e) {
            if ($(this).val().length > 0) {
                $('#lblDatabaseError').html('').hide();
            }
        });
        $('#' + txtUserId).keyup(function(e) {
            if ($(this).val().length > 0) {
                $('#lblUserIdError').html('').hide();
            }
        });
        $('#' + txtPassword).keyup(function(e) {
            if ($(this).val().length > 0) {
                $('#lblPasswordError').html('').hide();
            }
        });
        $('#' + ExistingDatabasename).keyup(function(e) {
            if ($(this).val().length > 0) {
                $('#lblExistingDatabaseError').html('').hide();
            }
        });
        $('#' + NewDatabasename).keyup(function(e) {
            if ($(this).val().length > 0) {
                $('#lblNewDatabaseError').html('').hide();
            }
        });
        function CheckValidation() {
            if ($('#' + txtServer).val() == "") {
                $("#lblServerError").text("Please Enter a Server name");
                return false;
            }
            if ($('#' + txtUserId).val() == "") {

                $("#lblUserIdError").text("Please Enter a UserId");
                return false;
            }
            if ($('#' + txtPassword).val() == "") {

                $("#lblPasswordError").text("Please Enter a Password");
                return false;
            }
            if ($('#rdbExistingDatabase').attr("checked") && $('#' + ExistingDatabasename).val() == "") {
                $("#lblExistingDatabaseError").text("Please Enter a Exesting Database Name");
                return false;
            }
            if ($('#rdbCreateDatabase').attr("checked") && $('#' + NewDatabasename).val() == "") {
                $("#lblNewDatabaseError").text("Please Enter a New Database Name");
                return false;
            }

        }
        $('#divTemplateList input:radio').attr("checked", false);
        $('#divTemplateList input:radio:first').attr("checked", true);
        $('#divTemplateList input:radio').live("change", function() {
            if ($(this).attr("checked"))
                $('#divTemplateList input:radio').not($(this)).attr("checked", false);
            else
                $(this).attr("checked", true);
        });

    });
    function eraseCookie(name) {
        createCookie(name, "", -1);
    }

    
    </script>
</head>
<body>
<form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
    <Services>
      <asp:ServiceReference Path="~/SageFrameWebService.asmx" />
    </Services>
  </asp:ScriptManager>
  <div id="sfInstallWrapper">
  
  	<div class="sfLogo">
        <h1>
          <asp:Label ID="lblTitle" runat="server" />
        </h1>
        <div class="sfVersion">
          <asp:Label ID="lblVersion" runat="server" />
        </div>
      </div>
      
      <div class="sfOuter sfCurve">
      
  
    <div class="sfInner sfCurve">
        <asp:Label ID="lblInstallError" runat="server" Visible="false" />
      <asp:HiddenField ID="hdnConnectionStringForAll" runat="server" Value="" />
      <asp:HiddenField ID="hdnNextButtonClientID" runat="server" Value="0" />
      <asp:Label ID="lblPermissionsError" runat="server" CssClass="cssClasssNormalRed"
        EnableViewState="false" Visible="false" />
      <asp:Label ID="lblDataBaseError" runat="server" CssClass="cssClasssNormalRed" EnableViewState="false" />
      <asp:Label ID="lblRequiredDatabaseName" runat="server" CssClass="cssClasssNormalRed"
        EnableViewState="false" />
        
        
      <asp:Panel ID="pnlStartInstall" runat="server">
      <div class="sfInstallpart">
        <div class="sfFormwrapper">
          <table id="tblDatabase" runat="Server" cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
            
            <td>
            <h2>Database Credentials</h2>
            </td>
            </tr>
            <tr>
              <td><asp:Label ID="lblFileName" runat="Server" CssClass="sfFormlabel" /></td>
            </tr>
            <tr class="sfTdseperator">
              <td><asp:Label ID="lblServer" runat="Server" CssClass="sfFormlabel" />
              <asp:TextBox ID="txtServer" runat="Server" CssClass="sfInputbox" />	
              <asp:Label ID="lblServerHelp" runat="Server" CssClass="sfHelptext" /></td>
            </tr>
            <tr>
            
            <td colspan="2"><label id="lblServerError" class="sfError"></label></td>
            </tr>
            <tr class="sfTdseperator">
              <td><asp:Label ID="lblIntegrated" runat="Server" CssClass="sfFormlabel" />
              <asp:CheckBox ID="chkIntegrated" runat="Server" AutoPostBack="True" OnCheckedChanged="chkIntegrated_CheckedChanged"
                                CssClass="sfCheckBox" />
                                <asp:Label ID="lblIntegratedHelp" runat="Server" CssClass="sfHelptext sfInline" /></td>
            </tr>
            <tr id="trDatabaseName" runat="server" visible="false" class="sfTdseperator">
                <td>
                    <h2>Database Name</h2>
                    <asp:Label ID="lblDatabase" runat="Server" CssClass="sfFormlabel" Text="Data Base:" />
                    <asp:TextBox ID="txtDataBase" runat="Server" CssClass="sfInputbox" />
                    <asp:Label ID="lblDatabaseNameHelp" runat="Server" CssClass="sfHelptext" />
                </td>
          
            </tr>
            <tr>
            
            <td colspan="2"><label id="lblDatabaseError" class="sfError"></label></td>
            </tr>
            <tr id="trUser" runat="Server" class="sfTdseperator">
              <td><asp:Label ID="lblUserID" runat="Server" CssClass="sfFormlabel" />
              <asp:TextBox ID="txtUserId" runat="Server" CssClass="sfInputbox" />
              <asp:Label ID="lblUserHelp" runat="Server" CssClass="sfHelptext" /></td>
            </tr>
            <tr>
            <td>
            <label id="lblUserIdError" class="sfError"></label>
            </td>
            </tr>
            <tr id="trPassword" runat="Server" class="sfTdseperator">
              <td><asp:Label ID="lblPassword" runat="Server" CssClass="sfFormlabel" />
              <asp:TextBox ID="txtPassword" runat="Server" CssClass="sfInputbox" TextMode="Password"
                                EnableViewState="true"  />
                                <asp:Label ID="lblPasswordHelp" runat="Server" CssClass="sfHelptext" /><label id="lblPasswordError" class="sfError"></label></td>
                                
                                
            </tr>
            <tr id="trDatabaseHeading" runat="server">
            
            <td>
            <h2>Database Name</h2>
            </td>
            </tr>
            
            <tr><td>
            
            
            <table>
            <tr>
              <td id="trrdbCreateDatabase" runat="server" class="sfTdseperator"> 
                <input id="rdbCreateDatabase"  type="radio" name="rdbDataBase" checked="checked" />
               <h3>Create New Database</h3>
             
                 </td>
                 
                 
              <td id="trrdbExistingDatabase" runat="server" class="sfgap"> 
                <input id="rdbExistingDatabase"  type="radio" name="rdbDataBase" />
                <h3>Existing Database</h3>
                 </td>
                 
                
            </tr>                                       
          
              <tr>
              
              <td id="trnewDatabase" runat="server" class="sfgap">
              <asp:Label ID="lblNewDataBaseName" runat="Server" CssClass="sfFormlabel" Text="Database Name"
                                />
                                <asp:TextBox ID="txtNewDataBaseName" runat="Server" CssClass="sfInputbox" AutoPostBack="false" />
              <asp:Label ID="lblNewDatabaseHelp" runat="Server" CssClass="sfHelptext" />
                 <label id="lblNewDatabaseError" class="sfError"></label>
              </td>
 
           
              <td id="trExistingDatabase" runat="server" class="sfgap2">
              <asp:Label ID="lblExistingDatabaseName" runat="Server" CssClass="sfFormlabel"
                                Text="Database Name" />
                                <asp:TextBox ID="txtExistingDatabaseName" runat="Server" CssClass="sfInputbox" AutoPostBack="false"/>
                                <asp:Label ID="lblExistingDatabaseHelp" runat="Server" CssClass="sfHelptext" />
                                <label id="lblExistingDatabaseError" class="sfError"></label></td>
            </tr>
            </table>
            </td>
            </tr>
            
             
            <%-- <tr class="sfTdseperator">
              <td><asp:Label ID="lblOwner" runat="Server" CssClass="sfFormlabel" />
              <asp:CheckBox ID="chkOwner" runat="Server" CssClass="sfCheckBox" Checked="true" />
              <asp:Label ID="lblOwnerHelp" runat="Server" CssClass="sfHelptext sfInline" /></td>
            </tr>--%>
          </table>
        </div>
        <div id="divTemplateList" class="sfTemplate">
           <tr>
            
            <td>
            <h2>Choose Template :</h2>
            </td>
            </tr>
          <ul>
            <asp:Repeater ID="rptrTemplateList" runat="server">
              <ItemTemplate>
                <li><p>
                    <asp:RadioButton ID="chkIsActive" runat="server" GroupName="SelectTemplate" />
                    <asp:Label ID="lblTemplateName" runat="server" Text='<%#Eval("TemplateName") %>' />
                  </p>
                  <asp:Image ID="imgThubNail" runat="server" ImageUrl='<%#Eval("ThumbImage") %>' />
                  <br />
                  
                </li>
              </ItemTemplate>
            </asp:Repeater>
          </ul>
          <div class="clear"></div>
        </div>

        </div>     
        
         <div class="sfButtonwrapper">
          <asp:Button ID="btnTestPermission" runat="server"  CssClass="sfBtn" Text=" Test Configuration" OnClick="btnTestPermission_Click" />
         </div>
      </div>
      <div class="sfinstalbtn">
      <asp:Button ID="btnInstall" runat="server" CssClass="sfBtn" Text="Install Sageframe" OnClick="btnInstall_Click" />
        </asp:Panel></div>
      <asp:Timer runat="server" ID="UpdateTimer" Interval="1000" OnTick="UpdateTimer_Tick"
        Enabled="false" />
      <asp:UpdatePanel runat="server" ID="TimedPanel" UpdateMode="Conditional">
        <Triggers>
          <asp:AsyncPostBackTrigger ControlID="UpdateTimer" EventName="Tick" />
        </Triggers>
        <ContentTemplate>
          <div class="sfProcessWrapper">
            <div class="sfmaincontent">
              <div class="sfloadingDiv" id="loadingDiv" runat="server">
                <asp:Label ID="lblDBProgress" runat="server" Text="Installing Database Scripts ...Please wait...This may take a moment"
                            EnableViewState="false"></asp:Label>
                <asp:Image ID="imgDBProgress" runat="server" AlternateText="Installing Database Scripts..."
                            ToolTip="Installing Database Scripts..." />
              </div>
              <asp:TextBox ID="txtFeedback" runat="server" class="cssClassFeedBack" Columns="60"
                        Rows="6" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
              <asp:Label ID="lblInstallErrorOccur" runat="server" Visible="false" EnableViewState="false" />
            </div>
          </div>
          <div class="sfButtonwrapper">
          <asp:Button ID="btnCancel" runat="server"  CssClass="sfBtn" Text="Cancel" visible="false"
              onclick="btnCancel_Click"  />
      </div>
        </ContentTemplate>
      </asp:UpdatePanel>
      
    
    </div>
  </div>
  </div>
</form>
</body>
</html>
