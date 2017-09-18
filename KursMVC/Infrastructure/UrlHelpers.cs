using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KursMVC.Infrastructure
{
    public static class UrlHelpers
    {
        public static string PathCategoryIcon(this UrlHelper helper, string nameCategoryIcon)
        {
            var categoryIconAbsoluteFolder = AppConfig.CategoryIconRelativeFolder;
            var path = Path.Combine(categoryIconAbsoluteFolder, nameCategoryIcon);
            var absolutePath = helper.Content(path);

            return absolutePath;
        }

        public static string PathImages(this UrlHelper helper, string nameImage)
        {
            var imagesAbsoluteFolder = AppConfig.ImagesRelativeFolder;
            var path = Path.Combine(imagesAbsoluteFolder, nameImage);
            var absolutePath = helper.Content(path);

            return absolutePath;
        }
    }
}