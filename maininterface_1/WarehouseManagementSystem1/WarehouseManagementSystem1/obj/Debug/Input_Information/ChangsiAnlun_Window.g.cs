﻿#pragma checksum "..\..\..\Input_Information\ChangsiAnlun_Window.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DD8C998C53831C801CF680753257571A107EB4BA"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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
using WarehouseManagementSystem1.Input_Information;


namespace WarehouseManagementSystem1.Input_Information {
    
    
    /// <summary>
    /// ChangsiAnlun_Window
    /// </summary>
    public partial class ChangsiAnlun_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\Input_Information\ChangsiAnlun_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbbTime;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Input_Information\ChangsiAnlun_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbColor;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Input_Information\ChangsiAnlun_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbModel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Input_Information\ChangsiAnlun_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbWeight;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Input_Information\ChangsiAnlun_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SipplierCombo;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Input_Information\ChangsiAnlun_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeCombo;
        
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
            System.Uri resourceLocater = new System.Uri("/WarehouseManagementSystem1;component/input_information/changsianlun_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Input_Information\ChangsiAnlun_Window.xaml"
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
            
            #line 8 "..\..\..\Input_Information\ChangsiAnlun_Window.xaml"
            ((WarehouseManagementSystem1.Input_Information.ChangsiAnlun_Window)(target)).Loaded += new System.Windows.RoutedEventHandler(this.LoadData);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbbTime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbColor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbModel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbWeight = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.SipplierCombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.TypeCombo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\..\Input_Information\ChangsiAnlun_Window.xaml"
            this.TypeCombo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TypeCombo_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 22 "..\..\..\Input_Information\ChangsiAnlun_Window.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 23 "..\..\..\Input_Information\ChangsiAnlun_Window.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

