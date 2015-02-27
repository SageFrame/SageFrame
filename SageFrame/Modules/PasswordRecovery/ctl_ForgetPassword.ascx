<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctl_ForgetPassword.ascx.cs"
    Inherits="SageFrame.Modules.PasswordRecovery.ctl_ForgetPassword" %>
<div class="sfForgetPasswordPage" runat="server" id="divForgotPwd">
    <div class="sfForgetPasswordPageLeft">
        <asp:Wizard ID="wzdForgetPassword" runat="server" DisplaySideBar="False" ActiveStepIndex="0"
            CellPadding="0" CellSpacing="0" DisplayCancelButton="True" CancelButtonType="Button" OnCancelButtonClick="CancelButton_Click"
            StartNextButtonType="Button" StepNextButtonType="Button" StepPreviousButtonType="Button"
            FinishPreviousButtonType="Button" FinishCompleteButtonType="Button" OnFinishButtonClick="wzdForgetPassword_FinishButtonClick"
            OnNextButtonClick="wzdForgetPassword_NextButtonClick">
            <StartNavigationTemplate>
                <div class="sfButtonwrapper sfMarginnone">
                    <asp:Button ID="StartNextButton" runat="server" AlternateText="Next" CausesValidation="True"
                        CommandName="MoveNext" CssClass="sfBtn" Text="Next" ValidationGroup="vdgForgetPassword" />
                    <asp:Button ID="CancelButton" runat="server" AlternateText="Cancel" CausesValidation="False"
                        CommandName="Cancel" CssClass="sfBtn" Text="Cancel" OnClick="CancelButton_Click" />
                </div>
            </StartNavigationTemplate>
            <StepNavigationTemplate>
                <div class="sfButtonwrapper">
                    <asp:Button ID="StepNextButton" runat="server" AlternateText="Next" CausesValidation="False"
                        CommandName="MoveNext" CssClass="sfBtn" Text="Next" />
                </div>
            </StepNavigationTemplate>
            <FinishNavigationTemplate>
                <div class="sfButtonwrapper">
                    <asp:Button ID="FinishButton" runat="server" AlternateText="Finish" CausesValidation="False"
                        CommandName="MoveComplete" CssClass="sfBtn" Text="Finish" />
                </div>
            </FinishNavigationTemplate>
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Prompt for Email Address">
                    <div class="sfForgetYourPassWordTopInfo">
                        <%= helpTemplate %>
                    </div>
                    <div class="sfForgetPasswordInfo">
                        <p>
                                    <asp:Label ID="lblUsername" runat="server" Text="" CssClass="sfFormlabel">User Name :</asp:Label>
                                </p>
                             
                                <p>
                                    <asp:TextBox ID="txtUsername" runat="server" CssClass="sfInputbox" autofocus="autofocus"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                                        ValidationGroup="vdgForgetPassword" ErrorMessage="*" CssClass="sfError"></asp:RequiredFieldValidator>
                                </p>
                           
                                <p>
                                    <asp:Label ID="lblEmail" runat="server" Text="" CssClass="sfFormlabel">Email :</asp:Label>
                                </p>
                           
                                <p>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="sfInputbox"></asp:TextBox>
                                    <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                        ValidationGroup="vdgForgetPassword" ErrorMessage="*" CssClass="sfError"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="Dynamic" ControlToValidate="txtEmail"
                                        CssClass="sfError" SetFocusOnError="true" ValidationGroup="vdgForgetPassword"
                                        ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </p>
                            
                    </div>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" runat="server" Title="Sending Email" StepType="Finish">
                    <asp:Literal ID="litInfoEmailFinish" runat="server"></asp:Literal>
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
    </div>
</div>
</div> 