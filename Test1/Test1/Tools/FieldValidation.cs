using Android.Util;
using System.Text.RegularExpressions;

namespace LoginApp
{
    public static class FieldValidation
    {
        public static bool CheckLogin(string field)
        {
            if (field == null)
            {
                throw new System.ArgumentNullException();
            }

            Regex regex = new Regex("^[a-zA-Z]*$");

            if (field.Length > 5 && regex.IsMatch(field))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckPassword(string field)
        {

            if (field == null)
            {
                throw new System.ArgumentNullException();
            }
     
            if (field.Length > 5 && !field.Contains(" "))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
