<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManagePages.ascx.cs" Inherits="Modules_Pages_ManagePages" %>

<script type="text/javascript">

    var PageMode = false;

    $(function() {

        var LSTSagePages = [];

        $(this).SageTreeBuilder({
            PortalID: '<%=PortalID%>',
            UserModuleID: '<%=UserModuleID%>',
            UserName: '<%=UserName%>',
            PageName: '<%=PageName%>',
            ContainerClientID: '#navContainer',
            CultureCode: '<%=CultureCode%>',
            baseURL: ServicePath + '/Modules/Pages/Services/PagesWebService.asmx/',
            Mode: $('#rdbAdmin').attr('checked'),
            AppName: '<%=appPath%>'
        });

        $(this).SageFramePageBuilder({
            PortalID: '<%=PortalID%>',
            UserModuleID: '<%=UserModuleID%>',
            UserName: '<%=UserName%>',
            PageName: '<%=PageName%>',
            ContainerClientID: '#navContainer',
            CultureCode: '<%=CultureCode%>',
            baseURL: ServicePath + '/Modules/Pages/Services/PagesWebService.asmx/',
            AppName: '<%=appPath%>'
        });

        /*$('#navContainer').css("min-height",$('#dvTab').height()+70);*/

        if ($('#gdvModules table tr').length == 0) {
            $('#gdvModules').html(SageFrame.messaging.showdivmessage("No Page Selected Yet"));
        }


    });

    
</script>

<h1>
    <span>Page Management</span>
</h1>
<div class="clearfix">
    <div id="dvPageType">
        <asp:Literal ID="ltrPageRadioButtons" runat="server"></asp:Literal>
    </div>
    <div class="clear sfSpacer">
    </div>
    <div class="cssClassTreeNav" id="navContainer">
    </div>
    <div class="cssClassDetails">
        <div class="sfButtonwrapper sftype1">
            <label id="btnAddpage" class="sfAdd">
                New Page</label>
        </div>
        <div id="myMenu1" class="sfContextmenu sfCurve Shadow" style="display: none">
            <ul>
                <li id="add">
                    <img runat="server" id="imgAddNew" alt="AddPage" title="AddPage" />
                    <b>Add New Page</b></li>
                <%--<li id="addmodule"> <img runat="server" id="imgAddModule" alt="AddModules" title="AddModules" /> <a href="#" id="rdrtManagemodule">Manage Modules</a></li>--%>
                <li id="remove">
                    <img runat="server" id="imgRemove" alt="Remove" title="Remove" />
                    <b>Delete Page</b></li>
            </ul>
        </div>
        <div id="dvTab" class="cssClassTabpanelContent">
            <ul>
                <li><a href="#dvPageSetting">Page Details</a></li>
                <%-- <li><a href="#dvModule">Modules</a></li>--%>
            </ul>
            <div id="dvPageSetting" class="cssClassTabPabelTabel">
                <div id="tblPageDetails">
                    <div class="sfFormwrapper">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="50%" class="sfVtop">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="25%">
                                                <span class="sfFormlabel">Page Name:</span>
                                            </td>
                                            <td width="30">
                                                :
                                            </td>
                                            <td>
                                                <input type="text" id="txtPageName" name="txtPageName" class="sfInputbox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%">
                                                <span class="sfFormlabel">Caption:</span>
                                            </td>
                                            <td width="30">
                                                :
                                            </td>
                                            <td>
                                                <input type="text" id="txtCaption" name="txtCaption" maxlength="100" class="sfInputbox" />
                                            </td>
                                        </tr>
                                        <tr id="trParent">
                                            <td>
                                                <span class="sfFormlabel">Parent Page:</span>
                                            </td>
                                            <td width="30">
                                                :
                                            </td>
                                            <td>
                                                <select id="cboParentPage" class="sfListmenu">
                                                    <option value="0">-- Select One--</option>
                                                </select>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="sfFormlabel">Refresh Interval</span>
                                            </td>
                                            <td width="30">
                                                :
                                            </td>
                                            <td>
                                                <input type="text" class="sfInputbox" id="txtRefreshInterval" />
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td>
                                                <span class="sfFormlabel">Start Date:</span>
                                            </td>
                                            <td width="30">
                                                :
                                            </td>
                                            <td>
                                                <input type="text" class="sfInputbox" id="txtStartDate" />
                                                <label id="lblError" class="sfError">
                                                </label>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td>
                                                <span class="sfFormlabel">End Date:</span>
                                            </td>
                                            <td>
                                                <input type="text" class="sfInputbox" id="txtEndDate" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="sfFormlabel">Icon</span>
                                            </td>
                                            <td width="30">
                                                :
                                            </td>
                                            <td>
                                                <input type="file" id="flIcon" />
                                                <div class="cssClassUploadFiles">
                                                    <ul>
                                                    </ul>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="trShowInDashboard">
                                            <td>
                                                <span class="sfFormlabel">Show In Dashboard</span>
                                            </td>
                                            <td width="30">
                                                :
                                            </td>
                                            <td>
                                                <input type="checkbox" id="chkShowInDashboard" />
                                            </td>
                                        </tr>
                                        <tr id="trIncludeInMenuLbl">
                                            <td>
                                                <span class="sfFormlabel">Include In Menu?</span>
                                            </td>
                                            <td width="30">
                                                :
                                            </td>
                                            <td>
                                                <input type="checkbox" id="chkMenu" />
                                            </td>
                                        </tr>
                                        <tr id="trIncludeInMenu">
                                            <td>
                                                <label class="sfFormlabel">
                                                    Select Menu</label>
                                            </td>
                                            <td width="30">
                                                :
                                            </td>
                                            <td colspan="3">
                                                <select multiple="multiple" id="selMenulist" class="sfListmenubig">
                                                    <option value="1">Top Menu</option>
                                                    <option value="2">Footer Menu</option>
                                                    <option value="3">Side Menu</option>
                                                </select>
                                            </td>
                                        </tr>
                                        <tr>
                                            <%-- <td><span class="sfFormlabel" visible=false>Is Secure?</span></td>
                      <td width="30"> : </td>
                      <td><input type="checkbox" id="chkIsSecure" disabled="disabled" visible="false" /></td>--%>
                                        </tr>
                                    </table>
                                </td>
                                <td width="50%" class="sfVtop">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <span class="sfFormlabel">Page Title:</span>
                                            </td>
                                            <td width="30">
                                                :
                                            </td>
                                            <td>
                                                <input type="text" id="txtTitle" name="txtTitle" class="sfInputbox" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="sfFormlabel">Description:</span>
                                            </td>
                                            <td width="30">
                                                :
                                            </td>
                                            <td>
                                                <textarea rows="30" cols="15" id="txtDescription" class="sfTextarea"></textarea>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="sfFormlabel">Keywords:</span>
                                            </td>
                                            <td width="30">
                                                :
                                            </td>
                                            <td>
                                                <textarea rows="30" cols="15" id="txtKeyWords" class="sfTextarea" maxlength="500"></textarea>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <h2>
                        Page Permission Settings
                    </h2>
                    <div class="sfFormwrapper">
                        <div class="sfButtonwrapper sftype1">
                            <label id="imbAddUsers" class="sfAdduser">
                                Add User</label>
                        </div>
                        <div class="divPermissions sfGridwrapper">
                            <table cellspacing="0" cellpadding="0" width="100%">
                            </table>
                        </div>
                        <div class="clear">
                        </div>
                        <div id="dvUser" class="sfGridwrapper">
                            <table id="tblUser" cellspacing="0" cellpadding="0" width="100%">
                            </table>
                        </div>
                    </div>
                </div>
                <div class="sfButtonwrapper sftype1">
                    <label id="btnSubmit" class="sfSave">
                        Save</label>
                    <label class="sfCancel" id="imbPageCancel">
                        Cancel</label>
                </div>
                <div class="clear">
                </div>
            </div>
            <div id="dvModule" class="cssClassTabPabelTabel" style="display: none">
                <div class="sfButtonwrapper sfMarginnone">
                    <a id="btnManageModules" href="#" class="sfBtn">Module Manager</a>
                </div>
                <div id="gdvModules" class="sfGridwrapper">
                </div>
                <div id="hdnModules" style="display: none">
                </div>
                <div id="divPager" class="sfPagination clearfix">
                </div>
            </div>
        </div>
        <div id="divAddUsers" class="sfFormwrapper" title="Search Users">
            <p class="sfNote">
                All form fields are required.</p>
            <table cellpadding="0" cellspacing="0" width="0">
                <tr>
                    <td>
                        <input type="text" name="name" id="txtSearchUsers" class="sfInputbox" />
                    </td>
                    <td class="sftype1">
                        <label id="btnSearchUsers" class="sfSearch">
                            Search</label>
                    </td>
                </tr>
            </table>
            <div id="divSearchedUsers">
            </div>
            <div class="sfButtonwrapper sftype1">
                <label id="btnAddUser" class="sfAdd">
                    Add</label>
                <label id="btnCancelUser" class="sfCancel">
                    Cancel</label>
            </div>
        </div>
    </div>
</div>
