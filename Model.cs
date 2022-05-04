using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Demo_MVVM
{
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) 
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Content { get; set; }
        public static System.Timers.Timer aTimer;

        public Model()
        {
            Content = 1;
            SetTimer();
        }

        public void SetTimer()
        {
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += aTimer_Elapsed;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void aTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Content++;
            OnPropertyChanged("Content");
        }
    }
}
