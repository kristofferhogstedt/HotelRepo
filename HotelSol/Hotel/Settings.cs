using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class Settings
    {
        public static string DatabaseName { get; } = "HotelDb_krho";
        public static string DatabaseString { get; } =
            $@"Server=.;Database={DatabaseName};Trusted_Connection=True;TrustServerCertificate=true;";
        public static string AppSettingsFileName { get; } = "appsettings.json";
    }
}
