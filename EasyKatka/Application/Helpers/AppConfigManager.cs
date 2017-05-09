using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Application.Helpers
{
    internal static class AppConfigManager
    {
        internal static string LotsImagesBasePath
        {
            get
            {
                string result = ConfigurationManager.AppSettings["LotsImagesBasePath"];
                return result;
            }
        }
    }
}