<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TemplateFilemanager.ascx.cs"
    Inherits="Modules_TemplateFileManager_TemplateFilemanager" %>
<script type="text/javascript">

    $(function() {

        var rdbChoice = '#<%=rdbChoice.ClientID%>';
        var lblCreateFile = '#<%=lblCreateFile.ClientID%>';
        var ddlExt = '#<%=ddlExt.ClientID%>';
        var lblCreateFile = '#<%=lblCreateFile.ClientID%>';
        $(ddlExt).hide();
        $(rdbChoice).live("click", function() {
            if ($(rdbChoice).find('input:checked').attr('value') == 0) {
                $(ddlExt).hide();
                $(lblCreateFile).text('Enter Folder Name');
            }
            else if ($(rdbChoice).find('input:checked').attr('value') == '1') {
                $(ddlExt).show();
                $(rdbChoice).find("Text").val('Enter File Name');
                $(lblCreateFile).text('Enter File Name');
            }
        });
        var id = '<%=txtEditor.ClientID%>';
       
       if(typeof $('#'+id).val()!='undefined')
       {  
            var editor = CodeMirror.fromTextArea(document.getElementById(id), {
                mode: "application/xml",
                lineNumbers: true,
                onCursorActivity: function() {
                    editor.setLineClass(hlLine, null);
                    hlLine = editor.setLineClass(editor.getCursor().line, "activeline");
                }
            });
          
            var hlLine = editor.setLineClass(0, "activeline");
        }
    });
  
</script>

<h1> Template File Manager</h1>
<div class="sfFormwrapper sfPadding sfMarginbtn">
  <div id="divSelectTemplate" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="12%"><asp:Label ID="lblSelectTemplate" runat="server" Text="Select Template" CssClass="sfFormlabel"></asp:Label></td>
        <td><asp:DropDownList ID="ddlTemplateList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTemplateList_SelectedIndexChanged"
                        CssClass="sfListmenu"> </asp:DropDownList></td>
      </tr>
    </table>
  </div>
</div>
<div class="sfTFMbreadcrumb" id="divBreadCrum" runat="server">
  <asp:Button ID="btnImgBack" CssClass="sfBack" runat="server" OnClick="btnImgBack_Click" />
  <asp:Repeater ID="rptBreadCrum" runat="server" OnItemCommand="rptBreadCrum_ItemCommand">
    <ItemTemplate>
      <asp:LinkButton ID="LinkFilePath" CommandName="FileName" CommandArgument='<%#Container.DataItem %>'
                runat="server"><%#Container.DataItem%></asp:LinkButton>
    </ItemTemplate>
  </asp:Repeater>
</div>
<div class="sfFormwrapper sfPadding sfMarginbtn sfTFM" id="divLstFile" runat="server">
  <div class="sfGridwrapper sfTFMgrid" runat="server">
    <asp:GridView GridLines="None" AllowPaging="True" ShowHeader="false" PageSize="20"
            EmptyDataText="..........Record is not Found.........." ID="gdvTemplateFileManager"
            runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="gdvTemplateFileManager_RowCommand"
            OnSelectedIndexChanged="gdvTemplateFileManager_SelectedIndexChanged" OnSelectedIndexChanging="gdvTemplateFileManager_SelectedIndexChanging"
            OnPageIndexChanging="gdvTemplateFileManager_PageIndexChanging" OnRowDeleting="gdvTemplateFileManager_RowDeleting"
            OnRowEditing="gdvTemplateFileManager_RowEditing" OnRowDataBound="gdvTemplateFileManager_RowDataBound">
      <Columns>
      <asp:TemplateField HeaderText="File Name">
        <ItemTemplate>
          <asp:LinkButton ID="hlnkFilename" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"FileName") %>'
                            CommandName="Explore" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"FileName") %>'></asp:LinkButton>
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
        <HeaderStyle HorizontalAlign="Left" />
      </asp:TemplateField>
      <asp:TemplateField>
        <ItemTemplate> <%#Eval("Size")%> bytes </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="Delete">
        <ItemTemplate>
          <asp:ImageButton ID="imbDeleteFile" ImageUrl='<%# GetTemplateImageUrl("imgdelete.png", true) %>'
                            runat="server" CommandName="Delete" AlternateText="Delete" CssClass="sfDelete"
                            CommandArgument='<%# Eval("FileName") %>' OnClientClick="return ConfirmDialog(this, 'Confirmation', 'Are you sure you want to delete this file/folder?');" />
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
        <HeaderStyle HorizontalAlign="Left" />
      </asp:TemplateField>
      </Columns>
      <PagerStyle CssClass="sfPagination" />
      <RowStyle CssClass="sfOdd" />
      <AlternatingRowStyle CssClass="sfEven" />
    </asp:GridView>
  </div>
</div>
<div class="sfFormwrapper sfPadding">
  <div class="sfAddFile">
    <asp:Image ID="imgEditor" runat="server" Visible="false" />
    <asp:TextBox ID="txtEditor" TextMode="MultiLine" runat="server" Visible="false"></asp:TextBox>
    <div class="sfButtonwrapper">
      <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" Visible="false"
                CssClass="sfBtn" />
      <asp:Button ID="btnCancel" Text="Cancel" runat="server" Visible="false" CssClass="sfBtn"
                OnClick="btnCancel_Click" />
    </div>
    <h3>
      <asp:Label ID="lblCreate" runat="server" Text="Create:"></asp:Label>
    </h3>
    <table runat="server" id="tblCreateFileFolder" cellpadding="0" cellspacing="0">
      <tr>
        <td colspan="3"><asp:RadioButtonList ID="rdbChoice" runat="server" RepeatDirection="Horizontal" CssClass="sfRadiobutton">
            <asp:ListItem Value="0" Text="Folder" Selected="True"></asp:ListItem>
            <asp:ListItem Value="1" Text="File"></asp:ListItem>
          </asp:RadioButtonList></td>
      </tr>
      <tr>
        <td><asp:Label ID="lblCreateFile" runat="server" Text="Enter Folder Name" CssClass="sfFormlabel"></asp:Label></td>
        <td><asp:TextBox ID="txtCreate" runat="server" CssClass="sfInputbox"></asp:TextBox>
          <asp:RequiredFieldValidator ID="rfvFileFolderName" runat="server" ErrorMessage="*"
                        ToolTip="Field is required" ValidationGroup="rfvF" ControlToValidate="txtCreate"></asp:RequiredFieldValidator>
          <asp:DropDownList ID="ddlExt" runat="server" CssClass="sfListmenu">
            <asp:ListItem Text="css"></asp:ListItem>
            <asp:ListItem Text="html"></asp:ListItem>
          </asp:DropDownList></td>
        <td><asp:Button ID="btnCreate" Text="Create" CssClass="sfBtn" runat="server" OnClick="btnCreate_Click"
                            ValidationGroup="rfvF" /></td>
      </tr>
      <tr id="divFileUploader" runat="server">
        <td><asp:Label ID="lblUploader" runat="server" Text="Upload File" CssClass="sfFormlabel"></asp:Label></td>
        <td><asp:FileUpload ID="fupFile" runat="server" />
          <asp:RequiredFieldValidator ID="rfvFileUpload" runat="server" ErrorMessage="*" ControlToValidate="fupFile"
                        ToolTip="Field is required" ValidationGroup="rfvU"></asp:RequiredFieldValidator></td>
        <td><asp:Button ID="btnUpload" CssClass="sfBtn" runat="server" Text="Upload" OnClick="btnUpload_Click"
                            ValidationGroup="rfvU" />
          <asp:Label ID="lblError" runat="server" ForeColor="Red" CssClass="sfFormlabel"></asp:Label></td>
      </tr>
    </table>
  </div>
</div>
