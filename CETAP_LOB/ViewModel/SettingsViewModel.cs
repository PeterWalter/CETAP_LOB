
using FirstFloor.ModernUI.Presentation;
using GalaSoft.MvvmLight;
using System;

namespace CETAP_LOB.ViewModel
{
  public class SettingsViewModel : ViewModelBase
  {
    private LinkCollection _mylinks = new LinkCollection();
    public const string LinksPropertyName = "Links";

    public LinkCollection Links
    {
      get
      {
        return this._mylinks;
      }
      set
      {
        if (this._mylinks == value)
          return;
        this._mylinks = value;
        this.RaisePropertyChanged("Links");
      }
    }

    public SettingsViewModel()
    {
      this.InitializeModels();
      this.RegisterCommands();
      this.LoadData();
    }

    private void InitializeModels()
    {
      Link link1 = new Link();
      link1.DisplayName = "Settings";
      link1.Source = new Uri("View/SettingsAppearance.xaml", UriKind.Relative);
      this._mylinks.Add(link1);
      Link link2 = new Link();
      link2.DisplayName = "About";
      link2.Source = new Uri("View/AboutView.xaml", UriKind.Relative);
      this._mylinks.Add(link2);
      Link link3 = new Link();
      link3.DisplayName = "Working Folders";
      link3.Source = new Uri("View/ScanSettingsView.xaml", UriKind.Relative);
      this._mylinks.Add(link3);
    }

    private void RegisterCommands()
    {
    }

    private void LoadData()
    {
    }
  }
}
