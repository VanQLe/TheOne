using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrideTek.Shell.Core
{
    public class NotificationObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Raised when the value of a property has changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises <see cref="PropertyChanged"/> for the property whose name matches <see cref="propertyName"/>.
        /// </summary>
        /// <param name="propertyName">Optional. The name of the property whose value has changed.</param>
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;

           if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            } 
        }
        protected virtual bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            field = value;
            NotifyPropertyChanged(propertyName);
            return true;
        }

    }
}