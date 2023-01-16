﻿#pragma checksum "..\..\..\..\Views\ShowSchools.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45F59736921F945B6FD4AF896376EC0A09D6B133"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Xpf.DXBinding;
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


namespace LanguageSchools.Views {
    
    
    /// <summary>
    /// ShowSchools
    /// </summary>
    public partial class ShowSchools : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Views\ShowSchools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miAddSchool;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Views\ShowSchools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miUpdateSchool;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Views\ShowSchools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miDeleteProfessor;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Views\ShowSchools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem professors;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Views\ShowSchools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sch;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Views\ShowSchools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listbox1;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Views\ShowSchools.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgSchools;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
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
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\Views\ShowSchools.xaml"
            ((LanguageSchools.Views.ShowSchools)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.DataWindow_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.miAddSchool = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\..\..\Views\ShowSchools.xaml"
            this.miAddSchool.Click += new System.Windows.RoutedEventHandler(this.miAddSchool_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.miUpdateSchool = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\..\..\Views\ShowSchools.xaml"
            this.miUpdateSchool.Click += new System.Windows.RoutedEventHandler(this.miUpdateSchool_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.miDeleteProfessor = ((System.Windows.Controls.MenuItem)(target));
            
            #line 21 "..\..\..\..\Views\ShowSchools.xaml"
            this.miDeleteProfessor.Click += new System.Windows.RoutedEventHandler(this.DeleteSch);
            
            #line default
            #line hidden
            return;
            case 5:
            this.professors = ((System.Windows.Controls.MenuItem)(target));
            
            #line 22 "..\..\..\..\Views\ShowSchools.xaml"
            this.professors.Click += new System.Windows.RoutedEventHandler(this.professors_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.sch = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\..\Views\ShowSchools.xaml"
            this.sch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.sch_TextChanged_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.listbox1 = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            
            #line 25 "..\..\..\..\Views\ShowSchools.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dgSchools = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

