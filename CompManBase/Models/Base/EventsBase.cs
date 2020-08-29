using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CompManBase.Annotations;

namespace CompManBase.Models
{
    public abstract class EventsBase : INotifyPropertyChanged
    {


        public EventsBase()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void Changed(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /////////////////////////////////////////////////////////////////////
    }
}
