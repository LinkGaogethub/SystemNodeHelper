   M S B A M L   `   `   `  ���� F  BNodeNetwork, Version=6.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:NodeNetwork.ViewsNodeNetwork.Views  G(clr-namespace:NodeNetwork.Views.ControlsNodeNetwork.Views.Controls  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089-    'NodeNetwork.Views.PendingConnectionView  �� 
TargetType �� Property �� Value �� 
TargetType*   $NodeNetwork.Views.Controls.FillPanel'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup    ErrorVisualStatesGroup   Name   States   System.Windows.VisualState    
ErrorState	   Name
   
Storyboard g� Duration �� 
TargetName �� TargetProperty  System.Windows.Visibility   	Collapsed R� Value   Visible    NonErrorState F�Name J� IsHitTestVisible    RegularBrush    Geometry    
ErrorBrush�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     )viewsclr-namespace:NodeNetwork.Views  5controls(clr-namespace:NodeNetwork.Views.Controls  %S  '         �� "    .���  �@  RegularBrush �	#C8FFFFFF��  �@  
ErrorBrush �	#C8FF0000��  � ��$ False����  � �� �� "   .R�     # Z .   #	 Z .
 �� .��T� $ 0D�$ RegularPath��$ 
Visibility�..�i� # Z T� $ 0D�$ 	ErrorPath��$ 
Visibility�..�i� # Z   #	 Z .
 �� .��T� $ 0D�$ RegularPath��$ 
Visibility�..�i� # Z T� $ 0D�$ 	ErrorPath��$ 
Visibility�..�i� # Z .+�F� $ RegularPath��$��2��$ False��#��z #��z F� $ 	ErrorPath��$��2��$ False��#��z #��z 