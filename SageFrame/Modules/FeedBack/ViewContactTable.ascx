<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewContactTable.ascx.cs"
    Inherits="SageFrame.Modules.FeedBack.ViewContactTable" %>
<div class="sfGridwrapper">
    <asp:GridView ID="gdvContactUs" runat="server" AutoGenerateColumns="False" Width="100%"
        AllowPaging="True" OnRowDataBound="gdvContactUs_RowDataBound" OnRowDeleting="gdvContactUs_RowDeleting"
        OnRowCommand="gdvContactUs_RowCommand" PageSize="15" OnPageIndexChanging="gdvContactUs_PageIndexChanging"
        meta:resourcekey="gdvContactUsResource1" EmptyDataText="No contacts available">
        <Columns>
            <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
                <ItemTemplate>
                    <asp:HiddenField ID="hdnFID" runat="server" Value='<%# Eval("FeedbackID") %>' />
                    <asp:Panel ID="pnlCon" runat="server" meta:resourcekey="pnlConResource1">
                    </asp:Panel>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
                <ItemTemplate>
                    <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("FeedbackID") %>'
                        CommandName="Delete" ImageUrl='<%# GetTemplateImageUrl("imgdelete.png", true) %>'
                        ToolTip="Delete" CssClass="cssClassColumnDelete" OnClientClick="return confirm('Are you sure ?');"
                        meta:resourcekey="imgDeleteResource1" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle CssClass="sfPagination" />
        <RowStyle CssClass="sfOdd" />
        <AlternatingRowStyle CssClass="sfEven" />
        <EmptyDataRowStyle CssClass="sfEmptyrow" />
    </asp:GridView>
</div>
