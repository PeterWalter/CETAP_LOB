// Decompiled with JetBrains decompiler
// Type: LOB.View.Composite.CompositeView
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

namespace LOB.View.Composite
{
  public partial class CompositeView : UserControl, IComponentConnector
  {
    internal Intellibox autoBox;
    internal DataGrid dataGrid;
    private bool _contentLoaded;

    public CompositeView()
    {
      this.InitializeComponent();
    }

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/LOB;component/view/composite/compositeview.xaml", UriKind.Relative));
    }

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [DebuggerNonUserCode]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.autoBox = (Intellibox) target;
          break;
        case 2:
          this.dataGrid = (DataGrid) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
