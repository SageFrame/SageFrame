<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WFEdit.ascx.cs" Inherits="Modules_WFContent_WFEdit" %>

<script type="text/javascript">
    $(function() {
        $(this).SageWorkFlow({
            UserModuleID: '<%=userModuleID %>',
            PortalID: '<%=portalID %>',
            CultureCode: '<%=cultureCode%>',
            UserName: '<%=userName%>',
            CheckUser: '<%=CheckUser %>',
            isTaskForModerator: '<%=isTaskForModerator %>'
        });
    });
</script>

<asp:Literal runat="server" ID="ltrID"></asp:Literal>
<div id="dialog" title="Confirmation Required">
    <label id="sf_lblConfirmation">
    </label>
</div>

<div class="notificationBar">
    <asp:Literal runat="server" ID="ltrNotification"></asp:Literal>
</div>
<div class="divModerator">
    <asp:Literal runat="server" ID="ltrMod"></asp:Literal>
</div>

<div id="divUser">
    <div id="divWF">
        <ul id="ulTabList">
            <li><a href="#divWFAssigne">Work Flow Basics</a></li>
            <li><a href="#divTask">WorkFlow</a></li>
            <li><a href="#divWork">Work</a></li>
            <li><a href="#divWFStatus">Work Flow Status</a></li>
        </ul>
        <div id="divWFAssigne">
            <div id="divWFList">
                <asp:Literal runat="server" ID="ltrWFList"></asp:Literal>
            </div>
            <input type='hidden' value='0' id='IsActive' />
            <%--            <input type='hidden' value='' id='WFID' />--%>
            <asp:Literal runat="server" ID="lblWFID"></asp:Literal>
            <div id="divWFedit" style="display: none;">
                <div class="sfFormwrapper">
                    <table class="tblWF" width="100%" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="20%">
                                <span class="sfFormlabel">WorkFlow Name :</span>
                            </td>
                            <td>
                                <%--<asp:Literal runat="server" ID="ltrWFName"></asp:Literal>--%>
                                <input type="text" id="txtWorkFlowName" name="txtWorkFlowName" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="sfFormlabel">Moderator:</span>
                            </td>
                            <%-- <td>
                            <asp:Literal runat="server" ID="ltrModerator"></asp:Literal>
                        </td>--%>
                            <td runat="server" id="tdChangeMod">
                                <div class="assignModerator">
                                    <select id="sltUserList">
                                    </select>
                                    <%--<input type="button" id="btnModCancel" class="sfBtn" value="Cancel" style="display: none;" />--%>
                                    <%-- <input type="button" id="btnModOK" class="sfBtn" value="OK" style="display: none;" />--%>
                                </div>
                                <%-- <div class="divModeratorName">
                            </div>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <span class="icon-close sfLocale sfBtn WFCancel" id="btnCancelWF_0">Cancel</span>
                                <span id='btnAddEditWFName' class='icon-save sfLocale sfBtn'>Save WorkFlow</span>
                                <%-- <asp:Literal runat="server" ID="ltrWFSaveBtn"></asp:Literal>--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="divTask">
            <div class="sfFlowleft">
                <ul class="sfDiagram">
                </ul>
            </div>
            <div class="sfFlowRight" >
            </div>
        </div>
        <div class="divWork" id="divWork">
            <div class="sfFormwrapper">
                <div class="Content" id="divWorkContent">
                    <%--<asp:Literal runat="server" ID="ltrContent"></asp:Literal>--%>
                </div>
            </div>
        </div>
        <div id="divWFStatus">
            <div id="divStatus">
            </div>
        </div>
    </div>
</div>
<div id="divModerator" style="display: none" class="sfSimpleTable">
</div>
<div id="divMore" style="display: none" class="clearfix">
    <div id="divddlHistory">
    </div>
    <div id="divReal" class="sfReal">
    </div>
    <div id="divHistory" class="sfHistory">
        <div id="divHistoryContain">
        </div>
    </div>
    <div id="divCompare" style="display: none">
        <div id="divColRight" onclick="this.contentEditable='true';" style="width: 48%; float: left;">
        </div>
        <div id="divColLeft" style="width: 48%; float: right;">
        </div>
        <div class="clearfix"><span class="Cancel icon-close sfBtn" id="spnCancelCompare">Close</span></div>
    </div>
</div>
<div id="divPreview" style="display: none;" class="overlay">
</div>
<div id="divLoader" style="display: none">
</div>
