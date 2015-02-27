<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SageMenu.ascx.cs" Inherits="Modules_SageMenu_SageMenu" %>

<asp:Literal ID="ltrNav" runat="server" EnableViewState="false"></asp:Literal>
 <script type="text/javascript">
    $(function(){    
       $(this).SageMenuBuilder({
                        PortalID:'<%=PortalID%>',
                        UserModuleID:'<%=UserModuleID%>',                        
                        UserName:'<%=UserName%>',
                        PageName:'<%=PageName%>',
                        ContainerClientID:'#'+'<%=ContainerClientID%>',
                        CultureCode:'<%=CultureCode%>',
                        baseURL:Path+'MenuWebService.asmx/',
                        AppPath:'<%=appPath%>'         
       });  
    });
    </script>
   
   
    
    
 
