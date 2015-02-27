<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BreadCrumb.ascx.cs"
    Inherits="Modules_BreadCrumb_BreadCrumb" %>

<script type="text/javascript">
    var DefaultPortalHomePage = '<%=DefaultPortalHomePage %>';
    $(function() {
        $(this).BreadCrumbBuilder({
            baseURL: BreadCrumPagePath + '/Modules/BreadCrumb/BreadCrumbWebService.asmx/',
            PagePath: BreadCrumPageLink,
            PortalID: '<%=PortalID%>',
            PageName: '<%=PageName%>',
            Container: "div.sfBreadcrumb",
            MenuId:'<%=MenuID%>'
        });
    });
</script>

<div class="sfBreadcrumb">
<%--<asp:Literal ID="ltrBreadCrumb" runat="server"></asp:Literal>--%>
</div>
