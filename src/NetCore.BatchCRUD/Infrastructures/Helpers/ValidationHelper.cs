using System;
using System.Globalization;

namespace NetCore.BatchCRUD.Infrastructures.Helpers
{
    public partial class ValidationHelper
    {
        /// <summary>
        /// Convert input value to integer number, return default value if input is null or empty
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetInteger(object inputValue, int defaultValue)
        {
            NumberStyles _currencyStyle = NumberStyles.Number;
            CultureInfo _culture = new CultureInfo("en-US");
            if (inputValue == null)
                return defaultValue;
            else
            {
                if (int.TryParse(inputValue.ToString().Trim(), _currencyStyle, _culture, out int value))
                    return value;
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert input value to integer number, return default value if input is null or empty
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime? GetDateTime(object inputValue, string format, DateTime? defaultValue)
        {
            if (inputValue == null)
                return defaultValue;
            else
            {
                DateTime value = new DateTime();
                if (DateTime.TryParseExact(inputValue.ToString(), format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out value))
                    return value;
                return defaultValue;
            }
        }
    }
}
