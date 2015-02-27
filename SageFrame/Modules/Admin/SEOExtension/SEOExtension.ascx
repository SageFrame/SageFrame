<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SEOExtension.ascx.cs"
    Inherits="Modules_Admin_SEOExtension_SEOExtension" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<h1>
    SEO Extension
</h1>
<div class="sfFormwrapper sfPadding">
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        meta:resourcekey="TabContainer1Resource1">
        <cc1:TabPanel ID="tpGoogleAnalytics" runat="server" 
            HeaderText="Google Analytics" meta:resourcekey="tpGoogleAnalyticsResource1">
            <ContentTemplate>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="10%">
                            <asp:Label ID="lblvalue" runat="server" Text="Google JS" ToolTip="Javascript code provided by google, paste here."
                                CssClass="sfFormlabel" meta:resourcekey="lblvalueResource1"></asp:Label>
                        </td>
                        <td width="30">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtvalue" runat="server" TextMode="MultiLine" Rows="10" ValidationGroup="GJSC"
                                CssClass="sfTextarea sfFullwidth" Height="200px" 
                                meta:resourcekey="txtvalueResource1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvJS" runat="server" ControlToValidate="txtvalue"
                                ErrorMessage="*" ValidationGroup="GJSC" CssClass="sfError" 
                                meta:resourcekey="rfvJSResource1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign='top'>
                            <asp:Label ID="lblisActive" runat="server" Text="Is Active" 
                                CssClass="sfFormlabel" meta:resourcekey="lblisActiveResource1"></asp:Label>
                        </td>
                        <td width="30">
                            :
                        </td>
                        <td>
                            <asp:CheckBox ID="chkIsActive" runat='server' ValidationGroup="GJSC" 
                                CssClass="sfCheckbox" meta:resourcekey="chkIsActiveResource1" />
                        </td>
                    </tr>
                </table>
                <div class="sfButtonwrapper">
                    <asp:ImageButton ID="imbSave" runat="server" OnClick="imbSave_Click" ToolTip="Save"
                        CausesValidation="False" ValidationGroup="GJSC" 
                        meta:resourcekey="imbSaveResource1" />
                    <asp:Label ID="lblSave" runat="server" Text="Update" ToolTip="Save" AssociatedControlID="imbSave"
                        Style="cursor: pointer;" meta:resourcekey="lblSaveResource1"></asp:Label>
                    <asp:ImageButton ID="imbRefresh" runat="server" ToolTip="Refresh" OnClick="imbRefresh_Click"
                        CausesValidation="False" meta:resourcekey="imbRefreshResource1" />
                    <asp:Label ID="lblRefresh" runat="server" Text="Refresh" ToolTip="Refresh" AssociatedControlID="imbRefresh"
                        Style="cursor: pointer;" meta:resourcekey="lblRefreshResource1"></asp:Label>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tpSitemap" runat="server" HeaderText="Sitemap" 
            meta:resourcekey="tpSitemapResource1">
            <ContentTemplate>
                <div id="divSitemap">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td width="27%">
                                <asp:Label ID="lblPriorityValues" runat="server" Text="Priority Values" 
                                    CssClass="sfFormlabel" meta:resourcekey="lblPriorityValuesResource1"></asp:Label>
                            </td>
                            <td width="30">
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPriorityValues" runat="server" CssClass="sfListmenu" 
                                    meta:resourcekey="ddlPriorityValuesResource1">
                                    <asp:ListItem meta:resourcekey="ListItemResource1">0.0</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource2">0.1</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource3">0.2</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource4">0.3</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource5">0.4</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource6">0.5</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource7">0.6</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource8">0.7</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource9">0.8</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource10">0.9</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource11">1.0</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblChangeFequency" runat="server" Text="Change Frequency" 
                                    CssClass="sfFormlabel" meta:resourcekey="lblChangeFequencyResource1"></asp:Label>
                            </td>
                            <td width="30">
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlChangeFrequency" runat="server" CssClass="sfListmenu" 
                                    meta:resourcekey="ddlChangeFrequencyResource1">
                                    <asp:ListItem meta:resourcekey="ListItemResource12">Always</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource13">Hourly</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource14">Daily</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource15">Weekly</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource16">Monthly</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource17">Yearly</asp:ListItem>
                                    <asp:ListItem meta:resourcekey="ListItemResource18">Never</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDisplay" runat="server" Text="Generate Sitemap" 
                                    CssClass="sfFormlabel" meta:resourcekey="lblDisplayResource1"></asp:Label>
                            </td>
                            <td width="30">
                                :
                            </td>
                            <td>
                                <asp:Button ID="BtnGenerateSitemap" class="sfBtn" runat="server" Text="Generate"
                                    OnClick="btnGenerateSitemap_Click" 
                                    meta:resourcekey="BtnGenerateSitemapResource1" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDisplaySearchEngine" runat="server" Text="Submit Sitemap to Search Engines"
                                    CssClass="sfFormlabel" meta:resourcekey="lblDisplaySearchEngineResource1"></asp:Label>
                            </td>
                            <td width="30">
                                :
                            </td>
                            <td>
                                <div class="sfCheckbox">
                                    <asp:CheckBoxList ID="chkSubmitSitemap" runat="server" RepeatDirection="Horizontal"
                                        ValidationGroup="checkselected" 
                                        meta:resourcekey="chkSubmitSitemapResource1">
                                        <asp:ListItem meta:resourcekey="ListItemResource19">Google</asp:ListItem>
                                        <asp:ListItem meta:resourcekey="ListItemResource20">Yahoo</asp:ListItem>
                                        <asp:ListItem meta:resourcekey="ListItemResource21">Bing</asp:ListItem>
                                        <asp:ListItem meta:resourcekey="ListItemResource22">Ask</asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" CssClass="sfBtn" runat="server" Text="Submit" 
                                    OnClick="btnSubmit_Click" meta:resourcekey="btnSubmitResource1" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tpRobots" runat="server" HeaderText="Robots" 
            meta:resourcekey="tpRobotsResource1">
            <ContentTemplate>
                <div id="divRobots">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td width="260">
                                <div class="sfCheckbox">
                                    <asp:CheckBoxList ID="chkChoice" runat="server" RepeatDirection="Horizontal" 
                                        ValidationGroup="checkselected" meta:resourcekey="chkChoiceResource1">
                                        <asp:ListItem meta:resourcekey="ListItemResource23">Google</asp:ListItem>
                                        <asp:ListItem meta:resourcekey="ListItemResource24">Yahoo</asp:ListItem>
                                        <asp:ListItem meta:resourcekey="ListItemResource25">Bing</asp:ListItem>
                                        <asp:ListItem meta:resourcekey="ListItemResource26">Msn</asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                            </td>
                            <td>
                                <asp:Button ID="btnGenerateRobots" runat="server" ValidationGroup="checkselected"
                                    CssClass="sfBtn" Text="Generate Robots" OnClick="btnGenerateRobots_Click" 
                                    meta:resourcekey="btnGenerateRobotsResource1"></asp:Button>
                            </td>
                        </tr>
                        <td colspan="2">
                            <div class="sfGridwrapper">
                                <asp:GridView ID="gdvRobots" runat="server" AutoGenerateColumns="False" 
                                    Width="100%" meta:resourcekey="gdvRobotsResource1">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Path Not To Crawl" 
                                            meta:resourcekey="TemplateFieldResource1">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkPath" runat="server" meta:resourcekey="chkPathResource1" />
                                                <asp:Label ID="lblTabPath" runat="server" Text='<%# Eval("TabPath") %>' 
                                                    meta:resourcekey="lblTabPathResource1"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <AlternatingRowStyle CssClass="sfEven" />
                                    <RowStyle CssClass="sfOdd" />
                                </asp:GridView>
                            </div>
                        </td>
                    </table>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
</div>
