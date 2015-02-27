<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="SageFrame.Sagin_Admin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <meta http-equiv="PAGE-ENTER" content="RevealTrans(Duration=0,Transition=1)" />
    <!--[if IE]><link rel="stylesheet" href="../css/IE.css" type="text/css" media="screen" /><![endif]-->
    <!--[if lt IE 7]>
        <script type="text/javascript" src="/js/SageFrameCorejs/IE8.js"></script>
     <![endif]-->
    <!--[if !IE 7]>
	<style type="text/css">
		#wrap {display:table;height:100%}
	</style>
	<![endif]-->

    <!--[if lt IE 9]>
<script src="/js/SageFrameCorejs/html5.js"></script>
<![endif]-->
    <asp:Literal ID="SageFrameModuleCSSlinks" runat="server"></asp:Literal>
    <link id="lnkLoginCss" href="" rel="stylesheet" type="text/css" runat="server" />
    <title>SageFrame Website</title>
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
                    $(this).next("div").slideToggle("fast", function() {
                        if (!$(this).closest("div.sfInformationholder").hasClass("Active")) {
                            $(this).closest("div.sfInformationholder").addClass("Active");
                        }
                        else if ($(this).closest("div.sfInformationholder").hasClass("Active")) {
                            $(this).closest("div.sfInformationholder").removeClass("Active");
                        }
                        $("div.sfInformationholder").not($(this).closest("div.sfInformationholder")).removeClass("Active");
                    });
                    $('div.sfInformationcontent').not($(this).next("div")).slideUp("fast");

                });

            });


            function ScrollToTop() {
                $(document).scrollTop(0);
            }
	   
    </script>
    </head>
    <body>
    <form id="form1" runat="server" enctype="multipart/form-data">
      <asp:ScriptManager ID="ScriptManager1" runat="server" LoadScriptsBeforeUI="false"
        ScriptMode="Release"> </asp:ScriptManager>
      <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
        <ProgressTemplate>
          <div class="sfLoadingbg"> &nbsp;</div>
          <div class="sfLoadingdiv">
            <asp:Image ID="imgPrgress" runat="server" AlternateText="Loading..." ToolTip="Loading..." />
            <asp:Label ID="lblPrgress" runat="server" Text="Please wait..."></asp:Label>
          </div>
        </ProgressTemplate>
      </asp:UpdateProgress>
      <noscript>
      <asp:Label ID="lblnoScript" runat="server" Text="This page requires java-script to be enabled. Please adjust your browser-settings."></asp:Label>
      </noscript>
      <div id="sfOuterwrapper">
        <div class="sfLogoholder"><a href="http://www.sageframe.com/" target="_blank" class="sflogo">
          <asp:Image ID="imgLogo" runat="server" alt="SageFrame"/>
          </a></div>
        <div class="sfSagewrapper">
          <div class="sfNavigation clearfix" id="divNavigation" runat="server" style="display: none">
            <asp:PlaceHolder ID="navigation" runat="server"> </asp:PlaceHolder>
          </div>
          <!--Body Content-->
          <div class="sfMiddlemain">
            <asp:PlaceHolder ID="message" runat="server"> </asp:PlaceHolder>
            <asp:PlaceHolder ID="middlemaincurrent" runat="server"> </asp:PlaceHolder>
            <div class="sfCpanel">
              <asp:PlaceHolder ID="cpanel" runat="server"></asp:PlaceHolder>
            </div>
            <p class="sfBack">
              <asp:HyperLink ID="hypPreview" runat="server" Text="← Back to Home Page"></asp:HyperLink>
            </p>
          </div>
        </div>
      </div>
      </div>
      </div>
      </div>
      <div id="dialog" title="Confirmation Required">
        <label id="sf_lblConfirmation"> </label>
      </div>
      <asp:Literal ID="LitSageScript" runat="server"></asp:Literal>
    </form>
</body>
</html>
