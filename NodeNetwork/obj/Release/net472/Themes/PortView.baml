   M S B A M L   `   `   `  ���� F  BNodeNetwork, Version=6.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:NodeNetwork.ViewsNodeNetwork.Views  G(clr-namespace:NodeNetwork.Views.ControlsNodeNetwork.Views.Controls  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089     NodeNetwork.Views.PortView  �� 
TargetType �� Property �� Value �� 
TargetType*   $NodeNetwork.Views.Controls.FillPanel'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup!    ConnectedVisualStatesGroup   Name   States   System.Windows.VisualState    ConnectedState	   Name
   
Storyboard g� Duration �� 
TargetName �� TargetProperty  System.Windows.Visibility   Visible R� Value    DisconnectedState   	Collapsed!    HighlightVisualStatesGroup    HighlightedState    NonHighlightedState    ErrorVisualStatesGroup    
ErrorState    NonErrorState    RegularStroke    RegularFill    ConnectedStroke    ConnectedFill    ErrorStroke    	ErrorFill    HighlightStroke    HighlightFill�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     )viewsclr-namespace:NodeNetwork.Views  5controls(clr-namespace:NodeNetwork.Views.Controls  %�  '         �� "    .���  �@  RegularStroke �#9E9E9E��  �@  RegularFill �#E0E0E0��  �@  ConnectedStroke �#AEAEAE��  �@  ConnectedFill �#F0F0F0��  �@  HighlightStroke �	#30FFFFFF��  �@  HighlightFill �	#30FFFFFF��  �@  ErrorStroke �#F44336��  �@  	ErrorFill �#FFCDD2��  � ��$ False����  � �� �� "   .R�     # Z .   #	 Z .
 �� .��T� $ 0D�$ ConnectedEllipse��$ 
Visibility�..�i� # Z   #	 Z .
 �� .��T� $ 0D�$ ConnectedEllipse��$ 
Visibility�..�i� # Z   # Z .   #	 Z .
 �� .��T� $ 0D�$ HighlightEllipse��$ 
Visibility�..�i� # Z   #	 Z .
 �� .��T� $ 0D�$ HighlightEllipse��$ 
Visibility�..�i� # Z   # Z .   #	 Z .
 �� .��T� $ 0D�$ ErrorEllipse��$ 
Visibility�..�i� # Z   #	 Z .
 �� .��T� $ 0D�$ ErrorEllipse��$ 
Visibility�..�i� # Z .+�A� $��RegularEllipse��$��2��#��z #��z A� $��ConnectedEllipse��$��2��#��z #��z A� $��ErrorEllipse��$��2��#��z #��z A� $��HighlightEllipse��$��2��#��z #��z 