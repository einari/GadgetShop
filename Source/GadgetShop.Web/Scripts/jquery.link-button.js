// Based on : http://www.concurrentdevelopment.co.uk/blog/index.php/2011/02/asp-net-mvc-linkbutton-with-htmlhelper-extensions/
(function ($) {
    $("a[data-link-button=true]").live("click", function (e) {
        e.preventDefault();
        var form = $(this).parents('form').first().submit();
        return false;
    });
})(jQuery);