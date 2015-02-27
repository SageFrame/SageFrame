<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctl_MessageTemplateManagement.ascx.cs"
    Inherits="SageFrame.Modules.Admin.MessageManagement.ctl_MessageTemplateManagement" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="System.Web" %>

<h1>
  <asp:Label ID="lblMessageTemplateManagement" runat="server" Text="Message Template Management"
        meta:resourcekey="lblMessageTemplateManagementResource1"></asp:Label>
</h1>
<asp:UpdatePanel ID="up" runat="server">
  <ContentTemplate>
    <asp:Panel ID="pnlMessageTemplate" runat="server" meta:resourcekey="pnlMessageTemplateResource1">
      <asp:UpdatePanel ID="upMessageTemplate" runat="server">
        <ContentTemplate>
          <div class="sfFormwrapper sfPadding">
            <h2>
              <asp:Label ID="lblAddEditMessageTemplate" runat="server" Text="Add/Edit Message Template"
                                meta:resourcekey="lblAddEditMessageTemplateResource1"></asp:Label>
            </h2>
            <asp:HiddenField ID="hdnMessageTemplateID" runat="server" Value="0" />
            <table cellspacing="0" cellpadding="0" border="0" width="100%">
              <tr>
                <td width="140"><asp:Label ID="lblMessageTemplateType1" runat="server" CssClass="sfFormlabel"
                                        Text="Message Template Type" meta:resourcekey="lblMessageTemplateType1Resource1"></asp:Label></td>
                <td width="30"> : </td>
                <td><asp:DropDownList ID="ddlMessageTemplateType" ToolTip="Select Message Template Type"
                                        runat="server" OnSelectedIndexChanged="ddlMessageTemplateType_SelectedIndexChanged"
                                        AutoPostBack="True" CssClass="sfListmenu" meta:resourcekey="ddlMessageTemplateTypeResource1"> </asp:DropDownList>
                  <asp:HyperLink ID="hypAddMessageTemplateType" runat="server" Text="Add Message Template Type"
                                        Visible="False" meta:resourcekey="hypAddMessageTemplateTypeResource1" /></td>
                <td></td>
              </tr>
              <tr>
                <td><asp:Label ID="lblFromEmail" runat="server" CssClass="sfFormlabel" Text="From Email"
                                        meta:resourcekey="lblFromEmailResource1"></asp:Label></td>
                <td> : </td>
                <td><asp:TextBox ID="txtMailFrom" runat="server" ToolTip="From Email Address" ValidationGroup="vdgMessageTemplate"
                                        CssClass="sfInputbox" meta:resourcekey="txtMailFromResource1"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMailFrom"
                                        ErrorMessage="*" ValidationGroup="vdgMessageTemplate" CssClass="sfError"
                                        meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMailFrom"
                                        SetFocusOnError="True" ErrorMessage="Invalid Email Address" ValidationGroup="vdgMessageTemplate"
                                        Text="Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        CssClass="sfError" meta:resourcekey="RegularExpressionValidator1Resource1"></asp:RegularExpressionValidator></td>
                <td></td>
              </tr>
              <tr>
                <td><asp:Label ID="lblSubject" runat="server" CssClass="sfFormlabel" Text="Subject"
                                        meta:resourcekey="lblSubjectResource1"></asp:Label></td>
                <td> : </td>
                <td><div style="float: left; width: 280px;">
                    <asp:TextBox ID="txtSubject" runat="server" ToolTip="Message template subject" ValidationGroup="vdgMessageTemplate"
                                            CssClass="sfInputbox" TextMode="MultiLine" meta:resourcekey="txtSubjectResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject"
                                            SetFocusOnError="True" ErrorMessage="*" ValidationGroup="vdgMessageTemplate"
                                            CssClass="sfError" meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                  </div>
                  <div class="cssClassFormLinkButton">
                    <asp:HyperLink ID="lnkAddSubjectMessageToken" runat="server" Text="Add Subject Token"
                                            meta:resourcekey="lnkAddSubjectMessageTokenResource1" />
                    <asp:Label ID="lblAddSubjectMessageToken" runat="server" Text="Add Subject Token"
                                            AssociatedControlID="lnkAddSubjectMessageToken" Style="cursor: pointer;" CssClass="sfFormlabel"
                                            meta:resourcekey="lblAddSubjectMessageTokenResource1"></asp:Label>
                  </div></td>
                <td></td>
              </tr>
              <tr>
                <td><asp:Label ID="lblMessage" runat="server" CssClass="sfFormlabel" Text="Message"
                                        meta:resourcekey="lblMessageResource1"></asp:Label></td>
                <td> : </td>
                <td><div class="cssClassFormLinkButton">
                    <asp:HyperLink ID="lnkAddBodyMessageToken" runat="server" Text="Add Body Message Token"
                                            meta:resourcekey="lnkAddBodyMessageTokenResource1" />
                    <asp:Label ID="lblAddBodyMessageToken" runat="server" Text="Add Body Message Token"
                                            AssociatedControlID="lnkAddBodyMessageToken" Style="cursor: pointer;" CssClass="sfFormlabel"
                                            meta:resourcekey="lblAddBodyMessageTokenResource1"></asp:Label>
                  </div></td>
                <td></td>
              </tr>
              <tr>
                <td></td>
                <td></td>
                <td><div class="sfCkeditor sfCurve">
                    <table cellspacing="0" cellpadding="0" border="0" id="tblTextEditor" runat="server"
                                            width="100%">
                      <tr runat="server">
                        <td class="editorheading" runat="server"><asp:Label ID="lblEditorTitle" runat="server" CssClass="sfFormlabel" Text="Editor:" /></td>
                      </tr>
                      <tr runat="server">
                        <td id="tdTextEditor" runat="server"><asp:Panel ID="pnlBasicTextBox" runat="server">
                            <div id="divEdit" runat="server">
                              <FCKeditorV2:FCKeditor ID="txtBody" runat="server" Height="450px" ToolbarSet="SageFrameLimited"
                                                                Width="100%"> </FCKeditorV2:FCKeditor>
                              <%-- <CKEditor:CKEditorControl  ID="txtBody" runat="server"></CKEditor:CKEditorControl>--%>
                            </div>
                            </asp:Panel></td>
                      </tr>
                    </table>
                  </div>
                  <div class="sfButtonwrapper" style="display:none">
                    <asp:Button ID="btnCustomizeEditor" runat="server" CausesValidation="False" CssClass="sfBtn"
                                            Text="Customize Editor" OnClick="btnCustomizeEditor_Click" meta:resourcekey="btnCustomizeEditorResource1" />
                    <asp:Button ID="btnDefault" runat="server" CausesValidation="False" CssClass="cssClassButtonEditor"
                                            Text="Default Editor" OnClick="btnDefault_Click" Visible="False" meta:resourcekey="btnDefaultResource1" />
                  </div></td>
                <td></td>
              </tr>
              <tr>
                <td><asp:Label ID="lblIsActive" runat="server" CssClass="sfFormlabel" Text="Is Active"
                                        meta:resourcekey="lblIsActiveResource1"></asp:Label></td>
                <td> : </td>
                <td><asp:CheckBox ID="chkIsActive" runat="server" CssClass="sfCheckbox" meta:resourcekey="chkIsActiveResource1" /></td>
                <td></td>
              </tr>
            </table>
          </div>
          <div class="sfButtonwrapper">
            <asp:ImageButton ID="imbSave" runat="server" OnClick="imbSave_Click" ToolTip="Click to save"
                            ValidationGroup="vdgMessageTemplate" meta:resourcekey="imbSaveResource1" />
            <asp:Label ID="lblSave" runat="server" Text="Save" AssociatedControlID="imbSave"
                            Style="cursor: pointer;" meta:resourcekey="lblSaveResource1"></asp:Label>
            <asp:ImageButton ID="imbCancel" runat="server" OnClick="imbCancel_Click" ToolTip="Click to cancel"
                            CausesValidation="False" meta:resourcekey="imbCancelResource1" />
            <asp:Label ID="lblCancel" runat="server" Text="Cancel" AssociatedControlID="imbCancel"
                            Style="cursor: pointer;" meta:resourcekey="lblCancelResource1"></asp:Label>
          </div>
        </ContentTemplate>
      </asp:UpdatePanel>
      </asp:Panel>
    <asp:Panel ID="pnlMessageTemplateList" runat="server" meta:resourcekey="pnlMessageTemplateListResource1">
      <div class="sfButtonwrapper">
        <asp:ImageButton ID="imbAddNew" runat="server" OnClick="imbAddNew_Click" ToolTip="Click to add message template"
                    meta:resourcekey="imbAddNewResource1" />
        <asp:Label ID="lblAddNew" runat="server" Text="Add New Message Template" AssociatedControlID="imbAddNew"
                    Style="cursor: pointer;" meta:resourcekey="lblAddNewResource1"></asp:Label>
      </div>
      <div class="sfGridwrapper">
        <asp:GridView ID="grdList" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record to Show..."
                    GridLines="None" AllowPaging="True" PageSize="15" BorderColor="White" BorderWidth="0px"
                    OnPageIndexChanging="grdList_PageIndexChanging" OnRowCommand="grdList_RowCommand"
                    OnRowDataBound="grdList_RowDataBound" OnRowDeleting="grdList_RowDeleting" OnRowEditing="grdList_RowEditing"
                    OnRowUpdating="grdList_RowUpdating" Width="100%" meta:resourcekey="grdListResource1">
          <Columns>
          <asp:TemplateField HeaderText="Message Template Subject">
            <ItemTemplate>
              <asp:LinkButton runat="server" CommandName="Edit" CommandArgument='<%# Eval("MessageTemplateID") %>'>
                <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
              </asp:LinkButton>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
            <HeaderStyle HorizontalAlign="Left" />
          </asp:TemplateField>
          <asp:TemplateField HeaderText="From Email" meta:resourcekey="TemplateFieldResource2">
            <ItemTemplate>
              <asp:Label ID="lblFromEmail" runat="server" Text='<%# Eval("MailFrom") %>' meta:resourcekey="lblFromEmailResource2"></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
            <HeaderStyle HorizontalAlign="Left" />
          </asp:TemplateField>
          <asp:BoundField DataField="IsActive" HeaderText="Is Active" meta:resourcekey="BoundFieldResource1">
            <HeaderStyle CssClass="cssClassColumnIsActive" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="AddedOn" meta:resourcekey="TemplateFieldResource3">
            <ItemTemplate> <%# Eval("AddedOn","{0:yyyy/MM/dd}") %> </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="100px" />
            <HeaderStyle HorizontalAlign="Left" CssClass="cssClassColumnAddedOn" />
          </asp:TemplateField>
          <asp:TemplateField HeaderText="UpdatedOn" meta:resourcekey="TemplateFieldResource4">
            <ItemTemplate> <%# Eval("UpdatedOn","{0:yyyy/MM/dd}") %> </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
            <HeaderStyle HorizontalAlign="Left" CssClass="cssClassColumnUpdatedOn" />
          </asp:TemplateField>
          <asp:TemplateField meta:resourcekey="TemplateFieldResource5">
            <HeaderStyle CssClass="cssClassColumnEdit" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
            <ItemTemplate>
              <asp:ImageButton ID="imbEdit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("MessageTemplateID") %>'
                                    CommandName="Edit" ImageUrl='<%# GetTemplateImageUrl("imgedit.png", true) %>'
                                    ToolTip="Edit" meta:resourcekey="imbEditResource1" />
            </ItemTemplate>
          </asp:TemplateField>
          </Columns>
          <PagerStyle CssClass="sfPagination" />
          <HeaderStyle CssClass="cssClassHeadingOne" />
          <RowStyle CssClass="sfOdd" />
          <AlternatingRowStyle CssClass="sfEven" />
        </asp:GridView>
      </div>
      </asp:Panel>
    <asp:Panel ID="pnlAddMessageTokenPopup" runat="server" Style="display: none;" meta:resourcekey="pnlAddMessageTokenPopupResource1">
      <div class="sfPopup">
        <div class="sfPopupinner">
          <asp:Panel ID="pnlAddMessageTokenHandle" runat="server"
                    meta:resourcekey="pnlAddMessageTokenHandleResource1">
            <h3> Select message token</h3>
            </asp:Panel>
          <div class="sfPopupclose" id="btnAddMessageTokenCancel" runat="server"> </div>
          <asp:Panel ID="pnlPopupBody" runat="server" meta:resourcekey="pnlPopupBodyResource1">
            <asp:ListBox ID="lstMessageToken" runat="server" Rows="10" CssClass="sfTextarea"
                            meta:resourcekey="lstMessageTokenResource1"></asp:ListBox>
            </asp:Panel>
          <div class="sfButtonwrapper">
            <input type="button" id="btnAddMessageTokenOk" runat="server" value="Add" class="sfBtn" />
          </div>
        </div>
      </div>
      </asp:Panel>
    <asp:HiddenField runat="server" ID="hiddenTargetControlForAddMessageTokenModalPopup" />
    <act:ModalPopupExtender runat="server" ID="mpeAddMessageTokenModalPopup" TargetControlID="hiddenTargetControlForAddMessageTokenModalPopup"
            PopupControlID="pnlAddMessageTokenPopup" BackgroundCssClass="modalBackground"
            OkControlID="btnAddMessageTokenOk" CancelControlID="btnAddMessageTokenCancel"
            PopupDragHandleControlID="pnlAddMessageTokenHandle" RepositionMode="RepositionOnWindowScroll"
            DynamicServicePath="" Enabled="True"> </act:ModalPopupExtender>
    <asp:UpdatePanel ID="upMessageTemplateType" runat="server">
      <ContentTemplate>
        <asp:Panel ID="pnlMessageTemplateType" runat="server" Style="background: #ccc;" meta:resourcekey="pnlMessageTemplateTypeResource1">
          <asp:Panel ID="pnlDragHandlerMessageTemplateType" runat="server" meta:resourcekey="pnlDragHandlerMessageTemplateTypeResource1">
            <asp:Label ID="lblAMTT" runat="server" Text="Add Message Template Type" meta:resourcekey="lblAMTTResource1"></asp:Label>
            </asp:Panel>
          <div class="sfFormwrapper">
            <table cellspacing="0" cellpadding="0" border="0" width="100%">
              <tr>
                <td><asp:Label ID="lblMessageTemplateType" runat="server" CssClass="sfFormlabel"
                                        Text="Message Template Type" meta:resourcekey="lblMessageTemplateTypeResource1"></asp:Label></td>
                <td> : </td>
                <td><asp:TextBox ID="txtMessageTemplateType" runat="server" meta:resourcekey="txtMessageTemplateTypeResource1"></asp:TextBox></td>
              </tr>
            </table>
            <div class="sfButtonwrapper">
              <asp:Button ID="btnOkMessageTemplateType" runat="server" Text="Add" OnClick="btnOkMessageTemplateType_Click"
                                meta:resourcekey="btnOkMessageTemplateTypeResource1" />
              <input type="button" id="okmessagetemplatetype" value="ok" runat="server" style="display: none;" />
              <input type="button" id="btnCancelMessageTemplateType" value="Cancel" />
            </div>
          </div>
          </asp:Panel>
      </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField runat="server" ID="hdnAddMessageTemplateType" />
    <act:ModalPopupExtender runat="server" ID="mpeMessageTemplateType" TargetControlID="hdnAddMessageTemplateType"
            PopupControlID="pnlMessageTemplateType" BackgroundCssClass="modalBackground"
            OkControlID="okmessagetemplatetype" CancelControlID="btnCancelMessageTemplateType"
            PopupDragHandleControlID="pnlDragHandlerMessageTemplateType" RepositionMode="RepositionOnWindowScroll"
            DynamicServicePath="" Enabled="True"> </act:ModalPopupExtender>
  </ContentTemplate>
</asp:UpdatePanel>
