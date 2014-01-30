using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Konvertera_temperaturer.Model
{
    public static class TemperatureConverter
    {
        // Konverterar Celsius till Fahrenheit.
        public static int CelsiusToFahrenheit(int degreesC)
        {
            return Convert.ToInt32(degreesC * 1.8 + 32);
        }

        // Konverterar Fahrenheit till Celsius.
        public static int FahrenheitToCelsius(int degreesF)
        {
            return Convert.ToInt32((degreesF - 32) * 5/9);
        }
    }
}