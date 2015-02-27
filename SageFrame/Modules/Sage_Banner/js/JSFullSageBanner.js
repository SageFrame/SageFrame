(function(a) {
    a.createSageBanner = function(b) {
        b = a.extend({
            baseURL: "Services/Services.aspx",
            BannerId: 2,
            Auto_Slide: "",
            DisplaySlideQty: 1,
            InfiniteLoop: "",
            NavigationImagePager: "",
            Pause_Time: 1,
            NumericPager: "",
            TransitionMode: "",
            Speed: 1,
            PortalID: 1,
            UserModuleID: 1111,
            SageURL: "/SageFrame",
            enablecontrol: false


        }, b);

        if (b.Auto_Slide == "True") {
            b.Auto_Slide = true
        } else {
            b.Auto_Slide = false
        }

        if (b.InfiniteLoop == "True") {
            b.InfiniteLoop = true
        } else {
            b.InfiniteLoop = false
        }
        if (b.NumericPager == "True") {
            b.NumericPager = true
        } else {
            b.NumericPager = false
        }

        b.TransitionMode = jQuery.trim(b.TransitionMode);

        a.ajax({
        type: "POST",
        async:false,
            url: b.baseURL + "Services/SageBannerService.asmx/GetBannerImages",
            data: JSON2.stringify({
                BannerID: b.BannerId,
                UserModuleID: b.UserModuleID,
                PortalID: b.PortalID
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(data) {
                var banner = data.d;
                if (banner.length > 0) {
                    var d = "";
                    var e = "";
                    a("#slider").html("");
                    if (banner == "") {
                        a("#slider").html('<li>No banner images are added yet</li>');
                    }
                    a.each(banner, function(index,item) {
                        if (item.ImagePath.length == 0) {
                            e += ("<li>" + item.HTMLBodyText + "</li>")
                        } else {
					
                        if (item.ReadMorePage == "") {
                            e += '<li><div class="sfImageholder"><img src=' + b.baseURL + "images/CroppedImages/" + item.ImagePath + ' /></div>';
                                if (item.Description != "") {
                                    e += '<div  class="sfBannerDesc"><p>' + item.Description + '<a class="sfReadmore" href=' + item.LinkToImage + "><span>" + item.ReadButtonText + "</span></a></p></div></li>";
                                }
                                else {
                                    e += '</li>';
                                }
                            } else {
                                var readmorelink = "#";
                                if (item.ReadMorePage != "#") {
                                     readmorelink = b.SageURL + item.ReadMorePage + ".aspx";
                                    e += '<li><div class="sfImageholder"><img src=' + b.baseURL + "images/CroppedImages/" + item.ImagePath + ' /></div>';
                                    if (item.Description != "") {
                                        e += '<div class="sfBannerdesc"><p>' + item.Description + '<a class="sfReadmore" href=' + readmorelink + "><span>" + item.ReadButtonText + "</span></a></p></div></li>";
                                    }
                                    else {
                                        e += '</li>';
                                    }
                                }
                            }
                        }

                    });
                    a("#slider").html(e);

                    var f = a("#slider").bxSlider({
                        mode: b.TransitionMode,
                        infiniteLoop: b.InfiniteLoop,
                        speed: b.Speed,
                        pager: b.NumericPager,
                        pagerType: "full",
                        pagerLocation: "bottom",
                        pagerActiveClass: "pager-active",
                        nextText: "next",
                        prevText: "prev",
                        captions: false,
                        captionsSelector: null,
                        auto: b.Auto_Slide,
                        autoDirection: "next",
                        autoControls: false,
                        autoControlsSelector: null,
                        autoStart: true,
                        autoHover: true,
                        pause: b.Pause_Time,
                        startText: "start",
                        stopText: "stop",
                        stopImage: "",
                        wrapperClass: "",
                        startingSlide: 0,
                        displaySlideQty: 1,
                        moveSlideQty: 1,
                        controls: b.enablecontrol == "False" ? false : true
                    });
                    a(".thumbs a").live("click", function() {
                        var b = a(".thumbs a").index(this);
                        f.goToSlide(b);
                        a(".thumbs a").removeClass("pager-active");
                        a(this).addClass("pager-active");
                        return false
                    });
                    a(this).addClass("pager-active");
                }
            },
            error: function() {
                alert("cant load banner images")
            }
        })
    };
    a.fn.SageBannerjs = function(b) {
        a.createSageBanner(b)
    }
})(jQuery)