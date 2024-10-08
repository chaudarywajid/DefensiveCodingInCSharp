using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEFCode.Utilities
{
    public static class Guard
    {
        public static void ThrowIfNullOrEmpty(string argumentValue, string message, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(argumentValue)) throw new ValidationException(message, parameterName);
        }

        public static double ThrowIfNotPositiveDecimal(string argumentValue, string message, string parameterName)
        {
            var success = double.TryParse(argumentValue, out double result);
            if (!success || result < 0) throw new ArgumentException(message, parameterName);

            return result;
        }

        public static double ThrowIfNotPositiveNonZeroDecimal(string argumentValue, string message, string parameterName)
        {
            var success = double.TryParse(argumentValue, out double result);
            if (!success || result <= 0) throw new ArgumentException(message, parameterName);

            return result;
        }
    }

}
