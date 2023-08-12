using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Themes
{
    public class AppTheme
    {
        public static void ChangeTheme(Uri uriTheme)
        {
            ResourceDictionary resDict = new ResourceDictionary() { Source = uriTheme};
            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(resDict);
        }
    }
}
