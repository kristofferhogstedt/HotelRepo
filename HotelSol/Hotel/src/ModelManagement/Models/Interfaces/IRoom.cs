namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IRoom : IModel
    {
        int ID { get; set; }
        string Name { get; set; }
        string? Description { get; set; }
        int Floor { get; set; }
        RoomDetails Details { get; set; }
        DateTime? CleanedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsInactive { get; set; }
        public DateTime? InactivatedDate { get; set; }
    }
}
