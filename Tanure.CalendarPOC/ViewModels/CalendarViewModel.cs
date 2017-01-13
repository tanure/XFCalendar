using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tanure.CalendarPOC.Models;
using Xamarin.Forms;

namespace Tanure.CalendarPOC.ViewModels
{
    public class CalendarViewModel : ViewModelBase
    {
        public event EventHandler<Day[,]> OnMakeCalendar;

        private Tanure.CalendarPOC.Models.Calendar _calendar;

        public CalendarViewModel()
        {
            _calendar = new Tanure.CalendarPOC.Models.Calendar(DateTime.Now);

            this.PriorCommand = new Command(() =>
            {
                _calendar.PriorMonth();

                OnPropertyChanged(nameof(YearMonthLabel));
                OnPropertyChanged(nameof(SelectedDates));

                this.RefreshChanges();
            });

            this.NextCommand = new Command(() =>
            {
                _calendar.NextMonth();

                OnPropertyChanged(nameof(YearMonthLabel));
                OnPropertyChanged(nameof(SelectedDates));

                this.RefreshChanges();
            });

        }

        #region [ Commands ]

        public ICommand NextCommand { get; protected set; }

        public ICommand PriorCommand { get; protected set; }

        #endregion

        public ObservableCollection<Day> SelectedDates
        {
            get
            {
                return _calendar.GetSelectedDates();
            }
        }

        public void Draw()
        {
            this.RefreshChanges();
        }

        public string YearMonthLabel
        {
            get { return $"{CultureInfo.CurrentUICulture.DateTimeFormat.AbbreviatedMonthNames[_calendar.CurrentMonth - 1]} / {_calendar.CurrentYear} "; }
        }

        public void UpdateSelectedDates()
        {
            OnPropertyChanged(nameof(SelectedDates));
        }

        private void RefreshChanges()
        {
            OnMakeCalendar?.Invoke(this, _calendar.CurrentCalendar);
        }
    }
}
