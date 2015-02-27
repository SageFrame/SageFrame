<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctl_SageSearchResult.ascx.cs"
    Inherits="Modules_SageSearch_ctl_SageSearchResult" %>

<div class="sfSearchpage">
  <h1>
    <asp:Label ID="lblSeachLable" Text="Search Keyword:" runat="server"></asp:Label>
    <asp:Label ID="lblSearchKeyword" runat="server" CssClass="sfSearchkey"></asp:Label>
  </h1>
  <div class="sfSearchorder clearfix">
    <ul>
      <li>
        <asp:RadioButtonList ID="rblOrdering" ToolTip="Select one of them." RepeatLayout="Table"
                                runat="server" RepeatColumns="4" RepeatDirection="Horizontal" CssClass="sfListmenu" ValidationGroup="sage_searchresultfilter"> </asp:RadioButtonList>
      </li>
      <li class="sfRight">
        <asp:Label ID="lblDisplay" runat="server" Text="Display:" CssClass="sfFormlabel"
                                            ToolTip="Select one of them"></asp:Label>
        <asp:DropDownList ID="ddlGridPager" CssClass="sfListmenu" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlGridPager_SelectedIndexChanged" ValidationGroup="sage_searchresultfilter">
          <asp:ListItem Value="0">All</asp:ListItem>
          <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
          <asp:ListItem Value="25">25</asp:ListItem>
          <asp:ListItem Value="50">50</asp:ListItem>
          <asp:ListItem Value="75">75</asp:ListItem>
          <asp:ListItem Value="100">100</asp:ListItem>
        </asp:DropDownList>
      </li>
    </ul>
  </div>
  <div class="sfSearchonly">
    <h2>
      <asp:Label ID="lblSearchOnly" runat="server" Text="Search Only text:"
                                            ToolTip="Select one of them"></asp:Label>
    </h2>
    <ul>
      <li>
        <asp:CheckBoxList ID="cblResultSection" ToolTip="Chek those boxs that you want."
                                            RepeatLayout="Table" runat="server" RepeatColumns="5" Width="100%" RepeatDirection="Horizontal"
                                             ValidationGroup="sage_searchresultfilter"> </asp:CheckBoxList>
      </li>
    </ul>
    <div class="sfButtonwrapper"> 
      <!--<asp:ImageButton ID="imbFilter" runat="server" OnClick="imbFilter_Click" CausesValidation="true" ValidationGroup="sage_searchresultfilter"/>-->
      <asp:Label ID="lblFilter" runat="server" Text="Filter" CssClass="sfBtn" AssociatedControlID="imbFilter"></asp:Label>
    </div>
  </div>
  <div class="sfSearchresult">
    <asp:GridView Width="100%" runat="server" ID="gdvList" AutoGenerateColumns="False"
                        AllowPaging="True" EmptyDataText=".........No result found........." OnPageIndexChanging="gdvList_PageIndexChanging"
                        ShowHeader="False">
      <EmptyDataRowStyle CssClass="sfNotFound" />
      <Columns>
      <asp:TemplateField>
        <ItemTemplate>
          <h2> <a href='<%# Eval("ResultUrl")%>' class="sfResultRedirect">
            <asp:Label ID="lblResultTitle" runat="server" Text='<%# Eval("ResultTitle")%>' CssClass="sfResultTitle"></asp:Label>
            </a> </h2>
          <%--<h3>
            <asp:Label ID="lblResultSection" runat="server" Text=''
                                            CssClass="sfResultSection"></asp:Label>
          </h3>--%>
          <p>
            <asp:Label ID="lblResultDetail" runat="server" Text='<%# FormatResult(Eval("ResultDetail").ToString())%>'
                                            CssClass="sfResultDetail"></asp:Label>
          </p>
          <%--<span class="sfUrlLink"><a href='<%# Eval("ResultUrl")%>' class="sfResultRedirect"> <%# Eval("ResultUrl")%></a></span>--%>
        </ItemTemplate>
      </asp:TemplateField>
      </Columns>
      <PagerStyle CssClass="sfPagination" />
      <RowStyle CssClass="sfOdd" />
      <AlternatingRowStyle CssClass="sfEven" />
    </asp:GridView>
  </div>
</div>
