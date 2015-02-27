(function ($) {
    var param = {
        objOrder: []
    };
    $.SageWorkFlow = function (p) {
        p = $.extend({
            DivID: 'divNav1',
            UserModuleID: '',
            PortalID: 1,
            CultureCode: 'en-US',
            UserName: '',
            CheckUser: false,
            isTaskForModerator: false
        }, p);
        var WF = {
            config: {
                isPostBack: false,
                async: false,
                cache: false,
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                data: { data: '' },
                dataType: 'json',
                baseURL: SageFrameAppPath + '/Modules/ContentApprovalWorkFlow/Services/WebService.asmx/',
                method: "",
                url: "",
                categoryList: "",
                ajaxCallMode: 0,
                lstPagePermission: [],
                Mode: false,
                PageID: 0,
                PortalID: p.PortalID,
                arrUsers: [],
                NewID: "",
                Mode: "",
                IsPageDuplicate: false,
                ImagePath: SageFrameAppPath + '/Modules/ContentApprovalWorkFlow/Images/'
            },
            ajaxSuccess: function (data) {
                switch (parseInt(WF.config.ajaxCallMode)) {
                    case 0:
                        $('#sltUserList').html(data.d);
                        break;
                    case 1:
                        //WF.GetWFBasic();
                        WF.GetWFBasicList();
                        break;
                    case 2:
                        WF.SetBasic(data);
                        break;
                    case 3:
                        $('#sltUser').html(data.d);
                        $('#sltUser option:selected').val(1);
                        break;
                    case 4:
                        var option = '';
                        $.each(data.d, function (index, value) {
                            option += '<option value=' + value.RoleId + '>' + value.RoleName + '</option>';
                        });
                        $('#sltRole').html(option);
                        //WF.GetUserList($('#sltRole option:selected').val());
                        break;
                    case 5:
                        var TID = data.d;
                        WF.config.NewID = TID;
                        SageFrame.messaging.show("Task Added/Updated successfully.", "Success");
                        break;
                    case 6:
                        WF.BindTaskByID(data);
                        break;
                    case 7:
                        break;
                    case 8:

                        break;
                    case 9:
                        WF.BindContainFromData(data);
                        break;
                    case 10:
                        WF.DrawDiagram(data);
                        break;
                    case 11:
                        SageFrame.messaging.show("Content saved successfully.", "Success");
                        break;
                    case 12:
                        SageFrame.messaging.show("Content saved successfully and sent for approval.", "Success");
                        $('#divWorkContent').html("<p class='sfUnderDevelop'>Sent for approval.</p>");
                        break;
                    case 13:
                        var data = data.d;
                        $('#divWFList').html(data);
                        $('#divWFList').show();
                        $('#divWFedit').hide();
                        $('#assignModerator').hide();
                        $('#IsActive').val('0');
                        $('#editWFID').val('0');
                        $('#WFID').val('0');
                        WF.SetWFID();
                        break;
                    case 14:
                        $("#WFID").val(data.d);
                        WF.GetWFBasicList();
                        break;
                    case 15:
                        WF.GetWFBasicList();
                        SageFrame.messaging.show("WorkFlow deleted sucessfully.", "Success");
                        break;
                    case 16:

                        $('#divWorkContent').html(data.d);
                        delete CKEDITOR.instances['txtContent'];
                        $('#txtContent').ckeditor("config");
                        break;
                    case 17:
                        $('.divInbox li').append(data.d);
                        break;
                    case 18:
                        $('.notificationBar').find('#spnModNoti').text('0');
                        break;
                    case 19:
                        SageFrame.messaging.show("Content published sucessfully.", "Success");
                        break;
                    case 20:
                        WF.BindContainByID(data);
                        break;
                    case 21:
                        SageFrame.messaging.show("Reassigned Task sucessfully.", "Success");
                        break;
                    case 22:
                        WF.BindContainByLevel(data);
                        break;
                    case 23:
                        WF.BindWFStatus(data);
                        break;

                }
            },
            ajaxFailure: function () {
                //SageFrame.messaging.show("Some kind of error occured", "Error");
            },
            ajaxCall: function (config) {
                $.ajax({
                    type: this.config.type,
                    contentType: this.config.contentType,
                    cache: this.config.cache,
                    url: this.config.url,
                    data: this.config.data,
                    dataType: this.config.dataType,
                    success: this.ajaxSuccess,
                    error: this.ajaxFailure,
                    async: false
                });
            },
            init: function () {
                this.BindEvents();
                $('#txtContent').ckeditor("config");
            },
            BindEvents: function () {
                var v = $("#form1").validate({
                    ignore: ':hidden',
                    rules: {
                        txtWorkFlowName: { required: true },
                        txtTaskName: { required: true },
                        txtDescription: { required: true }

                    },
                    messages: {
                        txtWorkFlowName: "WorkFlow name should not be blank.",
                        txtTaskName: "Task Name should not be blank.",
                        txtDescription: "Task Description should not be blank."
                    }
                });
                $("#divWF").tabs();
                if (p.CheckUser === 'False') {
                    $('#ui-id-2').remove();
                }
                if (p.isTaskForModerator === 'False') {
                    $('#ui-id-3').remove();
                }

                //                $(".divModeratorName").on('click', "#btnChangeMode", function() {
                //                    var $this = $(this);
                //                    var optionLength = $('#sltUserList option').length;
                //                    if (optionLength == 0) {
                //                        WF.GetUserListForModerator();
                //                    }
                //                    $('#sltUserList').show();
                //                    $('#btnModCancel').show();
                //                    //$('#btnModOK').show();
                //                    $('.divModeratorName').hide();
                //                    $('.assignModerator').show();
                //                    $("#btnChangeMode").hide();

                //                });
                $('#btnModCancel').on('click', function () {
                    $('.assignModerator').hide();
                    $("#btnChangeMode").show();
                });
                //                $('#btnModOK').on('click', function() {
                //                    $('#moderatorName').text($('#sltUserList option:selected').val());
                //                    $('.assignModerator').hide();
                //                    $("#btnChangeMode").show();
                //                });
                $('#btnAddEditWFName').on('click', function () {
                    if (v.form()) {
                        var WorkFlowName = $("#txtWorkFlowName").val().trim();
                        if (WorkFlowName.length != 0) {
                            var isDup = 0;
                            var WFID = $("#editWFID").val();
                            $('.tblWF tr').each(function () {
                                //debugger;
                                if ($(this).attr('id') !== "wfID_" + WFID) {
                                    var wfName = $(this).find('td').eq(0).text().toLowerCase().trim();
                                    if (wfName == WorkFlowName.toLowerCase()) {
                                        isDup = 1;
                                    }
                                }
                            });
                            if (isDup == 0) {
                                var ModeratorName = $('#sltUserList option:selected').text();
                                WF.AddUpdateWorkFlowBasics(WorkFlowName, ModeratorName);
                            }
                            else {
                                SageFrame.messaging.show("WorkFlow name duplicated.", "alert");
                            }
                        }
                        else {
                            SageFrame.messaging.show("WorkFlow name can't be blank.", "alert");
                        }
                    }
                });
                $('.sfDiagram').on('click', '#btnNewTask', function () {
                    $('.sfDiagram').html(WF.CreateBox('default work', 0, true, 'new Task', true));
                    var self = $(this);
                    WF.GetHtmlForSave();
                });

                $('.sfFlowRight').on('click', '#btnSaveTask', function () {
                    if (v.form()) {
                        var taskName = $('#txtTaskName').val();
                        var isDup = false;
                        $('.sfDiagram .sfFlow').each(function () {
                            if ($(this).parent('li').hasClass('sfActive')) {
                            }
                            else {
                                name = $(this).find('.TaskName').text().trim().toLowerCase();
                                if (name == taskName.trim().toLowerCase()) {
                                    isDup = true;
                                }
                            }
                        });
                        if (!isDup) {
                            var Des = $('#txtDescription').val();
                            var RoleID = $("#sltRole option:selected").val();
                            var WFID = $("#WFID").val();
                            var User = $("#sltUser option:selected").text();
                            WF.AddUpdateWFTask(taskName, Des, RoleID, User);
                            if (WF.config.NewID !== 0)
                                $('.sfDiagram li.sfActive input[type=hidden]').val(WF.config.NewID);
                            WF.UpdateOrder();
                            WF.GetRunningTaskList();
                        }
                        else {
                            SageFrame.messaging.show("Work flow name duplicated.", "Error");
                        }
                    }
                });
                $('.sfFlowleft').on('click', '.EditTask', function () {
                    $('label.sfError').remove();
                    $('textarea').removeClass('sfError');
                    //$(".sfActive ").remove();
                    $("li").removeClass("sfActive");
                    var self = $(this);
                    self.parents('li').addClass("sfActive");
                    var TID = $('.sfDiagram li.sfActive input[type=hidden]').val();
                    if (TID == "0") {
                        WF.GetHtmlForSave();
                    }
                    else
                        WF.GetTaskByID(TID);
                });
                $('.sfDiagram').on('click', '.NextTask', function () {
                    var len = $('#hdnTaskID_0').length;
                    if (len == 0) {
                        var li = $(this).parents('li');
                        $(this).parents('.sfDiagram').find('li').removeClass('sfActive');
                        li.after(WF.CreateBox('Add new work', 0, false, 'Add new task', true, 'Assigned user'));
                        WF.GetHtmlForSave();
                    }
                });
                $('.sfDiagram').on('click', '.RemoveTask', function () {

                    $('label.sfError').remove();
                    $('textarea').removeClass('sfError');


                    var li = $(this).parents('li');

                    var preli = $(this).parents('li').prev().prev();
                    var self = $(this);
                    var active = $(this).parents('li').hasClass('sfActive');
                    var length = $('.sfDiagram li div.sfFlow').length;
                    var nexli = $(this).parents('li').next().next();
                    var index = $(this).parents('li.flow').index();
                    $('#sf_lblConfirmation').text("Are you sure you want to delete?");
                    $("#dialog").dialog({
                        modal: true,
                        buttons: {
                            "Confirm": function () {
                                if ($('.sfDiagram li').index(li) == 0) {
                                    li.next().remove();
                                    if ($('.sfDiagram li.flow').length == 1) {
                                        var html = '<input type="button" class="sfBtn" id="btnNewTask" value="AddNewTask" />';
                                        $('.sfFlowRight').html('');
                                        $('.sfDiagram').html(html);
                                    }
                                }
                                else {
                                    li.prev().remove();

                                }
                                li.remove();
                                if (index == 0) {
                                    nexli.addClass('sfActive');
                                }
                                else {
                                    preli.addClass('sfActive');
                                }
                                if (active) {
                                    var TID = $('.sfDiagram li.sfActive input[type=hidden]').val();
                                    WF.GetTaskByID(TID);
                                }

                                var id = self.prev('input[type=hidden]').val();
                                WF.DeleteTaskByID(id);
                                SageFrame.messaging.show("Task deleted successfully.", "Success");
                                WF.UpdateOrder();
                                $(this).dialog("close");
                            },
                            "Cancel": function () {
                                $(this).dialog("close");
                            }
                        }
                    });

                });
                $('.sfDiagram').on('click', '.up', function () {
                    var box = $(this).parents('li');
                    var line = box.prev();
                    var upperbox = box.prev().prev();
                    box.insertBefore(upperbox);
                    line.insertBefore(upperbox);
                    WF.UpdateOrder();
                });
                $('.sfDiagram').on('click', '.down', function () {
                    var box = $(this).parents('li');
                    var line = box.next();
                    var lowerbox = box.next().next();
                    box.insertAfter(lowerbox);
                    line.insertAfter(lowerbox);
                    WF.UpdateOrder();
                });
                $('#divMore').on('click', '.PublishTask', function () {
                    var wfID = $('#WFID').val();
                    var contentID = $('#hdnPublishContentID').val();
                    WF.Publish(wfID, contentID);
                });
                //End for diagram

                //Moderator

                $('.divModerator').on('click', '#spnMod', function () {
                    //                    var Flag = 0;
                    //                    if (Flag == 0) {
                    //                        $(this).addClass('.active');
                    //                        Flag = 1
                    //                    }
                    //                    else {
                    //                        $(this).removeClass('.active');
                    //                        Flag = 0
                    //                    }

                    if ($(this).hasClass('active')) {
                        $(this).removeClass('active');
                    }
                    else {
                        $(this).addClass('active');
                    }

                    if (WF.config.mode == "") {
                        $('#divUser').show();
                        $('#divModerator').hide();
                        $('#divMore').hide();
                        WF.config.mode = "M";

                    }
                    else {
                        $('#divUser').hide();
                        $('#divModerator').show();
                        WF.GetContainForModerator();
                        WF.config.mode = "";
                    }
                });
                $('#divModerator').on('click', '.ViewMore', function () {
                    $('#divModerator').hide();
                    $('#divMore').show();
                    var id = $(this).attr("id");
                    WF.GetContainByID(id);

                });
                $('#divReal').on('click', '.ReassignTask', function () {
                    var WFID = $('#WFID').val();
                    var ContainLevel = $('#divReal textarea').attr('id');
                    var Level = ContainLevel.split('_')[1];
                    var TaskID = $('#divReal #ReTaskID').val();
                    WF.ReassigneTask(WFID, Level, TaskID);
                });
                $('#divMore').on('change', '#sltVersion', function () {

                    var ContentLevel = $("#sltVersion option:selected").text();
                    var TaskID = $("#sltVersion option:selected").attr('val');
                    if (ContentLevel != "0") {
                        WF.GetContainByLevel(TaskID, ContentLevel);
                        //WF.Compare();
                    }

                });
                $('#divReal').on('click', '#spnCancelMore', function () {

                    $('#divModerator').show();
                    $('#divMore').hide();
                });
                $('#divHistory').on('click', '#spnCompare', function () {
                    WF.ShowLoader();
                    var compare = $.Callbacks();
                    compare.add(WF.Compare());
                    compare.fire();

                    //WF.Compare();
                    $('#spnMod').hide();
                    $('#divddlHistory').hide();
                    $('#divReal').hide();
                    $('#divHistory').hide();
                    $('#divCompare').show();

                    $('.loader').remove();
                    $('#divLoader').hide();
                });
                $('#divCompare').on('click', '#spnCancelCompare', function () {
                    $('#divCompare #divColRight,#divCompare #divColLeft').html('');
                    $('#divCompare').hide();
                    $('#spnMod').show();
                    $('#divddlHistory').show();
                    $('#divReal').show();
                    $('#divHistory').show();


                });


                //End for Moderator

                //Start fo save Content
                $('.Content').on('click', '#btnSaveContent', function () {
                    WF.SaveContent(parseInt($('#ddlComplete option:selected').text()));
                });
                $('.Content').on('change', '#ddlComplete', function () {
                    if (parseInt($('#ddlComplete option:selected').text()) == 99) {
                        $('.Content').append('<label id="btnApproval"  class="icon-send sfBtn">Send for Approval</label>');
                        $('#btnSaveContent').hide();
                    }
                    else {
                        $('#btnApproval').remove();
                        $('#btnSaveContent').show();
                    }
                });
                $('.Content').on('click', '#btnApproval', function () {
                    WF.SaveContent(100);
                });

                //WFbasics open
                $('#divWFList').on('click', '#btnAddnewWF', function () {
                    $('#editWFID').val('0');
                    $('#divWFList').hide();
                    $('#divWFedit').show();
                    $('#assignModerator').show();
                    $('#btnChangeMode').hide();
                    $('#txtWorkFlowName').val('');
                    if ($('.tblWF').find('tr.sfTrActive').length === 0) {
                        $('#IsActive').val('1');
                    }
                    var optionLength = $('#sltUserList option').length;
                    if (optionLength == 0) {
                        WF.GetUserListForModerator();
                    }
                });
                $('.WFCancel').bind('click', function () {
                    $('label.sfError').remove();
                    $('#divWFList').show();
                    $('#divWFedit').hide();
                    $('#assignModerator').hide();
                    $('#IsActive').val('0');
                    WF.SetWFID();
                });
                $('#divWFList').on('click', '.sfWFEdit', function () {
                    var find = $(this).parents('tr');
                    $('#editWFID').val(find.attr('id').replace('wfID_', ''));
                    $("#txtWorkFlowName").val(find.find('td').eq(0).text());
                    $('#divWFList').hide();
                    $('#divWFedit').show();
                    $('#btnChangeMode').show();
                    var moderatorname = find.find('td').eq(1).text();
                    $('#assignModerator').hide();
                    $('#sltUserList').hide();
                    var isActive = find.find('td').eq(2).text();
                    if (isActive == "Actived") {
                        $('#IsActive').val('1');
                    }
                    else {
                        $('#IsActive').val('0');
                    }
                    var optionLength = $('#sltUserList option').length;
                    if (optionLength == 0) {
                        WF.GetUserListForModerator();
                    }
                    $('#sltUserList').show();
                    $('#sltUserList option:selected').text(moderatorname);
                });
                $('#divWFList').on('click', '.sfWFdeActive', function () {
                    var find = $(this).parents('tr');
                    var wfID = find.attr('id').replace('wfID_', '');
                    WF.ActiveWf(wfID);
                });
                $('#divWFList').on('click', '.sfWFDelete', function () {
                    var find = $(this).parents('tr');

                    jConfirm('Are you sure you want delete this comment?', 'Confirmation Dialog', function (r) {
                        if (r) {
                            var wfID = find.attr('id').replace('wfID_', '');
                            WF.DeleteWF(wfID);
                        }
                    });
                });
                //Wfbasics close


                //WF Status
                //                $('#divWF').on('click', 'a[href=#divWFStatus]', function() {
                //                    //var active = $("#divWF").tabs('option', 'active');
                //                });
                $('.notificationBar').on('click', '.notification', function () {
                    $('.divInbox').show();
                    var noti = $(this).find('#spnModNoti').text().trim();
                    if (parseInt(noti) != 0) {
                        WF.SeenComments();
                    }
                });
                $('.divInbox').on('click', '#spnCloseNoti', function () {
                    $('.divInbox').hide();
                });
                var isactive = 'work flow basics';
                $('#divWF ul li').on('click', function () {
                    var tabWord = $(this).find('a').text().toLowerCase();
                    var active = isactive == tabWord ? true : false;
                    if (!active) {
                        switch (tabWord) {
                            case 'work':
                                isactive = 'work';
                                WF.GetContent();
                                break;
                            case 'work flow basics':
                                isactive = 'work flow basics';
                                break;
                            case 'workflow':
                                isactive = 'workflow';
                                WF.GetRunningTaskList();
                                break;
                            case 'work flow status':
                                isactive = 'work flow status';
                                WF.GetWFStatus();
                                break;
                        }
                    }
                });

                //WF Contain Preview
                $('#divReal').on('click', '.Preview', function () {
                    var html = "";

                    var contain = $('#divReal .sfMoreReal').val();
                    html += '<span class="sfClose icon-close" id="spnCancelPreview">Close</span>';
                    html += contain;

                    $('span .ui-icon-extlink').trigger('click');
                    $('#divPreview').html(html);
                    $('#divPreview').show('slow');
                });
                $('#divPreview').on('click', '#spnCancelPreview', function () {
                    $('#divPreview').html('');
                    $('#divPreview').hide('slow');
                });
                $('#divWFList').on('click', '.sfUnPublished', function () {
                    var find = $(this).parents('tr');
                    var wfID = find.attr('id').replace('wfID_', '');
                    WF.PublishWF(wfID);
                });
                $('.notificationBar').on('click', '.btnShowmore', function () {
                    var pageno = $(this).attr('id').replace('page_', '');
                    WF.GetNotification(pageno);
                });
                $('.sfFlowRight').on('change', '#sltRole', function () {
                    WF.GetUserList($('#sltRole option:selected').val());
                });
            },
            SetWFID: function () {
                if ($('.tblWF').find('tr.sfTrActive').length > 0) {
                    $("#WFID").val($('.tblWF').find('tr.sfTrActive').prop('id').replace('wfID_', ''));
                    $("#editWFID").val($('.tblWF').find('tr.sfTrActive').prop('id').replace('wfID_', ''));
                }
            },
            ShowLoader: function () {
                var html = "";
                html += '<div class="loader" id="divLoading" style=" position:absolute; top:50%; left:50%; text-align:center;">';
                html += '<img src="' + WF.config.ImagePath + 'ajax-loader.gif" alt="Processing" />';
                html += '</div>';
                $('#divLoader').append(html);
                $('#divLoader').show();
            },
            SeenComments: function () {
                var wfID = $("#WFID").val();
                this.config.method = "SeenComments";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    wfID: wfID,
                    userName: p.UserName,
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 18;
                this.ajaxCall(this.config);
            },
            GetNotification: function (pageno) {
                var wfID = $("#WFID").val();
                this.config.method = "GetNotification";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    cultureCode: p.CultureCode,
                    userName: p.UserName,
                    wfID: parseInt(wfID),
                    pageNo: pageno + 1,
                    dataAmount: 10,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 17;
                this.ajaxCall(this.config);

            },
            PublishWF: function (wf) {
                this.config.method = "PublishWF";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    cultureCode: p.CultureCode,
                    userName: p.UserName,
                    wfID: parseInt(wf),
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 14;
                this.ajaxCall(this.config);
            },
            Publish: function (wf, contentID) {

                this.config.method = "PublishContent";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    wfID: parseInt(wf),
                    userName: p.UserName,
                    contentID: contentID,
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 19;
                this.ajaxCall(this.config);
            },
            GetContent: function (wf) {
                var WFID = $("#WFID").val();
                if (WFID.length > 0) {
                    this.config.method = "GetContent";
                    this.config.url = this.config.baseURL + this.config.method;
                    this.config.data = JSON2.stringify({
                        portalID: p.PortalID,
                        userModuleID: p.UserModuleID,
                        cultureCode: p.CultureCode,
                        userName: p.UserName,
                        wfID: parseInt(WFID),
                        secureToken: SageFrameSecureToken
                    });
                    this.config.ajaxCallMode = 16;
                    this.ajaxCall(this.config);
                }
            },
            GetWFStatus: function () {
                this.config.method = "GetWFStatus";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    cultureCode: p.CultureCode,
                    WFID: $('#WFID').val() == "" ? 0 : $('#WFID').val(),
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 23;
                this.ajaxCall(this.config);
            },

            //Compare
            Compare: function () {

                $('#divColLeft').empty();
                $('#divColRight').empty();

                var textOne = $.trim($('.sfMoreReal').val());
                var textTwo = $.trim($('.sfMoreCompare').val());

                var TempArr1 = textOne.split(' ');
                var TempArr2 = textTwo.split(' ');
                var arr1 = [];
                for (var i = 0; i < TempArr1.length; i++) {
                    if (TempArr1[i] !== "" && TempArr1[i] !== null) {
                        arr1.push(TempArr1[i]);
                    }
                }

                var arr2 = [];
                for (var i = 0; i < TempArr2.length; i++) {
                    if (TempArr2[i] !== "" && TempArr2[i] !== null) {
                        arr2.push(TempArr2[i]);
                    }
                }
                var minArrLen = arr1.length < arr2.length ? arr1.length : arr2.length;

                for (var x = 0; x < minArrLen; x++) {

                    var maxCharLen = arr1[x].length > arr2[x].length ? arr1[x].length : arr2[x].length;
                    for (var y = 0; y < maxCharLen; y++) {
                        if (arr1[x].charAt(y) == ' ') {
                            $('#divColLeft').append('<span  class="missing">' + arr2[x].charAt(y) + '</span>');

                            $('#divColRight').append('<span class="missmatch">' + arr2[x].charAt(y)) + '</span>';
                        }
                        else if (arr2[x].charAt(y) == ' ') {
                            $('#divColLeft').append('<span class="missing">' + arr1[x].charAt(y) + '</span>');

                            $('#divColRight').append('<span class="missmatch">' + arr1[x].charAt(y)) + '</span>';
                        } else if (arr1[x].charAt(y) == arr2[x].charAt(y)) {
                            $('#divColLeft,#divColRight').append(arr1[x].charAt(y));
                        }
                        else {
                            $('#divColLeft').append('<span  class="missmatch">' + arr1[x].charAt(y) + '</span>');
                            $('#divColRight').append('<span  class="missing">' + arr2[x].charAt(y) + '</span>');
                        }
                    }
                    $('#divColLeft').append(' ');
                    $('#divColRight').append(' ');
                }

                if (minArrLen < arr1.length) {
                    for (var Len = minArrLen; Len < arr1.length; Len++) {
                        $('#divColLeft').append(arr1[Len])
                                        .append(' ');
                    }
                } else if (minArrLen < arr2.length) {
                    for (var Len = minArrLen; Len < arr2.length; Len++) {
                        $('#divColRight').append(arr2[Len])
                                        .append(' ');
                    }
                }

            },

            BindWFStatus: function (data) {
                var data = data.d;
                var html = "";
                if (data.length > 0) {
                    $.each(data, function (index, value) {
                        html += "<div class='sfStatusBar'>";
                        html += "<span class='UserName'>" + value.UserName + "</span>";
                        html += "<span class='WFTaskName'>" + value.TaskName + "</span>";
                        html += "<div class='wf-status' id='divStatus_" + value.TaskID + "'><img src='../Modules/ContentApprovalWorkFlow/Images/poll-graph.png' width='0%' val='" + value.Completion + "%' height='15px' alt='Image' /></div>";
                        html += "<span class='percentComplete'>" + value.Completion + "%</span>";
                        html += "</div>";
                    });
                    $("#divStatus").fadeOut("fast").html(html).fadeIn("fast", function () { WF.animateResults(); });
                }
                else {
                    $("#divStatus").html("Work has not been assigned to any of the user.");
                }
            },
            animateResults: function () {
                $("#divStatus img").each(function () {
                    var percentage = $(this).attr("val");
                    $(this).animate({ width: percentage }, 'slow');
                });
            },
            DeleteWF: function (wf) {
                this.config.method = "DeleteWF";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    wfID: parseInt(wf),
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 15;
                this.ajaxCall(this.config);
            },
            ActiveWf: function (wf) {
                this.config.method = "ActivateWF";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    cultureCode: p.CultureCode,
                    userName: p.UserName,
                    wfID: parseInt(wf),
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 14;
                this.ajaxCall(this.config);
            },
            GetWFBasicList: function (completion) {
                this.config.method = "GetWFBasicList";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    cultureCode: p.CultureCode,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 13;
                this.ajaxCall(this.config);
            },
            SaveContent: function (completion) {
                var WFID = $("#WFID").val();
                this.config.method = "SaveContents";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    wfID: WFID,
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    cultureCode: p.CultureCode,
                    contentID: $('#hdnContentID').val(),
                    contents: $('#txtContent').val(),
                    complete: completion,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                if (completion == 100) {
                    this.config.ajaxCallMode = 12;
                }
                else {
                    this.config.ajaxCallMode = 11;
                }
                this.ajaxCall(this.config);
            },
            GetHtmlForSave: function () {
                var html = "";
                html += "<table><tr><td><span>Name:</td></span>";
                html += "<td><input type='text' id='txtTaskName' name='txtTaskName' /></td></tr>";
                html += "<tr><td><span>Description: </span></td>";
                html += "<td><textarea id='txtDescription' cols='30' rows='4' class='sfDescription' name='txtDescription'></textarea><td></tr>";
                html += "<tr><td><span>Role</span></td>";
                html += "<td><select id='sltRole'></select><td></tr>";
                html += "<tr><td><span>User</span></td>";
                html += "<td><select id='sltUser'></select></td></tr>";
                html += "<tr><td></td><td><input type='button' id='btnSaveTask' value='Save' class='sfBtn' /></td></tr></table>";
                $('.sfFlowRight').html(html);

                //Bind user and role
                //WF.GetUserList();
                WF.GetRoleList();
                WF.GetUserList($('#sltRole option:selected').val());
            },
            //Moderator

            GetUserListForModerator: function (roleID) {
                this.config.method = "WFGetUsers";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    portalID: p.PortalID,
                    roleID: '',
                    userModuleID: p.UserModuleID,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 0;
                this.ajaxCall(this.config);
            },
            GetContainForModerator: function () {
                this.config.method = "GetContainForModerator";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    cultureCode: p.CultureCode,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 9;
                this.ajaxCall(this.config);
            },
            BindContainFromData: function (data) {
                var data = data.d;
                var html = '';

                if (data.length > 0) {

                    html += '<table cellspacing="0" border="0" cellpadding="0" class="sfGridwrapper" style="width:100% ;border-collapse:collapse;">';

                    html += "<thead><th><span>User Name:</span></th>";
                    html += "<th><span>Task Name:</span></th>"
                    html += "<th><span>Contain:</span></th></thead>";
                    $.each(data, function (index, value) {

                        html += '<tr>';
                        html += '<td class="userName">' + value.UserName + '</td>';
                        html += '<td class="userName">' + value.TaskName + '</td>';
                        html += '<td class="userName"><pre>' + value.Contents.substr(0, 100).replace(/\</g, '&lt') + '.....</pre><span id="' + value.ContentID + "_" + value.TaskID + '" class="ViewMore">More</span></td>';
                        html += '</tr>';
                        html += '<tr style="display:none;">';
                        html += '<td colspan="3">';
                        html += '<input id="WFlowID' + value.ContentID + '" type="hidden" value=' + value.WFID + '>';
                        html += '<input id="WFContentLevel' + value.ContentID + '" type="hidden" value=' + value.ContentLevel + '>';
                        html += '<input id="WFTaskID' + value.ContentID + '" type="hidden" value=' + value.TaskID + '>';
                        html += '<input id="WFContain' + value.ContentID + '" type="hidden" value=' + value.ContentID + '>';
                        html += '</td>';
                        html += '</tr>';

                    });
                    html += "</table>"

                }
                else {
                    html += "No active work found!";
                }
                $('#divModerator').html(html);

            },
            GetContainByID: function (id) {

                this.config.method = "GetContainByID";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    CID: id,
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 20;
                this.ajaxCall(this.config);
            },
            GetTaskByLevel: function (TaskID, ContentLevel) {

                this.config.method = "GetTaskByLevel";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    TaskID: TaskID,
                    ContentLevel: ContentLevel,
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 20;
                this.ajaxCall(this.config);
            },
            BindContainByID: function (data) {
                var data = data.d;
                var html = "";
                html += '<span class="Preview icon-preview sfBtn">Preview</span>';
                html += '<input id="ReTaskID" type="hidden" value=' + data.TaskID + '>';
                html += '<input id="hdnPublishContentID" type="hidden" value=' + data.ContentID + '>';
                html += '<textarea id="txtContain_' + data.ContentLevel + '" rows="4" cols="50" class="sfMoreReal">' + data.Contents + '</textarea>';
                html += '<span class="PublishTask icon-checked sfBtn">Publish Content</span>';
                html += '<span class="ReassignTask icon-reassign sfBtn">Reassign  Task</span>';
                html += '<span class="Cancel icon-close sfBtn" id="spnCancelMore">Cancel</span>';
                //html += '<div id="divColLeft"></div>';
                $('#divReal').html(html);

                var level = data.ContentLevel
                if (parseInt(level) > 1) {
                    var option;
                    var options = '';
                    options += "<label class=''> Version </label><select id='sltVersion'>";
                    options += "<option value='0'> --- Select --- </option>";
                    for (option = 1; option <= level; option++) {
                        options += '<option val="' + data.TaskID + '">' + option + '</option>';
                    }
                    html += "</select>";
                    $('#divddlHistory').html(options);
                }


            },

            ///////-----Reassigne Task -----
            ReassigneTask: function (WFID, ContentLevel, TaskID) {
                this.config.method = "ReassigneTask";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    WFID: WFID,
                    ContentLevel: ContentLevel,
                    TaskID: TaskID,
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 21;
                this.ajaxCall(this.config);
            },

            GetContainByLevel: function (TaskID, ContentLevel) {
                this.config.method = "GetContainByLevel";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    TaskID: TaskID,
                    ContentLevel: ContentLevel,
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 22;
                this.ajaxCall(this.config);
            },
            BindContainByLevel: function (data) {
                var data = data.d;
                var html = "";
                html += '<textarea id="txtContain_' + data.ContentLevel + '" rows="4" cols="50" class="sfMoreCompare">' + data.Contents + '</textarea>';
                html += '<span class="Compare icon-compare sfBtn" id="spnCompare">Compare</span>';
                $('#divHistory #divHistoryContain').html(html);
            },
            //--- END ---
            GetUserList: function (roleID) {
                this.config.method = "WFGetUsers";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    portalID: p.PortalID,
                    roleID: roleID,
                    userModuleID: p.UserModuleID,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 3;
                this.ajaxCall(this.config);
            },
            GetRoleList: function () {
                this.config.method = "WFGetRoles";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 4;
                this.ajaxCall(this.config);
            },

            UpdateOrder: function () {
                this.config.method = "SaveOrder";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = WF.GetTaskOrder({
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 8;
                this.ajaxCall(this.config);
            },

            GetTaskOrder: function () {
                $('.flow').each(function (index) {
                    var self = $(this);
                    var TID = $(this).find('input[type=hidden]').val();
                    param.objOrder.push({ "Order": index, "TaskID": TID });
                });
                return JSON2.stringify(param);
            },

            AddUpdateWFTask: function (TaskName, Des, RoleID, User) {
                var TID = $('.sfDiagram li.sfActive input[type=hidden]').val();

                data = {
                    TaskID: TID,
                    UsertaskID: 0,
                    TaskName: TaskName,
                    TaskDescription: Des,
                    WFID: $('#WFID').val() == "" ? 0 : $('#WFID').val(),
                    UserName: User,
                    RoleID: RoleID,
                    AddedBy: p.UserName,
                    IsActive: true,
                    IsDeleted: false,
                    UserModuleID: p.UserModuleID,
                    PortalID: p.PortalID,
                    CultureCode: p.CultureCode
                }
                this.config.method = "AddUpdateWFTask";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    objWfTask: data,
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 5;
                this.ajaxCall(this.config);

            },

            AddUpdateWorkFlowBasics: function (workflowName, moderatorName) {
                data = {
                    WFID: $('#editWFID').val() == "" ? 0 : $('#editWFID').val(),
                    WorkFlowname: workflowName,
                    AddedBy: p.UserName,
                    IsDeleted: false,
                    IsActive: $('#IsActive').val() == 0 ? false : true,
                    ModeratorName: moderatorName,
                    PortalID: p.PortalID,
                    UserModuleID: p.UserModuleID,
                    CultureCode: p.CultureCode
                }
                this.config.method = "AddUpdateBasic";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    objWfList: data,
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 1;
                this.ajaxCall(this.config);
            },
            GetWFBasic: function () {
                this.config.method = "GetBasic";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    cultureCode: p.CultureCode,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 2;
                this.ajaxCall(this.config);
            },

            SetBasic: function (data) {
                var value = data.d;
                $('#WFID').val(value.WFID);
                $("#txtWorkFlowName").val(value.WorkFlowName);
                $("#moderatorName").text(value.WorkFlowModerator);
            },

            GetTaskByID: function (TaskID) {
                this.config.method = "GetTaskByID";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    TaskID: TaskID,
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 6;
                this.ajaxCall(this.config);
            },
            BindTaskByID: function (Item) {
                var data = Item.d;
                $('#txtTaskName').val(data.TaskName);
                $('#txtDescription').val(data.TaskDescription);
                $('#sltRole').val(data.RoleID);
                WF.GetUserList($('#sltRole option:selected').val());
                $('#sltUser').val(data.UserName);
            },
            DeleteTaskByID: function (TaskID) {
                this.config.method = "DeleteTaskByID";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    TaskID: TaskID,
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 7;
                this.ajaxCall(this.config);
            },
            //Quick Editable Zone
            Editable: function () {
                $('.isEditable ').off().on('click', function () {
                    var $this = $(this);
                    var id = $this.attr('id');
                    var text = $this.text();
                    var toAppend = '<input type="text" id="txtMovable" class="' + id + '" >';
                    $(this).hide();
                    $this.parent().append(toAppend);
                    $('#txtMovable').val(text);
                    $('#txtMovable').select().focus();
                });
                $('#txtMovable').off().on('focusout', function () {
                    var $this = $(this);
                    var id = $this.attr('class').trim();
                    $('#' + id).text($this.val());
                    $('#' + id).show();
                    $this.remove();
                });
            },

            GetRunningTaskList: function () {
                var WFID = $('#WFID').val() == "" ? 0 : $('#WFID').val();
                this.config.method = "GetTaskList";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({
                    portalID: p.PortalID,
                    userModuleID: p.UserModuleID,
                    cultureCode: p.CultureCode,
                    WFID: WFID,
                    userName: p.UserName,
                    secureToken: SageFrameSecureToken
                });
                this.config.ajaxCallMode = 10;
                this.ajaxCall(this.config);
            },
            DrawDiagram: function (data) {
                var data = data.d;
                var html = '';
                if (data.length > 0) {
                    $.each(data, function (index, value) {
                        if (index == 0) {
                            html += WF.CreateBox(value.TaskName, value.TaskID, true, value.TaskDescription, true, value.UserName);
                            WF.GetHtmlForSave();
                            $('#txtTaskName').val(value.TaskName);
                            $('#txtDescription').val(value.TaskDescription);
                            $('#sltRole').val(value.RoleID);
                            WF.GetUserList($('#sltRole option:selected').val());
                            $('#sltUser').val(value.UserName);
                        }
                        else {
                            html += WF.CreateBox(value.TaskName, value.TaskID, false, value.TaskDescription, false, value.UserName);
                        }
                    });
                }
                else {
                    if ($('#WFID').val() > 0) {
                        html += '<input type="button" class="sfBtn" id="btnNewTask" value="AddNewTask" />';
                    }
                    $('.sfFlowRight').html('');
                }
                $('.sfDiagram').html(html);
            },
            CreateBox: function (taskName, taskID, isFirst, TaskDescription, addSfClass, userName) {
                var html = '';
                if (!isFirst) {
                    html += '<li class="line"><div class="sfLine"></div></li>';
                }
                var myclass = "";
                if (addSfClass) {
                    myclass = "sfActive";
                }
                html += '<li class="flow ' + myclass + ' "><div class="sfFlow"><span class="up icon-arrow-slim-n"></span><span class="down icon-arrow-slim-s"></span>';
                html += '<span class="TaskName">' + taskName + '</span> ';
                html += '<span class="TaskDescription">' + TaskDescription + '</span><br /> ';
                html += '<span class="userName"> work to be done by: ' + userName + '</span><br /> ';
                html += '<input type="hidden" class="sfhdn" id="hdnTaskID_' + taskID + '" value="' + taskID + '" />';
                html += '<span class="RemoveTask icon-delete"></span>';
                html += '<span class="EditTask icon-edit"></span>';
                html += '<span class="NextTask icon-addnew"></span></div></li>';
                return html;
            }
        }
        WF.init();
    };
    $.fn.SageWorkFlow = function (p) {
        $.SageWorkFlow(p);
    };
})(jQuery);