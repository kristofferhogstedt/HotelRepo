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
        public static string CustomerLabelMapData01(IModelRegistrationForm registrationForm)
        {
            switch (registrationForm.ModelType)
            {
                case EModelType.Customer:
                    return "Förnamn";
                case EModelType.Address:
                    return "Gatuaddress";
                default:
                    return "";
            }
        }
        public static string CustomerLabelMapData02(IModelRegistrationForm registrationForm)
        {
            switch (registrationForm.ModelType)
            {
                case EModelType.Customer:
                    return "Efternamn";
                case EModelType.Address:
                    return "Postnummer";
                default:
                    return "";
            }
        }
        public static string CustomerLabelMapData03(IModelRegistrationForm registrationForm)
        {
            switch (registrationForm.ModelType)
            {
                case EModelType.Customer:
                    return "Födelsedatum";
                case EModelType.Address:
                    return "Stad";
                default:
                    return "";
            }
        }
        public static string CustomerLabelMapData04(IModelRegistrationForm registrationForm)
        {
            switch (registrationForm.ModelType)
            {
                case EModelType.Customer:
                    return "E-post";
                case EModelType.Address:
                    return "Land";
                default:
                    return "";
            }
        }
        public static string CustomerLabelMapData05(IModelRegistrationForm registrationForm)
        {
            switch (registrationForm.ModelType)
            {
                case EModelType.Customer:
                    return "Telefonnummer";
                default:
                    return "";
            }
        }
        public static string CustomerLabelMapData06(IModelRegistrationForm registrationForm)
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
