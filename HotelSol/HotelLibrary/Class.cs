using HotelLibrary.Interfaces;
using HotelLibrary.Utilities;
using HotelLibrary.Utilities.Interfaces;

namespace HotelLibrary
{
    public class Class : IClass
    {
        public void ProcessData()
        {
            ILogger _logger = new Logger();
            IDataAccess _dataAccess = new DataAccess();

            _logger.Log("Loggar...");
            Console.WriteLine("Processar data...");
            _dataAccess.LoadData();
            _dataAccess.SaveData("Record1");
            _logger.Log("Finished");
        }
    }
}
