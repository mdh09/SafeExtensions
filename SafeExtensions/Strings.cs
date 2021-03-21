using System;
namespace SafeExtensions
{
    public static class Strings
    {

        public static string SafeTrim(this string pStringToTrim, string pDefaultValue = "")
        {
            var returnVal = pDefaultValue;
            if(returnVal == null)
            {
                returnVal = "";
            }

            if(string.IsNullOrWhiteSpace(pStringToTrim))
            {
                return returnVal;
            }

            return pStringToTrim.Trim();

        }

    }
}
