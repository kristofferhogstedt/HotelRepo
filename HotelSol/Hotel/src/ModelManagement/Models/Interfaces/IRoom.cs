namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IRoom
    {
        int ID { get; set; }
        string Name { get; set; }
        string? Description { get; set; }
        string Floor { get; set; }
        RoomDetail Detail { get; set; }
        DateTime? CleanedDate { get; set; }
        public bool IsInactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }

    }
}
