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
            var _fromDate = booking.FromDate.Date;
            var _toDate = booking.ToDate.Date;
            var _dayCounter = _fromDate;
            DateTime _individualDate;

            List<DateTime> _individualDatesList = new List<DateTime>();

            for (int d = _dayCounter.Day; d <= _toDate.Day; d++)
            {
                _individualDate = _dayCounter;
                _individualDatesList.Add(_individualDate);
                _dayCounter = _dayCounter.AddDays(1);
            }

            return _individualDatesList;
        }
    }
}
