using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanure.CalendarPOC.Models;
using Tanure.CalendarPOC.ViewModels;
using Xamarin.Forms;

namespace Tanure.CalendarPOC.Views.Template
{
    public partial class DayViewTemplate : ContentView
    {
        public event EventHandler OnSelected;

        public DayViewTemplate(Day currentDay)
        {
            InitializeComponent();

            DayViewModel vm = new DayViewModel(currentDay);

            this.BindingContext = vm;
            vm.OnSelected += Vm_OnSelected;
        }

        private void Vm_OnSelected(object sender, EventArgs e)
        {
            if (OnSelected != null)
                OnSelected(this, new EventArgs());
        }
    }
}
