<%@ Control Language="C#" ClassName=custom %>
<div id='sfOuterWrapper' class="sfCurve" runat="server">
  <div id='sfHeadertop' class='sfOuterwrapper clearfix'>
    <div class='sfInnerwrapper clearfix'>
      <div class='sfWrapper'>
        <asp:PlaceHolder ID='pch_headertop' runat='server'></asp:Placeholder>
      </div>
    </div>
  </div>
  <div id='sfBanner' class='sfOuterwrapper clearfix'>
    <div class='sfInnerwrapper clearfix'>
      <div class='sfWrapper'>
        <asp:PlaceHolder ID='pch_banner' runat='server'></asp:Placeholder>
      </div>
    </div>
  </div>
  <div id='sfSpotlight' class='sfOuterwrapper clearfix'>
    <div class='sfInnerwrapper clearfix'>
      <div class='sfMoreblocks clearfix'>
        <div class='sfFixed1' style='float:left;width:33%;min-height:150px'>
          <div class='sfWrapper'>
            <asp:PlaceHolder ID='pch_pos1' runat='server'></asp:Placeholder>
          </div>
        </div>
        <div class='sfFixed2' style='float:left;width:33%;min-height:150px'>
          <div class='sfWrapper'>
            <asp:PlaceHolder ID='pch_pos2' runat='server'></asp:Placeholder>
          </div>
        </div>
        <div class='sfFixed3' style='float:left;width:33%;min-height:150px'>
          <div class='sfWrapper'>
            <asp:PlaceHolder ID='pch_pos3' runat='server'></asp:Placeholder>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div id='sfBodyContent' class='sfOuterwrapper sfCurve clearfix'>
    <div class='sfInnerwrapper clearfix'>
      <div id='sfMainWrapper'  style='width:80%'>
        <div class='sfContainer sfCurve'>
          <div class='sfMainContent sfCurve'>
            <div class='middlemaincurrent'>
              <div class='sfWrapper'>
                <asp:PlaceHolder ID='pch_middlemaincurrent' runat='server'></asp:Placeholder>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div id='sfRight' style='width:20%'>
        <div class='sfContainer sfCurve'>
          <div class='sfColswrap sfSingle sfCurve'>
            <div  class='sfRightB' style='width:100%'>
              <div class='sfWrapper sfCurve'>
                <asp:PlaceHolder ID='pch_righta' runat='server'></asp:Placeholder>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div id='sfFooter' class='sfOuterwrapper clearfix'>
    <div class='sfInnerwrapper clearfix'>
      <div class='sfWrapper'>
        <asp:PlaceHolder ID='pch_footer' runat='server'></asp:Placeholder>
      </div>
    </div>
  </div>
</div>
