$('.menu li > #nav-header > ul').each(function () {
    var u = $(this);
    function getHeight() {
        return u.height() + parseInt(u.css('paddingTop')) + parseInt(u.css('paddingBottom')) + parseInt(u.css('borderTopWidth')) + parseInt(u.css('borderBottomWidth'))
    }
    u.css({ display: 'block', marginTop: -getHeight() }).parent().parent().mouseenter(function () {
        u.stop().animate({ marginTop: 0 }, 200)
    }).mouseleave(function () {
        u.stop().animate({ marginTop: -getHeight() }, 200)
    })
})
