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

        public DayViewTemplate(DayModel currentDay)
        {
            InitializeComponent();

            DayViewModel vm = new DayViewModel(currentDay);

            this.BindingContext = vm;
            
            vm.OnSelected += Vm_OnSelected;

            this.lblDay.AutomationId = string.Format("LabelDay_{0}", currentDay.Date.ToString("dd"));
        }

        private void Vm_OnSelected(object sender, EventArgs e)
        {
            OnSelected?.Invoke(this, new EventArgs());
        }
    }
}
