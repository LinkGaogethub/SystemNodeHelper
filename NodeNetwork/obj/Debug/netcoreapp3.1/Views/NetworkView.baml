   M S B A M L   `   `   `  ����F  BNodeNetwork, Version=6.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:NodeNetwork.ViewsNodeNetwork.Views  5      G(clr-namespace:NodeNetwork.Views.ControlsNodeNetwork.Views.Controls  5      ?$clr-namespace:NodeNetwork.ViewModelsNodeNetwork.ViewModels  5	      E'clr-namespace:NodeNetwork.Utilities.WPFNodeNetwork.Utilities.WPF  5
      #    NodeNetwork.Views.NetworkView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:NodeNetwork.Views     5      =controls(clr-namespace:NodeNetwork.Views.Controls     5      J FReactiveUI.Wpf, Version=13.2.0.0, Culture=neutral, PublicKeyToken=null&
reactiveUihttp://reactiveui.net  5      5
viewModels$clr-namespace:NodeNetwork.ViewModels  5	      1wpf'clr-namespace:NodeNetwork.Utilities.WPF  5
      -   5          >�Name$
  self��5   Y   $
|�True��67    J� 	AllowDrop$
 True��6H   ���#333 J� InputBindings 5      �� 5   
   -   5        deleteBinding��
 �� Key$ Delete��5   ,    � 	Resources 5      5   /NodeNetwork.Utilities.WPF.BoolToZIndexConverter   BoolToZIndexConverter��%   &	          5   
   6$   5      .��5      � $
|�True��6   -  'System.Windows.Input.KeyboardNavigation   	IsTabStop$ False��6   .+�5   
   +   %NodeNetwork.Views.Controls.DragCanvas  -   5          Name$ 
dragCanvas��5   7   +   %NodeNetwork.Views.Controls.DragCanvas   Zoom$ DragCanvas_OnZoom��6      MouseLeftButtonDown$ OnClickCanvas��6K   ���	#01000000.+�5      �� -   5        $��contentContainer��5      ��6^   �� *ActualWidth+	 �� ElementName$	 
dragCanvas����6�   �� *ActualHeight+$	 
dragCanvas��
 J� Clip
 5      �� 5      -   5        clippingGeometry��5   (   .+�5      �� -   5        $��backgroundCanvas��5       J� IsHitTestVisible$ False��61   $
��1E15��6J   $
��1E15��6W    �� Left$
 -1E6��6e   
 �� Top$
 -1E6��6x   ��6�   �� *NetworkBackground+$
	 self���� 5      -   5         ��Name$ connectionsControl��5      $��False��6�   ��6;   �� *ActualWidth+$	 contentContainer����6w   �� *ActualHeight+$	 contentContainer����5       �� 5!      .R�5"      >   8NodeNetwork.Views.Controls.ViewModelViewHostNoAnimations  $��Stretch=�6[   $��Stretch=�6�   $��False��6�   "  ReactiveUI.ViewModelViewHost   	ViewModel 6E   �� 6�   5#      ��5%      �� 5&      .R�5'      �� 6'   5(      5+      �� 5-      -   5        $ nodesControl��5-      $��False��6�   ��65   �� *ActualWidth+$	 contentContainer����6q   �� *ActualHeight+$	 contentContainer����5.      �� 5/       �� DataType$ viewModels:NodeViewModel��6'   .R�50      �� .+�52   "   n� -	   5         52   {   ��  �� Path$ 
Position.X� 6�   �� $ 
Position.Y���53   &   �� 54   *   .R�55   .     $��Stretch=�6k   $��Stretch=�6�   $��False��6�    6U   �� 6�   56   +   58   #   59      5:      ��5<      �� 5=       �� 
TargetType" ��6    �5>      �� 5?   "    �� Property �@K�ZIndex �� Value 6A   �� $ 
IsSelected� �� 	Converter# [  5A      5C      �� 5E      -
   5         ��Name$ cutLine��5E      
������� �� StrokeDashArray$
 2, 4R�6;   $��1��6R   �� 5G      -   5         ��Name$ selectionRectangle��5G      
�������
������ $
 2, 4R�6Z   $��1��6q     5I      -   5          Name$ pendingConnectionView��5I   9   $��Stretch=�6X   $��Stretch=�6}   $��False��6�     5K      -   5        $ pendingNodeView��5K   9    J� Opacity$	 0.5Q�6R   $��False��6`   5L      5M      � 5O   
   -   5         �Name$ messagePopup��5O      $	��Top=�6&    � 	StaysOpen$
 True��66   $��Right=�6G   .��5P        -   5        $��messagePopupHost��5P   +   $��False��6C   5Q      �� 5S   
   -   5        $��messageHostBorder��5S      ���#EEE �� CornerRadius$ 5��6<   $��Center=�6M   $	��Top=�6j    �� Padding$ 10, 10, 10, 10q�6�   $��20q�6�   ._�5T        -   5        $��messageHost��5T   +   $��False��6>   5U      5V      5W      