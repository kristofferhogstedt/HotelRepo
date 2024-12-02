using HotelLibrary.Interfaces;
using HotelLibrary.Utilities.Interfaces;

namespace HotelLibrary
{
    public class BetterClass : IClass
    {
        ILogger _logger;
        IDataAccess _dataAccess;
        public BetterClass(ILogger logger, IDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }
        public void ProcessData()
        {
            _logger.Log("Loggar...");
            Console.WriteLine();
            Console.WriteLine("Processar data...");
            _dataAccess.LoadData();
            _dataAccess.SaveData("Record1");
            Console.WriteLine();
            _logger.Log("Finished");
        }
    }
}
