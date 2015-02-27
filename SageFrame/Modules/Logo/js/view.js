(function($) {
    $.BuildLogo = function(p) {
        p = $.extend
        ({
            PortalID: 1,
            UserModuleID: 0,
            ContainerID: 'divNav1',
            baseURL: ''
        }, p);

        var LogoView = {
            config: {
                moduleId: p.UserModuleID,
                portalId: p.PortalID,
                type: "POST",
                async: false,
                contentType: "application/json;charset=uf=8",
                dataType: "json",
                serviceUrl: p.baseURL,
                handlerUrl: '',
                ContainerID: p.ContainerID
            },
            GetData: function() {
                var myData = JSON2.stringify({ userModuleID: LogoView.config.moduleId, portalID: LogoView.config.portalId });

                $.ajax({
                    type: LogoView.config.type,
                    url: LogoView.config.serviceUrl + "GetLogoData",
                    data: myData,
                    contentType: LogoView.config.contentType,
                    dataType: LogoView.config.dataType,
                    success: function(data) {
                        var value = eval(data.d);
                        var elem = '';
                        $(LogoView.config.ContainerID).html('');
                        var imagepath = "";
                        var navUrl = "";
                        if (value.url == "http://" || value.url == "") {
                            navUrl = "#";
                        }
                        else {
                            navUrl = value.url;
                        }
                        if (value.LogoPath != "") {
                            imagepath = SageFrameAppPath + "/" + value.LogoPath;
                        }
                        elem += '<a href=' + navUrl + '><img id="imgLogo" class="sfLogoimg" src="' + imagepath + '" alt=""/><span>' + value.LogoText + '</span></a>';
                        elem += '<span class="sfSlogan">' + value.Slogan + '</span>';
                        $(LogoView.config.ContainerID).html(elem);
                        if (imagepath == "") {
                            $(LogoView.config.ContainerID).find("img.sfLogoimg").remove();
                        }
                    },
                    error: function() {
                        //alert("get logo error");
                    }
                });
            }

        };
        LogoView.GetData();
    };

    $.fn.LogoBuilder = function(p) {
        $.BuildLogo(p);
    };
})(jQuery);

