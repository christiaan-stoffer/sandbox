(function ($) {
    $.fn.sitImageUploader = function () {
        return this.each(function (index, element) {
            var $this = $(this);

            $this.find("input[type='file']").bind("change", function () {
                var $fileThis = $(this);
                $this.find("iframe").attr("src", $fileThis.val());
            });
        });
    };
})(jQuery);
