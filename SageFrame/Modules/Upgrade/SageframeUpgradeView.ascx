<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SageframeUpgradeView.ascx.cs" Inherits="Modules_Upgrade_SageframeUpgrade" %>
<%--<script type="text/javascript">


 $(document).ready(function() {   
   
     var upgrade='<%=btnUpload.ClientID %>';
     $("#"+upgrade).click(function(){
      
       $("#upgradeDiv").hide();
       var refreshId = setInterval(function() {        
          $("#reportDiv").load('../Reporter.ashx',function(response,status,xhr){            
                if(response.d!=null && response.d.lastIndexOf("Successfully")>-1){
                      clearInterval(refreshId);
                }
         });
       }, 4000);       
       $.ajaxSetup({ cache: false });
     });   
   
});
</script>--%>
<style>
.borderClass {
	border:solid 1px black;
	height:150px;
	width:350px;
	padding:5px 5px 5px 35px
}
.headerClass {
	background-color:Gray;
	font-size:large;
	font-weight:bold;
	padding:5px 5px 5px 25px
}
.errorMsgClass {
	color:Red;
}
#uniform-ctl13_fuUpgrade input {
	opacity:100 !important;
}
</style>
<%--<div id="reportDiv"></div>--%>
<h1>SageFrame Upgrader</h1>
<div class="sfFormwrapper sfPadding">
  <asp:FileUpload ID="fuUpgrade" runat="server"  />
 <div class="sfButtonwrapper"> <asp:Button ID="btnUpload" CssClass="sfBtn" runat="server" onclick="btnUpload_Click" 
        Text="Upgrade" />
  <asp:Label ID="lblErrorMsg" runat="server" Text="" CssClass="sfRequired"></asp:Label></div>
</div>
