<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsSettings.ascx.cs"
    Inherits="SageFrame.Modules.NewsModule.NewsSettings" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<div class="cssClassModuleWrapper">
  <ajax:TabContainer ID="TabContainerBannerSettings" runat="server" 
        ActiveTabIndex="0" meta:resourcekey="TabContainerBannerSettingsResource1">
    <ajax:TabPanel ID="TabPanelNewsSettings" runat="server" 
            meta:resourcekey="TabPanelNewsSettingsResource1">
      <HeaderTemplate> News Settings </HeaderTemplate>
      <ContentTemplate>
        <asp:Label ID="lblNewsSettingsHelp" runat="server" CssClass="cssClassHelpTitle" 
                    Text="In this section, you can set up the News settings for the News Module" 
                    meta:resourcekey="lblNewsSettingsHelpResource1"></asp:Label>
        <div class="sfFormwrapper">
          <table>
            <tr>
              <td width="20%"><asp:Label ID="lblNewsModuleTitle" runat="server" CssClass="sfFormlabel"
                                Text="News Module Title:" meta:resourcekey="lblNewsModuleTitleResource1"></asp:Label></td>
              <td><asp:TextBox ID="txtNewsModuleTitle" runat="server" 
                                    CssClass="sfInputbox" meta:resourcekey="txtNewsModuleTitleResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNewsModuleTitle" runat="server" ErrorMessage="Titles Required." 
                                    SetFocusOnError="True" ValidationGroup="newssetting" 
                                    ControlToValidate="txtNewsModuleTitle" CssClass="cssClassNormalRed" 
                                    meta:resourcekey="rfvNewsModuleTitleResource1"></asp:RequiredFieldValidator></td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td width="20%"><asp:Label ID="lblDefaultSorting" runat="server" CssClass="sfFormlabel" 
                                    Text="Default Sorting:" meta:resourcekey="lblDefaultSortingResource1"></asp:Label></td>
              <td><asp:DropDownList ID="ddlDefaultSorting" runat="server" 
                                    CssClass="sfListmenu" meta:resourcekey="ddlDefaultSortingResource1"> </asp:DropDownList></td>
              <td></td>
            </tr>
            <tr>
              <td><asp:Label ID="lblDateFormat" runat="server" CssClass="sfFormlabel" 
                                    Text="Date Format:" meta:resourcekey="lblDateFormatResource1"></asp:Label></td>
              <td><asp:DropDownList ID="ddlDateFormat" runat="server" CssClass="sfListmenu" 
                                    meta:resourcekey="ddlDateFormatResource1"> </asp:DropDownList></td>
              <td></td>
            </tr>
            <tr>
              <td><asp:Label ID="lblNumberOfNews" runat="server" CssClass="sfFormlabel" 
                                    Text="Number of News:" meta:resourcekey="lblNumberOfNewsResource1"></asp:Label></td>
              <td><asp:TextBox ID="txtNumberOfNews" runat="server" 
                                    CssClass="sfInputbox" meta:resourcekey="txtNumberOfNewsResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNumberOfNews" runat="server" ErrorMessage="*"
                                    ValidationGroup="newssetting" ControlToValidate="txtNumberOfNews" 
                                    CssClass="cssClassNormalRed" meta:resourcekey="rfvNumberOfNewsResource1"></asp:RequiredFieldValidator></td>
              <td><asp:RegularExpressionValidator ID="revNumberOfNews" runat="server" 
                                    ControlToValidate="txtNumberOfNews" ErrorMessage="Number Required." 
                                    ValidationExpression="^\d+$" CssClass="cssClassNormalRed" 
                                    meta:resourcekey="revNumberOfNewsResource1"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
              <td><asp:Label ID="lblMoreNewsText" runat="server" CssClass="sfFormlabel" 
                                    Text="More News Text:" meta:resourcekey="lblMoreNewsTextResource1"></asp:Label></td>
              <td><asp:TextBox ID="txtMoreNewsText" runat="server" 
                                    CssClass="sfInputbox" meta:resourcekey="txtMoreNewsTextResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMoreNewsText" runat="server" 
                                    ControlToValidate="txtMoreNewsText" ErrorMessage="Text Required." 
                                    SetFocusOnError="True" ValidationGroup="newssetting" 
                                    CssClass="cssClassNormalRed" meta:resourcekey="rfvMoreNewsTextResource1"></asp:RequiredFieldValidator></td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td><asp:Label ID="lblMoreNewsPageName" runat="server" CssClass="sfFormlabel" 
                                    Text="More News Page Name:" 
                                    meta:resourcekey="lblMoreNewsPageNameResource1"></asp:Label></td>
              <td><asp:TextBox ID="txtMoreNewsPageName" runat="server" 
                                    CssClass="sfInputbox" 
                                    meta:resourcekey="txtMoreNewsPageNameResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMoreNewsPageName" runat="server" 
                                    ControlToValidate="txtMoreNewsPageName" ErrorMessage="Name Required." 
                                    SetFocusOnError="True" ValidationGroup="newssetting" 
                                    CssClass="cssClassNormalRed" meta:resourcekey="rfvMoreNewsPageNameResource1"></asp:RequiredFieldValidator></td>
              <td></td>
            </tr>
          </table>
          <div class="sfButtonwrapper">
            <asp:ImageButton ID="imbSaveNewsSetting" runat="server" ValidationGroup="newssetting"
                            OnClick="imbSaveNewsSetting_Click" 
                            meta:resourcekey="imbSaveNewsSettingResource1" />
            <asp:Label ID="lblSaveNewsSetting" runat="server" Text="Save" Style="cursor: pointer;"
                            AssociatedControlID="imbSaveNewsSetting" 
                            meta:resourcekey="lblSaveNewsSettingResource1"></asp:Label>
          </div>
        </div>
      </ContentTemplate>
    </ajax:TabPanel>
    <ajax:TabPanel ID="TabPanelCategorySettings" runat="server" 
            meta:resourcekey="TabPanelCategorySettingsResource1">
      <HeaderTemplate> Category Settings </HeaderTemplate>
      <ContentTemplate>
        <asp:Label ID="lblCategorySettingsHelp" runat="server" CssClass="cssClassHelpTitle"
                    
                    Text="In this section, you can set up the Category settings for the News Module" 
                    meta:resourcekey="lblCategorySettingsHelpResource1"></asp:Label>
        <div class="sfFormwrapper">
          <table>
            <tr>
              <td width="20%"><asp:Label ID="lblNewsCategoryLists" runat="server" CssClass="sfFormlabel"
                                    Text="News Category To Show:" 
                                    meta:resourcekey="lblNewsCategoryListsResource1"></asp:Label></td>
              <td><asp:ListBox ID="lstNewsCategoryLists" runat="server" CssClass="sfListmenu "
                                    SelectionMode="Multiple" ValidationGroup="categorysetting" 
                                    meta:resourcekey="lstNewsCategoryListsResource1"></asp:ListBox></td>
              <td></td>
            </tr>
            <tr>
              <td><asp:Label ID="lblMaxNumberOfCategory" runat="server" CssClass="sfFormlabel"
                                    Text="Maximum Number of Category:" 
                                    meta:resourcekey="lblMaxNumberOfCategoryResource1"></asp:Label></td>
              <td><asp:TextBox ID="txtMaxNumberOfCategory" runat="server" 
                                    CssClass="sfInputbox" 
                                    meta:resourcekey="txtMaxNumberOfCategoryResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMaxNumberOfCategory" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtMaxNumberOfCategory" 
                                    ValidationGroup="categorysetting" CssClass="cssClassNormalRed" 
                                    meta:resourcekey="rfvMaxNumberOfCategoryResource1"></asp:RequiredFieldValidator></td>
              <td><asp:RegularExpressionValidator ID="rfvNumberOfCategory1" runat="server" ControlToValidate="txtMaxNumberOfCategory"
                                    ErrorMessage="Number Required." ValidationExpression="^\d+$" 
                                    ValidationGroup="categorysetting" CssClass="cssClassNormalRed" 
                                    meta:resourcekey="rfvNumberOfCategory1Resource1"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
              <td><asp:Label ID="lblIconSize" runat="server" CssClass="sfFormlabel" 
                                    Text="Category Icon Size:" meta:resourcekey="lblIconSizeResource1"></asp:Label></td>
              <td><asp:TextBox ID="txtIconSize" runat="server" CssClass="sfInputbox" 
                                    meta:resourcekey="txtIconSizeResource1"></asp:TextBox>
                <asp:Label ID="lblImageSize"
                                    runat="server" CssClass="sfFormlabel" Text="(KB) " 
                                    meta:resourcekey="lblImageSizeResource1"></asp:Label></td>
              <td><asp:RequiredFieldValidator ID="rfvIconSize" runat="server" ControlToValidate="txtIconSize"
                                    ErrorMessage="*" ValidationGroup="categorysetting" 
                                    CssClass="cssClassNormalRed" meta:resourcekey="rfvIconSizeResource1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rfvIconSize1" runat="server" ControlToValidate="txtIconSize"
                                    ErrorMessage="Number Required." ValidationExpression="^\d+$" 
                                    ValidationGroup="categorysetting" CssClass="cssClassNormalRed" 
                                    meta:resourcekey="rfvIconSize1Resource1"></asp:RegularExpressionValidator></td>
            </tr>
          </table>
          <div class="sfButtonwrapper">
            <asp:ImageButton ID="imbSaveCategorySetting" runat="server" OnClick="imbSaveCategorySetting_Click"
                            ValidationGroup="categorysetting" 
                            meta:resourcekey="imbSaveCategorySettingResource1" />
            <asp:Label ID="lblSaveCategorySetting" runat="server" AssociatedControlID="imbSaveCategorySetting"
                            Style="cursor: pointer;" Text="Save" 
                            meta:resourcekey="lblSaveCategorySettingResource1"></asp:Label>
          </div>
        </div>
      </ContentTemplate>
    </ajax:TabPanel>
  </ajax:TabContainer>
</div>
