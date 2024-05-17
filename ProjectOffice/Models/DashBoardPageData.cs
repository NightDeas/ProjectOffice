using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOffice.Models
{
    public class DashBoardPageData : INotifyPropertyChanged
    {
        private int countEndTask = 0;
        public int CountEndTask
        {
            get => countEndTask; set
            {
                countEndTask = value;
                OnPropertyChanged("CountEndTask");
            }
        }
        private Dictionary<string, int> topEmployee = new();
        public Dictionary<string, int> TopEmployee
        {
            get => topEmployee; set
            {
                topEmployee = value;
                OnPropertyChanged("TopEmployee");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
    }
}
