#pragma checksum "..\..\appRedaction.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "13F08115AEC52A756F3170F8656178A81774C897C00FE544A677E327835BFB68"
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
    /// appRedaction
    /// </summary>
    public partial class appRedaction : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\appRedaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\appRedaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nametext;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\appRedaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox amounttext;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\appRedaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox deptext;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\appRedaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\appRedaction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ApplicationCommit;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\appRedaction.xaml"
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
            System.Uri resourceLocater = new System.Uri("/WorkPlan;component/appredaction.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\appRedaction.xaml"
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
            
            #line 61 "..\..\appRedaction.xaml"
            ((System.Windows.Controls.Primitives.RepeatButton)(target)).Click += new System.Windows.RoutedEventHandler(this.increase);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 63 "..\..\appRedaction.xaml"
            ((System.Windows.Controls.Primitives.RepeatButton)(target)).Click += new System.Windows.RoutedEventHandler(this.decrease);
            
            #line default
            #line hidden
            return;
            case 6:
            this.deptext = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.combo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.ApplicationCommit = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\appRedaction.xaml"
            this.ApplicationCommit.Click += new System.Windows.RoutedEventHandler(this.AuthorizationCommit_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ApplicationBack = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\appRedaction.xaml"
            this.ApplicationBack.Click += new System.Windows.RoutedEventHandler(this.AuthorizationRollBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

