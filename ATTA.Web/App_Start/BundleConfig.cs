using System.Web.Optimization;
namespace ATTA.Web
{
    public class BundleConfig
    {
        public const string ScriptsBundlePath = "~/bundles/scripts.js";
        public const string Ie8ScriptsBundlePath = "~/bundles/ie8scripts.js";
        public const string StylesBundlePath = "~/bundles/styles.css";
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Javascript
            bundles.Add(new ScriptBundle(ScriptsBundlePath).Include("~/assets/js/libs/lazysizes.min.js")
                                                           .Include("~/assets/plugins/jquery/jquery-{version}.js")
                                                           .Include("~/assets/plugins/jquery/jquery-migrate.min.js")
                                                           .Include("~/assets/plugins/bootstrap/js/bootstrap.min.js")
                                                           .Include("~/assets/plugins/back-to-top.js")
                                                           .Include("~/assets/plugins/smoothScroll.js")
                                                           .Include("~/assets/plugins/parallax-slider/js/modernizr.js")
                                                           .Include("~/assets/plugins/parallax-slider/js/jquery.cslider.js")
                                                           .Include("~/assets/plugins/owl-carousel/owl-carousel/owl.carousel.js")
                                                           .Include("~/assets/plugins/fancybox/source/jquery.fancybox.pack.js")
                                                           .Include("~/assets/js/app.js")
                                                           .Include("~/assets/js/plugins/owl-carousel.js")
                                                           .Include("~/assets/js/plugins/parallax-slider.js")
                                                           .Include("~/assets/js/plugins/fancy-box.js")
                                                           .Include("~/assets/plugins/sky-forms-pro/skyforms/js/jquery.form.min.js")
                                                           .Include("~/assets/plugins/sky-forms-pro/skyforms/js/jquery.validate.min.js")
                                                           .Include("~/assets/js/forms/contact.js")
                                                           .Include("~/assets/js/custom.js"));
            //IE8 Scripts
            bundles.Add(new ScriptBundle(Ie8ScriptsBundlePath).Include("~/assets/plugins/respond.js")
                                                              .Include("~/assets/plugins/html5shiv.js")
                                                              .Include("~/assets/plugins/placeholder-IE-fixes.js"));
            //Css
            bundles.Add(new StyleBundle(StylesBundlePath).Include("~/assets/plugins/bootstrap/css/bootstrap.min.css", new CssRewriteUrlTransform())
                                                         .Include("~/assets/css/ie8.css")
                                                         .Include("~/assets/css/blocks.css")
                                                         .Include("~/assets/css/plugins.css")
                                                         .Include("~/assets/css/app.css")
                                                         .Include("~/assets/css/plugins/style-switcher.css")
                                                         .Include("~/assets/css/style.css", new CssRewriteUrlTransform())
                                                         .Include("~/assets/css/headers/header-default.css")
                                                         .Include("~/assets/css/footers/footer-v1.css", new CssRewriteUrlTransform())
                                                         .Include("~/assets/plugins/animate.css")
                                                         .Include("~/assets/plugins/line-icons/line-icons.css")
                                                         .Include("~/assets/plugins/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform())
                                                         .Include("~/assets/plugins/parallax-slider/css/parallax-slider.css", new CssRewriteUrlTransform())
                                                         .Include("~/assets/plugins/owl-carousel/owl-carousel/owl.carousel.css")
                                                         .Include("~/assets/plugins/sky-forms-pro/skyforms/css/sky-forms.css")
                                                         .Include("~/assets/plugins/sky-forms-pro/skyforms/custom/custom-sky-forms.css")
                                                         .Include("~/assets/plugins/fancybox/source/jquery.fancybox.css", new CssRewriteUrlTransform())
                                                         .Include("~/assets/css/pages/page_404_error.css")
                                                         .Include("~/assets/css/theme-colors/dark-blue.css")
                                                         .Include("~/assets/css/custom.css"));
        }
    }
}