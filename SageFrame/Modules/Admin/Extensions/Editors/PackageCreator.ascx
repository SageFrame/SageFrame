<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PackageCreator.ascx.cs"
    Inherits="SageFrame.Modules.Admin.Extensions.Editors.PackageCreator" %>
<%@ Register Src="PackageDetails.ascx" TagName="PackageDetails" TagPrefix="uc1" %>
<script type="text/javascript">
    //<![CDATA[
    var upload;
    var counter = 0;
    $(document).ready(function () {
        NewPackage.Init();

    });
    var NewPackage = {
        Settings: { next: '<%=btnNext.ClientID %>',
            previous: '<%=btnPrevious.ClientID %>',
            ModuleFilePath: 'Modules/Admin/Extensions/Editors/',
            validationObj: '',
            lstSource: []
        },
        Init: function () {
            var lstSource = [];
            var uploadInstallScript = '<%=fuInstallScript.ClientID %>';
            var uploadInstallScript2 = '<%=fuInstallScript2.ClientID %>';
            var uploadInstallScript3 = '<%=fuInstallScript3.ClientID %>';

            var uploadUninstallScript = '<%=fuUnistallScript.ClientID %>';

            var fuIncludeSource = '<%=fuIncludeSource.ClientID %>';
            var hdnInstallScriptFileName = '<%=hdnInstallScriptFileName.ClientID %>';
            var hdnInstallScriptFileName2 = '<%=hdnInstallScriptFileName2.ClientID %>';
            var hdnInstallScriptFileName3 = '<%=hdnInstallScriptFileName3.ClientID %>';

            var hdnSrcZipFile = '<%=hdnSrcZipFile.ClientID %>';
            var lboxcontrolList = '<%=lstFolderFiles.ClientID %>';
            var hdnUnInstallSQLFileName = '<%=hdnUnInstallSQLFileName.ClientID %>';
            var availblelistid = '<%=lbAvailableModules.ClientID %>';
            this.FileUploader(uploadInstallScript, "lblInstallScriptFileName", "sql", hdnInstallScriptFileName);
            this.FileUploader(uploadInstallScript2, "lblInstallScriptFileName2", "sql", hdnInstallScriptFileName2);
            this.FileUploader(uploadInstallScript3, "lblInstallScriptFileName3", "sql", hdnInstallScriptFileName3);

            this.FileUploader(uploadUninstallScript, "lblUninstallScriptName", "sql", hdnUnInstallSQLFileName);
            this.FileUploader(fuIncludeSource, "spIncludeSourceInfo", 'zip,rar', hdnSrcZipFile);
            this.RegisterValidationRules();
            this.AddNavigationRules();
            this.LoadTree();
            this.LoadTree1();

            $('#divTab').on("click",'li', function () {
                $(this).addClass("sfActive");
                $('#divTab li').not($(this)).removeClass("sfActive");
                NewPackage.LoadTree();
            });
            $('#divTab1').on("click", 'li', function () {
                $(this).addClass("sfActive");
                $('#divTab1 li').not($(this)).removeClass("sfActive");
                NewPackage.LoadTree1();
            });

            $('#dvSqlInstaller2').hide();
            $('#dvSqlInstaller3').hide();

            $('#btnAddNew').click(function () {
                if ($('#dvSqlInstaller2').attr('style') == "display: none;") {
                    $('#dvSqlInstaller2').show();
                    $('#dvSqlInstaller3').hide();
                }
                else {
                    $('#dvSqlInstaller2').show();
                    $('#dvSqlInstaller3').show();
                }
            });

            $('#btnMove').on('click', function () {
                if ($('#dvMovedFiles').find('a.active').length > 0) {
                    $('div.dvMovedFileList').append('<div  class="fileName"><div class="sfFileContent">' + $('#dvMoveFiles').find('a.active').attr('rel') + '#' + $('#dvMovedFiles').find('a.active').attr('rel') + '</div><a href="#" class="delete"><img src="/SageFrame/Modules/FileManager/images/delete.png"></a></div>');
                    SageFrame.messaging.show("Moved successfully", "Success");
                }
                else {
                    SageFrame.messaging.show("Please choose source and destination files or folder to move", "Alert");
                    return false;
                }
            });

            $('a.delete').on('click', function () {
                $(this).parents('div.fileName').remove();               
            });
            $('a.deleteScript').on('click', function () {
                $(this).parent('span').html('');
                $(this).remove();
            });


            $('#<%=chkIncludeSource.ClientID %>').click(function () {
                if ($("#<%=chkIncludeSource.ClientID %>").attr("checked")) {
                    $("#divIncludeSource").show();
                }
                else {
                    $("#divIncludeSource").hide();
                    $("#" + hdnSrcZipFile).val("");
                    $("#spIncludeSourceInfo").html("");
                }
            });
            $("#chkControls").click(function () {
                if ($("#chkControls").is(":checked")) {
                    $("#" + lboxcontrolList + " option").attr("selected", "selected");
                }
                else {
                    $("#" + lboxcontrolList + " option").removeAttr("selected");
                }
            });
        },
        LoadTree: function () {
            $('#dvMoveFiles').fileTree({
                root: NewPackage.GetRoot(),
                script: FileManagerPath123 + 'Script/script.aspx',
                expandSpeed: 300,
                collapseSpeed: 300,
                multiFolder: false
            }, function (file) {
            });
        },
        LoadTree1: function () {
            $('#dvMovedFiles').fileTree({
                root: NewPackage.GetRoot1(),
                script: FileManagerPath123 + 'Script/script.aspx',
                expandSpeed: 300,
                collapseSpeed: 300,
                multiFolder: false
            }, function (file) {
            });
        },
        AddNavigationRules: function () {
            var divs = $('#div1, #div2, #div3, #div4, #div5');
            if (counter == 0) {
                $('#div1').show();
                $('#' + NewPackage.Settings.previous).hide();
            }
            $('#' + NewPackage.Settings.next).click(function () {
                if (counter == 0) {
                   var $html = $('div.dvMovedFileList div.sfFileContent');
                  $.each($html, function () {
                       NewPackage.Settings.lstSource[NewPackage.Settings.lstSource.length] = $(this).html();
                    });
                  $("input[id$='hdnSourceFile']").val(NewPackage.Settings.lstSource);
                    return true;
                }
                if (NewPackage.Settings.validationObj.form()) {
                    counter++;
                    if (counter == 5) {
                        $('#' + NewPackage.Settings.next).unbind();
                        return true;
                    }
                    else {
                        $('#' + NewPackage.Settings.previous).show();
                        if (counter == 4) {
                            $('#' + NewPackage.Settings.next).val('Submit').unbind().bind('click', function () {

                                SageFrame.messaging.show("Package created", "Success");
                                divs.hide();
                                $("div.sfButtonwrapper").hide();
                            });
                        }
                        divs.hide()
                         .filter(function (index) { return index == counter }) // figure out correct div to show
                         .show('fast');
                        return false;
                    }
                }
            });
            $('#' + this.Settings.previous).click(function () {
                counter--;
                if (counter == 0) {
                    $('#' + NewPackage.Settings.previous).hide();
                }
                if (counter < 4) {
                    $('#' + NewPackage.Settings.next).val('Next');
                }
                divs.hide() // hide all divs
                .filter(function (index) { return index == counter }) // figure out correct div to show
                .show('fast');
                return false;
            });
        },
        RegisterValidationRules: function () {
            $.validator.addMethod("CheckView", function (value, element) {
                if (counter >= 3) {
                    return $.trim(value).length > 0;
                } else return true;
            }, "Please select View");
            $.validator.addMethod("CheckControls", function (value, element) {
                if (counter >= 2) {
                    return $.trim(value).length > 0;
                } else return true;
            }, "Please select Controls");
            $.validator.addMethod("CheckDLL", function (value, element) {
                if (counter == 4) {
                    return $.trim(value).length > 0;
                } return true;
            }, "Please select DLL files");
            this.Settings.validationObj = $("#form1").validate();
        },
        GetRoot: function () {
            var tab = $('#divTab  li');
            var getFolders = "";
            var folderPath = "";
            $.each(tab, function (index, item) {
                if ($(this).hasClass("sfActive")) {
                    getFolders = $(this).attr('id');
                }
            });
            if (getFolders == "Template") {
                folderPath = "/Templates/";
            }
            if (getFolders == "Module") {

                folderPath = "/Modules/";
            }
            if (getFolders == "System") {
                folderPath = "/";
            }
            return folderPath;
        },
        GetRoot1: function () {
            var tab = $('#divTab1  li');
            var getFolders = "";
            var folderPath = "";
            $.each(tab, function (index, item) {
                if ($(this).hasClass("sfActive")) {
                    getFolders = $(this).attr('id');
                }
            });
            if (getFolders == "Template1") {
                folderPath = "/Templates/";
            }
            if (getFolders == "Module1") {

                folderPath = "/Modules/";
            }
            if (getFolders == "System1") {
                folderPath = "/";
            }
            return folderPath;
        },
        RemoveSelected: function () {
            var tree = $('#divFileTree ul li');
            if (tree.length > 0) {
                $.each(tree, function (index, item) {
                    $(this).find("a").removeClass("cssClassTreeSelected");
                    $(this).find("a").removeClass("cssClassTreeSelectedDB");
                    $(this).find("a").removeClass("cssClassTreeSelectedLocked");
                });
            }

        },

        FileUploader: function (element, divID, validExtension, hdnSQLScriptFileName) {
            var uploadFlag = false;
            upload = new AjaxUpload($('#' + element), {
                action: sageRootPah + this.Settings.ModuleFilePath + 'UploadHandler.ashx',
                name: 'myfile[]',
                multiple: true,
                data: { folderPath: '<%=tmpFoldName.Value%>' },
                autoSubmit: true,
                responseType: 'json',
                onChange: function (file, ext) {
                },
                onSubmit: function (file, ext) {
                    if (validExtension.toLowerCase().indexOf(ext.toLowerCase()) < 0) {
                        alert("Not a valid " + validExtension + " file!</p>");
                        return false;
                    }
                },
                onComplete: function (file, response) {
                    var res = eval(response);
                    if (res && res.Status > 0) {
                        alert("Error while uploading file");
                    }
                    else {
                        $("#" + hdnSQLScriptFileName).val(file);
                        $("#" + divID).html(file + '<a href="#" class="deleteScript"><img src="/SageFrame/Modules/FileManager/images/delete.png"></a>');

                    }
                }
            });
        }
    }
    //]]>	
        
</script>
<div id="SubmitConfirmation" style="display: none;">
    Your Package has been created successfully.</div>
<div id="div1" style="display: none">
    <div class="sfFormwrapper sfPadding">
        <uc1:PackageDetails ID="PackageDetails1" runat="server" />
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td width="20%">
                    <asp:Label ID="lblfriendlyname" runat="server" Text="Friendly name" CssClass="sfFormlabel"
                        meta:resourcekey="lblfriendlynameResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtfriendlyname" runat="server" CssClass="sfInputbox" meta:resourcekey="txtfriendlynameResource1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblmodulename" runat="server" Text="Module name" CssClass="sfFormlabel required"
                        meta:resourcekey="lblmodulenameResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtmodulename" runat="server" CssClass="sfInputbox required" meta:resourcekey="txtmodulenameResource1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblbusinesscontrollerclass" runat="server" Text="Business controller class"
                        CssClass="sfFormlabel" meta:resourcekey="lblbusinesscontrollerclassResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtbusinesscontrollerclass" runat="server" CssClass="sfInputbox"
                        meta:resourcekey="txtbusinesscontrollerclassResource1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblcompatibleversions" runat="server" Text="Compatible versions" CssClass="sfFormlabel"
                        meta:resourcekey="lblcompatibleversionsResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtcompatibleversions" runat="server" CssClass="sfInputbox" meta:resourcekey="txtcompatibleversionsResource1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Cache Time" CssClass="sfFormlabel" meta:resourcekey="lblcompatibleversionsResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCacheTime" runat="server" CssClass="sfInputbox" meta:resourcekey="txtCacheTime"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblModuleSelect" runat="server" Text="Select a Folder" CssClass="sfFormlabel  required"
                        meta:resourcekey="lblModuleSelectResource1"></asp:Label>
                </td>
                <td>
                    <div class="sfAvailableModules">
                        <asp:ListBox ID="lbAvailableModules" runat="server" CssClass="sfListmenubig required"
                            SelectionMode="Single" Height="200"></asp:ListBox>
                    </div>
                    <div class='sfSelectedModules' style="display: none">
                        <asp:ListBox ID="lbModulesList" CssClass="sfListmenubig" runat="server" SelectionMode="Multiple"
                            Height="200"></asp:ListBox>
                        <asp:RequiredFieldValidator ID="rfvModulesList" runat="server" ControlToValidate="lbModulesList"
                            ValidationGroup="vdgExtension" ErrorMessage="* Please choose items" SetFocusOnError="True"
                            CssClass="sfError" meta:resourcekey="rfvModulesListResource1"></asp:RequiredFieldValidator>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Files To Move" CssClass="sfFormlabel"
                        meta:resourcekey="lblModuleSelectResource1"></asp:Label>
                </td>
                <td>
                    <div id="divFileTreeOuter">
                        <div id="divTab">
                            <ul class="sfTab">
                                <li id="Module" class="sfActive">
                                    <label class="sfFormlabel">
                                        Modules</label></li>
                            </ul>
                        </div>
                        <div class="clear">
                        </div>
                        <div id="dvMoveFiles" class="sfMove">
                        </div>
                    </div>
                </td>
                <td>
                    <input type="button" id="btnMove" class="sfBtn" value="Move ->>" />
                    <asp:HiddenField ID="hdnSourceFile" runat="server" />
                    <asp:HiddenField ID="hdnDestFile" runat="server" />
                </td>
                <td>
                    <div id="divFileTreeOuter1">
                        <div id="divTab1">
                            <ul class="sfTab1">
                                <li id="Template1" class="sfActive">
                                    <label class="sfFormlabel">
                                        Template</label></li>
                                <li id="Module1">
                                    <label class="sfFormlabel">
                                        Modules</label></li>
                                <li id="System1">
                                    <label class="sfFormlabel">
                                        System</label></li>
                            </ul>
                        </div>
                        <div class="clear">
                        </div>
                        <div id='dvMovedFiles' class="sfMove">
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <div class="dvMovedFileList">
        </div>
    </div>
</div>
<div id="div2" style="display: none">
    <div class="sfFormwrapper sfPadding">
        <div id="dvSqlInstaller">
            <h2>
                <asp:Label ID="lblInstallScript" runat="server" Text="Sql Script for Install:" meta:resourcekey="lblInstallScriptResource1"></asp:Label>
            </h2>
            <asp:FileUpload ID="fuInstallScript" runat="server" />
            <asp:HiddenField ID="hdnInstallScriptFileName" runat="server" />
            <span id="lblInstallScriptFileName"></span>
            <h3>
                OR Paste SQL Script below:</h3>
            <asp:TextBox Rows="18" Columns="280" runat="server" ID="InstallScriptTxt" TextMode="MultiLine"
                CssClass="sfTextarea sfFullwidth CheckSqlInstallContent" />
            <div class="orderWrapper">
                <asp:Label ID="Label4" runat="server" Text="Order" CssClass="sfFormlabel"></asp:Label>
                <asp:DropDownList ID="ddlOrder" runat="server" CssClass="sfOrder">
                    <asp:ListItem Value="01">1</asp:ListItem>
                    <asp:ListItem Value="02">2</asp:ListItem>
                    <asp:ListItem Value="03">3</asp:ListItem>
                    <asp:ListItem Value="04">4</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div id="dvSqlInstaller2">
            <h2>
                <asp:Label ID="lblInstallScript2" runat="server" Text="Sql Script for Install:" meta:resourcekey="lblInstallScriptResource1"></asp:Label>
            </h2>
            <asp:FileUpload ID="fuInstallScript2" runat="server" />
            <asp:HiddenField ID="hdnInstallScriptFileName2" runat="server" />
            <span id="lblInstallScriptFileName2"></span>
            <h3>
                OR Paste SQL Script below:</h3>
            <asp:TextBox Rows="18" Columns="280" runat="server" ID="InstallScriptTxt2" TextMode="MultiLine"
                CssClass="sfTextarea sfFullwidth CheckSqlInstallContent" />
            <div class="orderWrapper">
                <asp:Label ID="Label15" runat="server" Text="Order" CssClass="sfFormlabel"></asp:Label>
                <asp:DropDownList ID="ddlOrder2" runat="server" CssClass="sfOrder">
                    <asp:ListItem Value="01">1</asp:ListItem>
                    <asp:ListItem Value="02">2</asp:ListItem>
                    <asp:ListItem Value="03">3</asp:ListItem>
                    <asp:ListItem Value="04">4</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div id="dvSqlInstaller3">
            <h2>
                <asp:Label ID="lblInstallScript3" runat="server" Text="Sql Script for Install:" meta:resourcekey="lblInstallScriptResource1"></asp:Label>
            </h2>
            <asp:FileUpload ID="fuInstallScript3" runat="server" />
            <asp:HiddenField ID="hdnInstallScriptFileName3" runat="server" />
            <span id="lblInstallScriptFileName3"></span>
            <h3>
                OR Paste SQL Script below:</h3>
            <asp:TextBox Rows="18" Columns="280" runat="server" ID="InstallScriptTxt3" TextMode="MultiLine"
                CssClass="sfTextarea sfFullwidth CheckSqlInstallContent" />
            <div class="orderWrapper">
                <asp:Label ID="Label17" runat="server" Text="Order" CssClass="sfFormlabel"></asp:Label>
                <asp:DropDownList ID="ddlOrder3" runat="server" CssClass="sfOrder">
                    <asp:ListItem Value="01">1</asp:ListItem>
                    <asp:ListItem Value="02">2</asp:ListItem>
                    <asp:ListItem Value="03">3</asp:ListItem>
                    <asp:ListItem Value="04">4</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <input id="btnAddNew" type="button" value="AddNew" class="sfBtn" />
        <div id="dvSqlUnInstaller">
            <h3>
                <asp:Label ID="lblUnistallScript" runat="server" Text="Sql Script for Uninstall:"
                    meta:resourcekey="lblUnistallScriptResource1"></asp:Label>
            </h3>
            <asp:FileUpload ID="fuUnistallScript" runat="server" />
            <asp:HiddenField ID="hdnUnInstallSQLFileName" runat="server" />
            <span id="lblUninstallScriptName"></span>
            <h3>
                OR Paste SQL Script below:</h3>
            <asp:TextBox Rows="18" Columns="280" runat="server" ID="UnistallScriptTxt" TextMode="MultiLine"
                CssClass="sfTextarea sfFullwidth" />
            <div class="orderWrapper">
                <asp:Label runat="server" Text="Order" CssClass="sfFormlabel"></asp:Label>
                <asp:DropDownList ID="ddlUnInstallOrder" runat="server" CssClass="sfOrder">
                    <asp:ListItem Value="01">1</asp:ListItem>
                    <asp:ListItem Value="02">2</asp:ListItem>
                    <asp:ListItem Value="03">3</asp:ListItem>
                    <asp:ListItem Value="04">4</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="sfCheckbox">
            <asp:CheckBox ID="chkIncludeSource" runat="server" Text="Include Source File?" />
        </div>
        <div id="divIncludeSource" style="display: none" class="sfUploadfile clearfix">
            <p>
                <asp:Label ID="lblIncludeSource" runat="server" Text="Upload Source Files Zip:" CssClass="sfFormlabel"
                    meta:resourcekey="lblIncludeSourceResource1"></asp:Label>
            </p>
            <asp:FileUpload ID="fuIncludeSource" runat="server" />
            <asp:HiddenField ID="hdnSrcZipFile" runat="server" />
            <span id="spIncludeSourceInfo" />
        </div>
    </div>
</div>
<div id="div3" style="display: none">
    <div class="sfFormwrapper sfPadding">
        <p class="sfNote">
            <asp:Label ID="lblFilesList" runat="server" Text="The List of files for the package is shown here.In this section you can add,edit or delete the files for this package."
                meta:resourcekey="lblFilesListResource1"></asp:Label>
        </p>
        <asp:ListBox runat="server" ID="lstFolderFiles" SelectionMode="Multiple" CssClass="sfListmenubig sfFullwidth" />
        <br />
        <br />
        <div class="sfCheckbox">
            <input type="checkbox" id="chkControls" />
            <label>
                Select All Files.</label>
        </div>
    </div>
</div>
<div id="div4" style="display: none">
    <div class="sfFormwrapper sfPadding">
        <h3>
            Select View</h3>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr id="rowSource" runat="server">
                <td width="20%" id="Td5" runat="server">
                    <asp:Label ID="lblSource" runat="server" Text="Source" CssClass="sfFormlabel"></asp:Label>
                </td>
                <td id="Td6" runat="server">
                    <asp:DropDownList runat="server" ID="ddlViewControlSrc" CssClass="sfListmenu" AutoPostBack="false" />
                </td>
            </tr>
            <tr>
                <td width="20%">
                    <asp:Label ID="lblKey" runat="server" Text="Key" CssClass="sfFormlabel " meta:resourcekey="lblKeyResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtViewKey" runat="server" CssClass="sfInputbox CheckView" meta:resourcekey="txtKeyResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvModulekey" runat="server" ControlToValidate="txtViewKey"
                        ValidationGroup="vdgExtension" ErrorMessage="*" SetFocusOnError="True" CssClass="sfError"
                        meta:resourcekey="rfvModulekeyResource1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblViewTitle" runat="server" Text="Title" CssClass="sfFormlabel" meta:resourcekey="lblTitleResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtViewTitle" runat="server" CssClass="sfInputbox" meta:resourcekey="txtTitleResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvModuleTitle" runat="server" ControlToValidate="txtViewTitle"
                        ValidationGroup="vdgExtension" ErrorMessage="*" SetFocusOnError="True" CssClass="sfError"
                        meta:resourcekey="rfvModuleTitleResource1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr visible="false" runat="server">
                <td>
                    <asp:Label ID="lblType" runat="server" Text="Type" CssClass="sfFormlabel" meta:resourcekey="lblTypeResource1"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="sfListmenu" meta:resourcekey="ddlTypeResource1" />
                    <asp:Label ID="lblErrorControlType" runat="server" CssClass="sfError" Text="*" Visible="False"
                        meta:resourcekey="lblErrorControlTypeResource1"></asp:Label>
                </td>
            </tr>
            <tr id="rowDisplayOrder" runat="server" visible="False">
                <td id="Td7" runat="server">
                    <asp:Label ID="lblDisplayOrder" runat="server" Text="Display Order" CssClass="sfFormlabel"></asp:Label>
                </td>
                <td id="Td8" runat="server">
                    <asp:TextBox ID="txtDisplayOrder" runat="server" CssClass="sfInputbox" MaxLength="2"
                        Text="0"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblIcon" runat="server" Text="Icon" CssClass="sfFormlabel" meta:resourcekey="lblIconResource1"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlViewIcon" runat="server" CssClass="sfListmenu" meta:resourcekey="ddlIconResource1" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblHelpURL" runat="server" Text="Help URL" CssClass="sfFormlabel"
                        meta:resourcekey="lblHelpURLResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtViewHelpURL" runat="server" CssClass="sfInputbox" meta:resourcekey="txtHelpURLResource1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revHelpUrl" runat="server" ControlToValidate="txtViewHelpURL"
                        CssClass="sfError" ErrorMessage="The Help Url is not valid." SetFocusOnError="True"
                        ValidationExpression="^(([\w]+:)?\/\/)?(([\d\w]|%[a-fA-f\d]{2,2})+(:([\d\w]|%[a-fA-f\d]{2,2})+)?@)?([\d\w][-\d\w]{0,253}[\d\w]\.)+[\w]{2,4}(:[\d]+)?(\/([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)*(\?(&amp;?([-+_~.\d\w]|%[a-fA-f\d]{2,2})=?)*)?(#([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)?$"
                        meta:resourcekey="revHelpUrlResource1"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSupportsPartialRendering" runat="server" Text="Supports Partial Rendering?"
                        CssClass="sfFormlabel" meta:resourcekey="lblSupportsPartialRenderingResource1"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chkViewSupportsPartialRendering" runat="server" CssClass="sfCheckbox"
                        meta:resourcekey="chkSupportsPartialRenderingResource1" />
                </td>
            </tr>
        </table>
        <h3>
            Select Edit</h3>
        <div class="sfFormwrapper">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr id="Tr3" runat="server">
                    <td id="Td13" runat="server">
                        <asp:Label ID="Label6" runat="server" Text="Source" CssClass="sfFormlabel"></asp:Label>
                    </td>
                    <td id="Td14" runat="server">
                        <asp:DropDownList ID="ddlEditControlSrc" runat="server" CssClass="sfListmenu" AutoPostBack="false" />
                    </td>
                </tr>
                <tr>
                    <td width="20%">
                        <asp:Label ID="Label7" runat="server" Text="Key:" CssClass="sfFormlabel" meta:resourcekey="lblKeyResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEditKey" runat="server" CssClass="sfInputbox" meta:resourcekey="txtKeyResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEditKey"
                            ValidationGroup="vdgExtension" ErrorMessage="*" SetFocusOnError="True" CssClass="sfError"
                            meta:resourcekey="rfvModulekeyResource1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Title" CssClass="sfFormlabel" meta:resourcekey="lblTitleResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEditTitle" runat="server" CssClass="sfInputbox" meta:resourcekey="txtTitleResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEditTitle"
                            ValidationGroup="vdgExtension" ErrorMessage="*" SetFocusOnError="True" CssClass="sfError"
                            meta:resourcekey="rfvModuleTitleResource1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr visible="false" runat="server">
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Type" CssClass="sfFormlabel" meta:resourcekey="lblTypeResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTypeIcon" runat="server" CssClass="sfListmenu" meta:resourcekey="ddlTypeResource1" />
                        <asp:Label ID="Label10" runat="server" CssClass="sfError" Text="*" Visible="False"
                            meta:resourcekey="lblErrorControlTypeResource1"></asp:Label>
                    </td>
                </tr>
                <tr id="Tr4" runat="server" visible="False">
                    <td id="Td15" runat="server">
                        <asp:Label ID="Label11" runat="server" Text="Display Order" CssClass="sfFormlabel"></asp:Label>
                    </td>
                    <td id="Td16" runat="server">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="sfInputbox" MaxLength="2" Text="0"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Icon" CssClass="sfFormlabel" meta:resourcekey="lblIconResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEditIcon" runat="server" CssClass="sfListmenu" meta:resourcekey="ddlIconResource1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label13" runat="server" Text="Help URL" CssClass="sfFormlabel" meta:resourcekey="lblHelpURLResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEditHelpURL" runat="server" CssClass="sfInputbox" meta:resourcekey="txtHelpURLResource1"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEditHelpURL"
                            CssClass="sfError" ErrorMessage="The Help Url is not valid." SetFocusOnError="True"
                            ValidationExpression="^(([\w]+:)?\/\/)?(([\d\w]|%[a-fA-f\d]{2,2})+(:([\d\w]|%[a-fA-f\d]{2,2})+)?@)?([\d\w][-\d\w]{0,253}[\d\w]\.)+[\w]{2,4}(:[\d]+)?(\/([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)*(\?(&amp;?([-+_~.\d\w]|%[a-fA-f\d]{2,2})=?)*)?(#([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)?$"
                            meta:resourcekey="revHelpUrlResource1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="Supports Partial Rendering?" CssClass="sfFormlabel"
                            meta:resourcekey="lblSupportsPartialRenderingResource1"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkEditSupportsPartialRendering" runat="server" CssClass="sfCheckbox"
                            meta:resourcekey="chkSupportsPartialRenderingResource1" />
                    </td>
                </tr>
            </table>
        </div>
        <h3>
            Select Setting</h3>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr id="Tr7" runat="server">
                <td id="Td21" runat="server">
                    <asp:Label ID="lblSettingControlSearc" runat="server" Text="Source" CssClass="sfFormlabel"></asp:Label>
                </td>
                <td id="Td22" runat="server">
                    <asp:DropDownList ID="ddlSettingControlSrc" runat="server" AutoPostBack="false" CssClass="sfListmenu" />
                </td>
            </tr>
            <tr>
                <td width="20%">
                    <asp:Label ID="Label20" runat="server" Text="Key" CssClass="sfFormlabel" meta:resourcekey="lblKeyResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSettingKey" runat="server" CssClass="sfInputbox" meta:resourcekey="txtKeyResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSettingKey"
                        ValidationGroup="vdgExtension" ErrorMessage="*" SetFocusOnError="True" CssClass="sfError"
                        meta:resourcekey="rfvModulekeyResource1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label21" runat="server" Text="Title" CssClass="sfFormlabel" meta:resourcekey="lblTitleResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSettingTitle" runat="server" CssClass="sfInputbox" meta:resourcekey="txtTitleResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSettingTitle"
                        ValidationGroup="vdgExtension" ErrorMessage="*" SetFocusOnError="True" CssClass="sfError"
                        meta:resourcekey="rfvModuleTitleResource1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr visible="false" runat="server">
                <td>
                    <asp:Label ID="Label22" runat="server" Text="Type" CssClass="sfFormlabel" meta:resourcekey="lblTypeResource1"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList5" runat="server" CssClass="sfListmenu" meta:resourcekey="ddlTypeResource1" />
                    <asp:Label ID="Label23" runat="server" CssClass="sfError" Text="*" Visible="False"
                        meta:resourcekey="lblErrorControlTypeResource1"></asp:Label>
                </td>
            </tr>
            <tr id="Tr8" runat="server" visible="False">
                <td id="Td23" runat="server">
                    <asp:Label ID="Label24" runat="server" Text="Display Order" CssClass="sfFormlabel"></asp:Label>
                </td>
                <td id="Td24" runat="server">
                    <asp:TextBox ID="TextBox8" runat="server" CssClass="sfInputbox" MaxLength="2" Text="0"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label25" runat="server" Text="Icon" CssClass="sfFormlabel" meta:resourcekey="lblIconResource1"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSettingIcon" runat="server" CssClass="sfListmenu" meta:resourcekey="ddlIconResource1" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label26" runat="server" Text="Help URL" CssClass="sfFormlabel" meta:resourcekey="lblHelpURLResource1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSettingHelpURL" runat="server" CssClass="sfInputbox" meta:resourcekey="txtHelpURLResource1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSettingHelpURL"
                        CssClass="sfError" ErrorMessage="The Help Url is not valid." SetFocusOnError="True"
                        ValidationExpression="^(([\w]+:)?\/\/)?(([\d\w]|%[a-fA-f\d]{2,2})+(:([\d\w]|%[a-fA-f\d]{2,2})+)?@)?([\d\w][-\d\w]{0,253}[\d\w]\.)+[\w]{2,4}(:[\d]+)?(\/([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)*(\?(&amp;?([-+_~.\d\w]|%[a-fA-f\d]{2,2})=?)*)?(#([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)?$"
                        meta:resourcekey="revHelpUrlResource1"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label27" runat="server" Text="Supports Partial Rendering?" CssClass="sfFormlabel"
                        meta:resourcekey="lblSupportsPartialRenderingResource1"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chkSettingSupportsPartialRendering" runat="server" CssClass="sfCheckbox"
                        meta:resourcekey="chkSupportsPartialRenderingResource1" />
                </td>
            </tr>
        </table>
    </div>
</div>
<div id="div5" style="display: none">
    <div class="sfFormwrapper sfPadding">
        <p class="sfNote">
            <asp:Label ID="Label1" runat="server" Text="In this section you can select Assemblies to include in this package."
                meta:resourcekey="lblManifestPreviewResource1"></asp:Label>
        </p>
        <asp:ListBox runat="server" ID="lstAssembly" SelectionMode="Multiple" CssClass="sfListmenubig CheckDLL"
            Height="300" Width="500"></asp:ListBox>
    </div>
</div>
<div id="div6" style="display: none">
    <div class="sfFormwrapper sfPadding">
        <div>
            <asp:Label ID="lblCreateManifest" runat="server" Text="Create Manifest:" CssClass="sfFormlabel"
                meta:resourcekey="lblCreateManifestResource1"></asp:Label>
            <asp:CheckBox ID="chkManifest" runat="server" Checked="true" />
        </div>
        <div class="sfFormItem" id="trManifest2" runat="server">
            <asp:Label ID="lblManifestName" runat="server" Text="Manifest File Name:" CssClass="sfFormlabel"
                meta:resourcekey="lblManifestNameResource1"></asp:Label>
            <asp:TextBox ID="txtManifestName" runat="server" Style="width: 250px" />
        </div>
        <div class="sfFormItem">
            <asp:Label ID="lblCreatePackage" runat="server" Text="Create Package:" CssClass="sfFormlabel"
                meta:resourcekey="lblCreatePackageResource1"></asp:Label>
            <asp:CheckBox ID="chkPackage" runat="server" Checked="true" />
        </div>
        <div class="sfFormItem">
            <asp:Label ID="lblPackageName" runat="server" Text="Package Zip Name:" CssClass="sfFormlabel"
                meta:resourcekey="lblPackageNameResource1"></asp:Label>
            <asp:TextBox ID="txtPackageName" runat="server" />
            <asp:HiddenField ID="tmpFoldName" runat="server" />
        </div>
    </div>
</div>
<div class="sfButtonwrapper">
    <asp:Button ID="btnPrevious" runat="server" AlternateText="Previous" CausesValidation="False"
        CommandName="Previous" CssClass="sfBtn" Text="Previous" meta:resourcekey="btnPreviousResource2" />
    <asp:Button ID="btnNext" runat="server" AlternateText="Next" CausesValidation="False"
        CommandName="Next" CssClass="sfBtn" Text="Next" meta:resourcekey="btnNextResource1"
        OnClick="btnSubmit_Click" />
    <asp:Button ID="btnCancelled" runat="server" AlternateText="Cancel" CssClass="sfBtn"
        Text="Cancel" meta:resourcekey="btnCancelResource2" 
        UseSubmitBehavior="false" onclick="btnCancelled_Click"    />
</div>
