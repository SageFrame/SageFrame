<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditScriptInjection.ascx.cs"
    Inherits="Modules_ScriptInjection_EditScriptInjection" %>

<script type="text/javascript">
    $('#ibAddScript').live("click", function() {
        ClearForm();
        $('#<%=divScriptContainer.ClientID %>').hide();
        $('#<%=divScriptForm.ClientID %>').show();
    });
    function ClearForm() {
        $('#<%=txtScriptDescription.ClientID%>').val('');
        $('#<%=txtScriptName.ClientID%>').val('');
        $('#<%=txtScriptContent.ClientID%>').val('');
    }
</script>

<div class="cssClassFormHeading" width="100%">
    <asp:Label ID="lblScriptHeader" runat="server" CssClass="sfFormlabel">Here You Can Add And Edit Script To Be Embed</asp:Label>
</div>
<div id="divScriptContainer" runat="server">
    <div class="sfButtonwrapper sftype1">
        <label id="ibAddScript" class="sfAdd">
            Add New</label>
    </div>
    <div id="grdForm" class="sfGridwrapper" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblRecordsPage" runat="server" CssClass="sfFormlabel" Text="Show rows :"
                        meta:resourcekey="lblRecordsPageResource1" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlRecordsPerPage" runat="server" AutoPostBack="True" CssClass="sfListmenu"
                        meta:resourcekey="ddlRecordsPerPageResource1" OnSelectedIndexChanged="ddlRecordsPerPage_SelectedIndexChanged">
                        <asp:ListItem Value="10" meta:resourcekey="ListItemResource1">10</asp:ListItem>
                        <asp:ListItem Value="25" meta:resourcekey="ListItemResource2">25</asp:ListItem>
                        <asp:ListItem Value="50" meta:resourcekey="ListItemResource3">50</asp:ListItem>
                        <asp:ListItem Value="100" meta:resourcekey="ListItemResource4">100</asp:ListItem>
                        <asp:ListItem Value="150" meta:resourcekey="ListItemResource5">150</asp:ListItem>
                        <asp:ListItem Value="200" meta:resourcekey="ListItemResource6">200</asp:ListItem>
                        <asp:ListItem Value="250" meta:resourcekey="ListItemResource7">250</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <div class="cssClassGridWrapper">
            <asp:GridView ID="gdvScriptTobeEmbed" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                EmptyDataText="..........No Data Found.........." GridLines="None" Width="100%"
                PageSize="10" OnPageIndexChanging="gdvScriptTobeEmbed_PageIndexChanging" OnRowCommand="gdvScriptTobeEmbed_RowCommand"
                OnRowDataBound="gdvScriptTobeEmbed_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HiddenField ID="hdfScriptID" runat="server" Value='<%# Eval("ScriptID") %>' />
                            <asp:CheckBox ID="chkHideShowScript" runat="server" value='<%# Eval("IsVisible") %>'
                                Checked='<%# Convert.ToBoolean(Eval("IsVisible")) %>' meta:resourcekey="chkSendEmailResource1"
                                AutoPostBack="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblScriptNameForGrid" runat="server" Font-Bold="true" Text='<%# Eval("ScriptName")%>' />
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderScriptName" runat="server" Font-Bold="true" Text="Script Name" />
                        </HeaderTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblScriptName" runat="server" Font-Bold="true" Text='<%# Eval("ScriptDescription")%>' />
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="lblHeaderScriptDescription" runat="server" Font-Bold="true" Text="When to use" />
                        </HeaderTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEditScript" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ScriptID") %>'
                                CommandName="EditSCript" ImageUrl='<%# GetTemplateImageUrl("imgedit.png", true) %>' />
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssClassColumnDelete" VerticalAlign="Top" />
                        <ItemStyle VerticalAlign="Top" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgDeleteScript" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ScriptID") %>'
                                CommandName="DeleteScript" ImageUrl='<%# GetTemplateImageUrl("imgdelete.png", true) %>' />
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssClassColumnDelete" VerticalAlign="Top" />
                        <ItemStyle VerticalAlign="Top" />
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle CssClass="sfEven" />
                <HeaderStyle />
                <RowStyle CssClass="sfOdd" />
            </asp:GridView>
            <div class="sfButtonwrapper">
                <asp:ImageButton ID="imbSaveCheckedItem" runat="server" ValidationGroup="body" OnClick="imbSaveCheckedItem_Click" />
                <asp:Label ID="lblSaveCheckedItem" runat="server" Text="Save" AssociatedControlID="imbSaveCheckedItem"
                    CssClass="cssClassHtmlViewCursor"></asp:Label>
            </div>
        </div>
    </div>
</div>
<div id="divScriptForm" runat="server" class="sfFormwrapper" style="display: none;">
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="lblScriptName" CssClass="sfFormlabel" runat="server">Script Name</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtScriptName" runat="server" CssClass="sfInputbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvScriptName" runat="server" ControlToValidate="txtScriptName"
                    CssClass="cssClassNormalRed" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="text"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblScriptDescription" CssClass="sfFormlabel" runat="server">Description</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtScriptDescription" runat="server" TextMode="MultiLine" CssClass="sfInputbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtScriptDescription"
                    CssClass="cssClassNormalRed" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="text"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td width="20%">
                <asp:Label ID="lblScripts" CssClass="sfFormlabel" runat="server">Scripts Content</asp:Label>
            </td>
            <td width="80%">
                <asp:TextBox CssClass="sfInputbox" ID="txtScriptContent" runat="server" TextMode="MultiLine"
                    Width="100%" Height="231px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvScriptContent" runat="server" ControlToValidate="txtScriptContent"
                    CssClass="cssClassNormalRed" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="text"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <div class="sfButtonwrapper">
        <asp:ImageButton ID="imbSaveScript" runat="server" ValidationGroup="text" OnClick="imbSaveScript_Click" />
        <asp:Label ID="lblSaveScript" runat="server" Text="Save" AssociatedControlID="imbSaveScript"
            CssClass="cssClassHtmlViewCursor"></asp:Label>
        <asp:ImageButton ID="imbScriptInjectCancel" runat="server" OnClick="imbScriptInjectCancel_Click" />
        <asp:Label ID="lblCancelScript" runat="server" Text="Cancel" AssociatedControlID="imbScriptInjectCancel"
            CssClass="cssClassHtmlViewCursor"></asp:Label>
    </div>
</div>
