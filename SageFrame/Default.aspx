<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="SageFrame._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/TopStickyBar.ascx" TagName="TopStickyBar" TagPrefix="ucstickybar" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="head" enableviewstate="false">
    <link type="icon shortcut" runat="server" id="favicon" media="icon" href="favicon.ico" />
    <meta content="text/html; charset=UTF-8" http-equiv="Content-Type" />
    <meta content="text/javascript" http-equiv="Content-Script-Type" />
    <meta content="text/css" http-equiv="Content-Style-Type" />
    <meta id="MetaDescription" name="DESCRIPTION" />
    <meta id="MetaKeywords" name="KEYWORDS" />
    <meta id="MetaCopyright" name="COPYRIGHT" />
    <meta id="MetaGenerator" name="GENERATOR" />
    <meta id="MetaAuthor" name="AUTHOR" />
    <meta name="RESOURCE-TYPE" content="DOCUMENT" />
    <meta name="DISTRIBUTION" content="GLOBAL" />
    <meta id="MetaRobots" runat="server" name="ROBOTS" />
    <meta name="REVISIT-AFTER" content="1 DAYS" />
    <meta name="RATING" content="GENERAL" />
    <meta http-equiv="PAGE-ENTER" content="RevealTrans(Duration=0,Transition=1)" />
    <!--[if IE]><link rel="stylesheet" href="/css/IE.css" type="text/css" media="screen" /><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/SageFrameCorejs/IE8.js"></script>
     <![endif]-->
    <asp:Literal ID="SageFrameModuleCSSlinks" EnableViewState="false" runat="server"></asp:Literal>
    <asp:Literal ID="SageFrameCoreCss" EnableViewState="false" runat="server"></asp:Literal>
    <title>SageFrame Website</title>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <asp:ScriptManager ID="ScriptManager1" runat="server" LoadScriptsBeforeUI="false"
        ScriptMode="Release">
        <Services>
            <asp:ServiceReference Path="~/SageFrameWebService.asmx" />
        </Services>
    </asp:ScriptManager>
    <asp:PlaceHolder ID="phdDefault" runat="server"></asp:PlaceHolder>
    <div id="divAdminControlPanel" runat="server" style="display: block;">
        <ucstickybar:TopStickyBar ID="topStickybar" runat="server" />
    </div>
    <noscript>
        <asp:Label ID="lblnoScript" runat="server" Text="This page requires java-script to be enabled. Please adjust your browser-settings."></asp:Label>
    </noscript>
    <asp:Literal ID="ltrPlaceholders" runat="server"></asp:Literal>
    <div class="sfMessagewrapper" id="divMessage" runat="server">
    </div>
    <asp:PlaceHolder ID="pchWhole" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="pchtest" runat="server"></asp:PlaceHolder>
    <asp:Literal ID="LitSageScript" runat="server"></asp:Literal>
    <iframe id="divFrame" style="display: none" src='' width='100%'></iframe>
    <script type="text/javascript">
        $(function () {
            $('#navigation').superfish({
                delay: 200,
                animation: { opacity: 'show', height: 'show' },
                speed: 'fast',
                autoArrows: true,
                dropShadows: false
            });
            $('div.sfMessage').live("click", function () {

                $(this).slideUp();
            });
            $('a.sfManageControl').live("click", function (e) {

                var screen_res = screen.width;
                var align = (screen_res - 800) / 2;

                var url = $(this).attr("rel");
                $('#divFrame').attr("src", url);
                var dialogOptions = {
                    "title": "Manage",
                    "width": 800,
                    "height": 600,
                    "modal": true,
                    "position": [align, 150],
                    "z-index": 500,
                    "close": function () { location.reload(); }
                };
                if ($("#button-cancel").attr("checked")) {
                    dialogOptions["buttons"] = { "Cancel": function () {
                        ;
                        $(this).dialog("close");
                    }
                    };
                }
                //dialog-extend options
                var dialogExtendOptions = {
                    "maximize": true,
                    "minimize": false
                };

                //open dialog
                $("#divFrame").dialog(dialogOptions).dialogExtend(dialogExtendOptions);
                $('div.ui-dialog').css("z-index", "3000");
                return false;
            });
            //$("div.sfModuleControl").css("z-index",1001);
        });

        $(function () {
            var link = document.createElement('link');
            link.type = 'image/x-icon';
            link.rel = 'shortcut icon';
            link.href = '<%=templatefavicon%>';
            document.getElementsByTagName('head')[0].appendChild(link);
        } ());
    </script>
    </form>
</body>
</html>
