using Hotel.src.Interfaces;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Controllers;
using Hotel.src.ModelManagement.Controllers.Forms;
using Hotel.src.ModelManagement.Controllers.Forms.Interfaces;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.FactoryManagement
{
    public class ModelFactory
    {
        //private IApp _app;

        public ModelFactory()
        {
            //_app = app;
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
            //return CustomerController.GetInstance(previousMenu) as IModelController;
        }
        public static IModelRegistrationForm GetModelRegistrationForm(EModelType typeOfForm, IMenu previousMenu)
        {
            switch (typeOfForm)
            {
                //case EModelType.Booking:
                //    return BookingRegistrationForm.GetInstance(previousMenu);
                case EModelType.Room:
                    return RoomRegistrationForm.GetInstance(previousMenu);
                case EModelType.RoomDetails:
                    return RoomDetailsRegistrationForm.GetInstance(previousMenu);
                case EModelType.Customer:
                    return CustomerRegistrationForm.GetInstance(previousMenu);
                default:
                    return null;
            }
            //return CustomerController.GetInstance(previousMenu) as IModelController;
        }
    }
}

