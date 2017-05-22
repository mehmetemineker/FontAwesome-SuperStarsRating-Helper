$(function () {
    $(document).on('mouseleave', '.super-stars.rating i', function () {
        var t = $(this);
        var container = $(t).closest('.super-stars-container');

        if ($(container).find('.super-stars.rating').data('selected')) {
            var indexSelected = $(container).find('.super-stars.rating').data('selected')
            for (var i = 1; i <= indexSelected; i++) {
                $(container).find('.super-stars.rating i[data-index="' + i + '"]').removeClass('fa-star-o').addClass('fa-star');
            }
        } else {
            $(container).find('.super-stars.rating i').removeClass('fa-star').addClass('fa-star-o');
        }
    });

    $(document).on('mouseenter', '.super-stars.rating i', function () {
        var t = $(this);
        var container = $(t).closest('.super-stars-container');
        var index = $(t).data('index');

        $(container).find('.super-stars.rating i').removeClass('fa-star').addClass('fa-star-o');

        for (var i = 1; i <= index; i++) {
            $(container).find('.super-stars.rating i[data-index="' + i + '"]').removeClass('fa-star-o').addClass('fa-star');
        }
    });

    $(document).on('click', '.super-stars.rating i', function () {
        var t = $(this);
        var container = $(t).closest('.super-stars-container');
        var index = $(this).data('index');

        $(container).find('.super-stars.rating').data('selected', index);
        $(container).find('.super-stars.rating').find('input').val(index);
    });
});