   M S B A M L   `   `   `  ���� F  BNodeNetwork, Version=6.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:NodeNetwork.ViewsNodeNetwork.Views  G(clr-namespace:NodeNetwork.Views.ControlsNodeNetwork.Views.Controls  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089&     NodeNetwork.Views.ConnectionView  �� 
TargetType �� Property �� Value �� 
TargetType*   $NodeNetwork.Views.Controls.FillPanel'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup!    HighlightVisualStatesGroup   Name   States   System.Windows.VisualState    HighlightedState	   Name
   
Storyboard g� Duration �� 
TargetName �� TargetProperty  System.Windows.Visibility   Visible R� Value    NonHighlightedState   	Collapsed    ErrorVisualStatesGroup    
ErrorState    NonErrorState'     MarkedForDeleteVisualStatesGroup    MarkedForDeleteState    NotMarkedForDeleteState F�Name J� IsHitTestVisible    RegularBrush    Geometry    
ErrorBrush    MarkedForDeleteBrush    HighlightBrush�� H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     )viewsclr-namespace:NodeNetwork.Views  5controls(clr-namespace:NodeNetwork.Views.Controls  %  '         �� "    .���  �@  RegularBrush
 �������  �@  
ErrorBrush
 �  ����  �@  HighlightBrush
 � �����  �@  MarkedForDeleteBrush
 �  ����  � ��$ False����  � �� �� "   .R�     # Z .   #	 Z .
 �� .��T� $ 0D�$ HighlightPath��$ 
Visibility�..�i� # Z   #	 Z .
 �� .��T� $ 0D�$ HighlightPath��$ 
Visibility�..�i� # Z   # Z .   #	 Z .
 �� .��T� $ 0D�$ 	ErrorPath��$ 
Visibility�..�i� # Z   #	 Z .
 �� .��T� $ 0D�$ 	ErrorPath��$ 
Visibility�..�i� # Z   # Z .   #	 Z .
 �� .��T� $ 0D�$ DeleteMarkPath��$ 
Visibility�..�i� # Z   #	 Z .
 �� .��T� $ 0D�$ DeleteMarkPath��$ 
Visibility�..�i� # Z .+�F� $ RegularPath��$��2��$ False��#��z #��z F� $ 	ErrorPath��$��2��$ False��#��z #��z F� $ DeleteMarkPath��$��2��$ False��#��z #��z F� $ HighlightPath��$��2��$ False��#��z #��z 