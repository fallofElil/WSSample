using System;
using System.Diagnostics;
using System.ComponentModel;

namespace WSSample.ViewModels
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool ThrowOnInvalidPropertyName { get; set; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            
            if (PropertyChanged != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, e);
            }
        }

        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = $"Invalid property name: {propertyName}";

                if (ThrowOnInvalidPropertyName)
                    throw new NullReferenceException(msg);
                else
                    Debug.Fail(msg);
            }
        }
    }
}