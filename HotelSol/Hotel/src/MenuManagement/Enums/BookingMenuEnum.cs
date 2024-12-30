﻿using Hotel.src.MenuManagement.Enums.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Enums
{
    public enum BookingMenuOptions
    {
        [Description("Föregående meny")]
        PreviousMenu,
        [Description("Se bokningar")]
        DisplayBookings,
        [Description("Uppdatera bokningar")]
        UpdateBookings,
        [Description("Registrera ny bokning")]
        CreateBooking,
        [Description("Radera bokning")]
        DeleteBooking,
        [Description("Avsluta")]
        Exit
    }

    public static class BookingMenuEnum
    {
        public static string ShowBookingMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);
        }
    }
}
