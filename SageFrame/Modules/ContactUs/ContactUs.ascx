<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactUs.ascx.cs" Inherits="SageFrame.Modules.ContactUs.ContactUs" %>

<script language="javascript" type="text/javascript">
    //<![CDATA[
    $(function() {
        $(this).feedback({
            emailSucessMsg: '<%=emailSucessMsg%>',
            PortalID: '<%=PortalID %>',
            ContactUsPath: '<%=ModulePath %>',
            UserName: '<%=UserName %>',
            subject: '<%=messageSubject %>',
            UserModuleID: '<%=UserModuleID %>'
        });
        $(".sfLocale").SystemLocalize();
    });
    //]]>
</script>

<div class="cssClassFormWrapper">
    <div class="feedback-panel">
        <div class="cssClassContactWrapper">
            <div class="bannerText cssClassResetMargin">
                <h2>
                    Contact Us
                </h2>
                <p class="sfNote">
                    All fields are mandatory.</p>
                <div class="sfFormGroup">
                <label>Name</label>
                    <input type="text" id="txtName" name="name" class="sfInputbox required" placeholder="Your Name" />
                    </div>
                    <div class="sfFormGroup">
                    <label>Email</label>

                    <input type="email" id="txtContactEmail" name="email" class="sfInputbox required email"
                        placeholder="Your Email ID" />
                </div>
                <div class="sfFormGroup msgbox">
                <label>Message</label>
                    <textarea id="txtMessage" name="message" class="sfInputbox required" rows="5" cols="35" placeholder="Type Your Message"></textarea>
                </div>
                <div class="cssClassButtonWrapper">
                    <input type="button" id="btnSubmit" class="sfBtn sfPrimaryBtn sfLocale" value="Submit" />
                </div>
            </div>
        </div>
    </div>
</div>
