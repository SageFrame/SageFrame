<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Subscription.ascx.cs"
    Inherits="Modules_Subscribe_Subscription" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<div class="sfNewsletter" id="newsLetter" runat="server">
  <asp:Literal ID="lblHelpText" runat="server" Visible="false"></asp:Literal>
  <p>
    <asp:TextBox ID="txtNewsLetterEmail" runat="server" ValidationGroup="newsletter"
            CssClass="sfInputbox"></asp:TextBox>
    <cc1:TextBoxWatermarkExtender TargetControlID="txtNewsLetterEmail" WatermarkText="Subscribe to our newsletter"
            ID="txtWatermarkExtender" runat="server"> </cc1:TextBoxWatermarkExtender>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewsLetterEmail"
            ErrorMessage="Email address is required" ValidationGroup="newsletter" 
            Display="Dynamic" SetFocusOnError="True" CssClass="sfRequired" ToolTip="Enter Email address">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNewsLetterEmail"
            ErrorMessage="Invalid email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            ValidationGroup="newsletter" Display="Dynamic" SetFocusOnError="True" 
            ToolTip="Enter valid email Address"></asp:RegularExpressionValidator>
  </p>
  <asp:Button ID="btnSubscribe" runat="server" CssClass="sfBtn"
            OnClick="btnSubscribe_Click" ValidationGroup="newsletter" />
</div>
<div id="mainContainer" runat="server"> </div>
