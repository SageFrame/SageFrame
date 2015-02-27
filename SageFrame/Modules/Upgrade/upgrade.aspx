<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upgrade.aspx.cs" Inherits="upgrade" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script src="../js/jquery-1.4.4.js" type="text/javascript"></script>
<link href="../../Administrator/Templates/Default/css/admin.css" rel="stylesheet"
        type="text/css" />
<script type="text/javascript">
    var ModuleFilePath="../Modules/Upgrade/";

 $(document).ready(function() {   
   
   
    var options = {
        type: "POST",
        url: '<%=appPath%>'+"/Upgrade",
        data:"{installerZipFile:'<%=ViewState["fileName"]%>'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg) {
            if(msg.d=="done"){
               window.location="../";
            }
        }
    };
    
    $.ajax(options);
    
    
       var refreshId = setInterval(function() {        
          $("#reportDiv").load(ModuleFilePath+'Reporter.ashx',function(response,status,xhr){            
                if(response.d!=null && response.d.lastIndexOf("Successfully")>-1){
                      clearInterval(refreshId);
                }
         });
       }, 4000);       
       $.ajaxSetup({ cache: false });
  
   
});
</script>
</head>
<body>
<h1> Sageframe Upgrading Report</h1>
<div class="sfFormwrapper sfPadding">
  <div id="reportDiv"></div>
</div>
</body>
</html>
