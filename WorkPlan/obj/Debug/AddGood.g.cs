﻿#pragma checksum "..\..\AddGood.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "197CD914D67B58C1EFFB6B8A21B811799A13048721536C37BFDC39BBB019DAE5"
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
using WorkPlan;


namespace WorkPlan {
    
    
    /// <summary>
    /// AddGood
    /// </summary>
    public partial class AddGood : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\AddGood.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\AddGood.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nametext;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\AddGood.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox amounttext;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\AddGood.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ApplicationCommit;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\AddGood.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ApplicationBack;
        
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
            System.Uri resourceLocater = new System.Uri("/WorkPlan;component/addgood.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddGood.xaml"
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
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.nametext = ((System.Windows.Controls.TextBox)(target));
            
            #line 53 "..\..\AddGood.xaml"
            this.nametext.MouseEnter += new System.Windows.Input.MouseEventHandler(this.nametext_MouseEnter);
            
            #line default
            #line hidden
            
            #line 53 "..\..\AddGood.xaml"
            this.nametext.MouseLeave += new System.Windows.Input.MouseEventHandler(this.nametext_MouseLeave);
            
            #line default
            #line hidden
            
            #line 53 "..\..\AddGood.xaml"
            this.nametext.GotFocus += new System.Windows.RoutedEventHandler(this.nametext_GotFocus);
            
            #line default
            #line hidden
            
            #line 53 "..\..\AddGood.xaml"
            this.nametext.LostFocus += new System.Windows.RoutedEventHandler(this.nametext_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.amounttext = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 60 "..\..\AddGood.xaml"
            ((System.Windows.Controls.Primitives.RepeatButton)(target)).Click += new System.Windows.RoutedEventHandler(this.increase);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 62 "..\..\AddGood.xaml"
            ((System.Windows.Controls.Primitives.RepeatButton)(target)).Click += new System.Windows.RoutedEventHandler(this.decrease);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ApplicationCommit = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\AddGood.xaml"
            this.ApplicationCommit.Click += new System.Windows.RoutedEventHandler(this.AuthorizationCommit_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ApplicationBack = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\AddGood.xaml"
            this.ApplicationBack.Click += new System.Windows.RoutedEventHandler(this.AuthorizationRollBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

