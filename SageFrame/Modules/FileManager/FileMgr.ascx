<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FileMgr.ascx.cs" Inherits="Modules_FileManager_FileMgr" %>
<script type="text/javascript">

    $.FileMgr = {
        url: "WCF/ExtensionManagerWCF.svc/",
        uploadFolder: "E:/svnfeb13_/sageframe-Beta-01/SageFrame/Modules/FileManagerFiles/",
        filepath: "E:/svnfeb13_/sageframe-Beta-01/SageFrame/Modules/FileManagerFiles/",
        folderId: 0,
        toFolderId: 0,
        fileId: 0,
        destinationPath: "",
        mode: "normal",
        copyPath: "",
        address: "/",
        UserID: '<%=UserID%>',
        UserModuleID: '<%=UserModuleID%>',
        UserName: '<%=UserName%>',
        FileManagerControlArrayContainers: "#divControls li.upload,#divControls li.delete,#divControls li.delete_folder,#divControls li.copy,#divControls li.move,#divControls li.sfRefresh,#divControls li.permission,#divControls li.sync,#divBottomControls",
        FileManagerControlArray: "#divControls li.upload,#divControls li.delete,#divControls li.delete_folder,#divControls li.copy,#divControls li.move,#divControls li.sfRefresh,#divControls li.permission,#divControls li.sync,#imgAddFile,#imgAddFolder,#btnCopy,#imgDelFolder,#imgDelFile",
        PortalID: 1,
        ConfirmMode: "single",
        RowCount: 0,
        CurrentPage: 1,
        SelectedFolderID: 0
    };



    $(document).ready(function() {
        BindControlEvents();
        LoadTree();
        LoadImages();
        BindEvents();
        SetAddress();
        InitializeToolTip();

        $('#btnUpdateFile').bind("click", function() {
            UpdateFile();
            ClosePopUp('#divEditPopUp');
        });

        $('#btnCreateFolder').bind("click", function() {
            CreateNewFolder();
            LoadTree();
        });

        $('#imbSearch').bind("click", function() {
            $.FileMgr.mode = "search";
            SearchFileList($('#txtSearch').val());
            $.FileMgr.CurrentPage = 1;
        });

        $('span.sfClosepopup').bind("click", function() {
            $('#fade , #popuprel , #popuprel2 , #popuprel3,#newFolderPopUp,#uploadFilePopUp,#divMessagePopUp,#divEditPopUp,#divSuccessPopUp,#divConfirmPopUp,#divCopyFiles').fadeOut();

        });

        $('#fade').live("click", function() {
            $('#fade , #popuprel , #popuprel2 , #popuprel3,#newFolderPopUp,#uploadFilePopUp,#divMessagePopUp,#divEditPopUp,#divSuccessPopUp,#divConfirmPopUp').fadeOut();
            return false;
        });

        $('#divControls li.sfRefresh').bind("click", function() {
            $('#divFileList').html('');
            $('#txtAddress').val('/');
            $('#divFileTree').html('');
            LoadTree();

        });

        ///Confirmation events
        $('#btnConfirmYes').bind("click", function() {
            switch ($.FileMgr.ConfirmMode) {
                case "single":
                    $('#divConfirmPopUp,#fade').fadeOut();
                    DeleteFile($.FileMgr.filePath);
                    break;
                case "multiple":
                    $('#divConfirmPopUp,#fade').fadeOut();
                    DeleteFiles();
                    break;
                case "folder":
                    $('#divConfirmPopUp,#fade').fadeOut();
                    DeleteFolder();
                    break;
                case "sync":
                    $('#divConfirmPopUp,#fade').fadeOut();
                    SynchronizeFiles();
                    break;
                case "extract":
                    $('#divConfirmPopUp,#fade').fadeOut();
                    ExtractFiles();
                    break;
            }

            $('#divConfirmPopUp,#fade').fadeOut();
        });
        $('#btnConfirmNo').bind("click", function() {
            $('#divConfirmPopUp,#fade').fadeOut();
        });

        $('#ddlPageSize').bind("change", function() {
            $('#divPagerNav,#divFileList').html('');
            $.FileMgr.CurrentPage = 1;

            var currentNav = 1;
            var pageSize = $('#ddlPageSize option:selected').val() == null ? 10 : $('#ddlPageSize option:selected').val();
            var navCount = $.FileMgr.RowCount / pageSize;

            if (currentNav <= 10) {
                CreatePagerNavModel1();
            }
            else if (currentNav > 10 && currentNav < (navCount - 10)) {
                CreatePagerNavModel2();
            }
            else if (currentNav >= (navCount - 10) || currentNav == navCount) {
                CreatePagerNavModel3();
            }
            else {
                CreatePagerNavModel1();
            }
            if ($.FileMgr.mode == "normal") {
                LoadFileList($.FileMgr.address);
            }
            else if ($.FileMgr.mode = "search") {
                LoadSearchedFiles();
            }
            HighlightSelectedPage();
            if ($.FileMgr.mode == "normal") {
                LoadFileList($.FileMgr.address);
            }
            else if ($.FileMgr.mode = "search") {
                LoadSearchedFiles();
            }
            CheckPagerNavVisibility();
        });

        $('#divPagerNav ul li[class="nav"]').live("click", function() {

            $.FileMgr.CurrentPage = $(this).find("a").text();
            var currentNav = $(this).find("a").text();
            var pageSize = $('#ddlPageSize option:selected').val() == null ? 10 : $('#ddlPageSize option:selected').val();
            var navCount = $.FileMgr.RowCount / pageSize;

            if (currentNav <= 10) {
                CreatePagerNavModel1();
            }
            else if (currentNav > 10 && currentNav < (navCount - 10)) {
                CreatePagerNavModel2();
            }
            else if (currentNav >= (navCount - 10) || currentNav == navCount) {
                CreatePagerNavModel3();
            }
            else {
                CreatePagerNavModel1();
            }
            if ($.FileMgr.mode == "normal") {
                LoadFileList($.FileMgr.address);
            }
            else if ($.FileMgr.mode = "search") {
                LoadSearchedFiles();
            }
            HighlightSelectedPage();

        });



        $('#divPagerNav ul li[class="prev"]').live("click", function() {
            var currentNav = $.FileMgr.CurrentPage;

            if (currentNav > 1) {
                $.FileMgr.CurrentPage = parseInt($.FileMgr.CurrentPage) - 1;
                var pageSize = $('#ddlPageSize option:selected').val() == null ? 10 : $('#ddlPageSize option:selected').val();
                var navCount = $.FileMgr.RowCount / pageSize;

                if (currentNav <= 10) {
                    CreatePagerNavModel1();
                }
                else if (currentNav > 10 && currentNav < (navCount - 10)) {
                    CreatePagerNavModel2();
                }
                else if (currentNav >= (navCount - 10) || currentNav == navCount) {
                    CreatePagerNavModel3();
                }
                else {
                    CreatePagerNavModel1();
                }
                if ($.FileMgr.mode == "normal") {
                    LoadFileList($.FileMgr.address);
                }
                else if ($.FileMgr.mode = "search") {
                    LoadSearchedFiles();
                }

                HighlightSelectedPage();
            }
        });
        $('#divPagerNav ul li[class="next"]').live("click", function() {
            var currentNav = $.FileMgr.CurrentPage;
            var pageSize = $('#ddlPageSize option:selected').val() == null ? 10 : $('#ddlPageSize option:selected').val();
            var navCount = $.FileMgr.RowCount / pageSize;

            if (currentNav < navCount) {
                $.FileMgr.CurrentPage = parseInt($.FileMgr.CurrentPage) + 1;

                if (currentNav <= 10) {
                    CreatePagerNavModel1();
                }
                else if (currentNav > 10 && currentNav < (navCount - 10)) {
                    CreatePagerNavModel2();
                }
                else if (currentNav >= (navCount - 10) || currentNav == navCount) {
                    CreatePagerNavModel3();
                }
                else {
                    CreatePagerNavModel1();
                }
                if ($.FileMgr.mode == "normal") {
                    LoadFileList($.FileMgr.address);
                }
                else if ($.FileMgr.mode = "search") {
                    LoadSearchedFiles();
                }
                HighlightSelectedPage();
            }
        });

        $('#ddlPageSize').append('<option>10</option>');


    });

    function HighlightSelectedPage() {
        var list = $('#divPagerNav ul li');
        $.each(list, function(index, item) {
            if ($.FileMgr.CurrentPage == $(this).find("a").text()) {
                $(this).addClass("currentPage");
            }
            else {
                $(this).removeClass("currentPage");
            }
        });
    }

    function BindControlEvents() {
        $('#divControls li.sfUpload').bind("click", function() {
            if ($.FileMgr.address == "/") {
                ShowMessagePopUp("divMessagePopUp", "Please select a folder");
            }
            else {
                var param = JSON.stringify({ filePath: $.FileMgr.destinationPath, folderId: parseInt($.FileMgr.folderId) });
                var method = FileManagerPath + 'WebMethods/WebMethods.aspx/SetFilePath';
                $.jsonRequest(method, param, successFn);
                ShowPopUp("uploadFilePopUp");
            }
        });
        $('#imgAddFile').bind("click", function() {
            if ($.FileMgr.address == "/") {
                ShowMessagePopUp("divMessagePopUp", "Please select a folder");
            }
            else {
                var param = JSON.stringify({ filePath: $.FileMgr.destinationPath, folderId: parseInt($.FileMgr.folderId) });
                var method = FileManagerPath + 'WebMethods/WebMethods.aspx/SetFilePath';
                $.jsonRequest(method, param, successFn);
                ShowPopUp("uploadFilePopUp");
            }
        });
        $('li.sfAddfolder').bind("click", function() {
            if ($.FileMgr.address == "/") {
                ShowMessagePopUp("divMessagePopUp", "Please select a folder");
            }
            else {
                ShowPopUp("newFolderPopUp");
            }
        });
        $('#imgDelFile').bind("click", function() {
            var count = 0;
            $('#fileList tr').each(function(index) {
                var checkbox = $(this).find("span[class='check']").find("input");
                if ($(checkbox).attr("checked") == true) {
                    count++;
                }
            });
            if (count > 0) {
                $.FileMgr.ConfirmMode = "multiple";
                ShowConfirmPopUp("Are you sure you want to delete?");
            }
            else {
                ShowMessagePopUp("divMessagePopUp", "No files selected");
            }

        });
        $('#imgDelFolder').bind("click", function() {
            $.FileMgr.ConfirmMode = "folder";
            ShowConfirmPopUp("Are you sure you want to delete?");
        });


        $('.closePopUp').bind("click", function() {
            $('#fade , #popuprel , #popuprel2 , #popuprel3,#newFolderPopUp,#uploadFilePopUp,#divMessagePopUp,#divEditPopUp,#divSuccessPopUp,#divConfirmPopUp,#divCopyFiles').fadeOut();

        });
        $('#divControls li.sfDelete').bind("click", function() {
            var count = 0;
            $('#fileList tr').each(function(index) {
                var checkbox = $(this).find("span[class='check']").find("input");
                if ($(checkbox).attr("checked") == true) {
                    count++;
                }
            });
            if (count > 0) {
                $.FileMgr.ConfirmMode = "multiple";
                ShowConfirmPopUp("Are you sure you want to delete?");
            }
            else {
                ShowMessagePopUp("divMessagePopUp", "No files selected");
            }
        });

        $('#divControls li.sfCopy').bind("click", function() {
            var count = 0;
            $('#fileList tr').each(function(index) {
                var checkbox = $(this).find("span[class='check']").find("input");
                if ($(checkbox).attr("checked") == true) {
                    count++;
                }
            });
            if (count > 0) {
                $.FileMgr.mode = "copy";
                ShowCopyPopUp();
            }
            else {
                ShowMessagePopUp("divMessagePopUp", "No files selected");
            }
        });

        $('#btnCopy').bind("click", function() {
            $('#fileList tr').each(function(index) {
                var checkbox = $(this).find("span[class='check']").find("input");
                if ($(checkbox).attr("checked") == true && $.FileMgr.toFolderId != 0) {
                    var _fileId = $(checkbox).attr("id").replace(/[^0-9]/gi, '') + "-";
                    var _filePath = $(this).find("a[class='delete']").attr("rel");
                    var _folderId = $.FileMgr.folderId;
                    var _toFolderId = $.FileMgr.toFolderId;
                    var _fromPath = $.FileMgr.destinationPath;
                    var _toPath = $.FileMgr.copyPath;
                    var param = JSON.stringify({ fileId: parseInt(_fileId), filePath: _filePath, folderId: parseInt(_folderId), toFolderId: parseInt(_toFolderId), fromPath: _fromPath, toPath: _toPath });
                    var method = "";
                    if ($.FileMgr.mode == "copy")
                        method = FileManagerPath + 'WebMethods/WebMethods.aspx/CopyFile';
                    else if ($.FileMgr.mode == "move") {
                        method = FileManagerPath + 'WebMethods/WebMethods.aspx/MoveFile';
                    }
                    $.ajax({
                        type: "POST",
                        url: method,
                        contentType: "application/json; charset=utf-8",
                        data: param,
                        dataType: "json",
                        success: function(msg) {

                            ClosePopUp("#divCopyFiles");

                            if ($.FileMgr.mode == "copy") {
                                ShowMessagePopUp("divMessagePopUp", "Files Copied Successfully");

                            }
                            else if ($.FileMgr.mode == "move") {
                                ShowMessagePopUp("divMessagePopUp", "Files Moved Successfully");
                            }
                            BindPageSizeDropdown();
                            $.FileMgr.CurrentPage = 1;

                        },
                        error: function(msg) { errorFn(); }
                    });

                }

            });

        });
        ///move file
        $('#divControls li.sfMove').bind("click", function() {

            var count = 0;
            $('#fileList tr').each(function(index) {
                var checkbox = $(this).find("span[class='check']").find("input");
                if ($(checkbox).attr("checked") == true) {
                    count++;
                }
            });

            if (count > 0) {
                $.FileMgr.mode = "move";
                ShowCopyPopUp();
            }
            else {
                ShowMessagePopUp("divMessagePopUp", "No files selected");
            }
        });
        $('#divControls li.sfDeletefolder').bind("click", function() {
            $.FileMgr.ConfirmMode = "folder";
            ShowConfirmPopUp("Are you sure you want to delete?");
        });

        $('#divControls li.sfSync').bind("click", function() {
            $.FileMgr.ConfirmMode = "sync";
            ShowConfirmPopUp("Are you sure you want to synchronize?");
        });

    }

    function DeleteFiles() {
        $('#fileList tr').each(function(index) {
            var checkbox = $(this).find("span[class='check']").find("input");
            if ($(checkbox).attr("checked") == true) {
                var _fileId = $(checkbox).attr("id").replace(/[^0-9]/gi, '') + "-";
                var _filePath = $(this).find("a[class='delete']").attr("rel");
                var _folderId = $.FileMgr.folderId;
                var param = JSON.stringify({ filePath: _filePath, folderId: parseInt(_folderId), fileId: parseInt(_fileId) });
                var method = FileManagerPath + 'WebMethods/WebMethods.aspx/DeleteFile';
                $.ajax({
                    type: "POST",
                    url: method,
                    contentType: "application/json; charset=utf-8",
                    data: param,
                    dataType: "json",
                    success: function(msg) {
                        $.FileMgr.CurrentPage = 1;
                        BindPageSizeDropdown();
                        ShowMessagePopUp("divMessagePopUp", msg.d);

                    },
                    error: function(msg) { ShowMessagePopUp("divMessagePopUp", msg.d); }
                });
            }
        });
    }
    function SynchronizeFiles() {
        var method = FileManagerPath + 'WebMethods/WebMethods.aspx/Synchronize';
        $.ajax({
            type: "POST",
            url: method,
            contentType: "application/json; charset=utf-8",
            data: JSON2.stringify({ UserModuleID: parseInt($.FileMgr.UserModuleID) }),
            dataType: "json",
            success: function(msg) {
                LoadFileList($.FileMgr.uploadFolder);
                ShowMessagePopUp("divMessagePopUp", "Synchronization Complete");
                BindPageSizeDropdown();
                $.FileMgr.CurrentPage = 1;

            },
            error: function(msg) {
                ShowErrorPopUp("Could not synchronize file");
            }
        });
    }

    function InitializeToolTip() {
        $('#divBottomControls li img').tooltip({ effect: 'fade', position: 'bottom center' });
    }

    function CloseCopyPopUp() {
        $('#divCopyFiles,#divEditPopUp').fadeOut();
        $.FileMgr.mode = "normal";
    }
    function DeleteFolder() {
        ///Get the selected folder
        if ($.FileMgr.address == "/") {
            ShowPopUp("divMessagePopUp", "No Folder selected");
        }
        else {
            var selectedFolder = $.FileMgr.uploadFolder;
            var _folderId = $.FileMgr.folderId;
            var param = JSON.stringify({ filePath: selectedFolder, folderId: parseInt(_folderId), fileId: 0 });


            var method = FileManagerPath + 'WebMethods/WebMethods.aspx/DeleteFile';
            $.ajax({
                type: "POST",
                url: method,
                contentType: "application/json; charset=utf-8",
                data: param,
                dataType: "json",
                success: function(msg) {
                    ShowMessagePopUp("divMessagePopUp", msg.d);
                    LoadTree();
                },
                error: function(msg) {
                    ShowMessagePopUp("divMessagePopUp", msg.d);
                }
            });
        }
    }
    function BindEvents() {
        $('#fileList li a.download_link').live("click", function(e) {
            var el = $(this).closest("li").attr("class");
            if (el != "directory collapsed") {
            }
            else {
                var path = $(this).attr("rel");
                LoadFileList(path);
            }

        });

        $('#fileList tr a.delete').bind("click", function() {
            var el = $(this).attr("rel");
            $.FileMgr.fileId = $(this).parents("tr").find("a[class='download_link']").attr("rel");
            $.FileMgr.ConfirmMode = "single";
            $.FileMgr.filePath = el;
            ShowConfirmPopUp("Are you sure you want to delete?");
        });

        $('#fileList tr a.edit').bind("click", function() {

            $.FileMgr.fileId = $(this).parents("tr").children("td").find("a.download_link").attr("rel");

            var fileName = $(this).parents("tr").children("td").find("a.download_link").text();
            var el = $(this).attr("rel");
            var attr = $(this).parents("tr").children("td").find("span.info").children("span.attr").text();
            $.FileMgr.filePath = el;
            ShowEditPopUp(fileName, attr);


        });

        $('#fileList tr a.decompress').bind("click", function() {
            $.FileMgr.ConfirmMode = "extract";
            $.FileMgr.filepath = $(this).attr("rel");
            ShowConfirmPopUp("Do you want to extract the files?");
        });


        $('#fileList tr a.preview').lightBox({
            imageBtnClose: FileManagerPath + "images/lightbox-btn-close.gif",
            imageLoading: FileManagerPath + "images/lightbox-ico-loading.gif",
            imageBtnNext: FileManagerPath + "images/lightbox-btn-next.gif",
            imageBtnPrev: FileManagerPath + "images/lightbox-btn-prev.gif",
            imageBlank: FileManagerPath + "images/lightbox-blank.gif"
        });


        $('#fileList th span.fileName').bind("click", function() {
            var fldrId = $.FileMgr.folderId;
            var pageSize = $('#ddlPageSize option:selected').val();
            var param = JSON.stringify({ filePath: $.FileMgr.uploadFolder, folderId: parseInt(fldrId), UserID: parseInt($.FileMgr.UserID), IsSort: 1, UserModuleID: parseInt($.FileMgr.UserModuleID), UserName: $.FileMgr.UserName, CurrentPage: parseInt($.FileMgr.CurrentPage), PageSize: parseInt(pageSize) });
            var method = FileManagerPath + 'WebMethods/WebMethods.aspx/GetFileList';
            $.jsonRequest(method, param, BindFileList);

        });



        $('#chkSelectAll').bind("click", function() {
            if ($(this).attr("checked") == true) {
                $('#fileList tr').each(function(index) {
                    $(this).find("span[class='check']").find("input").attr("checked", true);
                });
            }
            else {
                $('#fileList tr').each(function(index) {
                    $(this).find("span[class='check']").find("input").attr("checked", false);
                });
            }

        });


    }

    function ExtractFiles() {
        var fileName = $.FileMgr.filepath;
        var param = JSON.stringify({ FilePath: fileName, FolderID: parseInt($.FileMgr.folderId), UserModuleID: parseInt($.FileMgr.UserModuleID) });
        var method = FileManagerPath + 'WebMethods/WebMethods.aspx/UnzipFiles';
        $.ajax({
            type: "POST",
            url: method,
            contentType: "application/json; charset=utf-8",
            data: param,
            dataType: "json",
            success: function(msg) {
                LoadFileList($.FileMgr.uploadFolder);
                if (msg.d.length == 0) {
                    ShowMessagePopUp("divMessagePopUp", "File already extracted");
                }
                else {
                    ShowMessagePopUp("divMessagePopUp", msg.d);
                }
            },
            error: function(msg) { ShowMessagePopUp("divMessagePopUp", "Extraction Failed"); }
        });
    }

    function UpdateFile() {
        var fileName = $('#txtEditFileName').val();
        var _attrString = GetAttrString();
        var param = JSON.stringify({ fileId: parseInt($.FileMgr.fileId), folderId: parseInt($.FileMgr.folderId), fileName: fileName, filePath: $.FileMgr.filePath, attrString: _attrString });
        var method = FileManagerPath + 'WebMethods/WebMethods.aspx/UpdateFile';
        $.ajax({
            type: "POST",
            url: method,
            contentType: "application/json; charset=utf-8",
            data: param,
            dataType: "json",
            success: function(msg) {
                LoadFileList($.FileMgr.uploadFolder);
            },
            error: function(msg) {
                ShowErrorPopUp("Could not update the file");
            }
        });
    }

    function GetAttrString() {

        var attrString = "";

        if ($('#chkArchive').attr("checked") == true) {
            attrString += "A-";
        }
        if ($('#chkRead').attr("checked") == true) {
            attrString += "R-";
        }
        if ($('#chkSystem').attr("checked") == true) {
            attrString += "S-";
        }
        if ($('#chkHidden').attr("checked") == true) {
            attrString += "H-";
        }
        attrString = attrString.substring(0, attrString.length - 1);
        return attrString;
    }

    function RemoveSelected() {
        var tree = $('#divFileTree ul li');
        if (tree.length > 0) {
            $.each(tree, function(index, item) {
                $(this).find("a").removeClass("cssClassTreeSelected");
                $(this).find("a").removeClass("cssClassTreeSelectedDB");
                $(this).find("a").removeClass("cssClassTreeSelectedLocked");
            });
        }

    }

    function ClearChecks() {
        var checks = $('.ulPermission li ul[class="header"] li[class="check"]');
        $.each(checks, function(i, itm) {
            var role = $(this).parent().find("li[class='role']").text().toLowerCase().replace(/ /g, '');
            if (role != "superuser" && role != "siteadmin")
                $(this).find("input").attr("checked", false);

        });

    }
    function LoadTree() {
        $('#divFileTree').html('');
        $('#divFileTree').fileTree({
            root: "/",
            script: FileManagerPath + 'js/script.aspx',
            expandSpeed: 300,
            collapseSpeed: 300,
            multiFolder: false
        }, function(file) {
            alert(file);
        },
             function(dir) {
                 if ($.FileMgr.mode == "search") {
                     $.FileMgr.mode = "normal";
                 }

                 RemoveSelected();
                 var directory = dir.substring(0, dir.indexOf('##'));
                 $.FileMgr.SelectedFolderID = dir.substring(dir.indexOf('##') + 2, dir.length) == "" ? 0 : dir.substring(dir.indexOf('##') + 2, dir.length);
                 //Check for permission keys

                 if ($.FileMgr.mode == "normal") {
                     $.FileMgr.folderId = dir.substring(dir.indexOf('##') + 2, dir.length) == "" ? 0 : dir.substring(dir.indexOf('##') + 2, dir.length);
                     //set the current path to session
                     $.FileMgr.destinationPath = directory;
                     $.FileMgr.address = directory;
                     BindPageSizeDropdown();
                     $.FileMgr.CurrentPage = 1;

                 }
                 else if ($.FileMgr.mode == "copy" || $.FileMgr.mode == "move") {
                     $.FileMgr.copyPath = directory;
                     $.FileMgr.toFolderId = dir.substring(dir.indexOf('##') + 2, dir.length) == "" ? 0 : dir.substring(dir.indexOf('##') + 2, dir.length);

                 }

                 $.FileMgr.address = directory;
                 SetAddress();
                 $('#divFileUpload').live("click", function() {
                     ShowPopUp("uploadFilePopUp");
                 });

             });
    }





    function AddSelectStyle() {
        var folderId = $.FileMgr.folderId;
    }

    function LoadFileList(_fileName) {
        $.FileMgr.uploadFolder = _fileName;
        var fldrId = $.FileMgr.SelectedFolderID;
        if ($.FileMgr.mode == "copy" || $.FileMgr.mode == "move") {
            fldrId = $.FileMgr.toFolderId;
        }

        var pageSize = $('#ddlPageSize option:selected').val() == null ? 10 : $('#ddlPageSize option:selected').val();
        var param = JSON.stringify({ filePath: _fileName, folderId: parseInt(fldrId), UserID: parseInt($.FileMgr.UserID), IsSort: 0, UserModuleID: parseInt($.FileMgr.UserModuleID), UserName: $.FileMgr.UserName, CurrentPage: parseInt($.FileMgr.CurrentPage), PageSize: parseInt(pageSize) });

        var method = FileManagerPath + 'WebMethods/WebMethods.aspx/GetFileList';
        $.jsonRequest(method, param, BindFileList);
    }

    function SearchFileList(_SearchQuery) {
        $('#ddlPageSize').html('');
        $('#divPagerNav').html('');

        var method = FileManagerPath + 'WebMethods/WebMethods.aspx/GetSearchCount';
        $.ajax({
            type: "POST",
            url: method,
            contentType: "application/json; charset=utf-8",
            data: JSON2.stringify({ SearchQuery: _SearchQuery, UserModuleID: parseInt($.FileMgr.UserModuleID), UserName: $.FileMgr.UserName }),
            dataType: "json",
            success: function(msg) {
                $.FileMgr.RowCount = msg.d;
                var html = '';
                if (msg.d < 10) {
                    html += '<option>10</option>';
                }
                else {
                    for (var i = 0; i <= $.FileMgr.RowCount; i += 10) {
                        if (i == 0) {
                            //html += '<option>All</option>';
                        }
                        else if (i < 75) {
                            html += '<option>' + i + '</option>';
                        }
                    }
                }

                $('#ddlPageSize').append(html);
                CreatePagerNavModel1();
                LoadSearchedFiles(_SearchQuery);


            },
            error: function(msg) { alert("error"); }
        });


    }
    function LoadSearchedFiles() {
        var _UserModuleID = $.FileMgr.UserModuleID;
        var _UserName = $.FileMgr.UserName;
        var _SearchQuery = $('#txtSearch').val();
        var pageSize = $('#ddlPageSize option:selected').val() == null ? 10 : $('#ddlPageSize option:selected').val();
        var param = JSON.stringify({ SearchQuery: _SearchQuery, UserModuleID: parseInt(_UserModuleID), UserName: _UserName, CurrentPage: parseInt($.FileMgr.CurrentPage), PageSize: parseInt(pageSize) });
        var method = FileManagerPath + 'WebMethods/WebMethods.aspx/SearchFiles';
        $.jsonRequest(method, param, BindFileList);

    }

    function BindFileList(data) {
        $('#divFileList').html('');
        $('#divFileList').append(data);
        BindEvents();

    }

    function DeleteFile(path) {
        var _folderId = $.FileMgr.folderId;
        var _fileId = $.FileMgr.fileId;
        var param = JSON.stringify({ filePath: path, folderId: parseInt(_folderId), fileId: parseInt(_fileId) });
        var method = FileManagerPath + 'WebMethods/WebMethods.aspx/DeleteFile';
        $.ajax({
            type: "POST",
            url: method,
            contentType: "application/json; charset=utf-8",
            data: param,
            dataType: "json",
            success: function(msg) {
                ShowSuccessPopUp(msg.d);
                $.FileMgr.CurrentPage = 1;
                BindPageSizeDropdown();
            },
            error: function(msg) { errorFn(); }
        });
    }

    (function($) {
        $.jsonRequest = function(url, para, successFn) {
            $.ajax({
                type: "POST",
                url: url,
                cache: true,
                contentType: "application/json; charset=utf-8",
                data: para,
                dataType: "json",
                success: function(msg) { successFn(msg.d); },
                error: function(msg) { errorFn(); }
            });
        }

    })(jQuery);


    function errorFn() {
        alert("Error");
    }
    function successFn() {

    }


    function ClosePopUp(divId) {
        $(divId).fadeOut();
        $('#fade , #popuprel , #popuprel2 , #popuprel3,#newFolderPopUp,#uploadFilePopUp,#divMessagePopUp,#divEditPopUp,#divConfirmPopUp').fadeOut();
    }
    function ShowCopyPopUp() {
        $('#divCopyFiles').fadeIn();
        var popuptopmargin = ($('#divCopyFiles').height() + 10) / 2;
        var popupleftmargin = ($('#divCopyFiles').width() + 10) / 2;
        $('#divCopyFiles').css({
            'margin-top': -popuptopmargin,
            'margin-left': -popupleftmargin
        });
        if ($.FileMgr.mode == "copy") {
            $('#hAction').text("Copy Files");
            $('#copyMessage').text("Select the target folder you want to copy to");
            $('#btnCopy').attr("value", "Copy");
        }
        else if ($.FileMgr.mode = "move") {
            $('#hAction').text("Move Files");
            $('#copyMessage').text("Select the target folder you want to move to");
            $('#btnCopy').attr("value", "Move");
        }
    }
    function ShowEditPopUp(fileName, attr) {
        ShowPopUp("divEditPopUp");
        $('#txtEditFileName').val(fileName);
        if (attr.indexOf("A") > -1) {
            $('#chkArchive').attr("checked", true);
        }
        if (attr.indexOf("R") > -1) {
            $('#chkRead').attr("checked", true);
        }
        if (attr.indexOf("S") > -1) {
            $('#chkSystem').attr("checked", true);
        }
        if (attr.indexOf("H") > -1) {
            $('#chkHidden').attr("checked", true);
        }

    }

    function CreateNewFolder() {
        var _folderName = $('#txtFolderName').val();
        var _fileType = $('#ddlFileType option:selected').val();
        var param = JSON.stringify({ FolderID: parseInt($.FileMgr.folderId), filePath: $.FileMgr.uploadFolder + _folderName, folderName: _folderName, fileType: parseInt(_fileType) });
        var method = FileManagerPath + 'WebMethods/WebMethods.aspx/CreateFolder';
        $.ajax({
            type: "POST",
            url: method,
            contentType: "application/json; charset=utf-8",
            data: param,
            dataType: "json",
            success: function(msg) {
                LoadFileList($.FileMgr.uploadFolder);
            },
            error: function(msg) { errorFn(); }
        });

        BindEvents();
        ClosePopUp("#newFolderPopUp");
    }

    function ImageUploader() {
        var upload = new AjaxUpload($('#fileUpload'), {
            action: FileManagerPath + 'FileUploadHandler.aspx?FolderID=' + $.FileMgr.folderId + '',
            name: 'myfile[]',
            multiple: false,
            data: {},
            autoSubmit: true,
            responseType: 'json',
            onChange: function(file, ext) {

            },
            onSubmit: function(file, ext) {
                var data = GetValidExtensions();
                if (data.indexOf(ext.toLowerCase()) > -1) {

                    $("#uploadFilePopUp,#fade").hide();
                }
                else {
                    ClosePopUp("#uploadFilePopUp");
                    ShowMessagePopUp("divMessagePopUp", "Not a valid file");
                    return false;
                }
            },
            onComplete: function(file, response) {

                $.FileMgr.mode = "normal";
                BindPageSizeDropdown();

            }
        });
    }

    function GetValidExtensions() {
        var method = FileManagerPath + 'WebMethods/WebMethods.aspx/GetExtensions';
        var param = JSON2.stringify({ UserModuleID: parseInt($.FileMgr.UserModuleID), PortalID: parseInt($.FileMgr.PortalID) });
        var data = "";
        $.ajax({
            type: "POST",
            url: method,
            contentType: "application/json; charset=utf-8",
            data: param,
            dataType: "json",
            async: false,
            success: function(msg) {
                data = msg.d;
            },
            error: function(msg) { errorFn(); }
        });
        return data;
    }
    function SetAddress() {
        $('#txtAddress').val($.FileMgr.address);
    }

    function LoadImages() {
        $('#imbUpload').attr("src", FileManagerPath + "images/btnUpload.png");
        $('#imgDeleteFile').attr("src", FileManagerPath + "images/delete_page.png");
        $('#imgDeleteFolder').attr("src", FileManagerPath + "images/delete_folder.png");
        $('#imgCopy').attr("src", FileManagerPath + "images/Copy-icon.png");
        $('#imgMove').attr("src", FileManagerPath + "images/lnkrestart.png");
        $('#imgRefresh').attr("src", FileManagerPath + "images/btnRefresh.png");
        $('#imgSync').attr("src", FileManagerPath + "images/sync.png");
        $('#imbSearch').attr("src", FileManagerPath + "images/search.png");
        $('#imgPermission').attr("src", FileManagerPath + "images/btnsetting.png");
        $('#imgAddFile').attr("src", FileManagerPath + "images/addfile.png");
        $('#imgAddFolder').attr("src", FileManagerPath + "images/addfolder.png");
        $('#imgDelFile').attr("src", FileManagerPath + "images/deletefile.png");
        $('#imgDelFolder').attr("src", FileManagerPath + "images/deletefolder.png");
        $('#imgCancelCopy,#imgCancelEdit,#imgNewFolder,#imgUpload,#imgMessage,#imgConfirmDelete,#imgSuccessClose,#imgErrorClose,#imgEditPopUp').attr("src", FileManagerPath + "images/cancel.png");


    }

    function ShowPopUp(popupid) {

        $('#' + popupid).fadeIn();
        $('body').append('<div id="fade"></div>');
        $('#fade').css({ 'filter': 'alpha(opacity=80)' }).fadeIn();
        var popuptopmargin = ($('#' + popupid).height() + 10) / 2;
        var popupleftmargin = ($('#' + popupid).width() + 10) / 2;
        $('#' + popupid).css({
            'margin-top': -popuptopmargin,
            'margin-left': -popupleftmargin
        });

        switch (popupid) {
            case "uploadFilePopUp":
                ImageUploader();
                break;
        }

    }
    function ShowMessagePopUp(popupid, message) {

        $('#' + popupid).show();
        $('body').append('<div id="fade"></div>');
        $('#fade').css({ 'filter': 'alpha(opacity=80)' }).show();
        var popuptopmargin = ($('#' + popupid).height() + 10) / 2;
        var popupleftmargin = ($('#' + popupid).width() + 10) / 2;
        $('#' + popupid).css({
            'margin-top': -popuptopmargin,
            'margin-left': -popupleftmargin
        });

        $('.cssClassMessage').text(message);

    }
    function ShowConfirmPopUp(message) {

        $('#divConfirmPopUp').show();
        $('body').append('<div id="fade"></div>');
        $('#fade').css({ 'filter': 'alpha(opacity=80)' }).show();
        var popuptopmargin = ($('#divConfirmPopUp').height() + 10) / 2;
        var popupleftmargin = ($('#divConfirmPopUp').width() + 10) / 2;
        $('#divConfirmPopUp').css({
            'margin-top': -popuptopmargin,
            'margin-left': -popupleftmargin
        });
        $('.sfConfirmmsg').text(message);

    }
    function ShowSuccessPopUp(message) {

        $('#divSuccessPopUp').show();
        $('body').append('<div id="fade"></div>');
        $('#fade').css({ 'filter': 'alpha(opacity=80)' }).show();
        var popuptopmargin = ($('#divSuccessPopUp').height() + 10) / 2;
        var popupleftmargin = ($('#divSuccessPopUp').width() + 10) / 2;
        $('#divSuccessPopUp').css({
            'margin-top': -popuptopmargin,
            'margin-left': -popupleftmargin
        });

        $('.cssClassSuccessMessage').text(message);

        $('#divSuccessPopUp').delay(1000).hide();
        $('#fade').delay(1000).fadeOut();

    }
    function ShowErrorPopUp(message) {

        $('#divErrorPopUp').show();
        $('body').append('<div id="fade"></div>');
        $('#fade').css({ 'filter': 'alpha(opacity=80)' }).show();
        var popuptopmargin = ($('#divErrorPopUp').height() + 10) / 2;
        var popupleftmargin = ($('#divErrorPopUp').width() + 10) / 2;
        $('#divErrorPopUp').css({
            'margin-top': -popuptopmargin,
            'margin-left': -popupleftmargin
        });

        $('.cssClassErrorMessage').text(message);

        $('#divErrorPopUp').delay(1000).hide();
        $('#fade').delay(1000).hide();

    }


    ///Pager area
    function CreatePagerNavModel1() {
        $('#divPagerNav').html('');
        var pageSize = $('#ddlPageSize option:selected').val() == null ? 10 : $('#ddlPageSize option:selected').val();
        if ($.FileMgr.RowCount > pageSize) {
            var navCount = $.FileMgr.RowCount / pageSize;
            var pageCount = navCount * pageSize
            navCount = parseInt(navCount);
            if ($.FileMgr.RowCount > (navCount * pageSize)) {
                navCount++;
            }
            if (navCount > 15) {
                var html = "<ul class='simplePagerNav'>";
                html += '<li class="prev"><a href="#">Prev</a></li>';
                html += '<li class="nav"><a href="#">1</a></li>';
                html += '<li class="nav"><a href="#">2</a></li>';
                for (var i = 3; i <= 15; i++) {
                    html += '<li class="nav"><a href="#">' + i + '</a></li>';
                }
                html += '<li  class="MoreNav"><a href="#">.........</a></li>';
                html += '<li class="nav"><a href="#">' + parseInt(navCount - 2) + '</a></li>';
                html += '<li class="nav"><a href="#">' + parseInt(navCount - 1) + '</a></li>';
                html += '<li class="next"><a href="#">Next</a></li>';
                html += '</ul>';
            }
            else {
                var html = "<ul class='simplePagerNav'>";
                html += '<li class="prev"><a href="#">Prev</a></li>';
                for (var i = 1; i <= navCount; i++) {
                    html += '<li class="nav"><a href="#">' + i + '</a></li>';
                }
                html += '<li class="next"><a href="#">Next</a></li>';
                html += '</ul>';
            }

            $('#divPagerNav').append(html);
        }
        CheckPagerNavVisibility();
        HighlightSelectedPage();
    }

    function CreatePagerNavModel2() {
        $('#divPagerNav').html('');
        var pageSize = $('#ddlPageSize option:selected').val() == null ? 10 : $('#ddlPageSize option:selected').val();

        if ($.FileMgr.RowCount > pageSize) {
            var navCount = $.FileMgr.RowCount / pageSize;
            var pageCount = navCount * pageSize
            navCount = parseInt(navCount);
            if ($.FileMgr.RowCount > (navCount * pageSize)) {
                navCount++;
            }
            var currentPage = $.FileMgr.CurrentPage;
            var startIndex = currentPage - 5;
            var endIndex = parseInt(currentPage) + 5;
            var html = "<ul class='simplePagerNav'>";
            html += '<li class="prev"><a href="#">Prev</a></li>';
            html += '<li class="nav"><a href="#">1</a></li>';
            html += '<li class="nav"><a href="#">2</a></li>';
            html += '<li  class="MoreNav"><a href="#">.........</a></li>';
            for (var i = startIndex; i <= endIndex; i++) {
                html += '<li class="nav"><a href="#">' + i + '</a></li>';
            }
            html += '<li  class="MoreNav"><a href="#">.........</a></li>';
            html += '<li class="nav"><a href="#">' + parseInt(navCount - 2) + '</a></li>';
            html += '<li class="nav"><a href="#">' + parseInt(navCount - 1) + '</a></li>';
            html += '<li class="next"><a href="#">Next</a></li>';
            html += '</ul>';



            $('#divPagerNav').append(html);
        }
        CheckPagerNavVisibility();
        HighlightSelectedPage();
    }
    function CreatePagerNavModel3() {
        $('#divPagerNav').html('');
        var pageSize = $('#ddlPageSize option:selected').val() == null ? 10 : $('#ddlPageSize option:selected').val();

        if ($.FileMgr.RowCount > pageSize) {
            var navCount = $.FileMgr.RowCount / pageSize;
            var pageCount = navCount * pageSize
            navCount = parseInt(navCount);
            if ($.FileMgr.RowCount > (navCount * pageSize)) {
                navCount++;
            }
            var currentPage = $.FileMgr.CurrentPage;
            var startIndex = navCount - 15;
            var endIndex = navCount;

            var html = "<ul class='simplePagerNav'>";
            html += '<li class="prev"><a href="#">Prev</a></li>';
            html += '<li class="nav"><a href="#">1</a></li>';
            html += '<li class="nav"><a href="#">2</a></li>';
            html += '<li  class="MoreNav"><a href="#">.........</a></li>';
            for (var i = startIndex; i <= endIndex; i++) {
                html += '<li class="nav"><a href="#">' + i + '</a></li>';
            }

            html += '<li class="next"><a href="#">Next</a></li>';
            html += '</ul>';
            $('#divPagerNav').append(html);

        }
        HighlightSelectedPage();
    }

    function BindPageSizeDropdown() {
        $('#ddlPageSize').html('');
        var method = FileManagerPath + 'WebMethods/WebMethods.aspx/GetCount';

        $.ajax({
            type: "POST",
            url: method,
            contentType: "application/json; charset=utf-8",
            data: JSON2.stringify({ FolderID: parseInt($.FileMgr.SelectedFolderID) }),
            dataType: "json",
            success: function(msg) {
                $.FileMgr.RowCount = msg.d;
                var html = '';
                if (msg.d < 10) {
                    html += '<option>10</option>';
                }
                else {
                    for (var i = 0; i <= $.FileMgr.RowCount; i += 10) {
                        if (i == 0) {
                            //html += '<option>All</option>';
                        }
                        else if (i < 75) {
                            html += '<option>' + i + '</option>';
                        }
                    }
                }


                $('#ddlPageSize').append(html);
                LoadFileList($.FileMgr.address);
                $.FileMgr.mode = "normal";
                CreatePagerNavModel1();
            },
            error: function(msg) { alert("error"); }
        });
    }

    function CheckPagerNavVisibility() {
        var pageSize = $('#ddlPageSize option:selected').val();
        var status = parseInt(pageSize) * parseInt($.FileMgr.CurrentPage);
        if ($.FileMgr.CurrentPage === 1) {
            if (status > $.FileMgr.RowCount || status == $.FileMgr.RowCount) {
                $('#divPagerNav').html('');
            }
        }

    }
            
</script>

<h1> SageFrame File Manager</h1>
<div class="sfFilemanageholder sfMargintop">
  <div id="divFileTreeOuter">
    <div id="divFileTree"> </div>
  </div>
  <div class="sfRightcol">
    <div class="sfFormwrapper sfPadding clearfix">
      <div id="divControls">
        <ul>
          <li class="sfUpload">Add File</li>
          <li class="sfDelete">Delete File</li>
          <li class="sfAddfolder">Add Folder</li>
          <li class="sfDeletefolder">Delete Folder</li>
          <li class="sfCopy">Copy</li>
          <li class="sfMove">Move</li>
          <li class="sfRefresh">Refresh</li>
          <li class="sfSync">Sync</li>
        </ul>
        <div class="clear"> </div>
      </div>
      <div id="divSearch" class="clearfix">
        <div class="sfLeftdiv">
          <table border="0" cellspacing="0" cellpadding="0" class="sfFloatleft">
            <tr>
              <td><label class="sfFormlabel"> Address:</label></td>
              <td><input type="text" id="txtAddress" class="sfInputbox" disabled="disabled" /></td>
              <td><label class="sfFormlabel"> Search:</label></td>
              <td><input type="text" id="txtSearch" class="sfInputbox sfAuto" /></td>
              <td><img src="" id="imbSearch" /></td>
            </tr>
          </table>
        </div>
        <div class="sfRightdiv">
        <label class="sfFormlabel"> Items Per Page:</label>
          <select id="ddlPageSize" class="sfListmenu sfAuto">
          </select>
        </div>
      </div>
    </div>
    <div id="divFileList"> </div>
    <div id='divPagerNav' class="sfPagination clearfix"> </div>
  </div>
</div>
<div id="uploadFilePopUp" class="popupbox sfFormwrapper" style="height: 150px; width: 200px;
    background-color: #fff">
  <div class="ui-widget-header ui-corner-all"> <span class="ui-dialog-title" id="ui-dialog-title-divEditPopUp">FileMgrPopUp</span><a
            href="#" class="ui-dialog-titlebar-close ui-corner-all" role="button"><span class="sfClosepopup ui-icon ui-icon-closethick">close</span></a></div>
  <table>
    <tr>
      <%-- <td colspan="3">
                <span id="spnPath"></span>
            </td>
        </tr>--%>
    <tr>
      <td><span class="sfFormlabel">Browse Files: </span></td>
      <td><input type="file" id="fileUpload" class="fileClass" /></td>
    </tr>
  </table>
</div>
<div id="newFolderPopUp" class="popupbox sfFormwrapper">
  <div class="ui-widget-header ui-corner-all"> <span class="ui-dialog-title" id="Span1">Add New Folder</span><a href="#" class="ui-dialog-titlebar-close ui-corner-all"
            role="button"><span class="sfClosepopup ui-icon ui-icon-closethick">close</span></a></div>
  <table>
    <tr>
      <td><span class="sfFormlabel">FolderName:</span></td>
      <td><input type="text" id="txtFolderName" class="sfInputbox" /></td>
      <td></td>
    </tr>
    <tr>
      <td><span class="sfFormlabel">Type:</span></td>
      <td><select id="ddlFileType" class="sfListmenu">
          <option value="0">Standard</option>
          <option value="1">Secured</option>
          <option value="2">Database</option>
        </select></td>
      <td><div class="sfButtonwrapper">
          <input type="button" id="btnCreateFolder" class="sfBtn" value="Create" />
        </div></td>
    </tr>
  </table>
</div>
<div id="divEditPopUp" class="popupbox sfFormwrapper">
  <div class="ui-widget-header ui-corner-all"> <span class="ui-dialog-title" id="Span2">Edit File</span><a href="#" class="ui-dialog-titlebar-close ui-corner-all"
            role="button"><span class="sfClosepopup ui-icon ui-icon-closethick">close</span></a></div>
  <table>
    <tr>
      <td width="80px"><span class="sfFormlabel">FileName:</span></td>
      <td><input type="text" id="txtEditFileName" class="sfInputbox" /></td>
    </tr>
    <tr>
      <td><span class="sfFormlabel">File Mode:</span></td>
      <td><input type="checkbox" id="chkRead" value="R" />
        Read </td>
    </tr>
    <tr>
      <td></td>
      <td><input type="checkbox" id="chkSystem" value="W" />
        Write<br /></td>
    </tr>
    <tr>
      <td></td>
      <td><input type="checkbox" id="chkHidden" value="H" />
        Hidden<br /></td>
    </tr>
    <tr>
      <td></td>
      <td><input type="checkbox" id="chkArchive" value="A" />
        Archive<br /></td>
      <td><div class="sfButtonwrapper">
          <input type="button" id="btnUpdateFile" value="Update" />
        </div></td>
    </tr>
  </table>
</div>
<div id="divCopyFiles" class="popupbox">
  <div class="ui-widget-header ui-corner-all"> <span class="ui-dialog-title" id="Span3">Message</span><a href="#" class="ui-dialog-titlebar-close ui-corner-all"
            role="button"><span class="sfClosepopup ui-icon ui-icon-closethick"> close</span></a></div>
  <p id="copyMessage"> </p>
  <div class="sfButtonwrapper">
    <input type="button" id="btnCopy" class="cssClassBtn" value="" />
  </div>
</div>
<div id="divMessagePopUp" class="popupbox">
  <div class="ui-widget-header ui-corner-all"> <a href="#" class="ui-dialog-titlebar-close ui-corner-all" role="button"><span class="sfClosepopup ui-icon ui-icon-closethick"> close</span></a></div>
  <div class="cssClassFileManagerPopUP" style="text-align: center"> <span class="cssClassMessage sfFormlabel"></span> </div>
</div>
<div id="divSuccessPopUp" class="popupbox">
  <div class="ui-widget-header ui-corner-all"> <a href="#" class="ui-dialog-titlebar-close ui-corner-all" role="button"><span class="sfClosepopup ui-icon ui-icon-closethick"> close</span></a></div>
  <div class="cssClassFileManagerPopUP" style="text-align: center"> <span class="cssClassSuccessMessage sfFormlabel"></span> </div>
</div>
<div id="divErrorPopUp" class="popupbox">
  <div class="ui-widget-header ui-corner-all"> <span class="ui-dialog-title" id="Span6">Add New Folder</span><a href="#" class="ui-dialog-titlebar-close ui-corner-all"
            role="button"><span class="sfClosepopup ui-icon ui-icon-closethick">close</span></a></div>
  <div class="cssClassFileManagerPopUP" style="text-align: center"> <span class="cssClassErrorMessage sfFormlabel"></span> </div>
</div>
<div id="divConfirmPopUp" class="popupbox sfFormwrapper">
  <div class="ui-widget-header ui-corner-all"> <span class="ui-dialog-title" id="Span7">Confirmation</span><a href="#" class="ui-dialog-titlebar-close ui-corner-all"
            role="button"><span class="sfClosepopup ui-icon ui-icon-closethick">close</span></a></div>
  <span class="sfFormlabel sfConfirmmsg" style="text-align: center"></span>
  <div class="sfButtonwrapper" style="text-align: center">
    <input type="button" id="btnConfirmYes" value="Yes" style="float: none" class="sfBtn" />
    <input type="button" id="btnConfirmNo" value="No" style="float: none" class="sfBtn" />
  </div>
</div>
<asp:HiddenField ID="hdnDestinationPath" runat="server" Value="" />
