﻿using Hotel.Enums;
using Hotel.src.ModelManagement.Models;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IRoom
    {
        int ID { get; set; }
        string? Name { get; set; }
        string? Description { get; set; }
        ERoomType Type { get; set; }
        string Floor { get; set; }
        ushort NumberOfBeds { get; set; }
        ushort Size { get; set; }
        DateTime CleanedDate { get; set; }
        bool IsActive { get; set; }
    }
}
