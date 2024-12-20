﻿using System.Net;

namespace HotelLibrary.Models.Interfaces
{
    public interface ICustomer
    {
        int CustomerId { get; set; }
        string CustomerFirstName { get; set; }
        string CustomerLastName { get; set; }
        Address Address { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        List<Booking> Bookings { get; set; }
    }
}