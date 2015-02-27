<%@ Control Language="C#" ClassName="All" %>
<div id='sfOuterWrapper' class="sfCurve" runat="server">
    <div id='sfHeadertop' class='sfOuterwrapper clearfix'>
        <div class='sfInnerwrapper clearfix'>
            <div class='sfMoreblocks clearfix'>
                <div id="sfBdlogo" style='width: 20%; float: left'>
                    <div class='sfWrapper'>
                        <asp:PlaceHolder ID='pch_bdlogo' runat='server'></asp:PlaceHolder>
                    </div>
                </div>
                <div id="sfBdnavigation" style='width: 80%; float: left'>
                    <div class='sfWrapper'>
                        <asp:PlaceHolder ID='pch_bdnavigation' runat='server'></asp:PlaceHolder>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id='sfBanner' class='sfOuterwrapper clearfix'>
        <div class='sfInnerwrapper clearfix'>
            <div class='sfWrapper'>
                <asp:PlaceHolder ID='pch_bdbanner' runat='server'></asp:PlaceHolder>
            </div>
        </div>
    </div>
    <div id='sfBodyContent' class='sfOuterwrapper sfCurve clearfix'>
        <div class='sfInnerwrapper clearfix'>
            <div class='clearfix'>
                <div id='sfMainWrapper' style='width: 69%'>
                    <div class='sfContainer sfCurve'>
                        <div class='sfMainContent sfCurve'>
                            <div class='sfMiddlemaincurrent '>
                                <div class='sfWrapper'>
                                    <asp:PlaceHolder ID='pch_innercontent' runat='server'></asp:PlaceHolder>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id='sfRight' style='width: 31%'>
                    <div class='sfContainer sfCurve'>
                        <div class='sfColswrap sfSingle sfCurve clearfix'>
                            <div class='sfRighta clearfix ' style='width: 100%'>
                                <div class='sfWrapper'>
                                    <asp:PlaceHolder ID='pch_rightb' runat='server'></asp:PlaceHolder>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id='sfFooterbtn' class='sfOuterwrapper clearfix'>
        <div class='sfInnerwrapper clearfix'>
            <div class='sfMoreblocks clearfix'>
                <div class='sfFixed1' style='float: left; width: 50%'>
                    <div class='sfWrapper'>
                        <asp:PlaceHolder ID='pch_bdcopyright' runat='server'></asp:PlaceHolder>
                    </div>
                </div>
                <div class='sfFixed2' style='float: left; width: 50%'>
                    <div class='sfWrapper'>
                        <asp:PlaceHolder ID='pch_bdfootermenu' runat='server'></asp:PlaceHolder>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
