using System;

namespace Tanure.CalendarPOC.Models
{
    public class Day
    {
        public bool Selected { get; set; }

        public DateTime Date { get; protected set; }

        public Day(DateTime date)
        {
            this.Date = date;
        }

        public static Day GetDayNothing()
        {
            return new Day(DateTime.MinValue);
        }
    }
}
