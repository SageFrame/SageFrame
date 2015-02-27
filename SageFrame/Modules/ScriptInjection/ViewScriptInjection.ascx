<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewScriptInjection.ascx.cs"
    Inherits="Modules_ScriptInjection_ViewScriptInjection"  %>

<script type="text/javascript">
//replaced
    $(this).EmbedScript({
        PortalID: '<%=PortalID%>',
        UserModuleID:'<%=UserModuleID%>',
        baseURL:ServicePath
    });
</script>

<%--zipped file
--%><asp:Literal ID="ltrScriptInject" runat="server"></asp:Literal>

