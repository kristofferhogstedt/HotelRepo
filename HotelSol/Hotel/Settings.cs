using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class Settings
    {
        public static bool IsAdmin { get; set; } = false;
        public static string DatabaseName { get; } = "HotelDb_krho";
        public static string DatabaseString { get; } =
            $@"Server=.;Database={DatabaseName};Trusted_Connection=True;TrustServerCertificate=true;";
        public static string AppSettingsFileName { get; } = "appsettings.json";
        public static ushort BedSize { get; } = 20;
        public static TimeOnly CheckInTime { get; } = new TimeOnly(14, 0);
        public static TimeOnly CheckOutTime { get; } = new TimeOnly(12, 0);
    }
}
