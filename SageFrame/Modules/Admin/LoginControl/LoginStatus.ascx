<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginStatus.ascx.cs" Inherits="Modules_Admin_LoginControl_LoginStatus" %>
<%@ Register Src="~/Controls/LoginStatus.ascx" TagName="LoginStatus" TagPrefix="uc1" %>
<div class="sfLogininfo">
    <ul>
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                <li class="sfLogout">
                    <uc1:LoginStatus ID="LoginStatus1" runat="server" />
                </li>
                <li class="sfRegister">
                    <%=RegisterURL%>
                </li>
            </AnonymousTemplate>
            <LoggedInTemplate>
                </li>
                <li>
                    <asp:Label ID="lblProfileURL" runat="server" meta:resourcekey="lblProfileURLResource1"></asp:Label>
                </li>
                <li>
                    <uc1:LoginStatus ID="LoginStatus2" runat="server" />
                </li>
            </LoggedInTemplate>
        </asp:LoginView>
    </ul>
</div>
