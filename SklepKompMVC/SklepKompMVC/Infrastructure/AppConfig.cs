using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SklepKompMVC.Infrastructure
{
    public class AppConfig
    {
        private static string _categoryIconsFolderRelative = ConfigurationManager.AppSettings["CategoryIconsFolder"];

        public static string CategoryIconsFolderRelative
        {
            get
            {
                return _categoryIconsFolderRelative;
            }
        }

        private static string _productCoverFolderRelative = ConfigurationManager.AppSettings["ProductCoverFolder"];

        public static string ProductCoverFolderRelative
        {
            get
            {
                return _productCoverFolderRelative;
            }
        }
    }
}