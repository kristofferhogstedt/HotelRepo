using Hotel.src.ModelManagement.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IRoomDetail : IModel
    {
        [Key]
        int ID { get; set; }

        //[ForeignKey("RoomID")]
        //int RoomID { get; set; }

        //[ForeignKey("TypeID")]
        //int TypeID { get; set; }
        int Size { get; set; }
        int NumberOfBeds { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
