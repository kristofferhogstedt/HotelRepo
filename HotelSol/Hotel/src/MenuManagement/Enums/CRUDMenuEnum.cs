﻿using Hotel.src.MenuManagement.Enums.Services;
using System.ComponentModel;

namespace Hotel.src.MenuManagement.Enums
{
    public enum CRUDMenuOptions
    {
        [Description("<--")]
        PreviousMenu,
        [Description("  Redigera")]
        Update,
        [Description("  Inaktivera")]
        Inactivate,
        [Description("  Återaktivera")]
        Reactivate,
        [Description("Avsluta")]
        Exit
    }
    public enum BookingCRUDMenuOptions
    {
        [Description("<--")]
        PreviousMenu,
        [Description("  Redigera")]
        Update,
        [Description("  Se faktura")]
        OpenInvoice,
        [Description("  Inaktivera")]
        Inactivate,
        [Description("  Återaktivera")]
        Reactivate,
        [Description("Avsluta")]
        Exit
    }

    public enum InvoiceCRUDMenuOptions
    {
        [Description("<--")]
        PreviousMenu,
        [Description("  Registrera betalning")]
        Update,
        [Description("Avsluta")]
        Exit
    }

    public enum RoomCRUDMenuOptions
    {
        [Description("<--")]
        PreviousMenu,
        [Description("  Redigera")]
        Update,
        [Description("  Lägg till/ta bort säng")]
        UpdateBeds,
        [Description("  Inaktivera")]
        Inactivate,
        [Description("  Återaktivera")]
        Reactivate,
        [Description("Avsluta")]
        Exit
    }

    public static class CRUDMenuEnum
    {
        public static string ShowCRUDMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);
        }
    }
}
