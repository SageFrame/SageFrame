(function($) {
    $.createSageMenu = function(p) {
        p = $.extend
        ({
            PortalID: 1,
            UserModuleID: 1,
            UserName: 'user',
            PageName: 'Home',
            ContainerClientID: 'divNav1',
            CultureCode: 'en-US',
            baseURL: 'Services/Services.aspx/',
            AppPath: "/sageframe"
        }, p);

        var SageMenu = {
            config: {
                isPostBack: false,
                async: false,
                cache: false,
                type: 'POST',
                contentType: "application/json; charset=utf-8",
                data: { data: '' },
                dataType: 'json',
                baseURL: p.baseURL,
                method: "",
                url: "",
                ajaxCallMode: 0,
                arr: [],
                arrPages: [],
                UserModuleID: p.UserModuleID,
                PortalID: p.PortalID,
                UserName: p.UserName,
                PageName: p.PageName,
                ContainerClientID: p.ContainerClientID,
                CultureCode: p.CultureCode

            },
            init: function() {
                this.LoadUserModuleSettings();
                this.BindEvents();
                this.HighlightSelected();
            },
            HighlightSelected: function() {
                var menu = $(SageMenu.config.ContainerClientID + " ul li");
                var menu = $(SageMenu.config.ContainerClientID + " ul li");
                $.each(menu, function(index, item) {
                    var hreflink = $(this).find("a").attr("href");
                    if (hreflink != undefined) {
                        if (location.href.toLowerCase().indexOf("aspx") == -1) {
                            if (location.href.toLowerCase().indexOf(hreflink.toLowerCase()) > -1 || hreflink.toLowerCase().indexOf(SageFrameDefaultPage) > -1) {
                                $(this).addClass('sfActive');
                            }
                        }
                        else {
                            if (location.href.toLowerCase().indexOf(hreflink.toLowerCase()) > -1) {
                                $(this).addClass('sfActive');
                            }
                        }
                    }
                });
            },
            ajaxSuccess: function(data) {
                switch (SageMenu.config.ajaxCallMode) {
                    case 0:
                    case 1:
                        SageMenu.BuildMenu(data);
                        break;
                    case 2:
                        SageMenu.BindPages(data);
                        break;
                    case 3:
                        SageMenu.BuildFooterMenu(data);
                        break;
                    case 4:
                        SageMenu.BuildSideMenu(data);
                        break;
                }
            },
            BindEvents: function() {
                $(SageMenu.config.ContainerClientID + " ul li").live("click", function() {
                    $(SageMenu.config.ContainerClientID + " ul li").removeClass("sfActive");
                    $(this).addClass("sfActive");
                });
            },
            ajaxFailure: function() {
            },
            ajaxCall: function(config) {
                $.ajax({
                    type: SageMenu.config.type,
                    contentType: SageMenu.config.contentType,
                    cache: SageMenu.config.cache,
                    url: SageMenu.config.url,
                    data: SageMenu.config.data,
                    dataType: SageMenu.config.dataType,
                    success: SageMenu.ajaxSuccess,
                    error: SageMenu.ajaxFailure
                });

            },
            GetPages: function(settings) {
                this.config.method = "GetMenuFront";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ PortalID: parseInt(SageMenu.config.PortalID), UserName: SageMenu.config.UserName, CultureCode: p.CultureCode, UserModuleID: p.UserModuleID });

                $.ajax({
                    type: SageMenu.config.type,
                    contentType: SageMenu.config.contentType,
                    cache: SageMenu.config.cache,
                    url: SageMenu.config.url,
                    data: SageMenu.config.data,
                    dataType: SageMenu.config.dataType,
                    success: function(data) {
                        SageMenu.BindPages(data, settings);
                    },
                    error: SageMenu.ajaxFailure
                });
            },
            LoadUserModuleSettings: function() {
                this.config.method = "GetMenuSettings";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ PortalID: SageMenu.config.PortalID, UserModuleID: SageMenu.config.UserModuleID });
                this.config.ajaxCallMode = 1;
                this.ajaxCall(this.config);
            },
            BuildMenu: function(data) {
                var setting = data.d;

                switch (parseInt(setting.MenuType)) {
                    case 0:
                        SageMenu.LoadTopAdminMenu();
                        break;
                    case 1:
                        SageMenu.GetPages(setting);
                        break;
                    case 2:
                        if (setting.SideMenuType == 1) {
                            SageMenu.LoadSideMenu(setting);
                        }
                        else {
                            SageMenu.LoadCustomSideMenu(setting);
                        }
                        break;
                    case 3:
                        SageMenu.LoadFooterMenu(setting);
                        break;
                }
            },
            LoadTopAdminMenu: function() { },
            BuildTopAdminMenu: function(data) { },
            LoadSideMenu: function(settings) {
                this.config.method = "GetSideMenu";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ PortalID: parseInt(SageMenu.config.PortalID), UserName: SageMenu.config.UserName, PageName: SageMenu.config.PageName, CultureCode: p.CultureCode });
                $.ajax({
                    type: SageMenu.config.type,
                    contentType: SageMenu.config.contentType,
                    cache: SageMenu.config.cache,
                    url: SageMenu.config.url,
                    data: SageMenu.config.data,
                    dataType: SageMenu.config.dataType,
                    success: function(data) {
                        SageMenu.BuildSideMenu(data, settings);

                    },
                    error: SageMenu.ajaxFailure
                });
            },
            LoadCustomSideMenu: function(settings) {
                this.config.method = "GetCustomSideMenu";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ PortalID: parseInt(SageMenu.config.PortalID), UserName: SageMenu.config.UserName, CultureCode: p.CultureCode, UserModuleID: p.UserModuleID });
                $.ajax({
                    type: SageMenu.config.type,
                    contentType: SageMenu.config.contentType,
                    cache: SageMenu.config.cache,
                    url: SageMenu.config.url,
                    data: SageMenu.config.data,
                    dataType: SageMenu.config.dataType,
                    success: function(data) {
                        SageMenu.BindCustomSideMenu(data, settings);

                    },
                    error: SageMenu.ajaxFailure
                });
            },
            LoadFooterMenu: function(settings) {
                this.config.method = "GetFooterMenu";
                this.config.url = this.config.baseURL + this.config.method;
                this.config.data = JSON2.stringify({ PortalID: parseInt(SageMenu.config.PortalID), UserName: SageMenu.config.UserName, CultureCode: p.CultureCode, UserModuleID: p.UserModuleID });
                $.ajax({
                    type: SageMenu.config.type,
                    contentType: SageMenu.config.contentType,
                    cache: SageMenu.config.cache,
                    url: SageMenu.config.url,
                    data: SageMenu.config.data,
                    dataType: SageMenu.config.dataType,
                    success: function(data) {
                        SageMenu.BuildFooterMenu(data, settings);

                    },
                    error: SageMenu.ajaxFailure
                });
            },
            BuildMenuClassContainer: function(MenuMode) {
                var html = '';
                switch (parseInt(MenuMode)) {
                    case 1:
                        html = '<ul class="sf-menu sf-vertical">';
                        break;
                    case 2:
                        html = '<ul class="sf-menu sf-navbar">';
                        break;
                    case 3:
                        html = '<ul class="sf-menu sfDropdown">';
                        break;
                    case 4:
                        html = '<ul class="sf-menu sfCssmenu">';
                        break;
                }
                return html;
            },
            BuildMenuItem: function(displayMode, item, PageLink, caption) {
                var html = '';
                if (!item.IsActive) { PageLink = '#'; }
                var title = item.LinkType == 0 ? item.PageName : item.Title;
                PageLink = item.LinkType == 1 ? '#' : PageLink;

                var image = p.AppPath + "/PageImages/" + item.ImageIcon;
                var imagetag = item.ImageIcon != "" ? '<img src=' + image + '>' : '';
                var arrowStyle = item.ChildCount > 0 ? '<span class="sf-sub-indicator"> »</span>' : '';
                switch (parseInt(displayMode)) {
                    case 0: //image only
                        if (caption == 1) {
                            html = '<a  href=' + PageLink + '><span class="sfPageicon">' + imagetag + '<em>' + item.Caption + '</em>' + '</span>' + arrowStyle + '</a>';
                        }
                        else {
                            html = '<a  href=' + PageLink + '><span class="sfPageicon">' + imagetag + '</span>'+arrowStyle+'</a>';
                        }
                        break;
                    case 1: //text only
                        if (caption == 1) {
                            html = '<a  href=' + PageLink + '><span class="sfPagename">' + title + '<em>' + item.Caption + '</em></span>' + arrowStyle + '</a>';
                        }
                        else {
                            html = '<a  href=' + PageLink + '><span class="sfPagename">' + title + '</span>' + arrowStyle + '</a>';
                        }

                        break;
                    case 2: //text and image both

                        if (caption == 1) {
                            html = '<a  href=' + PageLink + '><span class="sfPageicon">' + imagetag + '</span><span class="sfPagename">' + title + '<em>' + item.Caption + '</em></span>' + arrowStyle + '</a>';
                        }
                        else {
                            html = '<a  href=' + PageLink + '><span class="sfPageicon">' + imagetag + '</span><span class="sfPagename">' + title + '</span>' + arrowStyle + '</a>';
                        }


                        break;
                }
                return html;
            },

            BindPages: function(data, settings) {
                var pages = data.d;
                var PageID = "";
                var parentID = "";
                var PageLevel = 0;
                var itemPath = "";
                var html = "";
                var rootItemCount = 0;
                $.each(pages, function(index, item) {
                    if (item.MenuLevel == 0) {
                        rootItemCount = index;
                    }
                });

                html += SageMenu.BuildMenuClassContainer(settings.TopMenuSubType);
                $.each(pages, function(index, item) {
                    PageID = item.MenuItemID;
                    parentID = item.ParentID;
                    categoryLevel = item.MenuLevel;
                    if (item.MenuLevel == 0) {
                        var PageLink = item.LinkType == 0 ? PagePath + item.URL + ".aspx" : item.LinkURL;
                        if (item.ChildCount > 0) {
                            var firstClass = index == 0 ? 'class="sfFirst sfParent"' : index == rootItemCount ? 'class="sfParent sfLast"' : 'class="sfParent"';
                            html += '<li ' + firstClass + '>' + SageMenu.BuildMenuItem(settings.DisplayMode, item, PageLink, settings.Caption);
                        }
                        else {
                            var firstClass = index == 0 ? 'class="sfFirst"' : index == rootItemCount ? 'class="sfLast"' : '';
                            html += '<li ' + firstClass + '>' + SageMenu.BuildMenuItem(settings.DisplayMode, item, PageLink, settings.Caption);
                        }

                        if (parseInt(item.LinkType) == 1) {
                            html += '<ul class="megamenu"><li style="><div class="megawrapper">' + item.HtmlContent + '</div></li></ul>';
                        }
                        else {
                            if (item.ChildCount > 0) {
                                html += "<ul>";
                                itemPath += item.Title;
                                html += SageMenu.BindChildCategory(pages, PageID, settings.DisplayMode, settings.Caption);

                                html += "</ul>";
                            }
                        }
                        html += "</li>";
                    }
                    itemPath = '';
                });
                html += '</ul>';

                $(SageMenu.config.ContainerClientID).addClass("sfNavigation");

                $(SageMenu.config.ContainerClientID).html(html);
                SageMenu.InitializeSuperfish("ul.sfDropdown,ul.sf-navbar,ul.sf-vertical");
                SageMenu.HighlightSelected();

                SageMenu.AdjustSubMenuHeight();
            },
            AdjustSubMenuHeight: function() {
                var menuHeight = $(SageMenu.config.ContainerClientID).find("ul li:first").height();

                var parentuls = $(SageMenu.config.ContainerClientID + " >ul>li");
                $.each(parentuls, function() {
                    $(this).find("ul:first").css("top", menuHeight);

                });
            },
            BindChildCategory: function(response, PageID, MenuDisplayMode, ShowCaption) {
                var strListmaker = '';
                var childNodes = '';
                var path = '';
                var itemPath = "";
                itemPath += "";
                var html = '';
                $.each(response, function(index, item) {

                    if (item.MenuLevel > 0) {
                        if (item.ParentID == PageID) {
                            itemPath += item.Title;
                            var PageLink = item.LinkType == 0 ? PagePath + item.URL + ".aspx" : item.LinkURL;
                            var styleClass = item.ChildCount > 0 ? 'class="sfParent"' : '';
                            strListmaker += '<li ' + styleClass + '>' + SageMenu.BuildMenuItem(MenuDisplayMode, item, PageLink, 0);
                            childNodes = SageMenu.BindChildCategory(response, item.MenuItemID, MenuDisplayMode, ShowCaption);
                            if (childNodes != '') {
                                strListmaker += "<ul>" + childNodes + "</ul>";
                            }
                            if (item.HtmlContent != '') {
                                strListmaker += '<ul class="megamenu"><li style="><div class="megawrapper">' + item.HtmlContent + '</div></li></ul>';
                            }
                            strListmaker += "</li>";
                        }
                    }
                });
                return strListmaker;
            },
            InitializeSuperfish: function(selector) {

                jQuery(selector).superfish({
                    delay: 100,                            // one second delay on mouseout 
                    animation: { opacity: 'show', height: 'show' },  // fade-in and slide-down animation 
                    speed: 'fast',                          // faster animation speed 
                    autoArrows: false,                           // disable generation of arrow mark-up 
                    dropShadows: false                            // disable drop shadows 
                });
            },
            BuildSideMenu: function(data, settings) {
                var pages = data.d;
                var PageID = "";
                var parentID = "";
                var categoryLevel = 0;
                var itemPath = "";
                var html = "";
                html += '<ul class="sfSidemenu">';

                $.each(pages, function(index, item) {
                    PageID = item.PageID;
                    parentID = item.ParentID;
                    categoryLevel = item.Level;
                    var PageLink = item.LinkType == 0 ? PagePath + item.URL + ".aspx" : item.LinkURL;
                    if (item.Level == 0) {
                        html += '<li>';
                        if (item.ChildCount > 0) {
                            html += SageMenu.BuildMenuItem(settings.DisplayMode, item, PageLink);
                        }
                        else {
                            html += SageMenu.BuildMenuItem(settings.DisplayMode, item, PageLink);
                        }

                        if (item.ChildCount > 0) {
                            html += "<ul>";
                            itemPath += item.PageName;
                            html += SageMenu.BindSideMenuChildren(pages, PageID, settings.DisplayMode);
                            html += "</ul>";
                        }
                        html += "</li>";
                    }
                    itemPath = '';
                });
                html += '</ul>';
                $(SageMenu.config.ContainerClientID).html(html);
                InitializeSuperfish("ul.sfSidemenu");
                SageMenu.HighlightSelected();
            },
            BindSideMenuChildren: function(response, PageID, MenuDisplayMode) {
                var strListmaker = '';
                var childNodes = '';
                var path = '';
                var itemPath = '';
                itemPath += "";
                $.each(response, function(index, item) {
                    if (item.Level > 0) {
                        if (item.ParentID == PageID) {
                            itemPath += item.PageName;
                            var PageLink = item.LinkType == 0 ? PagePath + item.URL + ".aspx" : item.URL;
                            var styleClass = item.ChildCount > 0 ? 'class="sfParent"' : '';
                            strListmaker += '<li ' + styleClass + '>' + SageMenu.BuildMenuItem(MenuDisplayMode, item, PageLink);
                            childNodes = SageMenu.BindChildCategory(response, item.PageID, MenuDisplayMode);
                            itemPath = itemPath.replace(itemPath.lastIndexOf(item.AttributeValue), '');
                            if (childNodes != '') {
                                strListmaker += "<ul>" + childNodes + "</ul>";
                            }
                            strListmaker += "</li>";
                        }
                    }
                });
                return strListmaker;
            },
            BindCustomSideMenu: function(data, settings) {
                var pages = data.d;
                var PageID = "";
                var parentID = "";
                var PageLevel = 0;
                var itemPath = "";
                var html = "";

                html += '<ul class="sfSidemenu">';
                $.each(pages, function(index, item) {
                    PageID = item.MenuItemID;
                    parentID = item.ParentID;
                    categoryLevel = item.MenuLevel;
                    if (item.MenuLevel == 0) {
                        var PageLink = item.LinkType == 0 ? PagePath + item.URL + ".aspx" : item.LinkURL;
                        if (item.ChildCount > 0) {
                            html += '<li class="sfParent">' + SageMenu.BuildMenuItem(settings.DisplayMode, item, PageLink, settings.Caption);
                        }
                        else {
                            html += '<li>' + SageMenu.BuildMenuItem(settings.DisplayMode, item, PageLink, settings.Caption);
                        }

                        if (parseInt(item.LinkType) == 1) {
                            html += '<ul class="megamenu"><li><div class="megawrapper">' + item.HtmlContent + '</div></li><ul>';
                        }
                        else {
                            if (item.ChildCount > 0) {
                                html += "<ul>";
                                itemPath += item.Title;
                                html += SageMenu.BindCustomChildCategory(pages, PageID, settings.DisplayMode, settings.Caption);
                                html += "</ul>";
                            }
                        }
                        html += "</li>";
                    }
                    itemPath = '';
                });
                html += '</ul>';
                // $(SageMenu.config.ContainerClientID).addClass("sfNavigation");
                $(SageMenu.config.ContainerClientID).html(html);
                SageMenu.InitializeSuperfish("ul.sfSidemenu");
                SageMenu.HighlightSelected();
            },
            BindCustomChildCategory: function(response, PageID, MenuDisplayMode, ShowCaption) {
                var strListmaker = '';
                var childNodes = '';
                var path = '';
                var itemPath = "";
                itemPath += "";
                $.each(response, function(index, item) {
                    if (item.MenuLevel > 0) {
                        if (item.ParentID == PageID) {
                            itemPath += item.Title;
                            var PageLink = item.LinkType == 0 ? PagePath + item.URL + ".aspx" : item.URL;
                            var styleClass = item.ChildCount > 0 ? 'class="sfParent"' : '';
                            strListmaker += '<li ' + styleClass + '>' + SageMenu.BuildMenuItem(MenuDisplayMode, item, PageLink);
                            childNodes = SageMenu.BindCustomChildCategory(response, item.MenuItemID, MenuDisplayMode, ShowCaption);

                            if (childNodes != '') {
                                strListmaker += "<ul>" + childNodes + "</ul>";
                            }
                            strListmaker += "</li>";
                        }
                    }
                });
                return strListmaker;
            },
            BuildFooterMenu: function(data, settings) {
                var pages = data.d;
                var PageID = "";
                var parentID = "";
                var PageLevel = 0;
                var itemPath = "";
                var html = "";

                html = '<ul class="sfFootermenu">';
                $.each(pages, function(index, item) {
                    PageID = item.MenuItemID;
                    parentID = item.ParentID;
                    categoryLevel = item.MenuLevel;

                    if (item.MenuLevel == 0) {
                        var PageLink = item.LinkType == 0 ? PagePath + item.URL + ".aspx" : item.LinkURL;
                        if (item.ChildCount > 0) {
                            html += '<li class="sfParent">' + SageMenu.BuildMenuItem(settings.DisplayMode, item, PageLink, settings.Caption);
                        }
                        else {
                            html += '<li>' + SageMenu.BuildMenuItem(settings.DisplayMode, item, PageLink, settings.Caption);
                        }

                        if (parseInt(item.LinkType) == 1) {
                            html += '<ul class="megamenu"><li><div class="megawrapper">' + item.HtmlContent + '</div></li><ul>';
                        }
                        else {
                            if (item.ChildCount > 0) {
                                html += "<ul>";
                                itemPath += item.Title;
                                html += SageMenu.BuildFooterChildren(pages, PageID, settings.DisplayMode, settings.Caption);
                                html += "</ul>";
                            }
                        }
                        html += "</li>";
                    }
                    itemPath = '';
                });
                html += '</ul>';
                // $(SageMenu.config.ContainerClientID).addClass("sfNavigation");   
                $(SageMenu.config.ContainerClientID).html(html);
                SageMenu.HighlightSelected();
            },
            BuildFooterChildren: function(response, PageID, MenuDisplayMode, ShowCaption) {
                var strListmaker = '';
                var childNodes = '';
                var path = '';
                var itemPath = "";
                itemPath += "";
                $.each(response, function(index, item) {
                    if (item.MenuLevel > 0) {
                        if (item.ParentID == PageID) {
                            itemPath += item.Title;
                            var PageLink = item.LinkType == 0 ? PagePath + item.URL + ".aspx" : item.URL;
                            strListmaker += '<li>' + SageMenu.BuildMenuItem(MenuDisplayMode, item, PageLink);
                            childNodes = SageMenu.BuildFooterChildren(response, item.MenuItemID, MenuDisplayMode, ShowCaption);

                            if (childNodes != '') {
                                strListmaker += "<ul>" + childNodes + "</ul>";
                            }
                            strListmaker += "</li>";
                        }
                    }
                });
                return strListmaker;
            }

        };
        SageMenu.init();
    };

    $.fn.SageMenuBuilder = function(p) {
        $.createSageMenu(p);
    };
})(jQuery);

   
   