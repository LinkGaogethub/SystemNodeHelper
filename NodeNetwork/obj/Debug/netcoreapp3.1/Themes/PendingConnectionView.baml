   M S B A M L   `   `   `  ����F  BNodeNetwork, Version=6.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:NodeNetwork.ViewsNodeNetwork.Views  5      G(clr-namespace:NodeNetwork.Views.ControlsNodeNetwork.Views.Controls  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089-    'NodeNetwork.Views.PendingConnectionView  �� 
TargetType �� Property �� Value �� 
TargetType*   $NodeNetwork.Views.Controls.FillPanel'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup    ErrorVisualStatesGroup   Name   States   System.Windows.VisualState    
ErrorState	   Name
   
Storyboard g� Duration �� 
TargetName �� TargetProperty  System.Windows.Visibility   	Collapsed R� Value   Visible    NonErrorState F�Name J� IsHitTestVisible    RegularBrush    Geometry    
ErrorBrush�� 5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      )viewsclr-namespace:NodeNetwork.Views  5      5controls(clr-namespace:NodeNetwork.Views.Controls  5      %J  '         �� 5      "    6   .�5   
   ��  �@  RegularBrush �	#C8FFFFFF6)   �� 5   
    �@  
ErrorBrush �	#C8FF00006'   �� 5   
    � ��$ False��6&   �� 5	   
    � �� 5
      �� 5      "   6"   .R�5         5        5      # Z 6/   . 5   "     #	 Z 6.   .
 5   &   �� .��5   *   T� $ 0D�6H   $ RegularPath��6U   $ 
Visibility�6y   ..�5   .   i� # Z 6E   5   +   T� 5   *   $ 0D�6H   $ 	ErrorPath��6U   $ 
Visibility�6w   ..�5   .   i� # Z 6E   5   +   5   '   5   #     5   "   #	 Z 6.   .
 5   &   �� .��5   *   T� $ 0D�6H   $ RegularPath��6U   $ 
Visibility�6y   ..�5   .   i� # Z 6E   5   +   T� 5   *   $ 0D�6H   $ 	ErrorPath��6U   $ 
Visibility�6w   ..�5   .   i� # Z 6E   5    +   5!   '   5"   #   5#      .+�5%      F� $ RegularPath��6   $��2��64   $ False��6H   #��z 6a   #��z 6�   F� 5&      $ 	ErrorPath��6   $��2��62   $ False��6F   #��z 6_   #��z 6�   5'      5(      5*      5+      5,      