﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Aurora.Utils
{
    public class PropertyChangedExEventArgs : PropertyChangedEventArgs
    {
        public object OldValue { get; set; }

        public object NewValue { get; set; }

        public PropertyChangedExEventArgs(string propertyName, object oldValue, object newValue) : base(propertyName)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }

    public abstract class NotifyPropertyChangedEx : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void UpdateVar<T>(ref T var, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!var.Equals(newValue))
            {
                T oldValue = var;
                var = newValue;
                InvokePropertyChanged(oldValue, newValue, propertyName);
            }
        }

        protected void InvokePropertyChanged(object oldValue, object newValue, [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedExEventArgs(propertyName, oldValue, newValue));
        }
    }
}
