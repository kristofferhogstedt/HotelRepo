﻿using HotelLibrary.Interfaces;
using HotelLibrary.Utilities.Interfaces;

namespace HotelLibrary
{
    public class Class : IClass
    {
        ILogger _logger;
        IDataAccess _dataAccess;
        public Class(ILogger logger, IDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }
        public void ProcessData()
        {
            _logger.Log("Loggar...");
            Console.WriteLine("Processar data...");
            _dataAccess.LoadData();
            _dataAccess.SaveData("Record1");
            _logger.Log("Finished");
        }
    }
}
