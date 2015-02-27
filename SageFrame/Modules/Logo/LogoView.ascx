<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LogoView.ascx.cs" Inherits="Modules_Logo_LogoView" %>
<script type="text/javascript">
   
    $(function() {
        $(this).LogoBuilder({
            PortalID: '<%=portalID%>',
            UserModuleID: '<%=moduleID%>',
            ContainerID: '#' + '<%=ContainerClientID%>',
            baseURL: '<%=currentDirectory%>'+"LogoWebService.asmx/"
            });
    });
</script>

<asp:Literal ID="ltrLogo" runat="server" EnableViewState="false"></asp:Literal>
