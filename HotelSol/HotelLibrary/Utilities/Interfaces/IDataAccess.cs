namespace HotelLibrary.Utilities.Interfaces
{
    internal interface IDataAccess
    {
        void LoadData();
        void SaveData(string name);
    }
}