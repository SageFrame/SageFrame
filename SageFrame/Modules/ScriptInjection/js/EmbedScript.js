(function($) {
	//replaced
    $.createEmbeddedScript = function(p) {
        p = $.extend
        ({
            PortalID: 1,
            UserModuleID: 1,
            baseURL: 'Services/Services.aspx/'
        }, p);
        
        
            $.ajax({
                type: "POST",
                url: p.baseURL + "Services/ScriptInjectionWebService.asmx/GetScriptInView",
                data: JSON2.stringify({ UserModuleID: p.UserModuleID, PortalID: p.PortalID }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg) {
                    var html = "";
                    $.each(msg.d, function(index, Data) {
                        html += ('<div>' + Data.ScriptToBeEmbed + '</div>');
                    });                    
                    $('#divScript_' + p.UserModuleID + '').append(html);
                },
                error: function() {
                    alert('Error occured getting Script');
                }

            });
        
    }


    $.fn.EmbedScript = function(p) {
        $.createEmbeddedScript(p);
    };
})(jQuery);
