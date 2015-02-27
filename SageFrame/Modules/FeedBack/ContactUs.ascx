<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactUs.ascx.cs" Inherits="SageFrame.Modules.FeedBack.ContactUs" %>
<div class="sfContactform" id="divContactFormDetails" runat="server">
    <div class="sfContactinfo" id="ContactInformation" runat="server">
    </div>
    <div class="sfFormwrapper">
        <asp:Panel ID="pnlFormView" runat="server" meta:resourcekey="pnlFormViewResource1">
        </asp:Panel>
        <div class="sfButtonwrapper">
            <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" ValidationGroup="Feedback"
                CssClass="sfBtn" meta:resourcekey="btnSendResource1" />
        </div>
    </div>
</div>
