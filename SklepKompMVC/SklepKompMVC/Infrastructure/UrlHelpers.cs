using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepKompMVC.Infrastructure
{
    public static class UrlHelpers
    {
        public static string ProductCoverPath(this UrlHelper helper, string productCoverFilename)
        {
            var productCoverPath = AppConfig.ProductCoverFolderRelative;
            var path = Path.Combine(productCoverPath, productCoverFilename);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }

        public static string CategoryIconsPath(this UrlHelper helper, string categoryIconFilename)
        {
            var categoryIconsPath = AppConfig.CategoryIconsFolderRelative;
            var path = Path.Combine(categoryIconsPath, categoryIconFilename);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }
    }
}