﻿#pragma checksum "..\..\..\Add\SchedulesAdd.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "30CCF001BA772FF8A94BABFF01FF59F5EB212D49F21513F2B1530F68011F68F2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using BeautyArt.Add;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace BeautyArt.Add {
    
    
    /// <summary>
    /// SchedulesAdd
    /// </summary>
    public partial class SchedulesAdd : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\Add\SchedulesAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxTitle;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Add\SchedulesAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxTeach;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Add\SchedulesAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxType;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Add\SchedulesAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePickerDate;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Add\SchedulesAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.TimePicker TimePickerTime;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Add\SchedulesAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxCabinet;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Add\SchedulesAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\Add\SchedulesAdd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseButton;
        
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
            System.Uri resourceLocater = new System.Uri("/BeautyArt;component/add/schedulesadd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Add\SchedulesAdd.xaml"
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
            this.ComboBoxTitle = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.ComboBoxTeach = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.ComboBoxType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.DatePickerDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.TimePickerTime = ((MaterialDesignThemes.Wpf.TimePicker)(target));
            return;
            case 6:
            this.ComboBoxCabinet = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\Add\SchedulesAdd.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CloseButton = ((System.Windows.Controls.Button)(target));
            
            #line 103 "..\..\..\Add\SchedulesAdd.xaml"
            this.CloseButton.Click += new System.Windows.RoutedEventHandler(this.CloseButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
