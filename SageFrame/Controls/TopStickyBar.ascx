<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopStickyBar.ascx.cs"
    Inherits="Controls_TopStickyBar" %>
<%@ Register Src="LoginStatus.ascx" TagName="LoginStatus" TagPrefix="uc1" %>
<script type="text/javascript">
    $(function() {
        $('#imgAdmin').attr("src", SageFrame.utils.GetAdminImage("admin-icon.png"));
        $('#rdbEdit').attr("checked", true);
        $('span.sfPosition').hide();
        $('div.sfModule').append('<div class="sfClearDivTemp" style="clear:both"></div>');
        $('input[name="mode"]').live("click", function() {
            switch ($(this).attr("id")) {
                case "rdbEdit":
                    $('div.sfModuleControl').show();
                    $('span.sfPosition').hide();
                    $('div.sfModule').append('<div class="sfClearDivTemp" style="clear:both"></div>');
                    $('div.sfClearDivTemp').remove();
                    $('div.sfWrapper').removeClass("sfLayoutmode");
                    $('span.sfUsermoduletitle').hide();
                    $('div.sfWrapper div').css("opacity", "1");
                    //$('div.sfWrapper').css("opacity", "1");
                    break;
                case "rdbLayout":
                    $('span.sfPosition').show();
                    $('div.sfModuleControl').hide();
                    $('div.sfModule').append('<div class="sfClearDivTemp" style="clear:both"></div>');
                                        
                    var positions = $('div.sfWrapper');
                    $.each(positions, function() {
                        $(this).addClass("sfLayoutmode");
                    });
                    
                    $('div.sfLayoutmode div.sfModule').css("opacity", "0.5");

                    $('span.sfUsermoduletitle').show();

                    $('div.sfLayoutmode').hover(function() {
                        $(this).css("opacity", "1");
                        $(this).find("div.sfModule").css("opacity", "1");
                    }, function() { $(this).find("div.sfModule").css("opacity", "0.5"); });


                    break;
                case "rdbNone":
                    $('div.sfModuleControl').hide();
                    $('span.sfPosition').hide();
                    $('div.sfClearDivTemp').remove();
                    $('div.sfWrapper').removeClass("sfLayoutmode");
                    $('span.sfUsermoduletitle').hide();
                    $('div.sfWrapper div').css("opacity", "1");
                    //$('div.sfWrapper').css("opacity", "1");
                    break;
            }
        });

        $(".signin").click(function(e) {
            e.preventDefault();
            $("fieldset#signin_menu").toggle();
            $(".signin").toggleClass("menu-open");
        });

        $("fieldset#signin_menu").mouseup(function() {
            return false
        });
        $(document).mouseup(function(e) {
            if ($(e.target).parent("a.signin").length == 0) {
                $(".signin").removeClass("menu-open");
                $("fieldset#signin_menu").hide();
            }
        });

    });
</script>

<div class="sfTopbar clearfix">
  <ul class="left">
    <li> <img src="#" id="imgAdmin" alt="Admin Icon" />
      <asp:Literal ID="litUserName" runat="server" Text="Logged In As"></asp:Literal>
      &nbsp;<strong><%= Page.User == null ? "" : Page.User.Identity.Name %></strong></li>
    <li class="sfDashBoard">
      <asp:HyperLink ID="hlnkDashboard" runat="server">Dashboard</asp:HyperLink>
    </li>
  </ul>
   <div id="cpanel"  runat="server">
    <div id="divCpanel">
      <div id="topnav" class="topnav"><a href="login" class="signin"><span>CPANEL</span></a> </div>
      <fieldset id="signin_menu">
        <ul>
          <li> <strong class="sfSeperator1">Customize:</strong>
            <p>
              <label> Themes:</label>
              <asp:DropDownList ID="ddlThemes" runat="server"> </asp:DropDownList>
            </p>
            <p>
              <label> Screen:</label>
              <asp:DropDownList ID="ddlScreen" runat="server">
                <asp:ListItem Value="0">fluid</asp:ListItem>
                <asp:ListItem Value="1">wide</asp:ListItem>
                <asp:ListItem Value="2">narrow</asp:ListItem>
              </asp:DropDownList>
            </p>
            <p>
              <label> Layouts:</label>
              <asp:DropDownList ID="ddlLayout" runat="server"> </asp:DropDownList>
            </p>
            <p>
              <asp:Button ID="btnApply" OnClick="btnApply_Click" runat="server" Text="Apply" CssClass="sfBtn" />
            </p>
            <p class="sfMode"> <strong>Mode:</strong>
              <input id="rdbEdit" name="mode" type="radio" />
              <label>Edit</label>
              <input id="rdbLayout" name="mode" type="radio" />
              <label>Layout</label>
              <input id="rdbNone" name="mode" type="radio" />
              <label>None</label>
              
            </p>
          </li>
        </ul>
      </fieldset>
    </div>
  </div>
  <ul class="right">
    <li class="myaccount">
      <asp:HyperLink runat="server" ID="lnkAccount" Text="My Account"></asp:HyperLink>
    </li>
    <li class="logout">
      <uc1:LoginStatus ID="LoginStatus1" runat="server" />
    </li>
  </ul>
</div>
