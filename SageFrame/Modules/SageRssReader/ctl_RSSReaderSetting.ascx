<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctl_RSSReaderSetting.ascx.cs"
    Inherits="Modules_LatestBlog_ctl_RSSReaderSetting" %>

<asp:UpdatePanel ID="udpRssTest" runat="server">
  <ContentTemplate>
    <asp:HiddenField ID="hdnUserModuleID" runat="server" Value="0" />
    <h2>
      <asp:Label ID="lblHeading" runat="server" Text="RSS Reader Settings" />
    </h2>
    <div class="sfFormwrapper">
      <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
          <td width="20%"><asp:Label ID="lblDisplayTitle" runat="server" Text="Display Title:" CssClass="sfFormlabel"
                            ToolTip="Fill the title"></asp:Label></td>
          <td><asp:TextBox ID="txtDisplayTitle" runat="server" CssClass="sfInputbox"
                            ValidationGroup="vgRssSetting"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserNameRequired" runat="server" ControlToValidate="txtDisplayTitle"
                            ErrorMessage="*" ValidationGroup="vgRssSetting" CssClass="sfError"></asp:RequiredFieldValidator>
            <asp:HiddenField ID="hdnDisplayTitleID" runat="server" Value="0" /></td>
        </tr>
        <tr>
          <td><asp:Label ID="lblMaxNumberofPosts" runat="server" Text="Max No. of Posts:" CssClass="sfFormlabel"
                            ToolTip="Fill the Max Number of Posts"></asp:Label></td>
          <td><asp:TextBox ID="txtMaxNumberofPosts" runat="server" CssClass="sfInputbox"
                            ValidationGroup="vgRssSetting"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMaxNumberofPosts"
                            ErrorMessage="*" ValidationGroup="vgRssSetting" CssClass="sfError"></asp:RequiredFieldValidator>
            <asp:HiddenField ID="hdnMaxNumberofPostsID" runat="server" Value="0" /></td>
        </tr>
        <tr>
          <td><asp:Label ID="lblMaxDescriptionsLength" runat="server" Text="Max Description Length:"
                            CssClass="sfFormlabel" ToolTip="Fill the Max Descriptions Length"></asp:Label></td>
          <td><asp:TextBox ID="txtMaxDescriptionsLength" runat="server" CssClass="sfInputbox"
                            ValidationGroup="vgRssSetting"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMaxDescriptionsLength"
                            ErrorMessage="*" ValidationGroup="vgRssSetting" CssClass="sfError"></asp:RequiredFieldValidator>
            <asp:HiddenField ID="hdnMaxDescriptionsLengthID" runat="server" Value="0" /></td>
        </tr>
        <tr>
          <td><asp:Label ID="lblLastEdndent" runat="server" Text="Last Enddent:" CssClass="sfFormlabel"
                            ToolTip="Fill the Last Enddent"></asp:Label></td>
          <td><asp:TextBox ID="txtLastEdndent" runat="server" CssClass="sfInputbox"
                            ValidationGroup="vgRssSetting"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLastEdndent"
                            ErrorMessage="*" ValidationGroup="vgRssSetting" CssClass="sfError"></asp:RequiredFieldValidator>
            <asp:HiddenField ID="hdnLastEdndentID" runat="server" Value="0" /></td>
        </tr>
        <tr>
          <td><asp:Label ID="lblRssURL" runat="server" Text="Rss URL:" CssClass="sfFormlabel"
                            ToolTip="Fill the Rss URL"></asp:Label></td>
          <td><asp:TextBox ID="txtRssURL" runat="server" CssClass="sfInputbox" ValidationGroup="vgRssSetting"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRssURL"
                            ErrorMessage="*" ValidationGroup="vgRssSetting" CssClass="sfError"></asp:RequiredFieldValidator>
            <asp:HiddenField ID="hdnRssURLID" runat="server" Value="0" /></td>
        </tr>
      </table>
      <div class="sfButtonwrapper">
        <asp:ImageButton ID="imbSave" runat="server" OnClick="imbSave_Click" ValidationGroup="vgRssSetting" />
        <asp:Label ID="lblSave" runat="server" Text="Save" AssociatedControlID="imbSave"
                    Style="cursor: pointer;"></asp:Label>
        <asp:ImageButton ID="imbCancel" runat="server" OnClick="imbCancel_Click" CausesValidation="false" />
        <asp:Label ID="lblCancel" runat="server" Text="Cancel" AssociatedControlID="imbCancel"
                    Style="cursor: pointer;"></asp:Label>
      </div>
    </div>
  </ContentTemplate>
</asp:UpdatePanel>
