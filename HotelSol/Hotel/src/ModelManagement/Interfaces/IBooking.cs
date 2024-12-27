﻿namespace Hotel.src.ModelManagement.Interfaces
{
    public interface IBooking
    {
        int ID { get; }
        int CustomerID { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
    }
}
