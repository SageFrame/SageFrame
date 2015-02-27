<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LayoutManager.ascx.cs"
    Inherits="Modules_LayoutManager_LayoutManager" %>
<h1>
    <asp:Label ID="lblTemplateMgr" runat="server" Text="Template Manager"></asp:Label>
</h1>
<div class="sfFormwrapper sfPadding">
    <div class="sfTemplatemanger clearfix">
        <div class="sftype1 sfCreatetemplate">
            <asp:Label ID="lblUploadTemp" CssClass="sfFormlabel" runat="server">Upload Template</asp:Label>
            <asp:FileUpload ID="fupUploadTemp" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Choose Template"
                ControlToValidate="fupUploadTemp" ValidationGroup="rfvTemplate"></asp:RequiredFieldValidator>
            <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="sfBtn" OnClick="btnUpload_Click"
                ValidationGroup="rfvTemplate" />
            <input type="button" id="btnCreateTemplate" class="sfBtn" value="Create Template" />
            <div id="sfCreateTemplate" style="display: none" class="clearfix">
                <input type="text" id="txtNewTemplate" class="sfInputbox" />
                <input type="button" id="btnSaveTemplate" class="sfBtn" value="Ok" />
            </div>
        </div>
        <div id="templateList" class="clearfix">
        </div>
    </div>
    <div class="sfLayoutmanager" style="display: none">
        <div id="tabLayoutMgr">
            <ul>
                <li><a id="lnkBasicSettings" href="#basicsDiv">Basic Settings</a></li>
                <li><a id="lnkThemes" href="#themesDiv">Themes</a></li>
                <li><a id="lnkPresets" href="#presetsDiv">Presets</a></li>
                <li><a id="lnkVisualLayoutMgr" href="#visualLayoutMgr">Layout Manager</a></li>
            </ul>
            <div id="basicsDiv" style="display: none">
                <div class="sfTemplateinfo">
                    <fieldset title="Basics">
                        <legend>Template Details</legend>
                        <div class="sfGridwrapper">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr class="sfOdd">
                                    <td width="15%">
                                        <span class="sfLabel">Template Name</span>
                                    </td>
                                    <td width="30">
                                        :
                                    </td>
                                    <td>
                                        <span class="sfValue" id="spnTemplateName"></span>
                                    </td>
                                </tr>
                                <tr class="sfEven">
                                    <td>
                                        <span class="sfLabel">Template Author</span>
                                    </td>
                                    <td width="30">
                                        :
                                    </td>
                                    <td>
                                        <span class="sfValue" id="spnAuthor"></span>
                                    </td>
                                </tr>
                                <tr class="sfOdd">
                                    <td>
                                        <span class="sfLabel">Description</span>
                                    </td>
                                    <td width="30">
                                        :
                                    </td>
                                    <td>
                                        <span class="sfValue" id="spnDescription"></span>
                                    </td>
                                </tr>
                                <tr class="sfEven">
                                    <td>
                                        <span class="sfLabel">Website</span>
                                    </td>
                                    <td width="30">
                                        :
                                    </td>
                                    <td>
                                        <span class="sfValue" id="spnWebsite"></span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </fieldset>
                </div>
            </div>
            <div id="themesDiv" style="display: none">
                <div id="themeList" class="sfGridwrapper">
                </div>
            </div>
            <div id="presetsDiv" style="display: none">
                <div id="divMsgTemplate">
                </div>
                <fieldset>
                    <legend>Template Settings</legend>
                    <div class="sfGridwrapper">
                        <h2>
                            Layouts</h2>
                        <div id="activeLayoutList">
                        </div>
                        <div class="sfHolder clearfix">
                            <div class="sfTheme">
                                <h2>
                                    Select Themes</h2>
                                <div id="activeThemeList" class="clearfix">
                                </div>
                            </div>
                            <div class="sfScreen">
                                <h2>
                                    Select Screen</h2>
                                <div id="activeWidthList" class="clearfix">
                                    <ul>
                                        <li class="sfCurve">Wide</li>
                                        <li class="sfCurve">Narrow</li>
                                        <li class="sfCurve">Fluid</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <div id="presetControls">
                    <div style="width: 100%">
                        <div class="controls">
                            <div class="sfButtonwrapper sftype1">
                                <label id="btnSavePreset" class="sfSave">
                                    Save Preset</label>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>
            <div id="visualLayoutMgr">
                <div id="divControls" class="clearfix">
                    <select id="ddlLayoutList" class="sfListmenu">
                    </select>
                    <div class="sftype1">
                        <label id="imgAddLayout" class="sfAdd">
                            Add</label>
                        <label id="imgEditLayout_Visual" class="sfUpdate">
                            Edit</label>
                        <label id="btnDeleteLayout" class="sfDelete">
                            Delete</label>
                    </div>
                </div>
                <div id="divLayoutWireframe">
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="sfButtonwrapper sftype1">
            <label id="lblCancelEditMode" class="sfCancel">
                Cancel</label>
        </div>
    </div>
    <div id="divEditXML" style="display: none">
        <input type="hidden" id="hdnLayoutName" />
        <div id="msgDiv">
        </div>
        <div class="layoutEditor" id="addPlaceHolder">
            <div class="sflayoutbuilderhead">
                Create Layout Markup</div>
            <div class="sfFormwrapper sfBuilder">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="20%">
                            <label class="sfFormlabel">
                                Create:</label>
                        </td>
                        <td>
                            <select id="selTypes" class="sfListmenu">
                                <option value="2">Select</option>
                                <option value="0">Placeholder</option>
                                <option value="1">Wrapper</option>
                            </select>
                        </td>
                    </tr>
                </table>
                <table id="tblPch" style="display: none" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="20%">
                            <label id="spnName" class="spnAddPch sfFormlabel">
                                &lt;placeholder
                            </label>
                        </td>
                        <td>
                            <label id="lblAttr">
                            </label>
                            <select id="ddlAttr" class="sfListmenu sfInputlm">
                                <option value="0">Select</option>
                                <option value="1">name</option>
                                <option value="2">mode</option>
                                <option value="3">width</option>
                                <option value="4">wrapinner</option>
                                <option value="5">wrapouter</option>
                            </select>
                            <label>
                                &gt;</label>
                            <input type="text" id="txtPlaceholder" class="sfInputbox sfInputlm" />
                            <label>
                                &lt;/placeholder&gt;
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table id="tblAttr" cellpadding="0" cellspacing="0" width="100%">
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div id="pchPreview" class="sfPchpreview sfCurve">
                            </div>
                        </td>
                    </tr>
                </table>
                <table id="tblWrap" style="display: none" width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20%">
                            <label id="Label1" class="spnAddPch sfFormlabel">
                                &lt;wrap
                            </label>
                        </td>
                        <td>
                            <select id="ddlWrapattr" class="sfListmenu sfInputlm">
                                <option value="0">Select Attribute</option>
                                <option value="1">name</option>
                                <option value="2">type</option>
                                <option value="3">class</option>
                                <option value="4">depth</option>
                            </select>
                            <label>
                                &gt;</label>
                            <input type="text" id="txtPositions" title="wrapvalue" class="sfInputbox sfInputlm" />
                            <label>
                                &lt;wrap/&gt;
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table id="tblWrapAttr" cellpadding="0" cellspacing="0" width="100%">
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="sfCodepreview sfCurve">
                                &lt;wrappers&gt;
                                <div id="wrapPreview" class="sfWrappreview">
                                </div>
                                &lt;/wrappers&gt;
                                <img src="/Administrator/Templates/Default/images/copy.png" /></div>
                        </td>
                    </tr>
                </table>
            </div>
            <textarea id="txtLayoutEditor" class="sfTextarea sfEditor"></textarea>
            <div class="sfButtonwrapper sftype1">
                <label class="sfSave" id="SaveLayout_Edit">
                    Save</label>
            </div>
        </div>
    </div>
    <div id="divAddLayout" class="sfFormwrapper" style="display: none">
        <div id="msgAddLayout">
        </div>
        <input type="hidden" id="hdnLayoutName1" />
        <div class="layoutEditor" id="Div2">
            <table id="Table1" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td width="25%">
                        <label class="sfFormlabel">
                            Clone From:</label>
                    </td>
                    <td>
                        <select id="ddlClonebleLayouts" class="sfListmenu">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="sfFormlabel">
                            Layout Name:</label>
                    </td>
                    <td>
                        <input type="text" id="txtNewLayoutName" class="sfInputbox" />
                    </td>
                </tr>
            </table>
            <div class="sfButtonwrapper sftype1">
                <label id="btnCreateLayout" class="sfAdd">
                    Create</label>
            </div>
            <textarea id="txtLayoutCreator" class="sfTextarea sfEditor"></textarea>
        </div>
    </div>
    <div id="divEditHTML" class="sfPopup" style="display: none">
        <span class="sfPopupclose"></span>
        <textarea id="txtHTMLEditor" class="layoutEditor" cols="50" rows="20"></textarea>
        <br />
        <div class="cssClassHTMLButtonWrapper">
            <span class="save">Save</span>
        </div>
    </div>
    <div id="divPagePresets" style="display: none; overflow: auto">
        <div class="controls">
            <div id="pageList">
            </div>
            <div class="sfButtonwrapper sftype1">
                <label id="spnSavePagePreset" class="sfSave">
                    Apply</label>
            </div>
        </div>
    </div>
    <div id="divTemplatePreview" style="display: none">
        <div id="imagePreview">
        </div>
        <div id="imageThumbs">
        </div>
    </div>
</div>

<script type="text/javascript">

    $(function() {
    
          
       $(this).LayoutManager({
            PortalID: '<%=PortalID%>',
            AppPath: '<%=appPath%>'            
        });
       

    });
</script>

