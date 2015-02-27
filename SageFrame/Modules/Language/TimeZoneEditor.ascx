<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TimeZoneEditor.ascx.cs"
    Inherits="Modules_Language_TimeZoneEditor" %>
<h1>
    <asp:Label ID="lblTimeZoneEditor" runat="server" Text="Time Zone Editor" meta:resourcekey="lblTimeZoneEditorResource1"></asp:Label>
</h1>
<div>
    <div class="sfFormwrapper sfPadding">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="15%">
                    <asp:Label ID="lblAvailableLocales" runat="server" CssClass="sfFormlabel" Text="Available Locales"
                        meta:resourcekey="lblAvailableLocalesResource1"></asp:Label>
                </td>
                <td width="30">
                    :
                </td>
                <td>
                    <asp:DropDownList ID="ddlAvailableLocales" runat="server" CssClass="sfListmenu" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlAvailableLocales_SelectedIndexChanged" meta:resourcekey="ddlAvailableLocalesResource1">
                    </asp:DropDownList>
                    <asp:Image ID="imgFlag" runat="server" meta:resourcekey="imgFlagResource1" />
                </td>
            </tr>
        </table>
    </div>
    <div class="sfFormwrapper sfGridwrapper sfMargintop">
        <asp:GridView ID="gdvTimeZoneEditor" runat="server" AutoGenerateColumns="False" Width="100%"
            meta:resourcekey="gdvTimeZoneEditorResource1">
            <Columns>
                <asp:TemplateField HeaderText="Name" meta:resourcekey="TemplateFieldResource1">
                    <ItemTemplate>
                        <asp:TextBox ID="txtTimeZoneName" CssClass="sfInputbox sfFullwidth" runat="server"
                            Text='<%# Eval("name") %>' meta:resourcekey="txtTimeZoneNameResource1"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="key" HeaderText="Key" meta:resourcekey="BoundFieldResource1"
                    HeaderStyle-CssClass="sfKey" ItemStyle-CssClass="sfKey" >
<HeaderStyle CssClass="sfKey"></HeaderStyle>

<ItemStyle CssClass="sfKey"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="DefaultValue" meta:resourcekey="BoundFieldResource2" />
            </Columns>
            <PagerStyle CssClass="sfPagination" />
            <AlternatingRowStyle CssClass="sfEven" />
            <RowStyle CssClass="sfOdd" />
        </asp:GridView>
    </div>
</div>
<div class="sfButtonwrapper">
    <asp:ImageButton ID="imbUpdate" runat="server" ImageUrl="~/Administrator/Templates/Default/images/btnsave.png"
        Style="width: 16px" OnClick="imbUpdate_Click" meta:resourcekey="imbUpdateResource1" />
    <asp:Label ID="lblAddLanguage" runat="server" Text="Update" CssClass="sfFormlabel"
        AssociatedControlID="imbUpdate" Style="cursor: pointer;" meta:resourcekey="lblAddLanguageResource1"></asp:Label>
    <asp:ImageButton ID="imbCancel" runat="server" ImageUrl="~/Administrator/Templates/Default/images/btncancel.png"
        OnClick="imbCancel_Click" meta:resourcekey="imbCancelResource1" />
    <asp:Label ID="lblInstallLang" runat="server" CssClass="sfFormlabel" Text="Cancel"
        AssociatedControlID="imbCancel" Style="cursor: pointer;" meta:resourcekey="lblInstallLangResource1"></asp:Label>
</div>
