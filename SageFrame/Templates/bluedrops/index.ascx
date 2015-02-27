<%@ Control Language="C#" ClassName="index" %>
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
            <div id='sfMainWrapper' style='width: 100%'>
                <div class='sfContainer sfCurve'>
                    <div class='sfMiddletop'>
                        <div class='sfMoreblocks clearfix'>
                            <div class='sfFixed1' style='float: left; width: 33%; min-height: 99px'>
                                <div class='sfWrapper'>
                                    <asp:PlaceHolder ID='pch_box1' runat='server'></asp:PlaceHolder>
                                </div>
                            </div>
                            <div class='sfFixed2' style='float: left; width: 33%; min-height: 99px'>
                                <div class='sfWrapper'>
                                    <asp:PlaceHolder ID='pch_box2' runat='server'></asp:PlaceHolder>
                                </div>
                            </div>
                            <div class='sfFixed3' style='float: left; width: 34%; min-height: 99px'>
                                <div class='sfWrapper'>
                                    <asp:PlaceHolder ID='pch_box3' runat='server'></asp:PlaceHolder>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class='sfMainContent sfCurve'>
                        <div class='sfMiddlemaintop'>
                            <div class='sfWrapper'>
                                <asp:PlaceHolder ID='pch_welcome' runat='server'></asp:PlaceHolder>
                            </div>
                        </div>
                        <div class='sfMiddlemaincurrent'>
                            <div class='sfMoreblocks clearfix'>
                                <div class='sfFixed1' style='float: left; width: 33%'>
                                    <div class='sfWrapper'>
                                        <asp:PlaceHolder ID='pch_whatsnew' runat='server'></asp:PlaceHolder>
                                    </div>
                                </div>
                                <div class='sfFixed2' style='float: left; width: 33%'>
                                    <div class='sfWrapper'>
                                        <asp:PlaceHolder ID='pch_about' runat='server'></asp:PlaceHolder>
                                    </div>
                                </div>
                                <div class='sfFixed3' style='float: left; width: 34%'>
                                    <div class='sfWrapper'>
                                        <asp:PlaceHolder ID='pch_services' runat='server'></asp:PlaceHolder>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class='sfMiddlemainbottom'>
                            <div class='sfMoreblocks clearfix'>
                                <div class='sfWrapper'>
                                    <asp:PlaceHolder ID='pch_bdmidinfo' runat='server'></asp:PlaceHolder>
                                </div>
                                <div class='sfWrapper'>
                                    <asp:PlaceHolder ID='pch_bdgallery' runat='server'></asp:PlaceHolder>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id='sfFootertop' class='sfOuterwrapper clearfix'>
        <div class='sfInnerwrapper clearfix'>
            <div class='sfMoreblocks clearfix'>
                <div class='sfFixed1' style='float: left; width: 33%'>
                    <div class='sfWrapper'>
                        <asp:PlaceHolder ID='pch_bdtwitter' runat='server'></asp:PlaceHolder>
                    </div>
                </div>
                <div class='sfFixed2' style='float: left; width: 33%'>
                    <div class='sfWrapper'>
                        <asp:PlaceHolder ID='pch_bdblog' runat='server'></asp:PlaceHolder>
                    </div>
                </div>
                <div class='sfFixed3' style='float: left; width: 34%'>
                    <div class='sfWrapper'>
                        <asp:PlaceHolder ID='pch_bdcontact' runat='server'></asp:PlaceHolder>
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
