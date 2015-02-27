<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LanguageManager.ascx.cs"
    Inherits="Localization_Language" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Modules/Language/CreateLanguagePack.ascx" TagName="CreateLanguagePack"
    TagPrefix="uc1" %>
<%@ Register Src="~/Modules/Language/LanguagePackInstaller.ascx" TagName="LanguagePackInstaller"
    TagPrefix="uc2" %>
<%@ Register Src="~/Modules/Language/LanguageSetUp.ascx" TagName="LanguageSetUp"
    TagPrefix="uc3" %>
<%@ Register Src="~/Modules/Language/TimeZoneEditor.ascx" TagName="TimeZoneEditor"
    TagPrefix="uc4" %>


<script type="text/javascript">
    $.Localization = {
        TextAreaID: 0,
        FilePath: "",
        ID: 0,
        GridID: '<%=gdvResxKeyValue.ClientID%>'

    };
    $(document).ready(function() {
        //BindList();
        $('#' + $.Localization.GridID + ' img[class="sfEdit"]').live("click", function() {
            var index = $(this).attr("alt");
            $.Localization.ID = index;
            var data = $('#' + $.Localization.GridID + ' textarea[title="' + index + '"]').val();
            $('#txtResxValueEditor').val(data);
            ShowPopUp("editorDiv");

        });
        $('#txtResxValueEditor').ckeditor("config");
        BindEvents();

    });

    function BindEvents() {
        $('#fade').click(function() {
            $('#fade,#editorDiv,#translatorDiv,#divMessagePopUp,#divConfirmPopUp').fadeOut();
        });
        $('#btnCloseFB').bind("click", function() {
            var id = $.Localization.ID;
            $('#' + $.Localization.GridID + ' textarea[title="' + id + '"]').val($('#txtResxValueEditor').val());
            $('#editorDiv').dialog("close");
        });
        $('.closePopUp').bind("click", function() {
            $('#fade,#editorDiv,#translatorDiv,#divMessagePopUp,#divConfirmPopUp').fadeOut();
        });

        $('#btnSave').bind("click", function() {
            var id = $.Localization.ID;
            $('#' + $.Localization.GridID + ' textarea[title="' + id + '"]').val($('#translatedTxt').val());
            $('#translatorDiv,#fade').fadeOut();
        });



    }
    function ShowPopUp(popupid) {

        var options = {
            modal: true,
            title: "Edit Language",
            height: 500,
            width: 600,
            dialogClass: "sfFormwrapper"
        };
        dlg = $('#' + popupid).dialog(options);
        dlg.parent().appendTo($('form:first'));

    }
       
</script>

<div id="divActivityIndicator">
</div>
<div id="fade">
</div>
<div id="langEditFirstDiv" runat="server">
    <h1>
        <asp:Label ID="lblTimeZoneEditor" runat="server" Text="Language Manager" meta:resourcekey="lblTimeZoneEditorResource1"></asp:Label>
    </h1>
    <div class="sfFormwrapper sfPadding">
        <asp:HiddenField ID="hdnCultureCode" runat="server" Value="en-US" />
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td width="100">
                    <asp:Label ID="lblSysDefault" runat="server" Text="System Default" CssClass="sfFormlabel"
                        meta:resourcekey="lblSysDefaultResource1"></asp:Label>
                </td>
                <td width="30">
                    :
                </td>
                <td colspan="3">
                    <asp:Image ID="imgFlagSystemDefault" runat="server" meta:resourcekey="imgFlagSystemDefaultResource2" />
                    <asp:Label ID="lblSystemDefault" runat="server" meta:resourcekey="lblSystemDefaultResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCurrentCultureLbl" runat="server" Text="Current Culture:" CssClass="sfFormlabel"
                        meta:resourcekey="lblCurrentCultureLblResource1"></asp:Label>
                </td>
                <td width="30">
                    :
                </td>
                <td colspan="3">
                    <asp:Image ID="imgFlagCurrentCulture" runat="server" meta:resourcekey="imgFlagCurrentCultureResource1" />
                    <asp:Label ID="lblCurrentCulture" runat="server" meta:resourcekey="lblSiteDefaultResource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <p class="sfNote">
                        The default site language cannot be disabled</p>
                </td>
                <td width="110">
                    <asp:Label ID="lblPageSize" runat="server" Text="Page Size:" CssClass="sfFormlabel"
                        meta:resourcekey="lblPageSizeResource1"></asp:Label>
                    <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="sfListmenu sfAuto" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged1" meta:resourcekey="ddlPageSizeResource1">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <div class="sfGridwrapper sfPadding sfMargintop">
        <asp:GridView ID="gdvLangList" runat="server" GridLines="None" AllowPaging="True"
            Width="100%" AutoGenerateColumns="False" OnRowCommand="gdvLangList_RowCommand"
            OnRowDataBound="gdvLangList_RowDataBound" meta:resourcekey="gdvLangListResource1"
            OnPageIndexChanging="gdvLangList_PageIndexChanging" DataKeyNames="LanguageID">
            <Columns>
                <asp:TemplateField HeaderText="Language" meta:resourcekey="TemplateFieldResource1">
                    <ItemTemplate>
                        <asp:Image ID="imgFlag" runat="server" meta:resourcekey="imgFlagResource2" />
                        <span class="cssClassLangName">
                            <asp:Label ID="lblLanguageName" runat="server" Text='<%# Eval("LanguageN") %>' meta:resourcekey="lblLanguageNameResource1"></asp:Label>
                        </span><span class="cssClassCountry">(
                            <asp:Label ID="lblCountryName" runat="server" Text='<%# Eval("Country") %>' meta:resourcekey="lblCountryNameResource1"></asp:Label>
                            ) </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="LanguageCode" HeaderText="Code" meta:resourcekey="BoundFieldResource1">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="IsEnabled" meta:resourcekey="TemplateFieldResource2">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkIsEnabled" runat="server" meta:resourcekey="chkIsEnabledResource2"
                            OnCheckedChanged="chkIsEnabled_CheckedChanged" AutoPostBack="True" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle CssClass="sfEnable" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit" meta:resourcekey="TemplateFieldResource3">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnLanguageDel" runat="server" ImageUrl="~/Administrator/Templates/Default/images/imgedit.png"
                            CommandName="EditResources" CommandArgument='<%# Container.DataItemIndex %>'
                            meta:resourcekey="btnLanguageDelResource1" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle CssClass="sfEdit" />
                </asp:TemplateField>
                <asp:BoundField DataField="LanguageID" meta:resourcekey="BoundFieldResource2" />
                <asp:TemplateField HeaderText="Delete" 
                    meta:resourcekey="TemplateFieldResource4">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnLanguageDelete" runat="server" ImageUrl="~/Administrator/Templates/Default/images/imgdelete.png"
                            CommandName="DeleteResources" OnClientClick="return ConfirmDialog(this, 'Confirmation', 'Are you sure you want to delete the language?');"
                            CommandArgument='<%# Container.DataItemIndex %>' meta:resourcekey="btnLanguageDelResource1" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle CssClass="sfDelete" />
                </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle CssClass="sfEven" />
            <HeaderStyle CssClass="cssClassHeadingOne" />
            <PagerStyle CssClass="sfPagination" />
            <RowStyle CssClass="sfOdd" />
        </asp:GridView>
    </div>
    <div class="sfButtonwrapper">
        <asp:ImageButton ID="imbAddLanguage" runat="server" OnClick="imbAddLanguage_Click"
            meta:resourcekey="imbAddLanguageResource1" />
        <asp:Label ID="lblAddLanguage" runat="server" Text="Add Language" AssociatedControlID="imbAddLanguage"
            Style="cursor: pointer;" meta:resourcekey="lblAddLanguageResource1"></asp:Label>
        <asp:ImageButton ID="imbInstallLang" runat="server" OnClick="imbInstallLang_Click"
            meta:resourcekey="imbInstallLangResource1" />
        <asp:Label ID="lblInstallLang" runat="server" Text="Install Language Pack" AssociatedControlID="imbInstallLang"
            Style="cursor: pointer;" meta:resourcekey="lblInstallLangResource1"></asp:Label>
        <asp:ImageButton ID="imbCreateLangPack" runat="server" OnClick="imbCreateLangPack_Click"
            meta:resourcekey="imbCreateLangPackResource1" />
        <asp:Label ID="lblCreateLangPack" runat="server" Text="Create Language Pack" AssociatedControlID="imbCreateLangPack"
            Style="cursor: pointer;" meta:resourcekey="lblCreateLangPackResource1"></asp:Label>
        <asp:ImageButton ID="imbEditTimeZone" runat="server" OnClick="imbEditTimeZone_Click"
            meta:resourcekey="imbEditTimeZoneResource1" />
        <asp:Label ID="lblEditTimeZone" runat="server" Text="Time Zone Editor" AssociatedControlID="imbEditTimeZone"
            Style="cursor: pointer;" meta:resourcekey="lblEditTimeZoneResource1"></asp:Label>
        <asp:ImageButton ID="imbLocalizeMenu" OnClick="imbLocalizeMenu_Click" runat="server"
            meta:resourcekey="imbEditTimeZoneResource1" Style="width: 14px; visibility: hidden" />
        <asp:Label ID="Label1" runat="server" Text="Localize Menu" AssociatedControlID="imbLocalizeMenu"
            Style="cursor: pointer; visibility: hidden" 
            meta:resourcekey="Label1Resource1"></asp:Label>
    </div>
</div>
<div id="langEditSecondDiv" runat="server" class="sfLanguage">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h1>
                <asp:Label ID="lblLanguageResourceEditor" runat="server" Text="Language Resource Editor"
                    meta:resourcekey="lblLanguageResourceEditorResource1"></asp:Label>
            </h1>
            <div class="sfFormwrapper sfPadding">
                <div class="sfTreeview">
                    <asp:TreeView ID="tvList" ShowLines="True" runat="server"
                        ImageSet="Msdn" OnSelectedNodeChanged="tvList_SelectedNodeChanged" 
                        meta:resourcekey="tvListResource1">
                        <SelectedNodeStyle CssClass="sfSelectednode" />
                    </asp:TreeView>
                </div>
                <div class="sflanguagecontent" id="languageContent" runat="server">
                    <div class="sfLanguageinfo">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="25%">
                                    <label class="sfFormlabel">
                                        Selected Language</label>
                                </td>
                                <td width="30">
                                    :
                                </td>
                                <td>
                                    <asp:Image ID="imgSelectedLang" runat="server" 
                                        meta:resourcekey="imgSelectedLangResource1" />
                                    <asp:Label ID="lblSelectedLanguage" runat="server" meta:resourcekey="lblSelectedLanguageResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="sfFormlabel">
                                        Selected Folder</label>
                                </td>
                                <td width="30">
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblSelectedFolder" runat="server" meta:resourcekey="lblSelectedFolderResource1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="sfFormlabel">
                                        Resource File</label>
                                </td>
                                <td width="30">
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="lblSelectedFile" runat="server" meta:resourcekey="lblSelectedFileResource1"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="sfGridwrapper">
                        <asp:GridView ID="gdvResxKeyValue" runat="server" Width="100%" AutoGenerateColumns="False"
                            OnRowDataBound="gdvResxKeyValue_RowDataBound" meta:resourcekey="gdvResxKeyValueResource1">
                            <Columns>
                                <asp:TemplateField HeaderText="Default Values" meta:resourcekey="TemplateFieldResource5">
                                    <ItemTemplate>
                                        <ul>
                                            <li>
                                                <asp:Label runat="server" ID="lblKey" Text='<%# Eval("Key") %>' meta:resourcekey="lblKeyResource1"></asp:Label>
                                            </li>
                                            <li class="sfResxvalue">
                                                <%#Eval("DefaultValue")%></li>
                                        </ul>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Local Values" meta:resourcekey="TemplateFieldResource6">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtResxValue" ToolTip="<%# Container.DataItemIndex+1 %>" runat="server"
                                            TextMode="MultiLine" CssClass="sfTextarea" Text='<%# Eval("Value") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField meta:resourcekey="TemplateFieldResource7">
                                    <ItemTemplate>
                                        <asp:Image ID="imgEditResxValue" CssClass="sfEdit" AlternateText="<%# Container.DataItemIndex+1 %>"
                                            runat="server" 
                                            ImageUrl="~/Administrator/Templates/Default/images/imgedit.png" 
                                            meta:resourcekey="imgEditResxValueResource1" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <AlternatingRowStyle CssClass="sfEven" />
                            <RowStyle CssClass="sfOdd" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="sfButtonwrapper" id="controlButtons" runat="server">
                    <asp:ImageButton ID="imbUpdate" runat="server" OnClick="imbUpdate_Click" meta:resourcekey="imbUpdateResource1" />
                    <asp:Label ID="lblUpdateResxFile" runat="server" Text="Save" CssClass="sfFormlabel"
                        AssociatedControlID="imbUpdate" Style="cursor: pointer;" meta:resourcekey="lblUpdateResxFileResource1"></asp:Label>
                    <asp:ImageButton ID="imbCancel" runat="server" OnClick="imbCancel_Click" meta:resourcekey="imbCancelResource1" />
                    <asp:Label ID="Label2" runat="server" CssClass="sfFormlabel" Text="Back" AssociatedControlID="imbCancel"
                        Style="cursor: pointer;" meta:resourcekey="Label2Resource1"></asp:Label>
                    <asp:ImageButton ID="imbDeleteResxFile" runat="server" OnClick="imbDeleteResxFile_Click"
                        meta:resourcekey="imbDeleteResxFileResource1" />
                    <asp:Label ID="lblDeleteResx" runat="server" CssClass="sfFormlabel" Text="Delete File"
                        AssociatedControlID="imbDeleteResxFile" Style="cursor: pointer;" meta:resourcekey="lblDeleteResxResource1"></asp:Label>
                </div>
                <div class="clear">
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="imbCancel" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="editorDiv" style="display: none">
        <textarea id="txtResxValueEditor"></textarea>
        <div class="sfButtonwrapper sftype1">
            <label id="btnCloseFB" class="sfSave">
                Save</label>
        </div>
    </div>
</div>
<uc3:LanguageSetUp runat="server" ID="ctrl_LanguagePackSetup" />
<uc1:CreateLanguagePack runat="server" ID="CreateLanguagePack1" />
<uc4:TimeZoneEditor ID="ctrl_TimeZoneEditor" runat="server" />

<uc2:LanguagePackInstaller runat="server" ID="LanguagePackInstaller1" />
