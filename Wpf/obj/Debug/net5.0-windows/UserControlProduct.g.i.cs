﻿#pragma checksum "..\..\..\UserControlProduct.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1741312BBEC6AC47E0E54FDB8EF3727177EC791E"
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
using System.Windows.Controls.Ribbon;
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
using WPF_CF;


namespace WPF_CF {
    
    
    /// <summary>
    /// UserControlProduct
    /// </summary>
    public partial class UserControlProduct : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 33 "..\..\..\UserControlProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Image;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserControlProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnImage;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\UserControlProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMa;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\UserControlProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTen;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\UserControlProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtGia;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\UserControlProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbloai;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\UserControlProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbsize;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\UserControlProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpNgaylaphd;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\UserControlProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgCTSIZE;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\UserControlProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnThemSP;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\UserControlProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Wpf;component/usercontrolproduct.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControlProduct.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Image = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.btnImage = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\UserControlProduct.xaml"
            this.btnImage.Click += new System.Windows.RoutedEventHandler(this.btnImage_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtMa = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtTen = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtGia = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.cmbloai = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.cmbsize = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.dpNgaylaphd = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            
            #line 41 "..\..\..\UserControlProduct.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.dgCTSIZE = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 12:
            this.btnThemSP = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\UserControlProduct.xaml"
            this.btnThemSP.Click += new System.Windows.RoutedEventHandler(this.btnThemSP_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.dg = ((System.Windows.Controls.DataGrid)(target));
            
            #line 64 "..\..\..\UserControlProduct.xaml"
            this.dg.LoadingRowDetails += new System.EventHandler<System.Windows.Controls.DataGridRowDetailsEventArgs>(this.dg_LoadingRowDetails);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 11:
            
            #line 52 "..\..\..\UserControlProduct.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnXoa_Click_1);
            
            #line default
            #line hidden
            break;
            case 14:
            
            #line 74 "..\..\..\UserControlProduct.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnXoa_Click);
            
            #line default
            #line hidden
            break;
            case 15:
            
            #line 82 "..\..\..\UserControlProduct.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSua_Click);
            
            #line default
            #line hidden
            break;
            case 16:
            
            #line 118 "..\..\..\UserControlProduct.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSua_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
