﻿#pragma checksum "..\..\..\View\MediaElementDemo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C7EE63E03B53F317E7302E04279A678163C068D50D7A1C3D6EF47F58546E0B8B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ad2ex1.View {
    
    
    /// <summary>
    /// MediaElementDemo
    /// </summary>
    public partial class MediaElementDemo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\View\MediaElementDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement Media;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\View\MediaElementDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MediaName;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\View\MediaElementDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse Status;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\View\MediaElementDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider VolumeSlider;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\View\MediaElementDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider BalanceSlider;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\View\MediaElementDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider SpeedSlider;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ad2ex1;component/view/mediaelementdemo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\MediaElementDemo.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Media = ((System.Windows.Controls.MediaElement)(target));
            
            #line 23 "..\..\..\View\MediaElementDemo.xaml"
            this.Media.MediaOpened += new System.Windows.RoutedEventHandler(this.Media_MediaOpened);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\View\MediaElementDemo.xaml"
            this.Media.MediaEnded += new System.Windows.RoutedEventHandler(this.Media_MediaEnded);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\View\MediaElementDemo.xaml"
            this.Media.MediaFailed += new System.EventHandler<System.Windows.ExceptionRoutedEventArgs>(this.Media_MediaFailed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MediaName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Status = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 4:
            
            #line 39 "..\..\..\View\MediaElementDemo.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PlayButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 40 "..\..\..\View\MediaElementDemo.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PauseButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 41 "..\..\..\View\MediaElementDemo.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.StopButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 42 "..\..\..\View\MediaElementDemo.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Click += new System.Windows.RoutedEventHandler(this.MuteButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.VolumeSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 47 "..\..\..\View\MediaElementDemo.xaml"
            this.VolumeSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.VolumeSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BalanceSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 52 "..\..\..\View\MediaElementDemo.xaml"
            this.BalanceSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Balance_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.SpeedSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 57 "..\..\..\View\MediaElementDemo.xaml"
            this.SpeedSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Speed_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 66 "..\..\..\View\MediaElementDemo.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoadButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
