using Hotel.src.ModelManagement.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IRoomType : IModel
    {
        [Key]
        int ID { get; set; }
        string Name { get; set; }
        double PriceDefault { get; set; }
        int SizeDefault { get; set; }
        int SizeMax { get; set; }
        int NumberOfBedsDefault { get; set; }
        int NumberOfBedsMax { get; set; }
        List<RoomDetails> RoomDetails { get; set; }
        public bool IsInactive { get; set; }
        public DateTime? InactivatedDate { get; set; }
    }
}
