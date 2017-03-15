// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.ViewModelbase1
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using GalaSoft.MvvmLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CETAP_LOB.ViewModel
{
  internal class ViewModelbase1 : ViewModelBase, INotifyDataErrorInfo
  {
    public Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

    public bool HasErrors
    {
      get
      {
        return this._errors.Count > 0;
      }
    }

    public bool IsValid
    {
      get
      {
        return !this.HasErrors;
      }
    }

    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    public IEnumerable GetErrors(string propertyName)
    {
      if (string.IsNullOrEmpty(propertyName) || !this._errors.ContainsKey(propertyName))
        return (IEnumerable) null;
      return (IEnumerable) this._errors[propertyName];
    }

    public void AddError(string propertyName, string error)
    {
      this._errors[propertyName] = new List<string>()
      {
        error
      };
      this.NotifyErrorsChanged(propertyName);
    }

    public void RemoveError(string propertyName)
    {
      if (this._errors.ContainsKey(propertyName))
        this._errors.Remove(propertyName);
      this.NotifyErrorsChanged(propertyName);
    }

    private void NotifyErrorsChanged(string propertyName)
    {
      if (this.ErrorsChanged == null)
        return;
      this.ErrorsChanged((object) this, new DataErrorsChangedEventArgs(propertyName));
    }
  }
}
