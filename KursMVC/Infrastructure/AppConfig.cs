using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace KursMVC.Infrastructure
{
    public class AppConfig
    {
        private static string _folderIconCategoryRelativeFolder = ConfigurationManager.AppSettings["FolderIconsCategory"];

        public static string CategoryIconRelativeFolder => _folderIconCategoryRelativeFolder;

        private static string _folderImagesRelativeFolder = ConfigurationManager.AppSettings["FolderImages"];

        public static string ImagesRelativeFolder => _folderImagesRelativeFolder;
    }
}