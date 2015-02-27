(function($) {
    $.createPageTreeView = function(p) {
        p = $.extend
        ({
            PortalID: 1,
            UserModuleID: 1,
            UserName: 'user',
            PageName: 'Home',
            ContainerClientID: 'divNav1',
            CultureCode: 'en-US',
            baseURL: Path + '/Modules/PageTreeView/MenuWebService.asmx/',
            Mode: false,
            AppName:'/sageframe'
        }, p);

        var PageTreeView = {
            config: {
                isPostBack: false,
                async: true,
                cache: false,
                type: 'POST',
                contentType: "application/json; charset=u0tf-8",
                data: { data: '' },
                dataType: 'json',
                baseURL: p.baseURL,
                baseUrlForPages: p.baseUrlForPages,
                method: "",
                url: "",
                ajaxCallMode: 0,
                UserModuleID: p.UserModuleID,
                PortalID: p.PortalID,
                UserName: p.UserName,
                PageName: p.PageName,
                ContainerClientID: p.ContainerClientID,
                CultureCode: p.CultureCode,
                Mode: p.Mode,
                LSTPages: []
            },
            init: function() {
                this.GetPages();
                this.BindEvents();
            },
            ajaxSuccess: function(data) {
                switch (PageTreeView.config.ajaxCallMode) {
                    case 0:
                    case 1:
                        PageTreeView.BuildMenu(data);
                        break;
                    case 2:
                        PageTreeView.BindPages(data);
                        break;
                    case 3:
                        PageTreeView.BuildFooterMenu(data);
                        break;
                    case 4:
                        PageTreeView.BuildSideMenu(data);
                        break;
                    case 5:
                        SageFrame.messaging.show(SageFrame.messaging.GetLocalizedMessage("en-US", "PageManager", "PageDeletedSuccessful"), "Success");
                        PageTreeView.GetPages();
                        break;
                    case 6:
                        break;

                }
            },
            BindEvents: function() {
                $('#imbPageCancel').bind("click", function() {
                    PageTreeView.ClearControls();
                });
                $('#trShowInDashboard').hide();

                if ($('#rdbFronMenu').attr("checked")) {
                    $('#trShowInDashboard').hide();
                }

                $('#btnAddpage').live("click", function() {
                    PageTreeView.ClearControls();
                    PageTreeView.GetPages();
                    $("#flIcon").next('.filename').html('No file selected.');
                    $('#txtPageName').next("label").remove();
                    $('#txtTitle').next("label").remove();
                    $('#txtPageName').removeAttr("readonly");
                });
                $('#rdbAdmin, #rdbFronMenu').bind('click', function() {
                    PageTreeView.ClearControls();
                    PageTreeView.config.Mode = $(this).attr('id') === 'rdbAdmin' ? true : false;
                    PageMode = PageTreeView.config.Mode;
                    if ($(this).attr("id") == "rdbAdmin") {
                        $('#trIncludeInMenuLbl').hide();
                        $('#trShowInDashboard').show();
                        $('#trIncludeInMenu').hide();
                        $('#trParent').hide();
                        PageTreeView.IconUploaderAdmin();

                    }
                    else {
                        $('#trIncludeInMenuLbl').show();
                        $('#trShowInDashboard').hide();
                        $('#trIncludeInMenu').show();
                        $('#trParent').show();
                        PageTreeView.IconUploader();
                    }
                    PageTreeView.GetPages();
                });
            },
            ajaxFailure: function() {
            },
            ajaxCall: function(config) {
                $.ajax({
                    type: PageTreeView.config.type,
                    contentType: PageTreeView.config.contentType,
                    cache: PageTreeView.config.cache,
                    url: PageTreeView.config.url,
                    data: PageTreeView.config.data,
                    dataType: PageTreeView.config.dataType,
                    success: PageTreeView.ajaxSuccess,
                    error: PageTreeView.ajaxFailure
                });
            },
            GetPages: function() {
                this.config.method = "GetPortalPages";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ PortalID: parseInt(PageTreeView.config.PortalID), IsAdmin: PageTreeView.config.Mode });
                this.config.ajaxCallMode = 2;
                this.ajaxCall(this.config);
            },
            DeletePage: function(pageID, deletedBy, portalId) {
                this.config.method = "DeleteChildPages";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ pageID: pageID, deletedBY: deletedBy, portalID: portalId });
                this.config.ajaxCallMode = 5;
                this.ajaxCall(this.config);
            },
            UpdatePage: function(pageID, isVisiable, isPublished, portalID, deletedBY, updateFor) {
                this.config.method = "UpdatePageAsContextMenu";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ pageID: pageID, isVisiable: isVisiable, isPublished: isPublished, portalID: portalID, userName: deletedBY, updateFor: updateFor });
                this.config.ajaxCallMode = 6;
                this.ajaxCall(this.config);
            },
            SortTreeViewMenu: function(pageID, parentID, pageName, BeforeID, AfterID, portalID, userName) {
                if ($('#rdbAdmin').attr("checked")) {
                    parentID = 2;
                }
                this.config.method = "SortFrontEndMenu";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ pageID: pageID, parentID: parentID, pageName: pageName, BeforeID: BeforeID, AfterID: AfterID, portalID: portalID, userName: userName });
                this.config.ajaxCallMode = 6;
                this.ajaxCall(this.config);
            },
            SortAdminTreeViewMenu: function() {
                var lstPageOrder = [];
                $('#categoryTree li').each(function(ind, itm) {
                    lstPageOrder[ind] = { "PageID": $(this).attr('id'), "PageOrder": ind, "PortalID": p.PortalID };
                });
                lstPageOrder.pop();
                this.config.method = "SortAdminPages";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ "lstPages": lstPageOrder });
                this.config.ajaxCallMode = 6;
                this.ajaxCall(this.config);
            },
            BuildMenu: function(data) {
                var setting = data.d;
                switch (parseInt(setting.MenuType)) {
                    case 0:
                        PageTreeView.LoadTopAdminMenu();
                        break;
                    case 1:
                        PageTreeView.GetPages();
                        break;
                    case 2:
                        PageTreeView.LoadSideMenu();
                        break;
                    case 3:
                        PageTreeView.LoadFooterMenu();
                        break;
                }
            },
            BindPages: function(data) {

                var pages = data.d;
                var PageID = "";
                var parentID = "";
                var PageLevel = 0;
                var itemPath = "";
                var html = "";
                html += '<ul id="categoryTree">';
                var levelSelect = PageTreeView.config.Mode ? 1 : 0;
                $.each(pages, function(index, item) {
                    PageID = item.PageID;
                    parentID = item.ParentID;
                    categoryLevel = item.Level;

                    if (item.Level == levelSelect) {
                        if (item.ChildCount > 0) {
                            html += '<li ' + styles + '  id=' + PageID + '><span title=' + item.IsPublished + ' class=' + item.IsActive + '></span>';
                        }
                        else {
                            var styles = item.PortalID == "-1" || item.PageName.toLowerCase() == "home" ? 'class="file-folder required"' : 'class="file-folder"';
                            html += '<li ' + styles + ' id=' + PageID + '> <span title=' + item.IsPublished + ' class=' + item.IsActive + '></span>';
                        }
                        html += item.PageName.replace(new RegExp("-", "g"), ' ');

                        if (item.ChildCount > 0) {
                            html += "<ul>";
                            itemPath += item.PageName;
                            html += PageTreeView.BindChildCategory(pages, PageID);
                            html += "</ul>";
                        }
                        html += '</li>';
                    }
                    itemPath = '';
                });
                html += '</ul>';
                $(PageTreeView.config.ContainerClientID).html(html);
                PageTreeView.AddDragDrop();
                PageTreeView.AddContextMenu();
                PageTreeView.BindParentPages(data);
                LSTSagePages = data.d;
            },
            BindChildCategory: function(response, PageID) {
                var strListmaker = '';
                var childNodes = '';
                var path = '';
                var itemPath = "";
                itemPath += "";
                var tabPath = '';
                $.each(response, function(index, item) {
                    if (item.Level > 0) {
                        if (item.ParentID == PageID) {
                            itemPath += item.PageName;
                            var styles = item.PortalID == "-1" ? 'class="file-folder required"' : 'class="file-folder"';
                            strListmaker += '<li class="sfChild" ' + styles + ' id=' + item.PageID + '><span title=' + item.IsPublished + ' class=' + item.IsActive + '></span>' + item.PageNameWithoughtPrefix;
                            childNodes = PageTreeView.BindChildCategory(response, item.PageID);
                            itemPath = itemPath.replace(itemPath.lastIndexOf(item.AttributeValue), '');
                            if (childNodes != '') {
                                strListmaker += "<ul>" + childNodes + "</ul>";
                            }
                            strListmaker += '</li>';
                        }
                    }
                });
                return strListmaker;
            },
            AddDragDrop: function() {
                $('#categoryTree').tree({
                    expand: 'false',
                    droppable: [
            		            {
            		                element: 'li.ui-tree-node',
            		                tolerance: 'around',
            		                aroundTop: '25%',
            		                aroundBottom: '25%',
            		                aroundLeft: 0,
            		                aroundRight: 0
            		            },
            		            {
            		                element: 'li.ui-tree-list',
            		                tolerance: 'around',
            		                aroundTop: '25%',
            		                aroundBottom: '25%',
            		                aroundLeft: 0,
            		                aroundRight: 0
            		            }
            	            ],
                    drop: function(event, ui) {
                        $('.ui-tree-droppable').removeClass('ui-tree-droppable ui-tree-droppable-top ui-tree-droppable-center ui-tree-droppable-bottom');

                        switch (ui.overState) {
                            case 'top':
                                ui.target.before(ui.sender.getJSON(ui.draggable), ui.droppable);
                                ui.sender.remove(ui.draggable);

                                var html = $(ui.draggable).find('span:eq(1)').html();
                                var pageName = html.split('>');
                                var parentID = typeof $(ui.droppable).closest('ul').parent('li').attr('id') == 'undefined' ? 0 : $(ui.droppable).closest('ul').parent('li').attr('id');
                                if ($('#rdbFronMenu').attr("checked")) {
                                    //parentID = 2;
                                    PageTreeView.SortTreeViewMenu($(ui.draggable).attr('id'), parentID, pageName[pageName.length - 1], $(ui.droppable).parent('li').attr('id'), 0, p.PortalID, p.UserName);
                                }
                                break;

                            case 'bottom':
                                ui.target.after(ui.sender.getJSON(ui.draggable), ui.droppable);
                                ui.sender.remove(ui.draggable);

                                var html = $(ui.draggable).find('span:eq(1)').text();
                                var pageName = html.split('>');
                                var parentID = $(ui.droppable).closest('ul').parent('li').attr('id');
                                if (parentID == undefined) {
                                    parentID = 0;
                                }
                                if ($('#rdbFronMenu').attr("checked")) {
                                    //parentID = 2;
                                    PageTreeView.SortTreeViewMenu($(ui.draggable).attr('id'), parentID, pageName[pageName.length - 1], $(ui.droppable).parent('li').attr('id'), 0, p.PortalID, p.UserName);
                                }

                                break;

                            case 'center':
                                if (!$('#rdbAdmin').attr("checked")) {
                                    ui.target.append(ui.sender.getJSON(ui.draggable), ui.droppable);
                                    ui.sender.remove(ui.draggable);
                                    $(ui.droppable).parent('li').addClass('ui-tree-expanded');
                                    $(ui.droppable).parent('li').removeClass('ui-tree-list');
                                    $(ui.droppable).parent('li').addClass('ui-tree-node');

                                    var html = $(ui.draggable).find('span:eq(1)').html();
                                    var pageName = html.split('>');
                                    PageTreeView.SortTreeViewMenu($(ui.draggable).attr('id'), $(ui.droppable).parent('li').attr('id'), pageName[pageName.length - 1], 0, 0, p.PortalID, p.UserName);
                                }
                                break;
                        }
                    },
                    stop: function(event, ui) {
                        if ($('#rdbAdmin').attr("checked")) {
                            PageTreeView.SortAdminTreeViewMenu();
                        }

                    },
                    over: function(event, ui) {
                        $(ui.droppable).addClass('ui-tree-droppable');
                    },
                    out: function(event, ui) {
                        $(ui.droppable).removeClass('ui-tree-droppable');
                    },
                    overtop: function(event, ui) {
                        $(ui.droppable).addClass('ui-tree-droppable-top');
                    },
                    overcenter: function(event, ui) {
                        $(ui.droppable).addClass('ui-tree-droppable-center');
                    },
                    overbottom: function(event, ui) {
                        $(ui.droppable).addClass('ui-tree-droppable-bottom');
                    },
                    outtop: function(event, ui) {
                        $(ui.droppable).removeClass('ui-tree-droppable-top');
                    },
                    outcenter: function(event, ui) {
                        $(ui.droppable).removeClass('ui-tree-droppable-center');
                    },
                    outbottom: function(event, ui) {
                        $(ui.droppable).removeClass('ui-tree-droppable-bottom');
                    },
                    dblclick: function(event, ui) {
                        var id = ui.draggable[0].id;
                        id = ui.draggable[0].id.replace(/[^0-9]/gi, '');
                        GetCategoryByCagetoryID(id);
                        ResetImageTab();
                    }
                });
            },
            AddContextMenu: function() {
                var pageTree = $('#categoryTree li').not('#categoryTree li.required');
                $(pageTree).each(function(i) {
                    //if (!PageTreeView.IsUnassignedNode($(this))) { 
                    var self = $(this);
                    $(this).find("span").contextMenu('myMenu1', {

                        //                                onShowMenu: function(e, menu) {
                        //                                        if (isNode(getSelect().parent('li'))) {
                        //                                            $('#remove', menu).remove();
                        //                                        }
                        //                                        else {
                        //                                            $('#rename, #delete', menu).remove();
                        //                                        }                                   
                        //                                            return menu;
                        //                                    }, 

                        bindings: {
                            'add': function(t) {
                                PageTreeView.ClearControls();
                            },
                            'addmodule': function(t) {
                            },
                            'publish': function(t) {
                                PageTreeView.UpdatePage($(t).find('span.ui-tree-selected').parent('li').attr('id'), 0, 1, p.PortalID, p.UserName, "P");
                            },
                            'ubpublish': function(t) {
                                PageTreeView.UpdatePage($(t).find('span.ui-tree-selected').parent('li').attr('id'), 0, 0, p.PortalID, p.UserName, "P");
                            },
                            'showinmenu': function(t) {
                                PageTreeView.UpdatePage($(t).find('span.ui-tree-selected').parent('li').attr('id'), 1, 0, p.PortalID, p.UserName, "M");
                            },
                            'hideinmenu': function(t) {
                                PageTreeView.UpdatePage($(t).find('span.ui-tree-selected').parent('li').attr('id'), 0, 0, p.PortalID, p.UserName, "M");
                            },
                            'rename': function(t) {
                            },
                            'remove': function(t) {
                                $('#sf_lblConfirmation').text("Are you sure you want to delete this page?");
                                $("#dialog").dialog({
                                    modal: true,
                                    buttons: {
                                        "Confirm": function() {
                                            PageTreeView.DeletePage($(self).find('span.ui-tree-selected').parent('li').attr('id'), p.UserName, p.PortalID);
                                            $(self).find('span.ui-tree-selected').parent('li').remove();
                                            $(this).dialog("close");
                                        },
                                        "Cancel": function() {
                                            $(this).dialog("close");
                                        }
                                    }
                                });



                            }
                        },
                        menuStyle: {
                        //                                border: '1px solid #000'
                    },
                    itemStyle: {
                    //                                display: 'block',
                    //                                cursor: 'pointer',
                    //                                padding: '3px',
                    //                                border: '1px solid #fff',
                    //                                backgroundColor: 'transparent'
                },
                itemHoverStyle: {
                //                                border: '1px solid #0a246a',
                //                                backgroundColor: '#b6bdd2'
            }
        });
        // }
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
IconUploaderAdmin: function() {

    var uploadFlag = false;
    var upload = new AjaxUpload($('#flIcon'), {
        action: Path + 'UploadHandler.ashx',
        name: 'myfile[]',
        multiple: false,
        data: { rdbChecked: "A" },
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
ClearControls: function() {
    $('#txtPageName').val('').removeAttr("disabled").removeClass("sfDisable");
    $('#txtCaption').val('');
    $('#cboParentPage').val('');
    $('#flIcon').val('');
    $('#txtTitle').val('');
    $('#txtDescription').val('');
    $('#txtKeyWords').val('');
    $('#txtStartDate').val('');
    $('#txtEndDate').val('');
    $('#txtRefreshInterval').val('');
    $('#chkIsSecure').attr("checked", false);
    LstPagePermission: lstPagePermission = [];
    $('#txtPageName').attr('title', 0);
    $('#cboPositionTab').val('');
    $('span.ui-tree-selected').removeClass("ui-tree-selected")
    $("div.divPermissions tr:gt(1)").each(function() {
        $(this).find("input:checkbox").attr("checked", false);
    });
    $('#tblUser tr:gt(0)').remove();
    $('#tblUser').hide();

    $('div.cssClassUploadFiles').html('');
    $('#chkMenu').attr("checked", false);
    $('#gdvModules,#hdnModules,#divPager').html("");
    $('#selMenulist').html('').hide();
    $('label.sfError').remove();
    $('span.filename').text('No files selected');
},
IsUnassignedNode: function(li) {
    return (li.hasClass('unassigned-attributes'));
},
BindParentPages: function(pages) {
    var parentPages = pages.d;
    var html = "";
    if (PageTreeView.config.Mode) {
        html += '<option value="2">---None---</option>';
    }
    else {
        html += '<option value="0">---None---</option>';
    }
    $.each(parentPages, function(index, item) {
        html += '<option value=' + item.PageID + '>' + item.PageName.replace(new RegExp("-", "g"), ' ') + '</option>';
    });
    $('#cboParentPage').html(html);
}
};
PageTreeView.init();
};
$.fn.SageTreeBuilder = function(p) {
    $.createPageTreeView(p);
};
})(jQuery);

   
   