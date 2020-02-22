namespace MuOnline.Utilities
{
    using System;
    public class Validator
    {
        public static void ValidateIntLessThanZero(int value, string objectName)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{objectName} cannot be less than zero!");
            }
        }

        public static void ValidateStringIsNull(string value, string text)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"Invalid {text}!");
            }
        }

        public static void ValidateObjectIsNull(object objectName)
        {
            
        }
    }
}
