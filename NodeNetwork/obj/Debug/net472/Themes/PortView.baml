   M S B A M L   `   `   `  ����F  BNodeNetwork, Version=6.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:NodeNetwork.ViewsNodeNetwork.Views  5      G(clr-namespace:NodeNetwork.Views.ControlsNodeNetwork.Views.Controls  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089     NodeNetwork.Views.PortView  �� 
TargetType �� Property �� Value �� 
TargetType*   $NodeNetwork.Views.Controls.FillPanel'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup!    ConnectedVisualStatesGroup   Name   States   System.Windows.VisualState    ConnectedState	   Name
   
Storyboard g� Duration �� 
TargetName �� TargetProperty  System.Windows.Visibility   Visible R� Value    DisconnectedState   	Collapsed!    HighlightVisualStatesGroup    HighlightedState    NonHighlightedState    ErrorVisualStatesGroup    
ErrorState    NonErrorState    RegularStroke    RegularFill    ConnectedStroke    ConnectedFill    ErrorStroke    	ErrorFill    HighlightStroke    HighlightFill�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      )viewsclr-namespace:NodeNetwork.Views  5      5controls(clr-namespace:NodeNetwork.Views.Controls  5      %^  '         �� 5      "    6   .�5   
   ��  �@  RegularStroke �#9E9E9E6*   �� 5   
    �@  RegularFill �#E0E0E06(   �� 5   
    �@  ConnectedStroke �#AEAEAE6,   �� 5	   
    �@  ConnectedFill �#F0F0F06*   �� 5
   
    �@  HighlightStroke �	#30FFFFFF6,   �� 5   
    �@  HighlightFill �	#30FFFFFF6*   �� 5   
    �@  ErrorStroke �#F443366(   �� 5   
    �@  	ErrorFill �#FFCDD26&   �� 5   
    � ��$ False��6&   �� 5   
    � �� 5      �� 5      "   6"   .R�5         5        5      # Z 6/   . 5   "     #	 Z 6.   .
 5   &   �� .��5   *   T� $ 0D�6H   $ ConnectedEllipse��6V   $ 
Visibility�6   ..�5   .   i� # Z 6E   5   +   5   '   5   #     5   "   #	 Z 6.   .
 5   &   �� .��5   *   T� $ 0D�6H   $ ConnectedEllipse��6V   $ 
Visibility�6   ..�5   .   i� # Z 6E   5    +   5!   '   5"   #   5#        5$      # Z 6/   . 5%   "     #	 Z 6.   .
 5&   &   �� .��5'   *   T� $ 0D�6H   $ HighlightEllipse��6V   $ 
Visibility�6   ..�5(   .   i� # Z 6E   5)   +   5*   '   5+   #     5,   "   #	 Z 6.   .
 5-   &   �� .��5.   *   T� $ 0D�6H   $ HighlightEllipse��6V   $ 
Visibility�6   ..�5/   .   i� # Z 6E   50   +   51   '   52   #   53        54      # Z 6/   . 55   "     #	 Z 6.   .
 56   &   �� .��57   *   T� $ 0D�6H   $ ErrorEllipse��6U   $ 
Visibility�6z   ..�58   .   i� # Z 6E   59   +   5:   '   5;   #     5<   "   #	 Z 6.   .
 5=   &   �� .��5>   *   T� $ 0D�6H   $ ErrorEllipse��6U   $ 
Visibility�6z   ..�5?   .   i� # Z 6E   5@   +   5A   '   5B   #   5C      .+�5E      A� $��RegularEllipse��6"   $��2��68   #��z 6L   #��z 6u   A� 5F      $��ConnectedEllipse��6"   $��2��6:   #��z 6N   #��z 6y   A� 5G      $��ErrorEllipse��6"   $��2��66   #��z 6J   #��z 6q   A� 5H      $��HighlightEllipse��6"   $��2��6:   #��z 6N   #��z 6y   5I      5J      5L      5M      5N      