﻿using System.Web;
using System.Web.Optimization;

namespace WebApplication1
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/signalR").Include(
                       "~/Scripts/jquery.signalR-{version}.js",
                       "~/Scripts/jquery.unobtrusive-ajax.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // готово к выпуску, используйте средство сборки по адресу https://modernizr.com, чтобы выбрать только необходимые тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/Content/style").Include(          
          "~/Content/style.css"));
            bundles.Add(new StyleBundle("~/Content/SettingAccount").Include(
          "~/Content/SettingAccount.css"));
            bundles.Add(new ScriptBundle("~/Scripts/SettingAccount").Include(
                        "~/Scripts/SettingAccount.js"));
            bundles.Add(new StyleBundle("~/Content/StyleSheet1").Include(
        "~/Content/StyleSheet1.css"));



            bundles.Add(new ScriptBundle("~/Scripts/card_js").Include(
                       "~/Scripts/card_js.js"));
            bundles.Add(new StyleBundle("~/Content/card").Include(
        "~/Content/card.css"));
        }
    }
}
