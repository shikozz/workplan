﻿#pragma checksum "..\..\castApp.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C49566C0F27D60F6CDB0F6915DA4D623F15271ADB1D1848022C205C2C2B08B23"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
    /// castApp
    /// </summary>
    public partial class castApp : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\castApp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\castApp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nametext;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\castApp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox amounttext;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\castApp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox deptext;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\castApp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ApplicationCommit;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\castApp.xaml"
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
            System.Uri resourceLocater = new System.Uri("/WorkPlan;component/castapp.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\castApp.xaml"
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
            return;
            case 3:
            this.amounttext = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 60 "..\..\castApp.xaml"
            ((System.Windows.Controls.Primitives.RepeatButton)(target)).Click += new System.Windows.RoutedEventHandler(this.increase);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 62 "..\..\castApp.xaml"
            ((System.Windows.Controls.Primitives.RepeatButton)(target)).Click += new System.Windows.RoutedEventHandler(this.decrease);
            
            #line default
            #line hidden
            return;
            case 6:
            this.deptext = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ApplicationCommit = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\castApp.xaml"
            this.ApplicationCommit.Click += new System.Windows.RoutedEventHandler(this.AuthorizationCommit_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ApplicationBack = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\castApp.xaml"
            this.ApplicationBack.Click += new System.Windows.RoutedEventHandler(this.AuthorizationRollBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

