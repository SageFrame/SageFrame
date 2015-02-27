<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TwitterSettings.ascx.cs"
    Inherits="Modules_Twitter_TwitterSettings" %>
<h1 class="cssClassFormHeading">
    <asp:Label ID="lblHeading" runat="server" CssClass="sfFormlabel" Text="TwitterDeck Settings" /></h1>
<div class="sfFormwrapper">
    <table width="100%" cellpadding="0" cellspacing="0">
        
        <tr>
            <td>
                <asp:Label ID="lblUrl" runat="server" Text="Screen Name" CssClass="sfFormlabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtScreenName" runat="server" CssClass="sfInputbox"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvScreenName" runat="server" ErrorMessage="*"
                    ControlToValidate="txtScreenName" ValidationGroup="twitterdecksetting" CssClass="cssClassNormalRed"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCount" runat="server" Text="No of tweets to display" CssClass="sfFormlabel"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTwittsCount" runat="server" CssClass="sfInputbox" ValidationGroup="twitterdecksetting" ></asp:TextBox>
                <asp:RangeValidator ControlToValidate="txtTwittsCount" MinimumValue="0"  ValidationGroup="twitterdecksetting" MaximumValue="500"
                    ID="RangeValidator1" runat="server" ErrorMessage="Invalid Count"></asp:RangeValidator>
                 <asp:RequiredFieldValidator ID="rfvTwittsCount" runat="server" ErrorMessage="*"
                    ControlToValidate="txtTwittsCount" ValidationGroup="twitterdecksetting" CssClass="cssClassNormalRed"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cmpValNo_ofCounts" runat="server" ControlToValidate="txtTwittsCount"
                    ErrorMessage="Must be an integer" Type="Integer" Operator="DataTypeCheck" CssClass="cssClassNormalRed"
                    ValidationGroup="twitterdecksetting"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <div class="sfButtonwrapper">
                    <asp:ImageButton ID="imbSave" runat="server" OnClick="imbSave_Click" ValidationGroup="twitterdecksetting" />
                    <asp:Label ID="lblSave" runat="server" AssociatedControlID="imbSave" Style="cursor: pointer;"
                        Text="Save"></asp:Label>
                </div>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</div>
