   M S B A M L   `   `   `  ����  NodeNetworkToolkitM    GNodeNetwork.Toolkit.Group.AddEndpointDropPanel.AddEndpointDropPanelView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          >�Name$
  Self��5   7    � 	Resources 5          BooleanToVisibilityConverter��%   &	        �� 5	   
   6'   5
      .��5      � $
��Auto��6   $��40��6   y�5      �� *IsDropZoneVisible+ �� 	Converter# [  ��5   
   �� 5       �� 
TargetType" �6   .�5      ��  �� Property � �� �� Value
 ���� 6/    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value$
 True��65   	 N� EnterActions	 5      �� 5      .��5   "   �� .��5   &   �� 
 �� TargetProperty$/
 )(Grid.Background).(SolidColorBrush.Color)�65   	 �� To 	#44FFFFFF6{    g� Duration$ 0:0:0.1D�6�   5   #   5       N� ExitActions 5      �� 5      .��5   "   �� .��5   &   �� $/
 )(Grid.Background).(SolidColorBrush.Color)�65    Transparent6{   $ 0:0:0.1D�6�   5   #   5      5       5"      .+�5$   
   �� ���#fff$��2��6"    �� StrokeDashArray$	 4 4R�66    J� SnapsToDevicePixels$
 True��6L   �� 5%   
   $��Center=�6D    �� TextAlignment$ Center=�6_   $��14(�6v   $��	15,5,15,5q�6�   ��6   �� *DropHintText+ �� ElementName$
 Self��6�   5&      5'      