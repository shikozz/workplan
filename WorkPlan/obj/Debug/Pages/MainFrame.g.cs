﻿#pragma checksum "..\..\..\Pages\MainFrame.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "50CDD584AB37E88CC775041BF14AA30197E2B8C29C101BAAAD5D20F0F37D63FB"
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
using WorkPlan.Pages;


namespace WorkPlan.Pages {
    
    
    /// <summary>
    /// MainFrame
    /// </summary>
    public partial class MainFrame : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Pages\MainFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLight;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Pages\MainFrame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLight1;
        
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
            System.Uri resourceLocater = new System.Uri("/WorkPlan;component/pages/mainframe.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\MainFrame.xaml"
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
            
            #line 11 "..\..\..\Pages\MainFrame.xaml"
            ((System.Windows.Controls.Grid)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Grid_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnLight = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Pages\MainFrame.xaml"
            this.btnLight.Click += new System.Windows.RoutedEventHandler(this.btnLight_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnLight1 = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\Pages\MainFrame.xaml"
            this.btnLight1.Click += new System.Windows.RoutedEventHandler(this.btnLight1_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

