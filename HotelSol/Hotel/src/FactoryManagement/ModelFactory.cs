using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers;
using Hotel.src.ModelManagement.Controllers.Forms;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;

namespace Hotel.src.FactoryManagement
{
    public class ModelFactory
    {
        public ModelFactory()
        {
        }

        public static IModelController GetModelController(EModelType typeOfController, IMenu previousMenu)
        {
            switch (typeOfController)
            {
                case EModelType.Customer:
                    return CustomerController.GetInstance(previousMenu);
                case EModelType.Room:
                    return RoomController.GetInstance(previousMenu);
                case EModelType.Booking:
                    return BookingController.GetInstance(previousMenu);
                case EModelType.Invoice:
                    return InvoiceController.GetInstance(previousMenu);
                default:
                    return null;
            }
        }
        public static IModelRegistrationForm GetModelRegistrationForm(EModelType typeOfForm, IMenu previousMenu)
        {
            switch (typeOfForm)
            {
                case EModelType.Booking:
                    return BookingRegistrationForm.GetInstance(previousMenu);
                case EModelType.Room:
                    return RoomRegistrationForm.GetInstance(previousMenu);
                case EModelType.RoomDetails:
                    return RoomDetailsRegistrationForm.GetInstance(previousMenu);
                case EModelType.RoomBed:
                    return RoomBedRegistrationForm.GetInstance(previousMenu);
                case EModelType.Customer:
                    return CustomerRegistrationForm.GetInstance(previousMenu);
                case EModelType.Invoice:
                    return InvoiceRegistrationForm.GetInstance(previousMenu);
                default:
                    return null;
            }
        }
    }
}

