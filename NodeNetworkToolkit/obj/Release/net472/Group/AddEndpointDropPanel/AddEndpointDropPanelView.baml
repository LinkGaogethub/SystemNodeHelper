   M S B A M L   `   `   `  ����   NodeNetworkToolkitM    GNodeNetwork.Toolkit.Group.AddEndpointDropPanel.AddEndpointDropPanelView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -     >�Name$
  Self�� � 	Resources     BooleanToVisibilityConverter��%   &	        �� .��� $
��Auto��$��40��y��� *IsDropZoneVisible+ �� 	Converter# [  ����  �� 
TargetType" �.���  �� Property � �� �� Value
 ����  �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��	 N� EnterActions	 �� .���� .���� 
 �� TargetProperty$/
 )(Grid.Background).(SolidColorBrush.Color)�	 �� To 	#44FFFFFF g� Duration$ 0:0:0.1D� N� ExitActions �� .���� .���� $/
 )(Grid.Background).(SolidColorBrush.Color)� Transparent$ 0:0:0.1D�.+��� ���#fff$��2�� �� StrokeDashArray$	 4 4R� J� SnapsToDevicePixels$
 True���� $��Center=� �� TextAlignment$ Center=�$��14(�$��	15,5,15,5q����� *DropHintText+ �� ElementName$
 Self��