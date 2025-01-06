using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers.Forms.Utilities
{
    public class FormLabelMapper
    {
        public static string LabelMapData01(IModelRegistrationForm registrationForm)
        {
            switch (registrationForm.ModelType)
            {
                case EModelType.Customer:
                    return "Förnamn";
                case EModelType.Address:
                    return "Gatuaddress";
                case EModelType.Room:
                    return "Rumsnummer";
                case EModelType.RoomDetails:
                    return "Rumstyp";
                case EModelType.Booking:
                    return "Från-datum";
                case EModelType.Invoice:
                    return "Faktura betald";
                default:
                    return "";
            }
        }
        public static string LabelMapData02(IModelRegistrationForm registrationForm)
        {
            switch (registrationForm.ModelType)
            {
                case EModelType.Customer:
                    return "Efternamn";
                case EModelType.Address:
                    return "Postnummer";
                case EModelType.Room:
                    return "Beskrivning";
                case EModelType.RoomDetails:
                    return "Storlek";
                case EModelType.Booking:
                    return "Till-datum";
                default:
                    return "";
            }
        }
        public static string LabelMapData03(IModelRegistrationForm registrationForm)
        {
            switch (registrationForm.ModelType)
            {
                case EModelType.Customer:
                    return "Födelsedatum";
                case EModelType.Address:
                    return "Stad";
                case EModelType.Room:
                    return "Våning";
                case EModelType.RoomDetails:
                    return "Antal sängar";
                case EModelType.Booking:
                    return "Rum";
                default:
                    return "";
            }
        }
        public static string LabelMapData04(IModelRegistrationForm registrationForm)
        {
            switch (registrationForm.ModelType)
            {
                case EModelType.Customer:
                    return "E-post";
                case EModelType.Address:
                    return "Land";
                case EModelType.Room:
                    return "Våning";
                case EModelType.RoomDetails:
                    return "Rumsnummer";
                case EModelType.Booking:
                    return "Kund";
                default:
                    return "";
            }
        }
        public static string LabelMapData05(IModelRegistrationForm registrationForm)
        {
            switch (registrationForm.ModelType)
            {
                case EModelType.Customer:
                    return "Telefonnummer";
                default:
                    return "";
            }
        }
        public static string LabelMapData06(IModelRegistrationForm registrationForm)
        {
            switch (registrationForm.ModelType)
            {
                case EModelType.Customer:
                    return "Address";
                default:
                    return "";
            }
        }
        public static string LabelMapData07(IModelRegistrationForm registrationForm)
        {
            switch (registrationForm.ModelType)
            {
                case EModelType.Customer:
                    return "Address";
                default:
                    return "";
            }
        }
        public static string LabelMapData08(IModelRegistrationForm registrationForm)
        {
            switch (registrationForm.ModelType)
            {
                case EModelType.Customer:
                    return "Address";
                default:
                    return "";
            }
        }
        public static string LabelMapData09(IModelRegistrationForm registrationForm)
        {
            switch (registrationForm.ModelType)
            {
                case EModelType.Customer:
                    return "Address";
                default:
                    return "";
            }
        }
        public static string LabelMapData10(IModelRegistrationForm registrationForm)
        {
            switch (registrationForm.ModelType)
            {
                case EModelType.Customer:
                    return "Address";
                default:
                    return "";
            }
        }
    }
}
