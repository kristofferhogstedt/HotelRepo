using Hotel.src.ModelManagement.Utilities.Messagers;
using Hotel.src.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Utilities.Checkers
{
    public class DataElementChecker
    {
		// Bookings
		public static bool CheckBookingDataExists()
		{
			if (DatabaseLair.DatabaseContext.Bookings.Any())
				return true;
			else
			{
				ServiceMessager.DataNotFoundMessage();
				return false;
			}
		}
		public static bool CheckBookingDataExists(bool isInactive)
		{
			if (DatabaseLair.DatabaseContext.Bookings.Any(e => e.IsInactive == isInactive))
				return true;
			else
			{
				ServiceMessager.DataNotFoundMessage();
				return false;
			}
		}


		// Customers
		public static bool CheckCustomerDataExists()
		{
			if (DatabaseLair.DatabaseContext.Customers.Any())
				return true;
			else
			{
				ServiceMessager.DataNotFoundMessage();
				return false;
			}
		}

		public static bool CheckCustomerDataExists(bool isInactive)
		{
			if (DatabaseLair.DatabaseContext.Customers.Any(e => e.IsInactive == isInactive))
				return true;
			else
			{
				ServiceMessager.DataNotFoundMessage();
				return false;
			}
		}


		// Invoices
		public static bool CheckInvoiceDataExists()
		{
			if (DatabaseLair.DatabaseContext.Invoices.Any())
				return true;
			else
			{
				ServiceMessager.DataNotFoundMessage();
				return false;
			}
		}
		public static bool CheckInvoiceDataExists(bool isInactive)
		{
			if (DatabaseLair.DatabaseContext.Invoices.Any(e => e.IsInactive == isInactive))
				return true;
			else
			{
				ServiceMessager.DataNotFoundMessage();
				return false;
			}
		}


		// Rooms
		public static bool CheckRoomDataExists()
		{
			if (DatabaseLair.DatabaseContext.Rooms.Any())
				return true;
			else
			{
				ServiceMessager.DataNotFoundMessage();
				return false;
			}
		}

		public static bool CheckRoomDataExists(bool isInactive)
		{
			if (DatabaseLair.DatabaseContext.Rooms.Any(e => e.IsInactive == isInactive))
				return true;
			else
			{
				ServiceMessager.DataNotFoundMessage();
				return false;
			}
		}


		// RoomDetails
		public static bool CheckRoomDetailsDataExists()
		{
			if (DatabaseLair.DatabaseContext.RoomDetails.Any())
				return true;
			else
			{
				ServiceMessager.DataNotFoundMessage();
				return false;
			}
		}
		public static bool CheckRoomDetailsDataExists(bool isInactive)
		{
			if (DatabaseLair.DatabaseContext.RoomDetails.Any(e => e.IsInactive == isInactive))
				return true;
			else
			{
				ServiceMessager.DataNotFoundMessage();
				return false;
			}
		}


		// RoomTypes
		public static bool CheckRoomTypeDataExists()
		{
			if (DatabaseLair.DatabaseContext.RoomTypes.Any())
				return true;
			else
			{
				ServiceMessager.DataNotFoundMessage();
				return false;
			}
		}
		public static bool CheckRoomTypeDataExists(bool isInactive)
		{
			if (DatabaseLair.DatabaseContext.RoomTypes.Any(e => e.IsInactive == isInactive))
				return true;
			else
			{
				ServiceMessager.DataNotFoundMessage();
				return false;
			}
		}
	}
}
