using Hotel.src.ModelManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.Utilities.UserInputManagement
{
    public class BookedDateSplitter
    {
        public static List<DateTime> SplitDates(IBooking booking)
        {
            var _fromDate = Convert.ToInt32(booking.FromDate.Date);
            var _toDate = Convert.ToInt32(booking.ToDate.Date);

            List<DateTime> _individualDatesList = new List<DateTime>();

            for (int d = _fromDate; d <= _toDate; d++)
            {
                var _individualDate = Convert.ToDateTime(d);
                _individualDatesList.Add(_individualDate);
            }

            return _individualDatesList;
        }
    }
}
