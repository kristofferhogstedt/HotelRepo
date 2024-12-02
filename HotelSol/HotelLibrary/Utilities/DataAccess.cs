using HotelLibrary.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Utilities
{
    public class DataAccess : IDataAccess
    {
        ILogger _logger;
        public DataAccess(ILogger logger)
        {
            _logger = logger;
        }

        public void LoadData()
        {
            Console.WriteLine("Loading data");
            _logger.Log("Loading data");
        }

        public void SaveData(string name)
        {
            Console.WriteLine($"Saving: {name}");
            _logger.Log("Saving data");
        }
    }
}
