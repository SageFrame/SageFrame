<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsEdit.ascx.cs" Inherits="SageFrame.Modules.NewsModule.NewsEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<ajax:TabContainer ID="TabContainerNewsEdit" runat="server" ActiveTabIndex="0" 
    meta:resourcekey="TabContainerNewsEditResource1">
  <ajax:TabPanel ID="TabPanelManageNews" runat="server" 
        meta:resourcekey="TabPanelManageNewsResource1">
    <HeaderTemplate> Manage News </HeaderTemplate>
    <ContentTemplate>
      <h2>
        <asp:Label ID="lblManageNewsHelp" runat="server"
                Text="In this section, you can manage the News for the News Module" 
                meta:resourcekey="lblManageNewsHelpResource1"></asp:Label>
      </h2>
      <asp:Panel ID="pnlAddNews" runat="server" Width="100%" 
                meta:resourcekey="pnlAddNewsResource1">
        <div class="sfFormwrapper">
          <asp:HiddenField ID="hdfNewsID" runat="server" />
          <table id="tblManageNews" cellspacing="2" cellpadding="2" border="0" runat="server"
                        width="100%">
            <tr runat="server">
              <td valign="top" runat="server"><asp:Label ID="lblNewsType" runat="server" Text="News Type:" CssClass="sfFormlabel"></asp:Label></td>
              <td runat="server"><asp:DropDownList ID="ddlNewsType" runat="server" CssClass="sfListmenu"> </asp:DropDownList></td>
            </tr>
            <tr runat="server">
              <td valign="top" runat="server"><asp:Label ID="lblNewsCategory" runat="server" Text="News Category:" CssClass="sfFormlabel"></asp:Label></td>
              <td runat="server"><asp:DropDownList ID="ddlCategory" runat="server" CssClass="sfListmenu"> </asp:DropDownList></td>
            </tr>
            <tr runat="server">
              <td valign="top" runat="server"><asp:Label ID="lblNewsTitle" runat="server" Text="News Title:" CssClass="sfFormlabel"></asp:Label></td>
              <td runat="server"><asp:TextBox ID="txtNewsTitle" runat="server" CssClass="sfInputbox"
                                    TextMode="MultiLine" Height="90px" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNewsTitle" runat="server" ControlToValidate="txtNewsTitle"
                                    CssClass="cssClassNormalRed" ErrorMessage="<b>News Title cannot be left blank</b>"
                                    SetFocusOnError="True" ValidationGroup="text"></asp:RequiredFieldValidator></td>
            </tr>
            <tr runat="server">
              <td valign="top" runat="server"><asp:Label ID="lblNewsShortDescription" runat="server" Text="News Short Description:"
                                    CssClass="sfFormlabel"></asp:Label></td>
              <td runat="server"><asp:TextBox ID="txtNewsShortDescription" runat="server" Width="304px" CssClass="sfInputbox"
                                    TextMode="MultiLine" Height="93px" MaxLength="250"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNewsShortDescription" runat="server" ControlToValidate="txtNewsShortDescription"
                                    CssClass="cssClassNormalRed" ErrorMessage="<b>News Short Description cannot be left blank</b>"
                                    SetFocusOnError="True" ValidationGroup="text"></asp:RequiredFieldValidator></td>
            </tr>
            <tr runat="server">
              <td valign="top" runat="server"><asp:Label ID="lblAddLongDescription" runat="server" Text="News in Detail:" CssClass="sfFormlabel"></asp:Label></td>
              <td runat="server"><FCKeditorV2:FCKeditor ID="txtLongDesc" runat="server" Height="350px" Width="100%"> </FCKeditorV2:FCKeditor>
                <asp:CustomValidator ID="cvLong" runat="server" ErrorMessage="Required" OnServerValidate="cvFckLong_ServerValidate"
                                    ValidationGroup="text" /></td>
            </tr>
            <tr runat="server">
              <td valign="top" runat="server"><asp:Label ID="lblNewsDate" runat="server" Text="News Date:" CssClass="sfFormlabel"></asp:Label></td>
              <td runat="server"><table cellpadding="0" cellspacing="0" border="0" class="cssClassFormCalendar">
                  <tr>
                    <td><asp:TextBox ID="txtNewsDate" runat="server" CssClass="sfInputbox" MaxLength="11" /></td>
                    <td><ajax:CalendarExtender ID="cmdNewsCalendar" runat="server" CssClass="CssClassCalendar"
                                                Enabled="True" PopupButtonID="imbNewsCalender" PopupPosition="BottomRight" TargetControlID="txtNewsDate" />
                      <div class="cssClassCalendarBtn">
                        <asp:ImageButton ID="imbNewsCalender" runat="server" AlternateText="Click here to display calendar"
                                                    CausesValidation="False" />
                      </div></td>
                  </tr>
                </table></td>
            </tr>
            <tr runat="server">
              <td valign="top" runat="server"><asp:Label ID="lblIsActive" runat="server" Text="Is Active? " CssClass="sfFormlabel"></asp:Label></td>
              <td runat="server"><asp:CheckBox ID="chkIsActive" runat="server" Checked="True" /></td>
            </tr>
          </table>
        </div>
        <div class="sfButtonwrapper">
          <asp:ImageButton ID="imbUpdateNews" runat="server" OnClick="imbUpdateNews_Click"
                            ValidationGroup="text" meta:resourcekey="imbUpdateNewsResource1" />
          <asp:Label ID="lblUpdateNews" runat="server" Text="Save" AssociatedControlID="imbUpdateNews"
                            Style="cursor: pointer;" meta:resourcekey="lblUpdateNewsResource1"></asp:Label>
          <asp:ImageButton ID="imbNewsCancel" runat="server" CausesValidation="False" 
                            OnClick="imbNewsCancel_Click" meta:resourcekey="imbNewsCancelResource1" />
          <asp:Label ID="lblNewsCancel" runat="server" Text="Cancel" AssociatedControlID="imbNewsCancel"
                            Style="cursor: pointer;" meta:resourcekey="lblNewsCancelResource1"></asp:Label>
        </div>
        </asp:Panel>
      <asp:Panel ID="pnlNewsInGrid" runat="server" Width="100%" 
                meta:resourcekey="pnlNewsInGridResource1">
        <div class="sfButtonwrapper">
          <asp:ImageButton ID="imbAddNews" runat="server" CausesValidation="False" 
                        OnClick="imbAddNews_Click" meta:resourcekey="imbAddNewsResource1" />
          <asp:Label ID="lblAddNews" runat="server" Text="Add News" AssociatedControlID="imbAddNews"
                        Style="cursor: pointer;" meta:resourcekey="lblAddNewsResource1"></asp:Label>
        </div>
        <div class="sfFormwrapper">
          <asp:Label ID="lblNewsCatList" runat="server" Text="News Category:" 
                        CssClass="sfFormlabel" meta:resourcekey="lblNewsCatListResource1"></asp:Label>
          <asp:DropDownList ID="ddlNewsCatList" runat="server" CssClass="sfListmenu"
                        AutoPostBack="True" 
                        OnSelectedIndexChanged="ddlNewsCatList_SelectedIndexChanged" 
                        meta:resourcekey="ddlNewsCatListResource1"> </asp:DropDownList>
        </div>
        <div class="sfGridwrapper sfMargintop">
          <asp:GridView Width="100%" runat="server" ID="gdvManageNews" OnSelectedIndexChanged="gdvManageNews_SelectedIndexChanged"
                        AutoGenerateColumns="False" AllowPaging="True" EmptyDataText=".........No News filed under this category........."
                        OnPageIndexChanging="gdvManageNews_PageIndexChanging" OnRowCommand="gdvManageNews_RowCommand"
                        OnRowDataBound="gdvManageNews_RowDataBound" OnRowDeleting="gdvManageNews_RowDeleting"
                        OnRowUpdating="gdvManageNews_RowUpdating" 
                        OnRowEditing="gdvManageNews_RowEditing" 
                        meta:resourcekey="gdvManageNewsResource1">
            <Columns>
            <asp:TemplateField HeaderText="News Title" 
                                meta:resourcekey="TemplateFieldResource1">
              <ItemTemplate>
                <asp:Label ID="lblNewsTitle" runat="server" Text='<%# Eval("NewsTitle") %>' 
                                        meta:resourcekey="lblNewsTitleResource1"></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="News Date" 
                                meta:resourcekey="TemplateFieldResource2">
              <ItemTemplate>
                <asp:Label ID="lblNewsDate" runat="server" Text='<%# Eval("NewsDate") %>' 
                                        meta:resourcekey="lblNewsDateResource1"></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="News Short Description" 
                                meta:resourcekey="TemplateFieldResource3">
              <ItemTemplate>
                <asp:Label runat="server" Text='<%# Eval("NewsShortDescription") %>' 
                                        ID="lblShortNews" meta:resourcekey="lblShortNewsResource1" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField meta:resourcekey="TemplateFieldResource4">
              <ItemTemplate>
                <asp:ImageButton ID="imbEdit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("NewsID") %>'
                                        CommandName="Edit" ToolTip="Edit News" 
                                        ImageUrl='<%# GetTemplateImageUrl("imgedit.png", true) %>' 
                                        meta:resourcekey="imbEditResource1" />
              </ItemTemplate>
              <HeaderStyle CssClass="sfEdit" />
            </asp:TemplateField>
            <asp:TemplateField meta:resourcekey="TemplateFieldResource5">
              <ItemTemplate>
                <asp:ImageButton ID="imbDelete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("NewsID") %>'
                                        CommandName="Delete" ToolTip="Delete News" OnClientClick="return confirm('Are you sure ?');"
                                        ImageUrl='<%# GetTemplateImageUrl("imgdelete.png", true) %>' 
                                        meta:resourcekey="imbDeleteResource1" />
              </ItemTemplate>
              <HeaderStyle CssClass="sfDelete" />
            </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="sfOdd" />
            <AlternatingRowStyle CssClass="sfEven" />
          </asp:GridView>
        </div>
        </asp:Panel>
    </ContentTemplate>
  </ajax:TabPanel>
  <ajax:TabPanel ID="TabPanelManageNewsCategory" runat="server" 
        meta:resourcekey="TabPanelManageNewsCategoryResource1">
    <HeaderTemplate> Manage News Category </HeaderTemplate>
    <ContentTemplate>
      <asp:Label ID="lblManageNewsCategoryHelp" runat="server" CssClass="cssClassHelpTitle"
                
                Text="In this section, you can manage the News Category for the News Module" 
                meta:resourcekey="lblManageNewsCategoryHelpResource1"></asp:Label>
      <asp:Panel ID="pnlManageNewsCategory" runat="server" 
                meta:resourcekey="pnlManageNewsCategoryResource1">
        <div class="sfButtonwrapper">
          <asp:ImageButton ID="imbAddNewsCategory" runat="server" CausesValidation="False"
                        OnClick="imbAddNewsCategory_Click" 
                        meta:resourcekey="imbAddNewsCategoryResource1" />
          <asp:Label ID="lblAddNewsCategory" runat="server" Text="Add News Category" AssociatedControlID="imbAddNewsCategory"
                        Style="cursor: pointer;" meta:resourcekey="lblAddNewsCategoryResource1"></asp:Label>
        </div>
        <div class="sfGridwrapper">
          <asp:GridView Width="100%" runat="server" ID="gdvManageNewsCategory" DataKeyNames="NewsCategoryID"
                         OnSelectedIndexChanged="gdvManageNewsCategory_SelectedIndexChanged"
                        AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="..........News Category Not Found.........."
                        OnPageIndexChanging="gdvManageNewsCategory_PageIndexChanging" OnRowCommand="gdvManageNewsCategory_RowCommand"
                        OnRowDataBound="gdvManageNewsCategory_RowDataBound" OnRowDeleting="gdvManageNewsCategory_RowDeleting"
                        OnRowUpdating="gdvManageNewsCategory_RowUpdating" 
                        OnRowEditing="gdvManageNewsCategory_RowEditing" 
                        meta:resourcekey="gdvManageNewsCategoryResource1">
            <Columns>
            <asp:TemplateField HeaderText="News Category" 
                                meta:resourcekey="TemplateFieldResource6">
              <ItemTemplate>
                <asp:Label ID="lblNewsCategory" runat="server" 
                                        Text='<%# Eval("NewsCategory") %>' meta:resourcekey="lblNewsCategoryResource1"></asp:Label>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
              <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="News Category Description" 
                                meta:resourcekey="TemplateFieldResource7">
              <ItemTemplate>
                <asp:Label ID="lblNewsCategoryDescription" runat="server" 
                                        Text='<%# Eval("NewsCategoryDescription") %>' 
                                        meta:resourcekey="lblNewsCategoryDescriptionResource1" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
              <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IconFile" 
                                meta:resourcekey="TemplateFieldResource8">
              <ItemTemplate>
                <asp:Image ID="imgIcon" runat="server" 
                                        ImageUrl='<%# ReturnImageURL(Eval("SmallImagePath").ToString(), Eval("ImageExtension").ToString()) %>' 
                                        meta:resourcekey="imgIconResource1" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
              <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Added On" 
                                meta:resourcekey="TemplateFieldResource9">
              <ItemTemplate>
                <asp:Label ID="lblNewsCategoryDate" runat="server" 
                                        Text='<%# Eval("AddedOn") %>' meta:resourcekey="lblNewsCategoryDateResource1"></asp:Label>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
              <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField meta:resourcekey="TemplateFieldResource10">
              <ItemTemplate>
                <asp:ImageButton ID="imbEditNewsCategory" runat="server" CausesValidation="False"
                                        CommandArgument='<%# Eval("NewsCategoryID") %>' CommandName="Edit" ToolTip="Edit News Category"
                                        ImageUrl='<%# GetTemplateImageUrl("imgedit.png", true) %>' 
                                        meta:resourcekey="imbEditNewsCategoryResource1" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
              <HeaderStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField meta:resourcekey="TemplateFieldResource11">
              <ItemTemplate>
                <asp:ImageButton ID="imbDeleteNewsCategory" runat="server" CausesValidation="False"
                                        CommandArgument='<%# Eval("NewsCategoryID") %>' CommandName="Delete" ToolTip="Delete News Category"
                                        OnClientClick="return confirm('Are you sure ?');" 
                                        ImageUrl='<%# GetTemplateImageUrl("imgdelete.png", true) %>' 
                                        meta:resourcekey="imbDeleteNewsCategoryResource1" />
              </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="sfOdd" />
            <AlternatingRowStyle CssClass="sfEven" />
          </asp:GridView>
        </div>
        </asp:Panel>
      <asp:Panel ID="pnlAddNewsCategory" runat="server" 
                meta:resourcekey="pnlAddNewsCategoryResource1">
        <div class="sfFormwrapper">
          <table id="tblManageCategories" border="0">
            <tr id="rowNewsCategoryID" runat="server" visible="False">
              <td valign="top" runat="server"><asp:Label ID="lblNewsCategoryID" runat="server" Text="NewsCategoryID" CssClass="sfFormlabel"></asp:Label></td>
              <td runat="server"><asp:Label ID="lblNewsCatID" runat="server"></asp:Label>
                <asp:HiddenField ID="hdfNewsCategoryID" runat="server" /></td>
              <td runat="server"></td>
            </tr>
            <tr>
              <td valign="top"><asp:Label ID="lblCategoryName" runat="server" Text="News Category Name:" 
                                    CssClass="sfFormlabel" meta:resourcekey="lblCategoryNameResource1"></asp:Label></td>
              <td><asp:TextBox ID="txtCategoryName" runat="server" Width="304px" CssClass="sfInputbox"
                                    MaxLength="100" meta:resourcekey="txtCategoryNameResource1"></asp:TextBox></td>
              <td><asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" ControlToValidate="txtCategoryName"
                                    CssClass="cssClassNormalRed" ErrorMessage="<b>Name is required</b>" 
                                    meta:resourcekey="rfvCategoryNameResource1"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td valign="top" height="53"><asp:Label ID="lblCategoryDescription" runat="server" Text="News Category Description:"
                                    CssClass="sfFormlabel" 
                                    meta:resourcekey="lblCategoryDescriptionResource1"></asp:Label></td>
              <td height="53"><asp:TextBox ID="txtCategoryDescription" runat="server" Width="304px" CssClass="sfInputbox"
                                    TextMode="MultiLine" Height="93px" MaxLength="250" 
                                    meta:resourcekey="txtCategoryDescriptionResource1"></asp:TextBox></td>
              <td valign="top" height="53"><asp:RequiredFieldValidator ID="rfvCategoryDescription" runat="server" CssClass="cssClassNormalRed"
                                    ErrorMessage="<b> Description is Required </b>" 
                                    ControlToValidate="txtCategoryDescription" 
                                    meta:resourcekey="rfvCategoryDescriptionResource1"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td valign="top"><asp:Label ID="lblIcon" runat="server" Text="News Category Image:" 
                                    CssClass="sfFormlabel" meta:resourcekey="lblIconResource1"></asp:Label></td>
              <td valign="top"><asp:FileUpload ID="fluNewsCategory" runat="server" 
                                    meta:resourcekey="fluNewsCategoryResource1" />
                <asp:Label ID="lblError" runat="server" EnableViewState="False" 
                                    ForeColor="#FF3300" meta:resourcekey="lblErrorResource1"></asp:Label></td>
              <td style="text-align: left"><asp:Image ID="ImgNewsCategory" runat="server" Visible="False" 
                                    meta:resourcekey="ImgNewsCategoryResource1" /></td>
            </tr>
            <tr>
              <td valign="top"><asp:Label ID="lblPublish" runat="server" Text="Publish" 
                                    CssClass="sfFormlabel" meta:resourcekey="lblPublishResource1" /></td>
              <td><asp:CheckBox ID="chkPublish" runat="server" Checked="True" 
                                    cssClass="sfCheckbox" meta:resourcekey="chkPublishResource1" /></td>
              <td valign="top"></td>
            </tr>
          </table>
        </div>
        <div class="sfButtonwrapper">
          <asp:ImageButton ID="imbUpdate" runat="server" OnClick="imbUpdate_Click" 
                        meta:resourcekey="imbUpdateResource1"/>
          <asp:Label ID="lblUpdate" runat="server" Text="Update" AssociatedControlID="imbUpdate"
                        Style="cursor: pointer;" meta:resourcekey="lblUpdateResource1"></asp:Label>
          <asp:ImageButton ID="imbCancel" runat="server" OnClick="imbCancel_Click" 
                        CausesValidation="False" meta:resourcekey="imbCancelResource1" />
          <asp:Label ID="lblCancel" runat="server" Text="Cancel" AssociatedControlID="imbCancel"
                        Style="cursor: pointer;" meta:resourcekey="lblCancelResource1"></asp:Label>
        </div>
        </asp:Panel>
    </ContentTemplate>
  </ajax:TabPanel>
</ajax:TabContainer>
