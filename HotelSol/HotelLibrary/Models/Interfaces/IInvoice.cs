﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Models.Interfaces
{
    public interface IInvoice
    {
        int ID { get; set; }
        int BookingID { get; set; }
        double Amount { get; set; }
        DateTime CreateDate { get; set; }
        DateTime DueDate { get; set; }
        bool IsPaid { get; set; }
    }
}
