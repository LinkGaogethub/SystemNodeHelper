﻿#pragma checksum "..\..\..\..\ContextMenu\SearchableContextMenuView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92AB1046F7EF3A2554109C6612D34FE01B7F90B4"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using NodeNetwork.Toolkit.ContextMenu;
using NodeNetwork.ViewModels;
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


namespace NodeNetwork.Toolkit.ContextMenu {
    
    
    /// <summary>
    /// SearchableContextMenuView
    /// </summary>
    public partial class SearchableContextMenuView : System.Windows.Controls.ContextMenu, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\ContextMenu\SearchableContextMenuView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal NodeNetwork.Toolkit.ContextMenu.SearchableContextMenuView self;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\ContextMenu\SearchableContextMenuView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem SearchMenuItem;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\ContextMenu\SearchableContextMenuView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\ContextMenu\SearchableContextMenuView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Data.CollectionContainer CollectionContainer;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\ContextMenu\SearchableContextMenuView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Data.CollectionContainer ContainerBelowSearch;
        
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
            System.Uri resourceLocater = new System.Uri("/NodeNetworkToolkit;component/contextmenu/searchablecontextmenuview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ContextMenu\SearchableContextMenuView.xaml"
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
            this.self = ((NodeNetwork.Toolkit.ContextMenu.SearchableContextMenuView)(target));
            return;
            case 2:
            this.SearchMenuItem = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 3:
            this.SearchTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CollectionContainer = ((System.Windows.Data.CollectionContainer)(target));
            return;
            case 5:
            this.ContainerBelowSearch = ((System.Windows.Data.CollectionContainer)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

