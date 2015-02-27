<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewAllNews.ascx.cs" Inherits="SageFrame.Modules.NewsModule.ViewAllNews" %>
<asp:HiddenField ID="hdnUserModuleID" runat="server" Value="0" />
<asp:Panel ID="pnlDetailNews" runat="server" 
    meta:resourcekey="pnlDetailNewsResource1">
  <div class="sfNewsholder">
    <div class="sfFormwrapper">
      <h2>
        <asp:Label ID="lblNewsTitle" runat="server" 
                        meta:resourcekey="lblNewsTitleResource1"></asp:Label>
      </h2>
      <div class="sfNewsinfo">
        <asp:Label ID="lblNewsDate1" runat="server" class="sfNewsdate"
                            meta:resourcekey="lblNewsDate1Resource1"></asp:Label>
        <div class="sfNewsdesc">
          <asp:Literal ID="ltrNewsLong" runat="server" 
                            meta:resourcekey="ltrNewsLongResource1"></asp:Literal>
        </div>
      </div>
    </div>
    <div class="sfButtonwrapper">
      <asp:ImageButton ID="imgCancel" runat="server" OnClick="imbBack_Click" 
                meta:resourcekey="imgCancelResource1" />
      <asp:Label ID="lblCancel" runat="server" Text="Back" AssociatedControlID="imgCancel" CssClass="sfFormlabel" meta:resourcekey="lblCancelResource1"></asp:Label>
    </div>
  </div>
  </asp:Panel>
<asp:Panel ID="pnlMoreNews" runat="server" 
    meta:resourcekey="pnlMoreNewsResource1">
  <div class="sfNewsholder">
    <div class="sfFormwrapper">
      <asp:Label ID="lblNewsCatList" runat="server" Text="News Category:" 
            CssClass="sfFormlabel" meta:resourcekey="lblNewsCatListResource1"></asp:Label>
      <asp:DropDownList ID="ddlNewsCatList" runat="server" CssClass="sfListmenu"
            AutoPostBack="True" 
            OnSelectedIndexChanged="ddlNewsCatList_SelectedIndexChanged" 
            meta:resourcekey="ddlNewsCatListResource1"> </asp:DropDownList>
    </div>
    <div class="sfGridwrapper">
      <asp:GridView ID="gdvAllNews" ShowHeader="False" GridLines="None" AutoGenerateColumns="False"
                AllowPaging="True" runat="server" Width="100%" OnRowCommand="gdvAllNews_RowCommand"
                EmptyDataText=".........No News filed under this category........." OnRowDeleting="gdvAllNews_RowDeleting"
                OnRowEditing="gdvAllNews_RowEditing" 
                OnRowUpdating="gdvAllNews_RowUpdating" OnSelectedIndexChanging="gdvAllNews_SelectedIndexChanging"
                OnRowDataBound="gdvAllNews_RowDataBound" OnPageIndexChanging="gdvAllNews_PageIndexChanging"
                PageSize="5" meta:resourcekey="gdvAllNewsResource1">
        <Columns>
        <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
          <ItemTemplate>
            <div class="sfNews">
              <h2>
                <asp:HiddenField ID="hdfNewsID" runat="server" 
                                        Value='<%# DataBinder.Eval(Container.DataItem, "NewsID") %>' />
                <asp:HyperLink ID="hlnknewsInDetails" runat="server" 
                                        Text='<%# DataBinder.Eval(Container.DataItem, "NewsTitle") %>' 
                                        meta:resourcekey="hlnknewsInDetailsResource1"></asp:HyperLink>
              </h2>
              <div class="sfNewsinfo">
                <asp:Label ID="lblNewsDate" runat="server"  CssClass="sfNewsdate"
                                            Text='<%# DataBinder.Eval(Container.DataItem, "NewsDate") %>' 
                                            meta:resourcekey="lblNewsDateResource1"></asp:Label>
                <p>
                  <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NewsShortDescription") %>'
                                            ID="lblShortNews" meta:resourcekey="lblShortNewsResource1" />
                </p>
              </div>
            </div>
          </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        <AlternatingRowStyle CssClass="sfEven" />
        <PagerStyle CssClass="sfPagination" />
        <RowStyle CssClass="sfOdd" />
      </asp:GridView>
    </div>
    <div class="sfButtonwrapper">
      <asp:ImageButton ID="imbBack" runat="server" OnClick="imbBack_Click" 
            meta:resourcekey="imbBackResource1" />
      <asp:Label ID="lblBack" runat="server" Text="Back" AssociatedControlID="imbBack" CssClass="sfFormlabel" meta:resourcekey="lblBackResource1"></asp:Label>
    </div>
  </div>
  </asp:Panel>
