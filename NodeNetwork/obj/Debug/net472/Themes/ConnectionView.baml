   M S B A M L   `   `   `  ����F  BNodeNetwork, Version=6.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:NodeNetwork.ViewsNodeNetwork.Views  5      G(clr-namespace:NodeNetwork.Views.ControlsNodeNetwork.Views.Controls  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089&     NodeNetwork.Views.ConnectionView  �� 
TargetType �� Property �� Value �� 
TargetType*   $NodeNetwork.Views.Controls.FillPanel'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup!    HighlightVisualStatesGroup   Name   States   System.Windows.VisualState    HighlightedState	   Name
   
Storyboard g� Duration �� 
TargetName �� TargetProperty  System.Windows.Visibility   Visible R� Value    NonHighlightedState   	Collapsed    ErrorVisualStatesGroup    
ErrorState    NonErrorState'     MarkedForDeleteVisualStatesGroup    MarkedForDeleteState    NotMarkedForDeleteState F�Name J� IsHitTestVisible    RegularBrush    Geometry    
ErrorBrush    MarkedForDeleteBrush    HighlightBrush�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      )viewsclr-namespace:NodeNetwork.Views  5      5controls(clr-namespace:NodeNetwork.Views.Controls  5      %�  '         �� 5      "    6   .�5   
   ��  �@  RegularBrush
 �����6)   �� 5   
    �@  
ErrorBrush
 �  ��6'   �� 5   
    �@  HighlightBrush
 � ���6+   �� 5	   
    �@  MarkedForDeleteBrush
 �  ��61   �� 5
   
    � ��$ False��6&   �� 5   
    � �� 5      �� 5      "   6"   .R�5         5        5      # Z 6/   . 5   "     #	 Z 6.   .
 5   &   �� .��5   *   T� $ 0D�6H   $ HighlightPath��6U   $ 
Visibility�6{   ..�5   .   i� # Z 6E   5   +   5   '   5   #     5   "   #	 Z 6.   .
 5   &   �� .��5   *   T� $ 0D�6H   $ HighlightPath��6U   $ 
Visibility�6{   ..�5   .   i� # Z 6E   5   +   5   '   5   #   5        5       # Z 6/   . 5!   "     #	 Z 6.   .
 5"   &   �� .��5#   *   T� $ 0D�6H   $ 	ErrorPath��6U   $ 
Visibility�6w   ..�5$   .   i� # Z 6E   5%   +   5&   '   5'   #     5(   "   #	 Z 6.   .
 5)   &   �� .��5*   *   T� $ 0D�6H   $ 	ErrorPath��6U   $ 
Visibility�6w   ..�5+   .   i� # Z 6E   5,   +   5-   '   5.   #   5/        50      # Z 6/   . 51   "     #	 Z 6.   .
 52   &   �� .��53   *   T� $ 0D�6H   $ DeleteMarkPath��6U   $ 
Visibility�6|   ..�54   .   i� # Z 6E   55   +   56   '   57   #     58   "   #	 Z 6.   .
 59   &   �� .��5:   *   T� $ 0D�6H   $ DeleteMarkPath��6U   $ 
Visibility�6|   ..�5;   .   i� # Z 6E   5<   +   5=   '   5>   #   5?      .+�5A      F� $ RegularPath��6   $��2��64   $ False��6H   #��z 6a   #��z 6�   F� 5B      $ 	ErrorPath��6   $��2��62   $ False��6F   #��z 6_   #��z 6�   F� 5C      $ DeleteMarkPath��6   $��2��67   $ False��6K   #��z 6d   #��z 6�   F� 5D      $ HighlightPath��6   $��2��66   $ False��6J   #��z 6c   #��z 6�   5E      5F      5H      5I      5J      