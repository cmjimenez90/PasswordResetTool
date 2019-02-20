using GalaSoft.MvvmLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Cmjimenez.PasswordResetTool.Application.Main.ViewModel
{
    public class ModifiedBaseViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        protected Dictionary<String, List<String>> _errors = new Dictionary<string, List<string>>();

        public bool HasErrors =>  _errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public void AddError(string propertyName, string error)
        {
            // Add error to list
            this._errors[propertyName] = new List<string>() { error };
            this.NotifyChangeInErrors(propertyName);
        }

        public void RemoveError(string propertyName)
        {
            // remove error
            if (this._errors.ContainsKey(propertyName))
                this._errors.Remove(propertyName);
            this.NotifyChangeInErrors(propertyName);
        }
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !_errors.ContainsKey(propertyName))
                return null;
            return _errors[propertyName];
        }

        public void NotifyChangeInErrors(String propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

    }
}
