// Decompiled with JetBrains decompiler
// Type: LOB.View.writers.LoadFileView
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using GalaSoft.MvvmLight.Messaging;
using LOB.Helper;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace LOB.View.writers
{
  public partial class LoadFileView : UserControl, IComponentConnector
  {
    internal Grid grid;
    private bool _contentLoaded;

    public LoadFileView()
    {
      this.InitializeComponent();
      Messenger.Default.Send<CollectionViewMessage>(new CollectionViewMessage()
      {
        WebA = (CollectionViewSource) this.Resources[(object) "WebA"]
      });
    }

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/LOB;component/view/writers/loadfileview.xaml", UriKind.Relative));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      if (connectionId == 1)
        this.grid = (Grid) target;
      else
        this._contentLoaded = true;
    }
  }
}
