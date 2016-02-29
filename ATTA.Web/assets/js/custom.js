/* Write here your custom javascript codes */

$(function () {
    App.init();
    OwlCarousel.initOwlCarousel();
    ParallaxSlider.initParallaxSlider();
    FancyBox.initFancybox();
    ContactForm.initContactForm();

    //Disable click events for a[class="disabled"]
    $('body').on('click', 'a.disabled', function (event) {
        event.preventDefault();
    });

    //Disable scroll on Google map until clicked
    $('.map').click(function () {
        $(this).removeClass('scrolloff');
    });
    $('.map').mouseleave(function () {
        $(this).addClass('scrolloff');
    });
})
