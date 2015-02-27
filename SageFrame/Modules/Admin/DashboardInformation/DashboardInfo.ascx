<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DashboardInfo.ascx.cs"
    Inherits="Modules_Admin_DashboardInfo_DashboardInfo" %>
<div class="sfWelcomeWrap clearfix" runat="server" id="divDashboardHelp">
    <label class="icon-close sfFloatRight">
        <asp:Button runat="server" ID="btnDisableDashboardhelp" OnClick="btnDisableDashboardhelp_Click" />
    </label>
    <h1>
        Hi! Welcome to SageFrame Welcome Screen.</h1>
    <h2>
        You can take a quick tour to SageFrame, watch video tutorials, read user manuals
        and get an insight of available modules.</h2>
    <div class="sfTutorialWrap clearfix">
        <ul>
            <li class="sfTutorialA">
                <div class="sfTakeTour " id="sfTakeTour">
                </div>
                <h4>
                    Get acquainted with the SageFrame Dashboard.</h4>
                <span class="sfTour">Take the tour</span> </li>
            <li class="sfTutorialB"><a href="http://www.sageframe.com/Video-Gallery.aspx"></a>
                <h4>
                    Let’s start building the site.</h4>
                <span>Watch the video tutorials to get started with your first SageFrame site. </span>
            </li>
            <li class="sfTutorialC">
                <h3>
                    SageFrame Tutorials</h3>
                <a target="new" href="http://sageframe.com/Documentation.aspx">
                    Document Library</a> <a target="new" href="http://sageframe.com/Developer-Guide.aspx">
                       Developer Guide </a><a href="http://sageframe.com/Video-Gallery.aspx">Video Gallery</a>
                 <li class="sfModuleList">
                    <h3>
                        SageFrame3.5 Specials</h3>
                    <a href="#">Payment Gateway Settings </a> 
                    <a href="#">User Import and Export</a>                     
                    </li>
        </ul>
    </div>
</div>
