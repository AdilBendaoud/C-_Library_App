﻿#pragma checksum "..\..\..\Employes.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D5963430948C73F5FC5E3F8235C871EEE8597E1D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
using GestionBibliotheque;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace GestionBibliotheque {
    
    
    /// <summary>
    /// Employes
    /// </summary>
    public partial class Employes : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 110 "..\..\..\Employes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button empBtn;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\Employes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchInput;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\Employes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.12.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GestionBibliotheque;component/employes.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Employes.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.12.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 6 "..\..\..\Employes.xaml"
            ((GestionBibliotheque.Employes)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.HandleDragWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 21 "..\..\..\Employes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MinimizeBtn);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 34 "..\..\..\Employes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MaximizeBtn);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 47 "..\..\..\Employes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 71 "..\..\..\Employes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EmprruntHandle);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 79 "..\..\..\Employes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.goToAdherents);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 88 "..\..\..\Employes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LivreHandle);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 96 "..\..\..\Employes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AuteursHandle);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 103 "..\..\..\Employes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.goToCategories);
            
            #line default
            #line hidden
            return;
            case 10:
            this.empBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            
            #line 118 "..\..\..\Employes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SignOut);
            
            #line default
            #line hidden
            return;
            case 12:
            this.searchInput = ((System.Windows.Controls.TextBox)(target));
            
            #line 136 "..\..\..\Employes.xaml"
            this.searchInput.KeyUp += new System.Windows.Input.KeyEventHandler(this.Search);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 153 "..\..\..\Employes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddBtn);
            
            #line default
            #line hidden
            return;
            case 14:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 162 "..\..\..\Employes.xaml"
            this.dataGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.DataGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

