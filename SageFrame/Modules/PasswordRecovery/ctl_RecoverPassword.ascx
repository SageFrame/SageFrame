<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctl_RecoverPassword.ascx.cs"
    Inherits="SageFrame.Modules.PasswordRecovery.ctl_RecoverPassword" %>

<div class="sfRecoverPasswordPage" runat="server" id="divRecoverpwd">
  <div class="sfFormwrapper sfLogininside" >
    <asp:Wizard ID="wzdPasswordRecover" runat="server" DisplaySideBar="false" ActiveStepIndex="0"
        DisplayCancelButton="True" CancelButtonType="Button" OnCancelButtonClick="CancelButton_Click" StartNextButtonType="Button"
        StepNextButtonType="Button" StepPreviousButtonType="Button" FinishPreviousButtonType="Button"
        FinishCompleteButtonType="Button" OnNextButtonClick="wzdPasswordRecover_NextButtonClick"
        OnFinishButtonClick="wzdPasswordRecover_FinishButtonClick" Width="100%">
      <FinishNavigationTemplate>
        <div class="sfButtonwrapper">
          <asp:Button ID="FinishButton" runat="server" AlternateText="Finish"  CommandName="MoveComplete" CssClass="sfBtn"
                    Text="Finish" />
        </div>
      </FinishNavigationTemplate>
      <StartNavigationTemplate>
        <div class="sfButtonwrapper">
          <asp:Button ID="StartNextButton" runat="server" AlternateText="Next"  CommandName="MoveNext" CssClass="sfBtn" ValidationGroup="vdgRecoveredPassword"
                    Text="Next" />
          <asp:Button ID="CancelButton" runat="server" AlternateText="Cancel"  CommandName="Cancel" CssClass="sfBtn"
                    Text="Cancel" />
        </div>
      </StartNavigationTemplate>
      <StepNavigationTemplate>
        <div class="sfButtonwrapper">
          <asp:Button ID="StepNextButton" runat="server" AlternateText="Next"  CommandName="MoveNext" CssClass="sfBtn" ValidationGroup="vdgRecoveredPassword"
                    Text="Next" />
        </div>
      </StepNavigationTemplate>
      <WizardSteps>
        <asp:WizardStep ID="WizardStep1" runat="server" Title="Setting New Password"> <%= helpTemplate %>
          <div class="sfFormwrapper">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
              <tr>
                <td width="35%"><asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="sfFormlabel"></asp:Label></td>
                <td width="30">:</td>
                <td><asp:HiddenField ID="hdnRecoveryCode" runat="server" />
                  <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="sfInputbox" MaxLength="20"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="rfvRecoveredPassword" runat="server" ControlToValidate="txtPassword"
                                    ValidationGroup="vdgRecoveredPassword" ErrorMessage="*" CssClass="sfError"></asp:RequiredFieldValidator></td>
              </tr>
              <tr>
                <td><asp:Label ID="lblRetypePassword" runat="server" Text="Retype Password" CssClass="sfFormlabel" MaxLength="20"></asp:Label></td>
                <td width="30">:</td>
                <td><asp:TextBox ID="txtRetypePassword" runat="server" TextMode="Password" CssClass="sfInputbox"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="rfvRetypePassword" runat="server" ControlToValidate="txtRetypePassword"
                                    ValidationGroup="vdgRecoveredPassword" ErrorMessage="*" CssClass="sfError"></asp:RequiredFieldValidator>
                  <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="*" CssClass="sfError"
                                    ControlToCompare="txtPassword" ControlToValidate="txtRetypePassword"  ValidationGroup="vdgRecoveredPassword" ></asp:CompareValidator></td>
              </tr>
              <tr>
                <td colspan="3"><asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vdgRecoveredPassword" /></td>
              </tr>
              <tr>
                <td colspan="3"></td>
              </tr>
            </table>
          </div>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep2" runat="server" Title="Finished Template">
          <asp:Literal ID="litPasswordChangedSuccessful" runat="server"></asp:Literal>
        </asp:WizardStep>
      </WizardSteps>
    </asp:Wizard>
  </div>
</div>
