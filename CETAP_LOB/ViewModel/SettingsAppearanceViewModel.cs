// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.SettingsAppearanceViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using FirstFloor.ModernUI.Presentation;
using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;

namespace CETAP_LOB.ViewModel
{
  public class SettingsAppearanceViewModel : ViewModelBase
  {
    public const string SelectedPalettePropertyName = "SelectedPalette";
    public const string PalettesPropertyName = "Palettes";
    public const string SelectedMetroAccentColorPropertyName = "SelectedMetroAccentColor";
    public const string AccentColorsPropertyName = "AccentColors";
    public const string metroAccentColorsPropertyName = "metroAccentColors";
    public const string wpaccentColorsPropertyName = "wpAccentColors";
    public const string SelectedAccentColorPropertyName = "SelectedAccentColor";
    public const string ThemesPropertyName = "Themes";
    public const string SelectedThemePropertyName = "SelectedTheme";
    public const string SelectedFontSizePropertyName = "SelectedFontSize";
    private const string FontSmall = "small";
    private const string FontLarge = "large";
    private bool _colorLoadedYet;
    private string _mySelectedPalette;
    private ObservableCollection<string> _mypalettes;
    private Color _myMetroColor;
    private ObservableCollection<Color> _accentColors;
    private ObservableCollection<Color> _metroColor;
    private ObservableCollection<Color> _myProperty;
    private Color _selectedAccentColor;
    private LinkCollection themes;
    private Link _selectedTheme;
    private string selectedFontSize;

    public string SelectedPalette
    {
      get
      {
        return this._mySelectedPalette;
      }
      set
      {
        if (this._mySelectedPalette == value)
          return;
        this._mySelectedPalette = value;
        this.RaisePropertyChanged("AccentColors");
        this.SelectedAccentColor = this.AccentColors.FirstOrDefault<Color>();
        this.RaisePropertyChanged("SelectedPalette");
      }
    }

    public ObservableCollection<string> Palettes
    {
      get
      {
        return this._mypalettes;
      }
      set
      {
        if (this._mypalettes == value)
          return;
        this._mypalettes = value;
        this.RaisePropertyChanged("Palettes");
      }
    }

    public Color SelectedMetroAccentColor
    {
      get
      {
        return this._myMetroColor;
      }
      set
      {
        if (this._myMetroColor == value)
          return;
        this._myMetroColor = value;
        this.RaisePropertyChanged("SelectedMetroAccentColor");
      }
    }

    public ObservableCollection<Color> AccentColors
    {
      get
      {
        if (!(this.SelectedPalette == "metro"))
          return this.wpAccentColors;
        return this.metroAccentColors;
      }
      set
      {
        if (this._accentColors == value)
          return;
        this._accentColors = value;
        this.RaisePropertyChanged("AccentColors");
      }
    }

    public ObservableCollection<Color> metroAccentColors
    {
      get
      {
        return this._metroColor;
      }
      set
      {
        if (this._metroColor == value)
          return;
        this._metroColor = value;
        this.RaisePropertyChanged("metroAccentColors");
      }
    }

    public ObservableCollection<Color> wpAccentColors
    {
      get
      {
        return this._myProperty;
      }
      set
      {
        if (this._myProperty == value)
          return;
        this._myProperty = value;
        this.RaisePropertyChanged("wpAccentColors");
      }
    }

    public Color SelectedAccentColor
    {
      get
      {
        return this._selectedAccentColor;
      }
      set
      {
        if (this._selectedAccentColor == value)
          return;
        this._selectedAccentColor = value;
        AppearanceManager.Current.AccentColor = value;
        this.RaisePropertyChanged("SelectedAccentColor");
      }
    }

    public LinkCollection Themes
    {
      get
      {
        return this.themes;
      }
      set
      {
        if (this.themes == value)
          return;
        this.themes = value;
        this.RaisePropertyChanged("Themes");
      }
    }

    public Link SelectedTheme
    {
      get
      {
        return this._selectedTheme;
      }
      set
      {
        if (this._selectedTheme == value)
          return;
        this._selectedTheme = value;
        this.RaisePropertyChanged("SelectedTheme");
        AppearanceManager.Current.ThemeSource = value.Source;
      }
    }

    public string SelectedFontSize
    {
      get
      {
        return this.selectedFontSize;
      }
      set
      {
        if (this.selectedFontSize == value)
          return;
        this.selectedFontSize = value;
        this.RaisePropertyChanged("SelectedFontSize");
        AppearanceManager.Current.FontSize = value == "large" ? FontSize.Large : FontSize.Small;
        if (!this._colorLoadedYet)
          return;
        ApplicationSettings.Default.SelectedFontSize = this.selectedFontSize;
        ApplicationSettings.Default.Save();
      }
    }

    public string[] FontSizes
    {
      get
      {
        return new string[2]{ "small", "large" };
      }
    }

    public SettingsAppearanceViewModel()
    {
      ObservableCollection<string> observableCollection1 = new ObservableCollection<string>();
      observableCollection1.Add("metro");
      observableCollection1.Add("windows phone");
      this._mypalettes = observableCollection1;
      ObservableCollection<Color> observableCollection2 = new ObservableCollection<Color>();
      observableCollection2.Add(Color.FromRgb((byte) 51, (byte) 153, byte.MaxValue));
      observableCollection2.Add(Color.FromRgb((byte) 0, (byte) 171, (byte) 169));
      observableCollection2.Add(Color.FromRgb((byte) 51, (byte) 153, (byte) 51));
      observableCollection2.Add(Color.FromRgb((byte) 140, (byte) 191, (byte) 38));
      observableCollection2.Add(Color.FromRgb((byte) 240, (byte) 150, (byte) 9));
      observableCollection2.Add(Color.FromRgb(byte.MaxValue, (byte) 69, (byte) 0));
      observableCollection2.Add(Color.FromRgb((byte) 229, (byte) 20, (byte) 0));
      observableCollection2.Add(Color.FromRgb(byte.MaxValue, (byte) 0, (byte) 151));
      observableCollection2.Add(Color.FromRgb((byte) 162, (byte) 0, byte.MaxValue));
      this._metroColor = observableCollection2;
      ObservableCollection<Color> observableCollection3 = new ObservableCollection<Color>();
      observableCollection3.Add(Color.FromRgb((byte) 164, (byte) 196, (byte) 0));
      observableCollection3.Add(Color.FromRgb((byte) 96, (byte) 169, (byte) 23));
      observableCollection3.Add(Color.FromRgb((byte) 0, (byte) 138, (byte) 0));
      observableCollection3.Add(Color.FromRgb((byte) 0, (byte) 171, (byte) 169));
      observableCollection3.Add(Color.FromRgb((byte) 27, (byte) 161, (byte) 226));
      observableCollection3.Add(Color.FromRgb((byte) 0, (byte) 80, (byte) 239));
      observableCollection3.Add(Color.FromRgb((byte) 106, (byte) 0, byte.MaxValue));
      observableCollection3.Add(Color.FromRgb((byte) 170, (byte) 0, byte.MaxValue));
      observableCollection3.Add(Color.FromRgb((byte) 244, (byte) 114, (byte) 208));
      observableCollection3.Add(Color.FromRgb((byte) 216, (byte) 0, (byte) 115));
      observableCollection3.Add(Color.FromRgb((byte) 162, (byte) 0, (byte) 37));
      observableCollection3.Add(Color.FromRgb((byte) 229, (byte) 20, (byte) 0));
      observableCollection3.Add(Color.FromRgb((byte) 250, (byte) 104, (byte) 0));
      observableCollection3.Add(Color.FromRgb((byte) 240, (byte) 163, (byte) 10));
      observableCollection3.Add(Color.FromRgb((byte) 227, (byte) 200, (byte) 0));
      observableCollection3.Add(Color.FromRgb((byte) 130, (byte) 90, (byte) 44));
      observableCollection3.Add(Color.FromRgb((byte) 109, (byte) 135, (byte) 100));
      observableCollection3.Add(Color.FromRgb((byte) 100, (byte) 118, (byte) 135));
      observableCollection3.Add(Color.FromRgb((byte) 118, (byte) 96, (byte) 138));
      observableCollection3.Add(Color.FromRgb((byte) 135, (byte) 121, (byte) 78));
      this._myProperty = observableCollection3;
      this.themes = new LinkCollection();
      this.selectedFontSize = string.Empty;

      LinkCollection themes1 = this.themes;
      Link link1 = new Link();
      link1.DisplayName = "dark";
      link1.Source = AppearanceManager.DarkThemeSource;
      Link link2 = link1;
      themes1.Add(link2);
      LinkCollection themes2 = this.themes;
      Link link3 = new Link();
      link3.DisplayName = "light";
      link3.Source = AppearanceManager.LightThemeSource;
      Link link4 = link3;
      themes2.Add(link4);
      LinkCollection themes3 = this.themes;
      Link link5 = new Link();
      link5.DisplayName = "snowflake";
      link5.Source = new Uri("/LOB;component/Assets/ModernUI.Snowflakes.xaml", UriKind.Relative);
      Link link6 = link5;
      themes3.Add(link6);
      LinkCollection themes4 = this.themes;
      Link link7 = new Link();
      link7.DisplayName = "bing image";
      link7.Source = new Uri("/LOB;component/Assets/ModernUI.BingImage.xaml", UriKind.Relative);
      Link link8 = link7;
      themes4.Add(link8);
      LinkCollection themes5 = this.themes;
      Link link9 = new Link();
      link9.DisplayName = "cetap";
      link9.Source = new Uri("/LOB;component/Assets/ModernUI.Cetap.xaml", UriKind.Relative);
      Link link10 = link9;
      themes5.Add(link10);
      LinkCollection themes6 = this.themes;
      Link link11 = new Link();
      link11.DisplayName = "rose";
      link11.Source = new Uri("/LOB;component/Assets/ModernUI.Rose.xaml", UriKind.Relative);
      Link link12 = link11;
      themes6.Add(link12);
      LinkCollection themes7 = this.themes;
      Link link13 = new Link();
      link13.DisplayName = "bubbles";
      link13.Source = new Uri("/LOB;component/Assets/ModernUI.Bubbles.xaml", UriKind.Relative);
      Link link14 = link13;
      themes7.Add(link14);
      LinkCollection themes8 = this.themes;
      Link link15 = new Link();
      link15.DisplayName = "water drop";
      link15.Source = new Uri("/LOB;component/Assets/ModernUI.WaterDrop.xaml", UriKind.Relative);
      Link link16 = link15;
      themes8.Add(link16);
      this.SelectedFontSize = AppearanceManager.Current.FontSize == FontSize.Large ? "large" : "small";
      this.SyncThemeAndColor();
      AppearanceManager.Current.PropertyChanged += new PropertyChangedEventHandler(this.OnAppearanceManagerPropertyChanged);
    }

    private void OnAppearanceManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == "ThemeSource") && !(e.PropertyName == "AccentColor"))
        return;
      this.SyncThemeAndColor();
    }

    private void SyncThemeAndColor()
    {
      this.SelectedTheme = this.themes.FirstOrDefault<Link>((Func<Link, bool>) (l => l.Source.Equals((object) AppearanceManager.Current.ThemeSource)));
      this.SelectedAccentColor = AppearanceManager.Current.AccentColor;
      if (!this._colorLoadedYet)
        return;
      ApplicationSettings.Default.SelectedThemeDisplayName = this.SelectedTheme.DisplayName;
      ApplicationSettings.Default.SelectedThemeSource = this.SelectedTheme.Source;
      ApplicationSettings.Default.SelectedAccentColor = this.SelectedAccentColor;
      ApplicationSettings.Default.SelectedFontSize = this.SelectedFontSize;
      ApplicationSettings.Default.Save();
    }

    public void SetThemeAndColor(string themeSourceDisplayName, Uri themeSourceUri, Color accentColor, string fontSize)
    {
      Link link = new Link();
      link.DisplayName = themeSourceDisplayName;
      link.Source = themeSourceUri;
      this.SelectedTheme = link;
      this.SelectedAccentColor = accentColor;
      this.SelectedFontSize = fontSize;
      this._colorLoadedYet = true;
    }
  }
}
