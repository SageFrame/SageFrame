<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LangSwitch.ascx.cs" Inherits="Modules_Language_LangSwitch" %>
<script type="text/javascript">


$(function(){
$(this).langswitcher({
            PortalID:'<%=PortalID%>', 
            UserModuleID:'<%=UserModuleID%>', 
            LangSwitchContainerID:'#'+'<%=ContainerClientID%>'
});
});
   
</script>
<asp:Literal ID="ltrNav" runat="server" EnableViewState="false"></asp:Literal>


