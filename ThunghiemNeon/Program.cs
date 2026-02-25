using Microsoft.Extensions.Configuration;

namespace ThunghiemNeon
{
    internal static class Program
    {
        public static IConfigurationRoot AppConfig { get; private set; } = null!;
        static IConfigurationRoot BuildConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppConfig = BuildConfig();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}