(function($) {
    $.createPageBuilder = function(p) {
        p = $.extend
        ({
            PortalID: 1,
            UserModuleID: 1,
            UserName: 'user',
            PageName: 'Home',
            ContainerClientID: 'divNav1',
            CultureCode: 'en-US',
            baseURL: Path + 'Services/PagesWebService.asmx/',
            AppName: "/sageframe"
        }, p);


        var SagePages = {
            config: {
                isPostBack: false,
                async: false,
                cache: false,
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                data: { data: '' },
                dataType: 'json',
                baseURL: Path + 'Services/PagesWebService.asmx/',
                method: "",
                url: "",
                categoryList: "",
                ajaxCallMode: 0,
                lstPagePermission: [],
                Mode: false,
                PageID: 0,
                PortalID: p.PortalID,
                arrUsers: []

            },
            messages:
                {
                    nomenu: "No Menu"
                },
            init: function(config) {
                this.InitializeCotrols();
                this.InitToolTips();
                this.LoadRoles();
                this.BindEvents();
                this.IconUploader();
                SagePages.GetMenuList();

            },
            InitializeCotrols: function() {
                $('#dvTab').tabs({ fx: [null, { height: 'show', opacity: 'show'}] });
                $('#txtStartDate').datepicker();
                $('#txtEndDate').datepicker({ rangeSelect: true, numberOfMonths: 2 });
                //$('#tblUser').hide();
            },
            ajaxSuccess: function(data) {
                switch (parseInt(SagePages.config.ajaxCallMode)) {
                    case 0:
                        SagePages.BindPortalRoles(data);
                        break;
                    case 1:
                        SagePages.BindUsers(data);
                        break;
                    case 2:
                        SagePages.BindPageDetails(data);
                        break;
                    case 3:
                        SageFrame.messaging.show(SageFrame.messaging.GetLocalizedMessage("en-US", "PageManager", "PageSavedSuccessful"), "Success");
                        SagePages.RefreshPage(data);
                        break;
                    case 4:
                        SagePages.BindChildPages(data);
                        break;
                    case 5:
                        SagePages.BindPageModules(data);
                        break;
                    case 6:
                        break;
                }
            },
            ajaxFailure: function() {
                SageFrame.messaging.show("Some kind of error occured", "Error");
            },
            ajaxCall: function(config) {
                $.ajax({
                    type: SagePages.config.type,
                    contentType: SagePages.config.contentType,
                    cache: SagePages.config.cache,
                    url: SagePages.config.url,
                    data: SagePages.config.data,
                    dataType: SagePages.config.dataType,
                    success: SagePages.ajaxSuccess,
                    error: SagePages.ajaxFailure,
                    async: false
                });
            },
            InitToolTips: function() {
                //SageFrame.tooltip.GetTextBoxToolTipImage("txtPageName", "The name of the page");
                //SageFrame.tooltip.GetTextBoxToolTipImage("txtRefreshInterval", "The time interval after which page refreshes.</br> Store in the meta tags");
            },
            BindEvents: function() {




                var v = $("#form1").validate({
                    ignore: ':hidden',
                    rules: {
                        txtPageName: { required: true },
                        txtTitle: { required: true }

                    },
                    messages: {
                        txtPageName: "<br/>Please enter a Page Name",
                        txtTitle: "<br/>Please enter a Title"
                    }
                });

                $('#btnCancelUser').bind("click", function() {
                    $('#divAddUsers').dialog("close");
                });
                var attrTitleValue;
                $('#txtPageName').hover(function() {
                    attrTitleValue = $(this).attr("title");
                    $(this).attr("title", "");
                }, function() {
                    $(this).attr("title", attrTitleValue);
                });

                $('#txtRefreshInterval').keyup(function() {
                    $("#lblIntegerError").text('');
                    if (isNaN($('#txtRefreshInterval').val())) {
                        $('#txtRefreshInterval').after('<label class="Error"  id="lblIntegerError"><br/>Please Enter Integer Value.</label>');
                        return false;
                    }
                    else {
                        $("#lblIntegerError").hide();
                    }
                });
                $('#btnAddUser').bind("click", function() {
                    var users = $('#divAddUsers ul li.sfActive');
                    var html = '';
                    $.each(users, function(index, item) {
                        var userid = $(this).attr("id");
                        var username = $(this).html();
                        var rowStyle = index % 2 == 0 ? 'class="sfEven"' : 'class="sfOdd"';
                        if (!SagePages.UserAlreadyExists(username)) {
                            html += '<tr ' + rowStyle + ' id=' + userid + '><td width="40%"><label>' + username + '</label></td><td width="20%"><input type="checkbox" class="sfCheckbox" title="view"/></td>';
                            html += '<td width="20%"><input type="checkbox" class="sfCheckbox" title="edit"/></td><td width="10%"><a href="#" class="delete"><img class="delete" id="imgDelete" src=' + SageFrame.utils.GetAdminImage("delete.png") + '></a></td></tr>';
                        }
                    });
                    $('#tblUser').show();
                    $('#dvUser table').append(html);
                    $('#divAddUsers').dialog("close");
                });

                $('#trIncludeInMenu').hide();
                var appPath = SageFrame.utils.getapplicationname();
                var href = SageFramePortalID > 1 ? appPath + "/portal/" + SageFramePortalName + "/Admin/Page-Modules.aspx" : appPath + "/Admin/Page-Modules.aspx";
                $('#btnManageModules').attr("href", href);
                $('#rdrtManagemodule').attr("href", href);
                $('#imbAddUsers').bind("click", function() {
                    $("#divAddUsers").dialog("open");
                });
                $('#btnSearchUsers').bind("click", function() {
                    SagePages.SearchUsers();
                });

                $('#divSearchedUsers li').live("click", function() {
                    if (!$(this).hasClass("sfActive")) {
                        $(this).addClass("sfActive");
                    }
                    else {
                        $(this).removeClass("sfActive");
                    }
                });

                $('span.deleteIcon').live('click', function() {
                    var iconPath = $('.cssClassUploadFiles img').attr('title');
                    $(this).parent('div').html('');
                    $('span.filename').text('No file selected');
                    SagePages.DeleteIcon(iconPath);
                });
                $('#txtPageName').bind("change", function() {
                    if ($('#txtPageName').val() != "") {
                        if (!SageFrame.utils.ContainsInvalidChar($('#txtPageName').val())) {
                            $('#txtPageName').next("label").remove();
                            $('#txtPageName').after("<label id='lblInvalid' class='sfError sfInvalid'><br/>Contains Invalid Characters</label>");
                        }
                        else {
                            $('label.sfInvalid').remove();
                        }
                    }
                });
                $('#txtPageName').bind("keypress", function() {
                    $('#spnPagename').remove();
                    $('#lblInvalid').remove();

                });
                $('#txtTitle').bind("keypress", function() {
                    $('#spnTitle').remove();
                });
                $('#txtDescription').bind("keypress", function() {
                    $('#spnDescription').remove();
                });
                $('#txtCaption').bind("keypress", function() {
                    $('#spnCaption').remove();
                });

                $('#btnSubmit').bind("click", function() {
                    $('#txtPageName').removeAttr("readonly").removeClass("sfDisable");
                    if (isNaN($('#txtRefreshInterval').val())) {
                        $("#lblIntegerError").text('');
                        $('#txtRefreshInterval').after('<label class="Error"  id="lblIntegerError"><br/>Please Enter Integer Value.</label>');
                        return false;
                    }
                    else if (Date.parse($('#txtStartDate').val()) > Date.parse($('#txtEndDate').val())) {
                        $("#lblError").html("<br/>End date should be after start date");
                        return false;
                    }
                    else {
                        $("#lblError").text("");
                    }

                    if (v.form()) {
                        var pageName = $('#txtPageName').val();
                        var status = false;
                        var pages = $('#categoryTree span.ui-tree-title').not('#categoryTree span.ui-tree-selected');
                        $.each(pages, function() {
                            if ($(this).text().toLowerCase() == pageName.toLowerCase()) {
                                status = true;
                            }
                        });
                        if (!status) {

                            if ($('#txtPageName').val().length > 50 || $('#txtTitle').val().length > 60 || $('#txtDescription').val().length > 150 || $('#txtCaption').val().length > 25) {

                                var messagehtml = '';
                                if ($('#txtPageName').val().length > 50) {
                                    messagehtml = '';
                                    messagehtml = "<span id='spnPagename' class='sfError'><br>Page Name cannot be more than 50 chars long</span>";
                                    $('#txtPageName').after(messagehtml);
                                    $('#txtPageName').val('');
                                    $('#txtPageName').focus();
                                }
                                else {
                                    $('spnPagename').remove();
                                }
                                if ($('#txtTitle').val().length > 60) {
                                    messagehtml = '';
                                    messagehtml = "<span id='spnTitle'class='sfError'><br>Page Title cannot be more than 60 chars long</span>";
                                    $('#txtTitle').after(messagehtml);
                                    $('#txtTitle').val('');
                                    $('#txtTitle').focus();
                                }
                                else {
                                    $('spnTitle').remove();
                                }
                                if ($('#txtCaption').val().length > 25) {
                                    messagehtml = '';
                                    messagehtml = "<span id='spnCaption'class='sfError'><br>Caption  cannot be more than 25 chars long</span>";
                                    $('#txtCaption').after(messagehtml);
                                    $('#txtCaption').val('');
                                    $('#txtCaption').focus();
                                }
                                else {
                                    $('spnCaption').remove();
                                }

                                if ($('#txtDescription').val().length > 150) {
                                    messagehtml = '';
                                    messagehtml = "<span id='spnDescription' class='sfError'><br>Page Description cannot be more than 150 chars long</span>";
                                    $('#txtDescription').after(messagehtml);
                                    $('#txtDescription').val('');
                                    $('#txtDescription').focus();
                                }
                                else {
                                    $('spnDescription').remove();
                                }
                                return false;
                            }
                            if (!SageFrame.utils.ContainsInvalidChar($('#txtPageName').val())) {
                                $('#txtPageName').next("label").remove();
                                $('#txtPageName').after("<label class='sfError'><br/>Contains Invalid Characters</label>");
                                // return;
                            }
                            else {
                                SagePages.AddUpdatePage();
                                $("#flIcon").next('.filename').html('No file selected.');
                                $('#txtPageName').next("label").remove();
                                $('#txtTitle').next("label").remove();
                            }
                        }
                        else
                            SageFrame.messaging.show("The page name should be unique. A page with a same name already exists", "Alert");
                    }
                    else {
                        return;
                    }
                });

                $('input[value="Cancel"]').click(function() {
                    SagePages.ClearControls();
                });

                $("#tblUser img.delete").live("click", function() {
                    $(this).parent().parent('tr').remove();
                });
                $('span.ui-tree-title').live("click", function() {
                    $('label.sfError').remove();
                    $('span.filename').text('No files selected');
                    $('#categoryTree li').removeClass("sfActive").removeClass("sfActivechild");
                    if ($(this).parent("li").hasClass("file-folder")) {
                        $(this).parent("li").addClass("sfActivechild");
                    }
                    else {
                        $(this).parent("li").addClass("sfActive");
                    }

                    $('#tblUser tr:gt(0)').remove();
                    $("input[type='checkbox']").each(function() {
                        if (this.checked == true)
                            this.checked = false;
                    });
                    SagePages.BindParentPages();
                    SagePages.config.arrUsers = [];
                    if ($(this).text().toLowerCase() == "home" || $(this).parent("li").hasClass("required")) {
                        $('#txtPageName').attr("readonly", "true").addClass("sfDisable");
                    }
                    else {
                        $('#txtPageName').removeAttr("readonly").removeClass("sfDisable");
                    }
                    SagePages.GetPageDetails($(this).parent('li').attr('id'));
                    $('#txtPageName').attr('title', $(this).parent('li').attr('id'));
                    if ($('#tblUser tr:gt(0)').length > 0)
                        $('#tblUser').show();
                    else
                    // $('#tblUser').hide();
                        SagePages.config.PageID = $(this).parent('li').attr('id');


                });
                $('#cboParentPage').bind('change', function() {
                    SagePages.GetChildPages($('#cboParentPage').val(), null, null, null, p.UserName, p.PortalID);
                });

                $('#imgDelete').live('click', function() {
                    $(this).parents('tr').remove();
                });

                $('#chkMenu').bind("click", function() {
                    if ($(this).attr("checked")) {

                        var selected = $('#categoryTree  span.ui-tree-selected').length;


                        $('#trIncludeInMenu').slideDown();
                        $('#selMenulist').show();
                        SagePages.GetMenuList();
                        //                        if ($('#txtPageName').val() != "") {
                        //                            SagePages.GetPageDetails($('#txtPageName').attr('title'));
                        //                        }
                    }
                    else {
                        $('#trIncludeInMenu').slideUp();
                    }
                });
                $('label.sfError').remove();
            },
            BindParentPages: function() {
                var parentPages = LSTSagePages;
                var html = '';
                var selectedpage = $('#categoryTree span.ui-tree-selected').parent("li").attr("id");
                if ($('#rdbAdmin').attr("checked")) {
                    html += '<option value="2">---None---</option>';
                }
                else {
                    html += '<option value="0">---None---</option>';
                }
                $.each(parentPages, function(index, item) {
                    if (item.PageID != selectedpage && item.ParentID != selectedpage)
                        html += '<option value=' + item.PageID + '>' + item.PageName.replace(new RegExp("-", "g"), ' ') + '</option>';
                });
                $('#cboParentPage').html(html);

            },


            GetMenuList: function() {
                $.ajax({
                    type: SagePages.config.type,
                    contentType: SagePages.config.contentType,
                    cache: SagePages.config.cache,
                    async: false,
                    url: SagePages.config.baseURL + "GetAllMenu",
                    data: JSON2.stringify({ UserName: p.UserName, PortalID: p.PortalID }),
                    dataType: SagePages.config.dataType,
                    success: function(msg) {
                        var LstMenu = msg.d;
                        var html = '';
                        var menulist = '';
                        var check = '';

                        $.each(LstMenu, function(index, item) {
                            if (item != "") {
                                menulist += '<option value=' + item.MenuID + '>' + item.MenuName + '</li>';
                            }
                        });

                        if (LstMenu.length == 0) {
                            menulist = '<option value="0">No Menu Available</option>';
                        }

                        $('#selMenulist').html(menulist);

                    }
                });
            },

            DeleteIcon: function(IconPath) {
                this.config.method = "DeleteIcon";
                this.config.url = SagePages.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ IconPath: IconPath });
                this.config.ajaxCallMode = 6;
                this.ajaxCall(this.config);
            },

            LoadRoles: function() {
                this.config.method = "GetPortalRoles";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ PortalID: SageFramePortalID, UserName: p.UserName });
                this.config.ajaxCallMode = 0;
                this.ajaxCall(this.config);
            },
            AddUpdatePage: function() {
                var Mode = '';
                if ($('span.ui-tree-selected').hasClass("ui-tree-selected")) {
                    Mode = "E";
                } else { Mode = "A"; }

                var UpdateLabel = '';
                if ($('#cboParentPage').val() == '0') {
                    UpdateLabel = "NA";
                } else { UpdateLabel = "PA"; }



                var checks = $('div.divPermissions tr:gt(0), #dvUser tr').find('input.sfCheckbox:checked');
                SagePages.config.lstPagePermission = [];
                $.each(checks, function(index, item) {
                    if ($(this).attr("checked")) {
                        if ($(this).closest('table').attr('id') == "tblUser")
                            SagePages.config.lstPagePermission[index] = { "PermissionID": $(this).attr('title') == "view" ? 1 : 2, "RoleID": null, "Username": $(this).closest('tr').find('td:eq(0) label').html(), "AllowAccess": true };
                        else
                            SagePages.config.lstPagePermission[index] = { "PermissionID": $(this).attr('title') == "view" ? 1 : 2, "RoleID": $(this).closest('tr').attr('id'), "Username": "", "AllowAccess": true };
                    }
                });
                var beforeID = 0;
                var afterID = 0;

                if ($('#rdbBefore').attr('checked') == true) {
                    beforeID = $('#cboPositionTab').val();
                }
                else if ($('#rdbAfter').attr('checked') == true) {
                    afterID = $('#cboPositionTab').val();
                }

                var iconFile = '';
                $('div.cssClassUploadFiles > ul > li > span.iconFile').each(function() {
                    iconFile += $(this).html() + ', ';
                });

                if (iconFile != '')
                    iconFile = iconFile.substring(0, iconFile.length - 2);

                var MenuArr = new Array();
                var MenuSelected = 0;
                if ($('#chkMenu').is(':checked')) {
                    var MenuList = $('#selMenulist option:selected');
                    $.each(MenuList, function(index, item) {
                        MenuArr.push($(this).val());
                    });
                    MenuSelected = MenuArr.join(',');
                }

                var _IsVisible = $('#rdbAdmin').attr('checked') ? $('#chkShowInDashboard').attr("checked") : true;
                var PageDetails = {
                    PageEntity: {
                        Mode: Mode,
                        Caption: $('#txtCaption').val(),
                        PageID: $('#txtPageName').attr('title') > 0 ? $('#txtPageName').attr('title') : 0, PageName: $.trim($('#txtPageName').val()),
                        IsVisible: _IsVisible, ParentID: $('#cboParentPage').val(),
                        IconFile: $('div.cssClassUploadFiles img:eq(0)').attr('title'), Title: $('#txtTitle').val(), Description: $('#txtDescription').val(), KeyWords: $('#txtKeyWords').val(),
                        Url: "", StartDate: $('#txtStartDate').val(), EndDate: $('#txtEndDate').val(), RefreshInterval: $('#txtRefreshInterval').val() == "" ? 0 : $('#txtRefreshInterval').val(),
                        PageHeadText: "SageFrame", IsSecure: $('#chkIsSecure').attr("checked") ? true : false, PortalID: p.PortalID, IsActive: true,
                        AddedBy: p.UserName, BeforeID: beforeID, AfterID: afterID, IsAdmin: $('#rdbAdmin').attr('checked') ? true : false, LstPagePermission: SagePages.config.lstPagePermission,
                        MenuList: MenuSelected,
                        UpdateLabel: UpdateLabel
                    }
                };

                this.config.method = "AddUpdatePages";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ "objPageInfo": PageDetails.PageEntity });
                this.config.ajaxCallMode = 3;
                this.ajaxCall(this.config);
            },
            GetPageDetails: function(pageID) {
                this.config.method = "GetPageDetails";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ pageID: pageID });
                this.config.ajaxCallMode = 2;
                this.ajaxCall(this.config);
            },
            BindPortalRoles: function(data) {
                var html = '';
                if (data.d.length > 0)
                    html += '<tr><th><label>Role</label></th><th><label>View</label></th><th><label>Edit</label></th><th>&nbsp;</th></tr>';


                $.each(data.d, function(index, item) {
                    var accesscontrolled = item.RoleName.toLowerCase() === "superuser" || item.RoleName.toLowerCase() === "super user" ? 'checked="checked" disabled="true"' : "";
                    var style = index % 2 == 0 ? 'class="sfEven"' : 'class="sfOdd"';
                    html += '<tr ' + style + ' id=' + item.RoleID + '><td width="40%"><label>' + item.RoleName + '</label></td><td width="20%"><input type="checkbox" ' + accesscontrolled + ' class="sfCheckbox" title="view" /></td>';
                    html += '<td width="20%"><input type="checkbox" ' + accesscontrolled + ' class="sfCheckbox" title="edit"/></td><td width="10%">&nbsp;</td></tr>';
                });
                $('div.divPermissions table').append(html);

                SagePages.InitCustomControls();
            },
            SearchUsers: function() {
                this.config.method = "SearchUsers";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ SearchText: $('#txtSearchUsers').val(), PortalID: parseInt(SageFramePortalID), UserName: p.UserName });
                this.config.ajaxCallMode = 1;
                this.ajaxCall(this.config);
            },
            BindUsers: function(data) {

                var selectedUsers = $('#tblUser tr');
                if (data.d.length > 1) {
                    $('#divSearchedUsers').show();
                }
                $.each(selectedUsers, function() {
                    SagePages.config.arrUsers.push($(this).find("td:first label").text());
                });

                var html = '<ul>';
                $.each(data.d, function(index, item) {

                    var style = jQuery.inArray(item.UserName.toLowerCase(), SagePages.config.arrUsers) > -1 ? 'class="sfActive"' : "";
                    html += '<li ' + style + ' id=' + item.UserID + '>' + item.UserName + '</li>';

                });
                html += '</ul>';
                $('#divSearchedUsers').html(html);

            },
            UserAlreadyExists: function(username) {
                var Exists = false;
                var existingUsers = $('#tblUser tr');
                $.each(existingUsers, function() {                 
                    if ($(this).find("td:first label").text() == username) {
                        Exists = true;
                    }
                });
                return Exists;
            },
            GetChildPages: function(parentID, isActive, isVisiable, isRequiredPage, userName, portalID) {
                this.config.method = "GetChildPages";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ parentID: parentID, isActive: isActive, isVisiable: isVisiable, isRequiredPage: isRequiredPage, userName: userName, portalID: portalID });
                this.config.ajaxCallMode = 4;
                this.ajaxCall(this.config);
            },

            BindChildPages: function(data) {
                var html = '';
                $.each(data.d, function(index, item) {
                    html += '<option value=' + item.PageID + '>' + item.PageName + '</option>';
                });
                $('#cboPositionTab').html(html);
            },
            BindPageDetails: function(data) {
                $('#divSearchedUsers').html('');
                $('#txtPageName').val(data.d.PageName);
                $('#txtTitle').val(data.d.Title);
                $('#txtDescription').val(data.d.Description);
                $('#txtKeyWords').val(data.d.KeyWords);
                $('#txtRefreshInterval').val(data.d.RefreshInterval);
                $('#txtStartDate').val(data.d.StartDate);
                $('#txtEndDate').val(data.d.EndDate);
                $('#cboParentPage').val(data.d.ParentID);
                $('#txtCaption').val(data.d.Caption);

                $('#chkShowInDashboard').attr("checked", data.d.IsVisible);

                if (!$('#rdbAdmin').attr("checked")) {
                    var str = data.d.MenuPages;
                    SagePages.GetMenuList();
                    $("#selMenulist option").attr('selected', false);
                    var substr = str.split('/');

                    if (substr == "0") {
                        $('#trIncludeInMenu').hide();
                    }
                    else {
                        $('#trIncludeInMenu,#selMenulist').show();
                        $.each(substr, function(index, item) {
                            $("#selMenulist option[value='" + substr[index] + "']").attr('selected', 'selected');
                        });
                    }
                }

                if (data.d.IsSecure == true ? $('#chkIsSecure').attr('checked', true) : $('#chkIsSecure').attr('checked', false));
                if (data.d.IsVisible == true ? $('#chkMenu').attr('checked', true) : $('#chkMenu').attr('checked', false));
                if (substr == "0") {
                    $('#chkMenu').attr("checked", false);
                }
                $('div.cssClassUploadFiles').html('');
                if (data.d.IconFile != "") {
                    var filePath = p.AppName + "/PageImages/" + data.d.IconFile;
                    var html = '<img title="' + data.d.IconFile + '" src="' + filePath + '"/><span class="deleteIcon"><img class="delete" src=' + SageFrame.utils.GetAdminImage("delete.png") + '></span>';
                    $('div.cssClassUploadFiles').html(html);
                }

                var arr = new Array();
                $.each(data.d.LstPagePermission, function(inxs, ww) {
                    if (jQuery.inArray(ww.Username, arr) == -1)
                        arr.push(ww.Username);
                });


                $('#dvUser table').html('').show();
                var userHtml = "";
                $.each(arr, function(inx, itw) {
                    if (itw != "") {
                        var style = inx % 2 == 0 ? 'class="sfEven"' : 'class="sfOdd"';
                        userHtml += '<tr ' + style + '><td width="40%"><label>' + arr[inx] + '</label></td><td width="20%"><input type="checkbox" class="sfCheckbox" title="view"/></td>';
                        userHtml += '<td width="20%"><input type="checkbox" class="sfCheckbox" title="edit"/></td><td width="10%"><img class="delete" src=' + SageFrame.utils.GetAdminImage("delete.png") + ' alt="delete"></td></tr>';
                    }
                });

                if (userHtml != "")
                    $('#dvUser table').append(userHtml);

                if ($('#tblUser tr').length > 0)
                    $('#tblUser').show();
                else
                    $('#tblUser').hide();

                var roles = $('div.divPermissions tr:gt(0)');
                var user = $('#dvUser tr');
                $.each(data.d.LstPagePermission, function(indx, itm) {
                    $.each(roles, function(index, item) {
                        if ($(item).attr('id') == itm.RoleID && itm.PermissionID == 1) {
                            $(item).find('input[title="view"]').attr('checked', true);
                        }
                        else if ($(item).attr('id') == itm.RoleID && itm.PermissionID == 2) {
                            $(item).find('input[title="edit"]').attr('checked', true);
                        }
                    });
                    $.each(user, function(index, ite) {
                        if ($(ite).find('td:eq(0) label').html() == itm.Username && itm.PermissionID == 1) {
                            $(ite).find('input[title="view"]').attr('checked', true);
                        }
                        else if ($(ite).find('td:eq(0) label').html() == itm.Username && itm.PermissionID == 2) {
                            $(ite).find('input[title="edit"]').attr('checked', true);
                        }
                    });
                });

                //SagePages.GetPageModules(SagePages.config.PageID, p.PortalID);
            },
            InitCustomControls: function() {
                $("input:submit,input:button").button();
                $("#divAddUsers").dialog({
                    autoOpen: false,
                    width: 350,
                    modal: true

                });
            },
            IconUploader: function() {

                var uploadFlag = false;
                var upload = new AjaxUpload($('#flIcon'), {
                    action: Path + 'UploadHandler.ashx',
                    name: 'myfile[]',
                    multiple: false,
                    data: { rdbChecked: "NA" },
                    autoSubmit: true,
                    responseType: 'json',
                    onChange: function(file, ext) {
                    },
                    onSubmit: function(file, ext) {
                        ext = ext.toLowerCase();
                        if (ext == "png" || ext == "jpg" || ext == "gif" || ext == "bmp" || ext == "JPEG" || ext == "jpeg" || ext == "ico") {
                            return true;
                        }
                        else {
                            return ConfirmDialog(this, 'message', "Not a valid image file");
                            return false;
                        }
                    },
                    onComplete: function(file, response) {
                        if (response == "large") {
                            return ConfirmDialog(this, 'message', "The image size is too large. Should be less than 1mb");
                        }
                        var pageimage = file.split(" ").join("_");
                        var filePath = p.AppName + "/PageImages/" + pageimage;
                        $('span.filename').text(pageimage);
                        var html = '<img title="' + pageimage + '" src="' + filePath + '" /><span class="deleteIcon"><img class="delete" src=' + SageFrame.utils.GetAdminImage("delete.png") + '></span>';
                        $('div.cssClassUploadFiles').html(html);
                    }
                });
            },
            RefreshPage: function(data) {
                if (data.d == "1") {
                    $('#categoryTree').html('');
                    $(this).SageTreeBuilder({
                        PortalID: p.PortalID,
                        UserModuleID: p.UserModuleID,
                        UserName: p.UserName,
                        PageName: p.PageName,
                        ContainerClientID: p.ContainerClientID,
                        CultureCode: p.CultureCode,
                        baseURL: p.baseURL,
                        Mode: $('#rdbAdmin').attr('checked')
                    });
                    SagePages.ClearControls();
                }
            },
            ClearControls: function() {
                if ($('#rdbAdmin').attr('checked')) {
                    $('#trShowInDashboard').show();
                }
                $('#txtPageName').val('').removeAttr("disabled").removeClass("sfDisable");
                $('#cboParentPage').val('');
                $('#flIcon').val('');
                $('#txtTitle').val('');
                $('#txtDescription').val('');
                $('#txtCaption').val('');
                $('#txtKeyWords').val('');
                $('#txtStartDate').val('');
                $('#txtEndDate').val('');
                $('#txtRefreshInterval').val('');
                $('#chkIsSecure').attr("checked", false);
                LstPagePermission: lstPagePermission = [];
                $('#txtPageName').attr('title', 0);
                $('#cboPositionTab').val('');
                $('span.ui-tree-selected').removeClass("ui-tree-selected")

                $('#tblUser tr:gt(0)').remove();
                //$('#tblUser').hide();
                $("div.divPermissions tr:gt(1)").each(function() {
                    $(this).find("input:checkbox").attr("checked", false);
                });
                $('div.cssClassUploadFiles').html('');
                $('#chkMenu').attr("checked", false);
                $('#selMenulist').html('').hide();
                $('#trIncludeInMenu').hide();
                $('span.filename').text('No files selected');

            },
            GetPageModules: function(_pageID, _portalID) {
                this.config.method = "GetPageModules";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ pageID: parseInt(_pageID), portalID: parseInt(_portalID) });
                this.config.ajaxCallMode = 5;
                this.ajaxCall(this.config);
            },
            BindPageModules: function(data) {
                var html = '<table width="100%" cellpadding="0" cellspacing="0">';
                var modules = data.d;
                if (modules.length > 0) {
                    html += '<tr><th>UserModule</th><th>Postion</th><th></th></tr>';
                }
                var link = p.AppName + '/Admin/ControlEditor.aspx?uid=';
                $.each(modules, function(index, item) {
                    if (item != null) {
                        var hreflink = link + item.UserModuleID;
                        if (index % 2 == 0) {
                            html += '<tr class="sfEven"><td>' + item.UserModuleTitle + '</td><td>' + item.PaneName + '</td></tr>';
                        }
                        else {
                            html += '<tr class="sfOdd"><td>' + item.UserModuleTitle + '</td><td>' + item.PaneName + '</td></tr>';
                        }
                    }
                });
                html += '</table>';
                $('#hdnModules').html(html);

                if ($('#hdnModules table tr').length == 0) {
                    $('#hdnModules').html(SageFrame.messaging.showdivmessage(SageFrame.messages.NoModulesAssigned));
                }
                SagePages.InitPaging();

            },
            DeletePageModules: function(tblID, argus) {
                switch (tblID) {
                    case "gdvModule":
                        if (argus[3]) {
                            var properties = { onComplete: function(e) { SagePages.PageModuleDelete(argus[0], deletedBy, portalId, e); } }
                            csscody.confirm("<h2>Delete Confirmation</h2><p>Do you want to delete this module?</p>", properties);
                        }
                        break;
                    default:
                        break;
                }
            },
            PageModuleDelete: function(moduleID, deletedBy, portalID, event) {
                if (event) {
                    $.ajax({
                        type: "POST",
                        url: servicePath + "DeletePageModule",
                        data: JSON2.stringify({ moduleID: moduleID, deletedBy: deletedBy, portalID: portalId }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function() {
                        }
                    });
                }
                return false;
            },
            InitPaging: function() {
                var optInit = {
                    items_per_page: 15,
                    num_display_entries: 10,
                    current_page: 0,
                    num_edge_entries: 2,
                    link_to: "#",
                    prev_text: "<<",
                    next_text: ">>",
                    ellipse_text: "...",
                    prev_show_always: true,
                    next_show_always: true,
                    callback: SagePages.pagingCallback

                };

                var members = $('#hdnModules tr');
                $("#divPager").pagination(members.length, optInit);

            },
            pagingCallback: function(page_index, jq) {

                // Get number of elements per pagionation page from form
                var items_per_page = 15;
                var members = $('#hdnModules tr');
                var max_elem = Math.min((page_index + 1) * items_per_page, members.length);
                var newcontent = '<table cellspacing="0" cellpadding="0" width="100%"><tr><th>UserModule</th><th>Postion</th><th></th></tr>';
                var modules = $('#hdnModules tr');
                var i = 0;
                $.each(modules, function() {
                    if (i < max_elem && i >= page_index * items_per_page) {
                        var style = i % 2 == 0 ? 'class="sfEven"' : 'class="sfOdd"';
                        newcontent += '<tr ' + style + '><td>' + $(this).find("td:first").text() + '</td><td>' + $(this).find("td:eq(1)").text() + '</td></tr>';
                    }
                    i++;
                });
                newcontent += '</table>';
                $('#gdvModules').empty().html(newcontent);
                // Prevent click eventpropagation
                return false;
            }
        };
        SagePages.init();

    }
    $.fn.SageFramePageBuilder = function(p) {
        $.createPageBuilder(p);
    };
})(jQuery);