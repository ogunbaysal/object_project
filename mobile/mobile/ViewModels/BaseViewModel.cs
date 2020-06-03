using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using mobile.Models;
using mobile.Services.Interface;

namespace mobile.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<string, object> PropertyValues = new Dictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            return GetValue(propertyName, default(T));
        }

        protected void SetValue<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName)) return;

            var shouldNotify = !PropertyValues.ContainsKey(propertyName) || !object.Equals(value, PropertyValues[propertyName]);

            PropertyValues[propertyName] = value;

            if (shouldNotify)
                RaisePropertyChanged(propertyName);
        }

        private T GetValue<T>(string propertyName, T defaultValue)
        {
            if (PropertyValues.ContainsKey(propertyName))
                return (T)PropertyValues[propertyName];

            return defaultValue;
        }

        private void RaisePropertyChanged(string propName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
