﻿#pragma checksum "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "46FF7DCF7086E27A781088C59036789D2B83188776F4A1695E4F691447763C14"
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
    /// ChangsiResult_Window
    /// </summary>
    public partial class ChangsiResult_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Changsi_message;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bnEdit_Copy;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bnEdit;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bnSave;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bnDelete;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bnquit;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label WeightContent;
        
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
            System.Uri resourceLocater = new System.Uri("/WarehouseManagementSystem1;component/information_inquiry/changsiresult_window.xa" +
                    "ml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
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
            
            #line 8 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
            ((WarehouseManagementSystem1.Information_Inquiry.ChangsiResult_Window)(target)).Loaded += new System.Windows.RoutedEventHandler(this.LoadData);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Changsi_message = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
            this.Changsi_message.BeginningEdit += new System.EventHandler<System.Windows.Controls.DataGridBeginningEditEventArgs>(this.Changsi_message_BeginningEdit);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
            this.Changsi_message.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.Changsi_message_CellEditEnding);
            
            #line default
            #line hidden
            return;
            case 3:
            this.bnEdit_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
            this.bnEdit_Copy.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.bnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
            this.bnEdit.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.bnSave = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
            this.bnSave.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.bnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
            this.bnDelete.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.bnquit = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Information_Inquiry\ChangsiResult_Window.xaml"
            this.bnquit.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.WeightContent = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

