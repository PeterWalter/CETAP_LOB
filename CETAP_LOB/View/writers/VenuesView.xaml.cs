// Decompiled with JetBrains decompiler
// Type: LOB.View.writers.VenuesView
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using FeserWard.Controls;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace LOB.View.writers
{
  public partial class VenuesView : UserControl, IComponentConnector
  {
    internal Intellibox autoBox;
    internal ListBox listBox1;
    private bool _contentLoaded;

    public VenuesView()
    {
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/LOB;component/view/writers/venuesview.xaml", UriKind.Relative));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.autoBox = (Intellibox) target;
          break;
        case 2:
          this.listBox1 = (ListBox) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
