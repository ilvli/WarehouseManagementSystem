﻿#pragma checksum "..\..\..\Information_Inquiry\Color_Window.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A82BD25541CE587F98B3E51E607C7C33CB4E8C9AB097B2129DFA0B6F978842D4"
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
    /// Color_Window
    /// </summary>
    public partial class Color_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Information_Inquiry\Color_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Color_message;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Information_Inquiry\Color_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bnEdit;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Information_Inquiry\Color_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bnSave;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Information_Inquiry\Color_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bnDelete;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Information_Inquiry\Color_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bnquit;
        
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
            System.Uri resourceLocater = new System.Uri("/WarehouseManagementSystem1;component/information_inquiry/color_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Information_Inquiry\Color_Window.xaml"
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
            
            #line 8 "..\..\..\Information_Inquiry\Color_Window.xaml"
            ((WarehouseManagementSystem1.Information_Inquiry.Color_Window)(target)).Loaded += new System.Windows.RoutedEventHandler(this.LoadData);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Color_message = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\..\Information_Inquiry\Color_Window.xaml"
            this.Color_message.BeginningEdit += new System.EventHandler<System.Windows.Controls.DataGridBeginningEditEventArgs>(this.Color_message_BeginningEdit);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\Information_Inquiry\Color_Window.xaml"
            this.Color_message.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.Color_message_CellEditEnding);
            
            #line default
            #line hidden
            return;
            case 3:
            this.bnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Information_Inquiry\Color_Window.xaml"
            this.bnEdit.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.bnSave = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Information_Inquiry\Color_Window.xaml"
            this.bnSave.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.bnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Information_Inquiry\Color_Window.xaml"
            this.bnDelete.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.bnquit = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Information_Inquiry\Color_Window.xaml"
            this.bnquit.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

