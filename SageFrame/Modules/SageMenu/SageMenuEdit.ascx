<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SageMenuEdit.ascx.cs"
    Inherits="Modules_SageMenu_SageMenuEdit" %>
<script type="text/javascript">
    $(function() {
        var SageMenuEdit = {
            config: {
                isPostBack: false,
                async: true,
                cache: false,
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                data: '{}',
                dataType: 'json',
                baseURL: '<%=appPath%>' + '/Modules/Admin/MenuManager/MenuWebService.asmx/',
                method: "",
                url: "",
                categoryList: "",
                ajaxCallMode: 0,
                UserModuleID: '<%=UserModuleID%>', ///0 for get categories and bind, 1 for notification,2 for versions bind   
                PortalID: '<%=PortalID%>'
            },
            vars: {},
            init: function() {
                this.LoadMenu();
                $('#btnSaveMenu').bind("click", function() {
                    SageMenuEdit.UpdateSelectedMenu();
                    SageFrame.messaging.show("Menu Setting updated successfully", "Success");
                });
                $('#menuList ul li input:checkbox').live("change", function() {
                    if ($(this).attr("checked")) {
                        $('#menuList ul li input:checkbox').not($(this)).attr("checked", false);
                    }
                    else {
                        $(this).attr("checked", true);
                    }
                });

            },
            LoadMenu: function() {
                this.config.method = "GetSageMenu";
                this.config.data = JSON2.stringify({ UserName: 'superuser', UserModuleID: SageMenuEdit.config.UserModuleID, PortalID: SageMenuEdit.config.PortalID });
                this.config.url = SageMenuEdit.config.baseURL + this.config.method;
                this.config.ajaxCallMode = 0;
                this.ajaxCall(this.config);
            },
            BindMenuList: function(data) {
                var LstMenu = data.d;
                var html = '';
                var menulist = '<ul>';
                $.each(LstMenu, function(index, item) {
                    if (item != "") {
                        var selectionstatus = item.SelectedMenu == item.MenuID ? 'checked="checked"' : "";
                        var editid = 'edit_' + item.MenuID;
                        var delid = 'del_' + item.MenuID;
                        menulist += '<li id=' + item.MenuID + '><input type="checkbox" ' + selectionstatus + ' class="sfCheckbox"/><label>' + item.MenuName;
                        menulist += '</label></li>';
                        //$('#chkIsDefault').attr("checked", item.IsDefault);
                    }
                });
                if (LstMenu.length == 0) {
                    menulist += '<li><p  class="sfNote">No Menus Created</p></li>';
                    $('#btnSaveMenu').hide();

                }
                else {
                    $('#btnSaveMenu').show();
                }
                menulist += '</ul>';

                $('#menuList').html(menulist);

            },
            UpdateSelectedMenu: function() {
                var sel_menu = $('#menuList li input:checked');
                SageMenuEdit.config.method = "SaveSageMenu";
                SageMenuEdit.config.data = JSON2.stringify({ UserModuleID: SageMenuEdit.config.UserModuleID, PortalID: SageMenuEdit.config.PortalID, SettingKey: 'MenuID', SettingValue: $(sel_menu).parent("li").attr("id") });
                SageMenuEdit.config.url = SageMenuEdit.config.baseURL + SageMenuEdit.config.method;
                SageMenuEdit.config.ajaxCallMode = 1;
                this.ajaxCall(this.config);
            },
            ajaxSuccess: function(data) {
                switch (SageMenuEdit.config.ajaxCallMode) {
                    case 0:
                        SageMenuEdit.BindMenuList(data);
                        break;
                    case 1:
                        SageMenuEdit.LoadMenu();
                }
            },
            ajaxFailure: function() {
            },
            ajaxCall: function(config) {
                $.ajax({
                    type: SageMenuEdit.config.type,
                    contentType: SageMenuEdit.config.contentType,
                    cache: SageMenuEdit.config.cache,
                    async: SageMenuEdit.config.async,
                    url: SageMenuEdit.config.url,
                    data: SageMenuEdit.config.data,
                    dataType: SageMenuEdit.config.dataType,
                    success: SageMenuEdit.ajaxSuccess,
                    error: SageMenuEdit.ajaxFailure
                });

            }

        };
        SageMenuEdit.init();
    });
</script>

<div class="sfFormwrapper sfPadding">
  <div id="menuList"> </div>
  <div class="sfButtonwrapper sftype1">
    <label id="btnSaveMenu" class="sfSave"> Save</label>
  </div>
</div>
