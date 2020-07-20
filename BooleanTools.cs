namespace JG.Application
{
    public static class BooleanTools
    {
        public static bool ToBool(this string stringValue, bool defaultValue = true)
        {
            bool result;
            return bool.TryParse(stringValue, out result) ? result : defaultValue;
        }

        public static bool ToBoolTrue(this string stringValue)
        {
            bool result;
            return !bool.TryParse(stringValue, out result) || result;
        }
        public static bool ToBoolFalse(this string stringValue)
        {
            bool result;
            return bool.TryParse(stringValue, out result) && result;
        }
    }
}