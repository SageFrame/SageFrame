<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Sidebar.ascx.cs" Inherits="Controls_Sidebar" %>
<script type="text/javascript">
$(function(){

SidebarMgr.init();
 });
 var SidebarMgr = {
     config: {
         isPostBack: false,
         async: false,
         cache: false,
         type: 'POST',
         contentType: "application/json; charset=utf-8",
         data: '{}',
         dataType: 'json',
         method: "",
         url: "",
         categoryList: "",
         ajaxCallMode: 0,
         arr: [],
         arrModules: [],
         baseURL: '<%=appPath%>' + '/Modules/Dashboard/Services/DashboardWebService.asmx/',
         PortalID: 1,
         Path: '<%=appPath%>' + '/Modules/Dashboard/',
         SaveMode: "Add",
         SidebarItemID: 0,
         SidebarMode: '<%=SidebarMode%>',
         ShowSideBar: '<%=IsSideBarVisible%>',
         UserName: '<%=UserName%>',
         PortalID: '<%=PortalID%>'
     },
     init: function() {



         if (SidebarMgr.config.SidebarMode == 0) {
             InitSuperfish();

             
         }
         else {
             $('ul.menu').initMenu();
             SidebarMgr.HighlightSelected();
         }


         if (SidebarMgr.config.ShowSideBar == "1")
             $('div.sfHidepanel').live("click", function() {
                 if (!$('div.sfSidebar').hasClass("sfSidebarhide")) {
                     $('div.sfSidebar').find("ul li ul").hide(function() { $(this).animate({ display: "none" }, 100) });
                     $('div.sfSidebar').find("ul li a span").hide(function() { $(this).animate({ display: "none" }, 100) });
                     $('div.sfHidepanel').find("a span").hide(function() { $(this).animate({ display: "none" }, 100) });
                     $('div.sfSidebar').animate({ width: "45px" }, 400, function() {

                         $('div.sfHidepanel').find("img").animate({ opacity: 0 }, 100, function() {
                             $('div.sfHidepanel img').attr("src", SageFrame.utils.GetAdminImage("show-arrow.png"))
                             $('div.sfHidepanel img').animate({ opacity: 1 }, 100);
                         });
                     });

                     InitSuperfish();
                     $('div.sfSidebar').addClass("sfSidebarhide");
                     InitModuleFloat(65);
                     SidebarMgr.UpdateSidebarMode();

                 }
                 else {

                     // $('div.sfMaincontent').animate({width:"83%"},200);
                     $('div.sfSidebar').find("ul li ul").show(function() { $(this).animate({ display: "block" }, 100) });
                     $('div.sfSidebar').find("ul li a span").show(function() { $(this).animate({ display: "block" }, 100) });
                     $('div.sfSidebar').animate({ width: "150px" }, 400, function() {

                         $('div.sfHidepanel').find("a span").show(function() { $(this).animate({ display: "block" }, 100) });
                         $('div.sfHidepanel').find("img").attr("src", SageFrameAppPath + "/Administrator/Templates/Default/images/hide-arrow.png");

                     });
                     InitAccordianMode();
                     $('#sidebar ul').attr("class", "menu").css("visibility", "visible");
                     $('#sidebar ul li.parent ul').attr("class", "acitem fullwidth");
                     $('#sidebar ul li a').removeAttr("class");
                     $('div.sfSidebar').removeClass("sfSidebarhide");
                     InitModuleFloat(200);
                     SidebarMgr.UpdateSidebarMode();
                 }

             });


     },
     HighlightSelected: function() {
         var sidebar = $('#sidebar ul li.sfLevel0');
         $.each(sidebar, function(index, item) {
             if ($(this).hasClass("parent")) {
                 var submenu = $(this).find("ul li");
                 $.each(submenu, function() {
                     var hreflink = $(this).find("a").attr("href");
                     if (location.href.toLowerCase().indexOf(hreflink.toLowerCase()) > -1) {

                         $(this).parent("ul.acitem").css("display", "block").addClass("active");
                         $(this).parent("ul.acitem").prev("a").addClass("active");
                     }
                 });

             }
             else if(!$(this).hasClass("parent")){
                 var hreflink = $(this).find("a").attr("href");
                 if (location.href.toLowerCase().indexOf(hreflink.toLowerCase()) > -1) {
                     $(this).find("a").addClass('active');
                 }
             }
         });
     },
     LoadRealSidebar: function() {
         $.ajax({
             type: SidebarMgr.config.type,
             contentType: SidebarMgr.config.contentType,
             cache: SidebarMgr.config.cache,
             url: SidebarMgr.config.baseURL + "GetSidebar",
             data: JSON2.stringify({ UserName: SidebarMgr.config.UserName, PortalID: SidebarMgr.config.PortalID }),
             dataType: SidebarMgr.config.dataType,
             success: function(msg) {
                 var links = msg.d;
                 var html = '<ul class="menu">';
                 $.each(links, function(index, item) {
                     var image = SidebarMgr.config.Path + "Icons/" + item.ImagePath;
                     var url = SidebarMgr.BuildURL(item);
                     var sidebartext = '<span>' + item.DisplayName + '</span>';
                     if (item.ChildCount == 0 && item.ParentID == 0) {
                         html += '<li><a href=' + url + '><img src=' + image + '>' + sidebartext + '</a></li>';
                     }
                     else if (item.ChildCount > 0) {
                         html += '<li class="parent"><a href=' + url + '><img src=' + image + ' >' + sidebartext + '</a>';
                         html += '<ul class="acitem">';
                         $.each(links, function(i, it) {
                             var url = SidebarMgr.BuildURL(it);
                             if (it.ParentID == item.SidebarItemID) {
                                 html += '<li><a href=' + url + '>' + it.DisplayName + '</a></li>';
                             }
                         });
                         html += '</ul>';
                         html += '</li>';
                     }
                 });
                 html += '</ul>';
                 var toggleSwitch = '<div class="sfHidepanel clearfix"><a href="#"><img src=' + SageFrame.utils.GetAdminImage("hide-arrow.png") + ' alt="Hide " /><span>Hide Panel</span></a></div>';
                 $('#sidebar').html(html).append(toggleSwitch);
                 if (SidebarMgr.config.SidebarMode == 0) {
                     InitCollapsedMode();

                     $('#sidebar ul li a span').hide();
                 }
                 else {
                     InitAccordianMode();

                 }
             }

         });
     },
     BuildURL: function(item) {
         var portalchange = SidebarMgr.config.PortalID > 1 ? "/portal/" + '<%=PortalName%>' : "";
         var url = '<%=appPath%>' + portalchange + item.URL + ".aspx"
         return url;
     },
     UpdateSidebarMode: function() {
         var _status = $('div.sfSidebar').hasClass("sfSidebarhide") ? "closed" : "open";
         var param = JSON2.stringify({ status: _status, PortalID: SageFramePortalID, UserName: SageFrameUserName });
         $.ajax({
             type: SidebarMgr.config.type,
             contentType: SidebarMgr.config.contentType,
             cache: SidebarMgr.config.cache,
             url: SidebarMgr.config.baseURL + "UpdateSidebar",
             data: param,
             dataType: SidebarMgr.config.dataType,
             success: function(msg) {

             }
         });
     }

 };


function InitCollapsedMode()
{

            $('div.sfSidebar').find("ul li ul").hide(function(){$(this).animate({display:"none"},100)});
			$('div.sfHidepanel').find("a span").hide(function(){$(this).animate({display:"none"},100)});
			$('div.sfSidebar').animate({width:"45px"},400,function(){			
			$('div.sfHidepanel').find("img").animate({opacity:0},100,function(){
				$('div.sfHidepanel img').attr("src",GetAdminImage("show-arrow.png"))
				$('div.sfHidepanel img').animate({opacity:1},100);
				//$('div.sfMaincontent').animate({width:"95%"},200);
			});
			});
			$('div.sfSidebar').addClass("sfSidebarhide");
			
			InitSuperfish();
			
}
function GetAdminImage(imagename)
{
    return(SageFrameAppPath+"/Administrator/Templates/Default/images/"+imagename);
}
function InitSuperfish()
{
$('ul.menu').addClass("sf-vertical");
  var ul=$('ul.menu ul.acitem');
  $.each(ul,function(index,item){ 
    $(this).addClass("sfCollapsed").removeClass("fullwidth");    
  });
  
 $('ul.menu').superfish({ 
            animation: {height:'show'},   // slide-down effect without fade-in 
            delay:     100               // 1.2 second delay on mouseout 
        });
         	
//$('.sfSidebar ul li ul').css("z-index",$.maxZIndex());

}

function InitAccordianMode()
{
 var ul=$('ul.menu ul.acitem');
  $.each(ul,function(index,item){  
    $(this).removeClass("sfCollapsed").addClass("fullwidth");
     
  });
  $('ul.menu').removeClass("sf-vertical");
   $('ul.menu').initMenu();   
    
}


</script>

 
 <asp:Literal ID="ltrSidebar" runat="server"></asp:Literal>
 