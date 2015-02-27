<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModuleManager.ascx.cs"
    Inherits="Modules_ModuleManager_ModuleManager" %>

<script type="text/javascript">
    var parentDiv = "";
    var droppableOrder = "";
    var singlemodule = "";
    var dropStatus = 0;
    var droppableAttr = "";
    var ModuleName = "";
    var ModuleId = "";
    var Scope_Identity = "";
    var uniqueelem = "";
    var UserModuleID = 0;
    var lstModulePermission = [];
    var ModuleDefID = 0;
    var globalpageid = 1;
    var uniquekey = 1;
    $(function() {
        $(this).ModuleManager({
            ShowSideBar: '<%=IsSideBarVisible%>'
        });
    });
</script>
<h1>
    <asp:Label ID="lblModuleManager" runat="server" Text="Manage Modules"></asp:Label>
</h1>
<div class="sfFormwrapper sfPadding sfMarginbtn sfModuletopwrapper">
    <div id="divSearch" class="sfModulesearch clearfix">
        <input id="txtSearchModules" type="text" class="sfInputbox" />
        <input id="imgSearch" type="button" class="sfSearch" value="Search" />
    </div>
    <select id="ddlPages" class="sfListmenu">
    </select>
    <div class="sfModeswitch">
        <asp:Literal ID="ltrModuleRadioButtons" runat="server"></asp:Literal>
    </div>
    <div id="handheldSwitch" class="sfHandheldswitch">
        <img id="imgMobileSwitch" title="Handheld Layout" src="<%=appPath%>/Administrator/Templates/Default/images/mobile.png" />
    </div>
    <div class="clear">
    </div>
</div>
<div>
    <div id="wrapper">
        <div id="divDroppable" class="sfFormwrapper sfNone">
            <div id="divFloat" class="clearfix">
                <span id="spnFix" class="sfFloatPin">
                    <img src="<%=appPath%>/Administrator/Templates/Default/images/pin.png" /></span>
                <img alt="sort" class="sfSorting sfSortdown" src="<%=appPath%>/Administrator/Templates/Default/images/sort.png"
                    id="imgSort" />
                <div id="Pagination" class="sfPagination">
                </div>
                <div class="clear">
                </div>
                <div class="sfLcontent">
                    <ul class="alt_content">
                    </ul>
                    <ul class="hdnModulelist" style="display: none">
                    </ul>
                </div>
            </div>
        </div>
        <div id="divLayout">
            <div id="divLayoutWireframe">
            </div>
        </div>
    </div>
    <div id="showPopup" style="display: none">
        <div class="sfPopupinner sfFormwrapper">
            <div id="dvTabPanel">
                <ul>
                    <li><a href="#dvEdit">
                        <asp:Label ID="lblEdit" runat="server" Text="Module Basics"></asp:Label>
                    </a></li>
                    <li><a href="#dvPermissions">
                        <asp:Label ID="lblSetting" runat="server" Text="Permissions"></asp:Label>
                    </a></li>
                </ul>
                <div id="dvEdit" class="sfFormwrapper sfModulepopbox">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <label class="sfFormlabel">
                                    Module Name
                                </label>
                            </td>
                            <td width="30">
                                :
                            </td>
                            <td>
                                <label id="lblmoduleName">
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="sfFormlabel">
                                    Module Title
                                </label>
                            </td>
                            <td width="30">
                                :
                            </td>
                            <td>
                                <input type="text" id="txtModuleTitle" class="sfInputbox" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="sfFormlabel">
                                    Pane Name
                                </label>
                            </td>
                            <td width="30">
                                :
                            </td>
                            <td>
                                <label id="spnPaneName">
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="sfFormlabel">
                                    Header Text
                                </label>
                            </td>
                            <td width="30">
                                :
                            </td>
                            <td>
                                <input type="text" id="txtHeaderTxt" class="sfInputbox" maxlength="50" />
                                <input type="checkbox" id="chkShowHeader" class="sfCheckbox" />
                                <label class="sfFormlabelsmall">
                                    Show Header
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="sfFormlabel">
                                    Module Suffix Class
                                </label>
                            </td>
                            <td width="30">
                                :
                            </td>
                            <td>
                                <input type="text" id="txtModuleSuffix" class="sfInputbox">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="sfFormlabel">
                                    IsActive</label>
                            </td>
                            <td width="30">
                                :
                            </td>
                            <td>
                                <input type="checkbox" id="chkIsActive" checked="checked" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="sfFormlabel">
                                    Show in Other Pages
                                </label>
                            </td>
                            <td width="30">
                                :
                            </td>
                            <td>
                                <input type="checkbox" value="All" id="rbAllPages" name="showPagesGroup" />
                                <label>
                                    All</label>
                                <input type="checkbox" value="Custom" id="rbCustomPages" name="showPagesGroup" />
                                <label>
                                    Customize</label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="32">
                                <div id="trPages">
                                    <div id="pageList_Apply" class="sfGridwrapper">
                                        <div class="sfLcontent">
                                            <ul class="alt_content" id="pageTree_popup">
                                            </ul>
                                            <ul id="hdnPageList" style="display: none">
                                            </ul>
                                        </div>
                                        <div class="sfPagination" id="pagePagination">
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <input type="checkbox" class="sfCheckbox" id="chkInheritPermissions" />
                                <label id="lblInherit" class="sfFormlabel">
                                    Inherit Permissions From Page</label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <input type="checkbox" id="chkDonotshow" class="sfCheckbox" />
                                <label id="lblDonotshow" class="sfFormlabel">
                                    Do not show this popup again</label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="dvPermissions">
                    <div>
                        <div class="sfPopupsearch clearfix">
                            <label class="sfFormlabel">
                                Search User:
                            </label>
                            <input type="text" class="sfInputbox searchinput" id="txtSearchUsers" />
                            <div class="sfButtonwrapper sftype1 sfInline">
                                <label id="btnSearchUser" class="sfSearch">
                                    Search</label>
                            </div>
                        </div>
                        <br />
                        <div class="divPermissions sfGridwrapper">
                            <table width="100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        <label>
                                            Role</label>
                                    </th>
                                    <th>
                                        <label>
                                            View</label>
                                    </th>
                                    <th>
                                        <label>
                                            Edit</label>
                                    </th>
                                    <th>
                                    </th>
                                </tr>
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                        <div id="dvUser" class="sfGridwrapper">
                            <table id="tblUser" width="100%" cellpadding="0" cellspacing="0">
                            </table>
                        </div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="sfButtonwrapper sftype1 sfInline">
                    <label id="spnBtnSave" class="sfSave">
                        Save</label>
                    <label id="spnBtnCancel" class="sfCancel">
                        Cancel</label>
                </div>
            </div>
        </div>
    </div>
    <iframe id="divFrame" style="display: none" src='' width='100%'></iframe>
</div>