using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IRoomType
    {
        int ID { get; set; }
        string Name { get; set; }
        int Size { get; set; }
        int NumberOfBedsDefault { get; set; }
        int NumberOfBedsMax { get; set; }
    }
}
