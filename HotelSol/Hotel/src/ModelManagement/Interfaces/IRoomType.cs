namespace Hotel.src.ModelManagement.Interfaces
{
    public interface IRoomType
    {
        int ID { get; }
        string Name { get; set; }
        string Description { get; set; }
        ushort NumberOfBedsDefault { get; set; }
        ushort NumberOfBedsMax { get; set; }
    }
}
