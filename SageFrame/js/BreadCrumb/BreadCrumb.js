(function($) {
    $.createBreadCrumb = function(p) {
        p = $.extend({ baseURL: '/Modules/BreadCrumb/BreadCrumbWebService.asmx/', PagePath: "Home", PortalID: 1, PageName: 'Home', Container: "div.sfBreadcrumb",MenuId:"1" }, p); var BreadCrum = { config: { isPostBack: false, async: true, cache: false, type: 'POST', contentType: "application/json; charset=utf-8", data: { data: '' }, dataType: 'json', baseURL: p.baseURL, PagePath: p.PagePath, method: "", url: "", ajaxCallMode: 0, PortalID: p.PortalID, PageName: p.PageName,MenuId: p.MenuId, arr: [], arrPages: [] }, init: function() { this.LoadBreadCrum() }, LoadBreadCrum: function() { this.config.method = "GetBreadCrumb"; this.config.url = BreadCrum.config.baseURL + this.config.method; this.config.data = JSON2.stringify({ PortalID: BreadCrum.config.PortalID, PageName: BreadCrum.config.PageName ,MenuId: BreadCrum.config.MenuId}); this.config.ajaxCallMode = 0; this.ajaxCall(this.config) },
            BindBreadCrum: function(data) {
                var breadcrum = data.d; var arrPages = breadcrum.split('/');
                var html = '';
                var childPages = '';
                var isadmin = false;
                $.each(arrPages, function(index, item) {
                    if (item != "") {
                        childPages += item + "/"; childPages = childPages.substring(0, childPages.length - 1);
                        var pageLink = BreadCrum.config.PagePath + "/" + childPages + '.aspx';
                        if (item === "Admin") {
                            pageLink = pageLink;
                            isadmin = true;
                        }
                        else if (item === "Super-User") {
                            pageLink = pageLink;
                            isadmin = true;
                        }
                        childPages += "/";
                        html += '<li><a href=' + pageLink + '>' + item.replace(new RegExp("-", "g"), ' ') + '</a></li>';
                        //html += '<li> > </span>';
                    }
                });
             
                if (!isadmin) {
                    html = '<ul><li class="sfFirst"><a href="' + DefaultPortalHomePage + '">Home</a></li>' + html + '</ul>';                   
                }
                $(p.Container).append(html);
                //$(p.Container + ' li:last').remove();
                var lastLink = $(p.Container + ' li:last a').html();
                $(p.Container + ' li:last').addClass("sfLast").html(lastLink);
            }
, ajaxSuccess: function(data)
{ switch (BreadCrum.config.ajaxCallMode) { case 0: BreadCrum.BindBreadCrum(data); break } }, ajaxFailure: function() { }, ajaxCall: function(config) { $.ajax({ type: BreadCrum.config.type, contentType: BreadCrum.config.contentType, cache: BreadCrum.config.cache, url: BreadCrum.config.url, data: BreadCrum.config.data, dataType: BreadCrum.config.dataType, success: BreadCrum.ajaxSuccess, error: BreadCrum.ajaxFailure }) }
        }; BreadCrum.init()
    }; $.fn.BreadCrumbBuilder = function(p) { $.createBreadCrumb(p) }
})(jQuery);