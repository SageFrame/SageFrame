<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctl_ManageRoles.ascx.cs"
    Inherits="SageFrame.Modules.Admin.UserManagement.ctl_ManageRoles" %>
<h1>
    <asp:Label ID="lblRolesManagement" runat="server" Text="Roles Management"></asp:Label>
</h1>
<asp:Panel ID="pnlRole" runat="server">
    <div class="sfFormwrapper">
        <h2>
            <asp:Label ID="lblAddRoles" runat="server" Text="Add New Role"></asp:Label>
        </h2>
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td width="15%">
                    <asp:Label ID="lblRole" runat="server" CssClass="sfFormlabel" Text="Role Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRole" runat="server" CssClass="sfInputbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRole" runat="server" ErrorMessage="*" ControlToValidate="txtRole"
                        ValidationGroup="SageFrameRole"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </div>
    <div class="sfButtonwrapper">
        <asp:LinkButton ID="imgAdd" runat="server" ValidationGroup="SageFrameRole" OnClick="imgAdd_Click"
            ToolTip="save" CssClass="icon-save sfBtn" Text="Save" />
        <asp:LinkButton ID="imgCancel" runat="server" CausesValidation="False" OnClick="imgCancel_Click"
            ToolTip="cancel" CssClass="icon-close sfBtn" Text="Cancel" />
    </div>
</asp:Panel>
<asp:Panel ID="pnlRoles" runat="server">
    <div class="sfButtonwrapper">
        <asp:LinkButton ID="imbAddNewRole" runat="server" OnClick="imbAddNewRole_Click" ToolTip="Add New Role"
            CssClass="icon-addnew sfBtn" Text="Add New Role" />
    </div>
    <div class="sfGridwrapper">
        <asp:GridView ID="gdvRoles" runat="server" AutoGenerateColumns="False" GridLines="None"
            OnRowDeleting="gdvRoles_RowDeleting" DataKeyNames="Role,RoleID" Width="100%"
            OnRowDataBound="gdvRoles_RowDataBound" OnRowCommand="gdvRoles_RowCommand">
            <Columns>
                <asp:BoundField DataField="Role" HeaderText="Roles" />
                <asp:TemplateField HeaderStyle-CssClass="sfDelete">
                    <ItemTemplate>
                        <asp:LinkButton ID="imbDelete" runat="server" CausesValidation="False" CommandArgument='<%#Container.DataItemIndex%>'
                            CommandName="Delete" OnClientClick="return ConfirmDialog(this, 'Confirmation', 'Are you sure you want to delete this role?');"
                            CssClass="icon-delete" ToolTip="Delete the role" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="sfOdd" />
            <AlternatingRowStyle CssClass="sfEven" />
        </asp:GridView>
    </div>
</asp:Panel>
