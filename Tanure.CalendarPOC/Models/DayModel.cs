using System;

namespace Tanure.CalendarPOC.Models
{
    public class DayModel
    {
        public bool Selected { get; set; }

        public DateTime Date { get; protected set; }

        public DayModel(DateTime date)
        {
            this.Date = date;
        }

        public static DayModel GetDayNothing()
        {
            return new DayModel(DateTime.MinValue);
        }
    }
}
