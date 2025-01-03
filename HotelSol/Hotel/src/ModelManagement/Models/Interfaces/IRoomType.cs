using Hotel.src.ModelManagement.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IRoomType
    {
        [Key]
        ERoomType ID { get; set; }
        string Name { get; set; }
        int SizeDefault { get; set; }
        int NumberOfBedsDefault { get; set; }
        int NumberOfBedsMax { get; set; }
    }
}
