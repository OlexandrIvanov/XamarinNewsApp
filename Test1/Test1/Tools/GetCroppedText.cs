using Android.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace LoginApp.NewsViewModel
{
   public class CroppText : IValueConverter
    {
        public static string GetCroppedText(string text, int countOfNumbers)
        {

            if (text == null)
            {
                throw new NullReferenceException();
            }

                
            if (text.Length > countOfNumbers)
            {

                text = text.Remove(countOfNumbers);
                if (text.Contains(" "))
                {
                    text = text.Remove(text.LastIndexOf(" "));
                    text = text + "...";
                }
                else return text = "...";
            }

            return text;

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {


            if (value == null)
            {
                return GetCroppedText("...", 99);
            }
            return GetCroppedText(value as String, 99);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
