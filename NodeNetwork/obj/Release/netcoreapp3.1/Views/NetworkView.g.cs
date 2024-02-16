﻿#pragma checksum "..\..\..\..\Views\NetworkView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BEF833FEDA8A7628ECD1F13686BE6DA66608E904"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using NodeNetwork.Utilities.WPF;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using NodeNetwork.Views.Controls;
using ReactiveUI;
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


namespace NodeNetwork.Views {
    
    
    /// <summary>
    /// NetworkView
    /// </summary>
    public partial class NetworkView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 12 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal NodeNetwork.Views.NetworkView self;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Input.KeyBinding deleteBinding;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal NodeNetwork.Views.Controls.DragCanvas dragCanvas;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas contentContainer;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.RectangleGeometry clippingGeometry;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas backgroundCanvas;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl connectionsControl;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl nodesControl;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Line cutLine;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle selectionRectangle;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal NodeNetwork.Views.Controls.ViewModelViewHostNoAnimations pendingConnectionView;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal NodeNetwork.Views.Controls.ViewModelViewHostNoAnimations pendingNodeView;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup messagePopup;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReactiveUI.ViewModelViewHost messagePopupHost;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border messageHostBorder;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Views\NetworkView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ReactiveUI.ViewModelViewHost messageHost;
        
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
            System.Uri resourceLocater = new System.Uri("/NodeNetwork;component/views/networkview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\NetworkView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.self = ((NodeNetwork.Views.NetworkView)(target));
            return;
            case 2:
            this.deleteBinding = ((System.Windows.Input.KeyBinding)(target));
            return;
            case 3:
            this.dragCanvas = ((NodeNetwork.Views.Controls.DragCanvas)(target));
            return;
            case 4:
            this.contentContainer = ((System.Windows.Controls.Canvas)(target));
            
            #line 21 "..\..\..\..\Views\NetworkView.xaml"
            this.contentContainer.LayoutUpdated += new System.EventHandler(this.ContentContainer_OnLayoutUpdated);
            
            #line default
            #line hidden
            return;
            case 5:
            this.clippingGeometry = ((System.Windows.Media.RectangleGeometry)(target));
            return;
            case 6:
            this.backgroundCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 7:
            this.connectionsControl = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 8:
            this.nodesControl = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 10:
            this.cutLine = ((System.Windows.Shapes.Line)(target));
            return;
            case 11:
            this.selectionRectangle = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 12:
            this.pendingConnectionView = ((NodeNetwork.Views.Controls.ViewModelViewHostNoAnimations)(target));
            return;
            case 13:
            this.pendingNodeView = ((NodeNetwork.Views.Controls.ViewModelViewHostNoAnimations)(target));
            return;
            case 14:
            this.messagePopup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 15:
            this.messagePopupHost = ((ReactiveUI.ViewModelViewHost)(target));
            return;
            case 16:
            this.messageHostBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 17:
            this.messageHost = ((ReactiveUI.ViewModelViewHost)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 9:
            
            #line 50 "..\..\..\..\Views\NetworkView.xaml"
            ((System.Windows.Controls.Primitives.Thumb)(target)).DragStarted += new System.Windows.Controls.Primitives.DragStartedEventHandler(this.OnNodeDragStart);
            
            #line default
            #line hidden
            
            #line 50 "..\..\..\..\Views\NetworkView.xaml"
            ((System.Windows.Controls.Primitives.Thumb)(target)).DragDelta += new System.Windows.Controls.Primitives.DragDeltaEventHandler(this.OnNodeDrag);
            
            #line default
            #line hidden
            
            #line 50 "..\..\..\..\Views\NetworkView.xaml"
            ((System.Windows.Controls.Primitives.Thumb)(target)).DragCompleted += new System.Windows.Controls.Primitives.DragCompletedEventHandler(this.OnNodeDragEnd);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

