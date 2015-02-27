<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SubscriptionSetting.ascx.cs"
    Inherits="Modules_Subscribe_SubscriptionSetting" %>
<%@ Register Src="~/Controls/sectionheadcontrol.ascx" TagName="sectionheadcontrol"
    TagPrefix="sfe" %>
<div class="sfFormwrapper">
    <sfe:sectionheadcontrol ID="shcFAQsSettings" runat="server" CssClass="CssClassHead"
        Section="tblSubscribtionSettings" IncludeRule="true" IsExpanded="true" Text="Subscribtion Settings" />
    <table id="tblSubscribtionSettings" runat="server" cellpadding="0" cellspacing="0"
        border="0" width="100%">
        <tr>
            <td style="width: 25;">
            </td>
            <td>
                <table id="tblSubscribtionSettingsInfo" runat="server">
                    <tr>
                        <td style="width: 175px" valign="top">
                            <asp:Label ID="lblSubscriptionType" runat="server" Text="Subscription Type:" CssClass="sfFormlabel"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:DropDownList ID="ddlSubscriptionType" runat="server" Width="258px" CssClass="sfListmenu"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlSubscriptionType_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="rowSubscriptionModuleTitle" runat="server">
                        <td style="width: 175px" valign="top">
                            <asp:Label ID="lblSubscriptionModuleTitle" runat="server" Text="Subscription Module Title:"
                                CssClass="sfFormlabel"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtSubscriptionModuleTitle" runat="server" CssClass="sfInputbox"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvSubscriptionModuleTitle" runat="server" ErrorMessage="Titles Required."
                                CssClass="sfError" SetFocusOnError="True" ValidationGroup="subscriptionsetting"
                                ControlToValidate="txtSubscriptionModuleTitle"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr id="rowSubscriptionHelpText" runat="server">
                        <td style="width: 175px" valign="top">
                            <asp:Label ID="lblSubscriptionHelpText" runat="server" Text="Subscription Help Text:"
                                CssClass="sfFormlabel"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtSubscriptionHelpText" runat="server" CssClass="sfInputbox" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSubscriptionHelpText" runat="server" ErrorMessage="Help Text Required."
                                CssClass="sfError" SetFocusOnError="True" ValidationGroup="subscriptionsetting"
                                ControlToValidate="txtSubscriptionHelpText"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 175px" valign="top">
                            <asp:Label ID="lblTextBoxWaterMark" runat="server" Text="WaterMark Text:" CssClass="sfFormlabel"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtTextBoxWaterMark" runat="server" CssClass="sfInputbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 175px" valign="top">
                            <asp:Label ID="lblSubmitButtonText" runat="server" Text="Submit Button Text:" CssClass="sfFormlabel"></asp:Label>
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtSubmitButtonText" runat="server" CssClass="sfInputbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSubmitButtonText" runat="server" ErrorMessage="Text is Required."
                                CssClass="sfError" SetFocusOnError="True" ValidationGroup="subscriptionsetting"
                                ControlToValidate="txtSubmitButtonText"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <div class="sfButtonwrapper">
                    <asp:ImageButton ID="imbSave" runat="server" OnClick="imbSave_Click" ValidationGroup="subscriptionsetting"
                        CausesValidation="true" />
                    <asp:Label ID="lblSave" runat="server" Text="Save" AssociatedControlID="imbSave"
                        Style="cursor: pointer;"></asp:Label>
                </div>
            </td>
        </tr>
    </table>
    <%--    <div id="auditBar" runat="server" class="cssClassAuditBar" visible="false">
        <asp:Label ID="lblCreatedBy" runat="server" CssClass="sfFormlabel" Visible="false" /><br />
        <asp:Label ID="lblUpdatedBy" runat="server" CssClass="sfFormlabel" Visible="false" />
    </div>--%>
</div>
