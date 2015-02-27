<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="SageFrame.Sagin_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/TopStickyBar.ascx" TagName="TopStickyBar" TagPrefix="ucstickybar" %>
<%@ Register Src="~/Controls/DashboardQuickLinks.ascx" TagName="DashboardQuickLinks"
    TagPrefix="ucquicklink" %>
<%@ Register Src="~/Controls/Sidebar.ascx" TagName="Sidebar" TagPrefix="ucsidebar" %>
<%@ Register Src="~/Controls/LoginStatus.ascx" TagName="LoginStatus" TagPrefix="uc1" %>
<%@ Register Src="../Controls/ctl_CPanleFooter.ascx" TagName="ctl_CPanleFooter" TagPrefix="uc3" %>
<%@ Register Src="../Controls/ctl_AdminBreadCrum.ascx" TagName="AdminBreadCrumb"   TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="head">
    <link type="icon shortcut" media="icon" href="favicon.ico" />
    <meta content="text/html; charset=UTF-8" http-equiv="Content-Type" />
    <meta content="text/javascript" http-equiv="Content-Script-Type" />
    <meta content="text/css" http-equiv="Content-Style-Type" />
    <meta id="MetaDescription" runat="Server" name="DESCRIPTION" />
    <meta id="MetaKeywords" runat="Server" name="KEYWORDS" />
    <meta id="MetaCopyright" runat="Server" name="COPYRIGHT" />
    <meta id="MetaGenerator" runat="Server" name="GENERATOR" />
    <meta id="MetaAuthor" runat="Server" name="AUTHOR" />
    <meta name="RESOURCE-TYPE" content="DOCUMENT" />
    <meta name="DISTRIBUTION" content="GLOBAL" />
    <meta id="MetaRobots" runat="server" name="ROBOTS" />
    <meta name="REVISIT-AFTER" content="1 DAYS" />
    <meta name="RATING" content="GENERAL" />
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <!-- Mimic Internet Explorer 7 -->
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7">
    <meta http-equiv="PAGE-ENTER" content="RevealTrans(Duration=0,Transition=1)" />
    <!--[if IE 8]><script type="text/javascript" src="/js/SageFrameCorejs/excanvas.js"></script><![endif]-->
    <!--[if IE]><link rel="stylesheet" href="/css/IE.css" type="text/css" media="screen" /><![endif]-->
    <!--[if IE 7]><script type="text/javascript" src="/js/SageFrameCorejs/IE8.js"></script><![endif]-->
    <!--[if !IE 7]>
	<style type="text/css">
		#wrap {display:table;height:100%}
	</style>
	<![endif]-->
    <asp:Literal ID="SageFrameCoreCss" EnableViewState="false" runat="server"></asp:Literal>
    <asp:Literal ID="SageFrameModuleCSSlinks" runat="server"></asp:Literal>
    <title>SageFrame Website</title>
</head>
<body onload="__loadScript();">
    <form id="form1" runat="server" enctype="multipart/form-data">
    <asp:ScriptManager ID="ScriptManager1" runat="server" LoadScriptsBeforeUI="false"
        ScriptMode="Release">
    </asp:ScriptManager>
    <%-- <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" CombineScriptsHandlerUrl="~/CombineScriptsHandler.ashx" runat="server"   ScriptMode="Release" CombineScripts="true">
    </cc1:ToolkitScriptManager>--%>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <div class="sfLoadingbg">
                &nbsp;</div>
            <div class="sfLoadingdiv">
                <asp:Image ID="imgPrgress" runat="server" AlternateText="Loading..." ToolTip="Loading..." />
                <br />
                <asp:Label ID="lblPrgress" runat="server" Text="Please wait..."></asp:Label>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <noscript>
        <asp:Label ID="lblnoScript" runat="server" Text="This page requires java-script to be enabled. Please adjust your browser-settings."></asp:Label>
    </noscript>
    <div id="sfOuterwrapper">
        <div class="sfSagewrapper">
            <div class="sfTopbar clearfix" id="divAdminControlPanel" runat="server" style="display: block;">
                <ul class="left">
                    <li>
                        <img src="<%=Page.Request.ApplicationPath=="/"?"":Page.Request.ApplicationPath%>/Administrator/Templates/Default/images/admin-icon.png"
                            alt="Admin Icon" />
                        <span>
                            <asp:Literal ID="litUserName" runat="server" Text="Logged In As"></asp:Literal> &nbsp; </span>
                        <asp:HyperLink runat="server" ID="lnkAccount" Text="Logged In As">                                
                                <strong><%= Page.User == null ? "" : Page.User.Identity.Name %></strong>
                        </asp:HyperLink></li>
                    <li class="sfUpgrade">
                        <asp:HyperLink ID="hypUpgrade" runat="server" Text="Upgrade"></asp:HyperLink></li>
                </ul>
                <ul class="right">
                    <li class="home">
                        <asp:HyperLink ID="hypHome" runat="server" Target="_blank" Style="display: none"></asp:HyperLink>
                    </li>
                    <li class="preview">
                        <asp:HyperLink ID="hypPreview" runat="server" Text="Preview" Target="_blank"></asp:HyperLink>
                    </li>
                    <li class="logout">
                        <uc1:LoginStatus ID="LoginStatus1" runat="server" />
                    </li>
                </ul>
                <div class="clear">
                </div>
            </div>
            <ucquicklink:DashboardQuickLinks ID="DashboardQuickLinks1" runat="server" />
            <!--End of CPanel Head-->
            <!--Navigation Wrapper-->
            <div class="sfNavigation clearfix" id="divNavigation" runat="server" style="display: none">
                <asp:PlaceHolder ID="navigation" runat="server"></asp:PlaceHolder>
            </div>
            <!--Body Content-->
            <div class="sfContentwrapper clearfix">
                <div id="divCenterContent">
                    <ucsidebar:Sidebar ID="Sidebar1" runat="server" />
                    <div class="sfMaincontent">
                        <div class="sfBreadcrumb clearfix">
                            <uc4:AdminBreadCrumb ID="adminbreadcrumb" runat="server" />
                        </div>
                        <asp:PlaceHolder ID="message" runat="server"></asp:PlaceHolder>
                        <asp:PlaceHolder ID="toppane" runat="server"></asp:PlaceHolder>
                        <div class="clearfix">
                            <div class="sfMasterleft" id="divLeft" runat="server" style="display: none">
                                <asp:PlaceHolder ID="LeftA" runat="server"></asp:PlaceHolder>
                            </div>
                            <div class="sfMasterright" id="divRight" runat="server" style="display: none">
                                <asp:PlaceHolder ID="middlemaincurrent" runat="server"></asp:PlaceHolder>
                            </div>
                        </div>
                        <div class="sfCpanel" runat="server" id="divBottompanel" style="display: none">
                            <asp:PlaceHolder ID="cpanel" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--Footer Wrapper-->
        <div class="sfFooterwrapper clearfix" id="divFooterWrapper" runat="server">
            <uc3:ctl_CPanleFooter ID="ctl_CPanleFooter1" runat="server" />
        </div>
    </div>
    <div id="dialog" title="Confirmation Required">
        <label id="sf_lblConfirmation">
        </label>
    </div>
    <asp:Literal ID="LitSageScript" runat="server"></asp:Literal>

    <script type="text/javascript">
        String.Format = function() {
            var s = arguments[0];
            for (var i = 0; i < arguments.length - 1; i++) {
                var reg = new RegExp("\\{" + i + "\\}", "gm");
                s = s.replace(reg, arguments[i + 1]);
            }
            return s;
        }

        var dialogConfirmed = false;
        function ConfirmDialog(obj, title, dialogText) {
            if (!dialogConfirmed) {
                $('body').append(String.Format("<div id='dialog-confirm' title='{0}'><p>{1}</p></div>",
                    title, dialogText));

                if (title == "message") {
                    $('#dialog-confirm').dialog
                    ({
                        height: 150,
                        width: 350,
                        modal: true,
                        resizable: false,
                        draggable: false,
                        close: function(event, ui) { $('body').find('#dialog-confirm').remove(); },
                        buttons:
                        {
                            'OK': function() {
                                $(this).dialog('close');
                            }
                        }
                    });
                }
                else {
                    $('#dialog-confirm').dialog
                    ({
                        height: 110,
                        modal: true,
                        resizable: false,
                        draggable: false,
                        close: function(event, ui) { $('body').find('#dialog-confirm').remove(); },
                        buttons:
                        {
                            'Yes': function() {
                                $(this).dialog('close');
                                dialogConfirmed = true;
                                if (obj) obj.click();
                            },
                            'No': function() {
                                $(this).dialog('close');
                            }
                        }
                    });
                }
            }

            return dialogConfirmed;
        }
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                String.Format = function() {
                    var s = arguments[0];
                    for (var i = 0; i < arguments.length - 1; i++) {
                        var reg = new RegExp("\\{" + i + "\\}", "gm");
                        s = s.replace(reg, arguments[i + 1]);
                    }
                    return s;
                }

                var dialogConfirmed = false;
                function ConfirmDialog(obj, title, dialogText) {
                    if (!dialogConfirmed) {
                        $('body').append(String.Format("<div id='dialog-confirm' title='{0}'><p>{1}</p></div>",
                    title, dialogText));

                        if (title == "message") {
                            $('#dialog-confirm').dialog
                    ({
                        height: 110,
                        modal: true,
                        resizable: false,
                        draggable: false,
                        close: function(event, ui) { $('body').find('#dialog-confirm').remove(); },
                        buttons:
                        {
                            'OK': function() {
                                $(this).dialog('close');
                            }
                        }
                    });
                        }
                        else {
                            $('#dialog-confirm').dialog
                    ({
                        height: 110,
                        modal: true,
                        resizable: false,
                        draggable: false,
                        close: function(event, ui) { $('body').find('#dialog-confirm').remove(); },
                        buttons:
                        {
                            'Yes': function() {
                                $(this).dialog('close');
                                dialogConfirmed = true;
                                if (obj) obj.click();
                            },
                            'No': function() {
                                $(this).dialog('close');
                            }
                        }
                    });
                        }
                    }

                    return dialogConfirmed;
                }
            }
        }

        $(function() {
            $("input:file").uniform();

            $('div.sfCollapsecontent').hide();
            $('div.sfCollapsewrapper div.sfCollapsecontent').show();
            $('div.sfCollapsewrapper div.sfAccordianholder').addClass("Active");
            $('div.sfAccordianholder').live("click", function() {
                if (!$(this).hasClass("Active")) {
                    $(this).addClass("Active");
                    $(this).parent().next("div").slideDown("fast");

                }
                else {
                    $(this).removeClass("Active");
                    $(this).parent().next("div").slideUp("fast");
                }
            });



            $('div.sfInformationcontent:first').show();
            $('div.sfInformationholder:first').addClass("Active");
            $('div.sfInformationheader').live("click", function() {
                $(this).next("div").slideToggle(function() {
                    if (!$(this).closest("div.sfInformationholder").hasClass("Active")) {
                        $(this).closest("div.sfInformationholder").addClass("Active");
                    }
                    else if ($(this).closest("div.sfInformationholder").hasClass("Active")) {
                        $(this).closest("div.sfInformationholder").removeClass("Active");
                    }
                    $("div.sfInformationholder").not($(this).closest("div.sfInformationholder")).removeClass("Active");
                });
                $('div.sfInformationcontent').not($(this).next("div")).hide();

            });

        });


        function ScrollToTop() {
            $(document).scrollTop(0);
        }
	   
    </script>

    </form>
</body>
</html>
