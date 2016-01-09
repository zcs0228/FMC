﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace FMC.App_Start
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Common/jquery.min.js",
                        "~/Scripts/Common/jquery.ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.easyui").Include(
                        "~/Lib/easyui/jquery.easyui.min.js",
                        "~/Lib/easyui/easyloader.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Lib/easyui/themes/default/easyui.css",
                        "~/Lib/easyui/themes/icon.css"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "/JavaScript/Common/jquery.*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}