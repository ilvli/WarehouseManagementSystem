﻿#pragma checksum "..\..\..\Information_Inquiry\Changsi_Inquiry_Window.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AF4917D29268752818416313107686FCF4AA6306"
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
using WarehouseManagementSystem1.Information_Inquiry;


namespace WarehouseManagementSystem1.Information_Inquiry {
    
    
    /// <summary>
    /// Changsi_Inquiry_Window
    /// </summary>
    public partial class Changsi_Inquiry_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Information_Inquiry\Changsi_Inquiry_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TypeCombo;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Information_Inquiry\Changsi_Inquiry_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbStartData;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Information_Inquiry\Changsi_Inquiry_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbEndData;
        
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
            System.Uri resourceLocater = new System.Uri("/WarehouseManagementSystem1;component/information_inquiry/changsi_inquiry_window." +
                    "xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Information_Inquiry\Changsi_Inquiry_Window.xaml"
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
            
            #line 8 "..\..\..\Information_Inquiry\Changsi_Inquiry_Window.xaml"
            ((WarehouseManagementSystem1.Information_Inquiry.Changsi_Inquiry_Window)(target)).Loaded += new System.Windows.RoutedEventHandler(this.LoadData);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TypeCombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            
            #line 15 "..\..\..\Information_Inquiry\Changsi_Inquiry_Window.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 16 "..\..\..\Information_Inquiry\Changsi_Inquiry_Window.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbStartData = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbEndData = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
