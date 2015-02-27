<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuManager.ascx.cs" Inherits="Modules_Admin_MenuManager_MenuManager" %>
<script type="text/javascript">
    $(function() {
        $(this).MenuManager();
    });
</script>

<h1> Menu Manager</h1>
<div class="sfFormwrapper sfPadding">
  <div id="tabMenu">
    <div id="dvView" class="clearfix">
      <div class="sfLeftdiv">
        <fieldset>
          <legend>Menu </legend>
          <div class="sfQuicklink">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td colspan="2"><label id="lblAddMenu" class="sfFormlabel"> Add Menu</label></td>
              </tr>
              <tr>
                <td><input id="txtMenuName" class="sfInputbox sfFullwidth" type="text" /></td>
                <td><div class="sfButtonwrapper sftype1" id="divAdd">
                    <label id="imgAdd" class="sfAdd" style="display: none"> Create</label>
                    <label id="imgUpdate" class="sfUpdate"> Update</label>
                    <label id="imgCancel" class="sfCancel"> Cancel</label>
                  </div></td>
              </tr>
            </table>
            <table cellpadding="0" cellspacing="0" width="100%">
              <tr>
                <td colspan="3"><div id="menuList"> </div></td>
              </tr>
              <tr>
                <td colspan="3"><h3 id="h3MenuType"> <span id="lblMenuItm">Choose Menu Item Type</span> </h3></td>
              </tr>
              <tr>
                <td colspan="3"><div class="sfRadiobutton">
                    <asp:Literal ID="ltrMenuRadioButtons" runat="server"></asp:Literal>
                  </div></td>
              </tr>
              <tr id="trSubtext">
                <td colspan="3"><div class="divSubText" style="display: none">
                    <table cellpadding="0" cellspacing="0">
                      <tr>
                        <td width="75"><label class="sfFormlabel"> SubText:</label></td>
                        <td><input type="text" id="txtSubText" class="sfInputbox" /></td>
                      </tr>
                      <tr>
                        <td></td>
                        <td><div class="sfCheckbox">
                            <label> IsActive:</label>
                            <input type="checkbox" id="chkIsActivePage" />
                            <label> IsVisible:</label>
                            <input type="checkbox" id="chkIsVisiblePage" />
                          </div></td>
                      </tr>
                    </table>
                  </div></td>
              </tr>
              <tr id="pageMenuitem">
                <td colspan="3"><div class="divExternalLink" style="display: none">
                    <table width="100%" cellpadding="0" cellspacing="0">
                      <tr>
                        <td><label class="sfFormlabel"> Link Title:</label>
                          <input type="text" class="sfInputbox sfAuto" id="txtLinkTitle" name="txtLinkTitle" /></td>
                        <td><label class="sfFormlabel"> Link Url:</label>
                          <input type="text" id="txtExternalLink" class="sfInputbox sfAuto" name="txtExternalLink" /></td>
                      </tr>
                      <tr>
                        <td><label class="sfFormlabel"> Caption :</label>
                          <input type="text" id="txtCaptionExtLink" class="sfInputbox sfAuto" /></td>
                        <td><label class="sfFormlabel"> Icon</label>
                          <input type="file" id="fupIconExtLink" />
                          <div class="sfUploadedFilesExtLink"> </div></td>
                      </tr>
                      <tr>
                        <td colspan="2"><div class="sfCheckbox">
                            <input type="checkbox" id="chkLinkActive" />
                            <label class="sfFormlabel"> IsActive:</label>
                            <input type="checkbox" id="chkLinkVisible" />
                            <label class="sfFormlabel"> IsVisible:</label>
                          </div></td>
                      </tr>
                    </table>
                  </div>
                  <div class="divHtmlContent" style="display: none">
                    <table width="100%" cellpadding="0" cellspacing="0">
                      <tr>
                        <td><label class="sfFormlabel"> Link Title:</label>
                          <input type="text" class="sfInputbox sfAuto" id="txtTitleHtmlContent" name="txtTitleHtmlContent" /></td>
                        <td><label class="sfFormlabel"> Caption :</label>
                          <input type="text" id="txtCaptionHtmlContent" class="sfInputbox sfAuto" name="txtCaptionHtmlContent" /></td>
                      </tr>
                      <tr>
                        <td><label class="sfFormlabel"> Icon</label>
                          <input type="file" id="fupIconHtmlContent" />
                          <div class="sfUploadedFilesHtmlContent"> </div></td>
                        <td colspan="2"><label class="sfFormlabel"> IsVisible:</label>
                          <input type="checkbox" id="chkVisibleHtmlContent" /></td>
                      </tr>
                      <tr>
                        <td colspan="2"><textarea cols="50" rows="5" id="txtHtmlContent" class="sfTextarea"> </textarea></td>
                      </tr>
                    </table>
                  </div></td>
              </tr>
              <tr id="trPages">
                <td colspan="3"><h3 id="lblChoosePage"> <span>Choose Pages</span> </h3>
                  <div class="sfCheckbox sfMargintop clearfix">
                    <input type="checkbox" class="sfCheckbox" id="chkPageOrder" />
                    <label> Preserve Page Order</label>
                  </div>
                  <div id="divPagelist" class="sfPageList"> </div></td>
              </tr>
              <tr>
                <td width="80"><label class="sfFormlabel"> Parent Item:</label></td>
                <td colspan="2"><select id="selMenuItem" class="sfListmenu">
                  </select></td>
              <tr>
                <td></td>
                <td colspan="2"><div class="sfButtonwrapper sftype1">
                    <label id="imgAddmenuItem" class="sfAdd"> Add Menu Item</label>
                    <label id="imgAddMenuCancel" class="sfCancel"> Cancel</label>
                  </div></td>
              </tr>
                </tr>
              
            </table>
          </div>
          <div class="clear"> </div>
        </fieldset>
      </div>
      <div class="sfRightdiv">
        <div class="">
          <fieldset>
            <legend>Manage: </legend>
            <div class="sfRadiobutton">
              <input id="rdbView" type="radio" name="rdbsetting" checked="checked" value="1" />
              <label> View</label>
              <input id="rdbSetting" type="radio" name="rdbsetting" value="2" />
              <label> Setting</label>
              <%--   <input id="rdbPermission" type="radio" name="rdbsetting" value="2" />
                            <label>
                                Permission</label>--%>
            </div>
            <fieldset id="MenuMgrView">
              <legend>Menu Items: </legend>
              <div id="divLstMenu"> </div>
            </fieldset>
            <fieldset id="MenuMgrSetting" style="display:none">
              <legend><span>Choose Menu Type:</span> </legend>
              <div class="sfRadiobutton">
                <input id="rdbHorizontalMenu" type="radio" name="rdbChooseMenuType" checked="checked"
                                    value="1" />
                <label> Horizontal</label>
                <input id="rdbSideMenu" type="radio" name="rdbChooseMenuType" value="2" />
                <label> Side Menu</label>
                <input id="rdbFooter" type="radio" name="rdbChooseMenuType" value="3" />
                <label> Footer Menu</label>
              </div>
              <div id="tblTopClientMenu" class="sfRadiobutton sfMargintop">
                <input id="rdbFlyOutMenu" type="radio" name="rdbMenuTypeStyle" value="1" style="display:none" />
                <label style="display:none"> Flyout Menu</label>
                <input id="rdbDropdown" type="radio" name="rdbMenuTypeStyle" value="3" />
                <label> Dropdown</label>
                <input id="rdbCssMenu" type="radio" name="rdbMenuTypeStyle" value="4" />
                <label> Css Menu</label>
              </div>
              <div id="tblSideMenu" style="display:none" class="sfRadiobutton sfMargintop">
                <input id="rdbDynamic" type="radio" name="rdbSideMenuTypeStyle" value="1"/>
                <label> Page Wise Dynamic</label>
                <input id="rdbCustom" type="radio" checked="checked" name="rdbSideMenuTypeStyle" value="2" />
                <label> Custom</label>
              </div>
              <div id="tblShowImage" class="sfCheckbox sfMargintop">
                <input id="chkShowImage" value="Show Image" type="checkbox" />
                <label id="lblShowImage"> Show Image</label>
                <input id="chkShowText" value="Show Text" type="checkbox" />
                <label id="lblShowText"> Show Text</label>
              </div>
              <div class="sfCheckboxholder sfMargintop">
                <input id="chkCaption" value="Caption" type="checkbox" />
                <label id="lblCaption"> Caption</label>
                <br />
                <br />
                <div id="divCaption" visible="false">
                  <label id="lblLevel"> Level</label>
                  <select id="selLevel" class="sfListmenu sfAuto">
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                  </select>
                </div>
              </div>
              <div class="sfButtonwrapper sftype1">
                <label id="btnSave" class="sfSave"> Save Settings</label>
              </div>
            </fieldset>
            <fieldset id="MenuMgrPermissiom" class="sfMenupermission" style="display:none">
              <legend>
              <asp:Label ID="lblpermissions" runat="server" Text="Menu Permission Settings"></asp:Label>
              </legend>
              <div class="sfButtonwrapper sftype1">
                <label class="sfAdd" id="imbAddUsers"> Add User</label>
              </div>
              <div class="divPermissions sfGridwrapper">
                <table cellspacing="0" cellpadding="0" width="100%">
                </table>
              </div>
              <div class="clear"> </div>
              <div id="dvUser" class="sfGridwrapper">
                <table id="tblUser" cellspacing="0" cellpadding="0" width="100%">
                </table>
              </div>
              <div class="sfButtonwrapper sftype1">
                <label class="sfSave" id="imgSavePermission"> Save</label>
              </div>
            </fieldset>
          </fieldset>
        </div>
        <div class="clear"> </div>
      </div>
    </div>
    <div id="divAddUsers" title="Search Users" class="sfFormwrapper" style="display:none">
      <p class="sfNote"> All form fields are required.</p>
      <table cellpadding="0" cellspacing="0" width="0">
        <tr>
          <td><input type="text" name="name" id="txtSearchUsers" class="sfInputbox" /></td>
          <td class="sftype1"><label id="btnSearchUsers" class="sfSearch"> Search</label></td>
        </tr>
      </table>
      <div id="divSearchedUsers"> </div>
      <div class="sfButtonwrapper sftype1">
        <label id="btnAddUser" class="sfAdd"> Add</label>
        <label id="btnCancelUser" class="sfCancel"> Cancel</label>
      </div>
    </div>
  </div>
  <div id="myMenu1" class="sfContextmenu sfCurve Shadow">
    <ul>
      <li id="remove"> <img runat="server" id="imgRemove" alt="Remove" title="Remove" /> <b>Delete Menu Item</b></li>
    </ul>
  </div>
</div>
