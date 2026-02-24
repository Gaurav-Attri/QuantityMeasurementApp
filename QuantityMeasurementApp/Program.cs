using System;

namespace QuantityMeasurementApp
{
    /// <summary>
    /// Bootstraps the console application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Application starting method.
        /// </summary>
        private static void Main(string[] arguments)
        {
            LaunchApplication();
        }

        private static void LaunchApplication()
        {
            var appMenu = new QuantityMeasurementAppMenu();
            appMenu.Run();
        }
    }
}