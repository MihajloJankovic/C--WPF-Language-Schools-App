﻿#pragma checksum "..\..\..\..\Views\ShowSchools.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8FBB520031831174FAC61B06CE876CD1CFA42042"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LanguageSchools.Views;
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


namespace LanguageSchools.Views {
    
    
    /// <summary>
    /// ShowSchools
    /// </summary>
    public partial class ShowSchools : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Views\ShowSchools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miAddSchool;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Views\ShowSchools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miUpdateSchool;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Views\ShowSchools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miDeleteProfessor;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Views\ShowSchools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgSchools;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LanguageSchools;component/views/showschools.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ShowSchools.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.miAddSchool = ((System.Windows.Controls.MenuItem)(target));
            
            #line 18 "..\..\..\..\Views\ShowSchools.xaml"
            this.miAddSchool.Click += new System.Windows.RoutedEventHandler(this.miAddSchool_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.miUpdateSchool = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\..\..\Views\ShowSchools.xaml"
            this.miUpdateSchool.Click += new System.Windows.RoutedEventHandler(this.miUpdateSchool_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.miDeleteProfessor = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\..\..\Views\ShowSchools.xaml"
            this.miDeleteProfessor.Click += new System.Windows.RoutedEventHandler(this.DeleteSch);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dgSchools = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

