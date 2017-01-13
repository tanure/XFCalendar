using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanure.CalendarPOC.Models
{
    public class Calendar
    {
        #region [ Constants ]

        private const int MAX_WEEKS = 6;
        private const int MAX_DAYS = 7;

        #endregion

        private DateTime currentDate;

        private Day[,] currentCalendar;

        

        public Day[,] CurrentCalendar
        {
            get
            {
                return currentCalendar;
            }
        }

        public int CurrentYear
        {
            get
            {
                return currentDate.Year;
            }
        }

        public int CurrentMonth
        {
            get
            {
                return currentDate.Month;
            }
        }

        public ObservableCollection<Day> GetSelectedDates()
        {
            ObservableCollection<Day> selectedDates = new ObservableCollection<Day>();

            for (int i = 0; i < currentCalendar.GetLength(0); i++)
            {
                for(int j = 0; j < currentCalendar.GetLength(1);j++)
                {
                    if (currentCalendar[i, j] != null && currentCalendar[i, j].Selected)
                        selectedDates.Add(currentCalendar[i, j]);
                }
            }

            return selectedDates;
        }

        public Calendar(DateTime baseDate)       
        {   
            currentDate = baseDate;
            this.MakeCurrentCalendar();
        }

        public void NextMonth()
        {
            currentDate = currentDate.AddMonths(1);
            this.MakeCurrentCalendar();
        }

        public void PriorMonth()
        {
            currentDate = currentDate.AddMonths(-1);
            this.MakeCurrentCalendar();
        }

        private void MakeCurrentCalendar()
        {
            currentCalendar = new Day[MAX_WEEKS, MAX_DAYS];

            int lastDay = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);

            DateTime cDate = new DateTime(currentDate.Year, currentDate.Month, 1);

            Day dayCellAux = null;

            for (int i = 1, line = 0; i <= lastDay; i++)
            {
                dayCellAux = new Day(cDate)
                {
                    Selected = false
                };

                currentCalendar[line, Convert.ToInt32(cDate.DayOfWeek)] = dayCellAux;

                if (cDate.DayOfWeek == DayOfWeek.Saturday)
                    line++;

                cDate = cDate.AddDays(1);
            }
        }
        
    }
    
}
