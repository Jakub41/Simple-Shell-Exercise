using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Data;
using System.Globalization; 
using Microsoft.Win32; 
using System.Diagnostics;
using System.IO;
using Microsoft.VisualBasic;

namespace FileManagement
{
    public class GeneralConfiguration
    {
        
        public static string ApplicationImagePath()
        {
            string ImagePath = @"D:\VShopLite\VShopLite\VShopWindows\ImageResources\";
            return ImagePath;
        }

        public static void OpenInBrowser()
        {
            string url = "http://www.softzoneit.com/";
            string browserPath = GeneralConfiguration.GetDefaultBrowserPath();
            if (string.IsNullOrEmpty(browserPath))
            {
                
            }
            else
            {
                Process.Start(browserPath, url);
            }
        }

        public static string GetDefaultBrowserPath()
        {
            string browserPath = string.Empty;
            RegistryKey browserKey = null;
            try
            {
                browserKey = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);
                if (browserKey == null)
                {
                    browserKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http", false); ;
                }
                if (browserKey != null)
                {
                    browserPath = (browserKey.GetValue(null) as string).ToLower().Replace("\"", "");
                    if (!browserPath.EndsWith("exe"))
                    {
                        browserPath = browserPath.Substring(0, browserPath.LastIndexOf(".exe") + 4);
                    }
                    browserKey.Close();
                }
            }
            catch
            {
                return string.Empty;
            }
            return browserPath;
        }
    }
}
