<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewBanner.ascx.cs" Inherits="Modules_Sage_Banner_ViewBanner" %>
<script type="text/javascript">
    //<![CDATA[
    $(function() {

        var BannerID = parseInt('<%=BannerId%>');
     
        if (BannerID != 0) {
            $(this).SageBannerjs({
                baseURL: SageBannerServicePath,
                BannerId: parseInt('<%=BannerId%>'),
                Auto_Slide: '<%=Auto_Slide %>',
                InfiniteLoop: '<%=InfiniteLoop%>',
                Pause_Time: parseInt('<%=Pause_Time%>'),
                NumericPager: '<%=NumericPager%>',
                TransitionMode: '<%=TransitionMode%>',
                Speed: parseInt('<%=Speed%>'),
                PortalID: '<%=PortalId %>',
                UserModuleID: '<%=UserModuleId%>',
                SageURL: '<%=SageURL%>',
                enablecontrol: '<%=EnableControl%>'
            });
        }
    });
    //]]>
</script>

<ul id="slider">
</ul>
