   M S B A M L   `   `   `  ���� F  BNodeNetwork, Version=6.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:NodeNetwork.Views.ControlsNodeNetwork.Views.Controls  >    8NodeNetwork.Views.Controls.ViewModelViewHostNoAnimations   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:NodeNetwork.Views.Controls     J FReactiveUI.Wpf, Version=13.2.0.0, Culture=neutral, PublicKeyToken=null&
reactiveUihttp://reactiveui.net  ����   �� 
TargetType,  &ReactiveUI.TransitioningContentControl"   .���  �� Property � �� �� Value ��  �� 
TargetType"  .R��  �Name$ PART_Container��#��z��#��z��'  !System.Windows.VisualStateManager   VisualStateGroups %  System.Windows.VisualStateGroup  PresentationStates��   States.    System.Windows.VisualState  
Normal��   
Storyboard. �� .��T�  g� 	BeginTime 00:00:00	 �� 
TargetName$*	 $PART_PreviousContentPresentationSite��
 �� TargetProperty$
 (UIElement.Visibility)�..�i�  R� KeyTime$ 00:00:00�� R� Value   System.Windows.Visibility 	Collapsed=�  Transition_Fade��. �� .��W�  00:00:00 g� Duration$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$
 (UIElement.Opacity)� W� From 1	 W� To 0W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$
 (UIElement.Opacity)� 0 1  Transition_SlideLeft��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)� -30 0  Transition_SlideRight��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)� -30 0  Transition_SlideDown��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)� -30 0  Transition_SlideUp��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)� -30 0  Transition_MoveLeft��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)� -30 0W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)� 0 30  Transition_MoveRight��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)� -30 0W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)� 0 30  Transition_MoveDown��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)� -30 0W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)� 0 30  Transition_MoveUp��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)� -30 0W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)� 0 30  Transition_DropDown��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)� -30 0W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)� 0 30W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$
 (UIElement.Opacity)� 0 1W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$
 (UIElement.Opacity)� 1 0  Transition_DropUp��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)� 0 30W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)� -30 0W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$
 (UIElement.Opacity)� 0 1W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$
 (UIElement.Opacity)� 1 0  Transition_DropRight��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)� -30 0W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)� 0 30W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$
 (UIElement.Opacity)� 0 1W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$
 (UIElement.Opacity)� 1 0  Transition_DropLeft��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)� -30 0W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)� 0 30W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$
 (UIElement.Opacity)� 0 1W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$
 (UIElement.Opacity)� 1 0  Transition_BounceLeftIn��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)� -90 0W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$
 (UIElement.Opacity)� 0 1T� $*	 $PART_PreviousContentPresentationSite��$
 (UIElement.Visibility)�..�i� $ 00:00:00��  	Collapsed=�  Transition_BounceLeftOut��. �� .��W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)� 0 -90T� $)	 #PART_CurrentContentPresentationSite��$
 (UIElement.Visibility)�..�i� $ 00:00:00��  	Collapsed=�  Transition_BounceRightIn��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)� -90 0W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$
 (UIElement.Opacity)� 0 1T� $*	 $PART_PreviousContentPresentationSite��$
 (UIElement.Visibility)�..�i� $ 00:00:00��  	Collapsed=�  Transition_BounceRightOut��. �� .��W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.X)� 0 -90T� $)	 #PART_CurrentContentPresentationSite��$
 (UIElement.Visibility)�..�i� $ 00:00:00��  	Collapsed=�  Transition_BounceUpIn��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)� -90 0W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$
 (UIElement.Opacity)� 0 1T� $*	 $PART_PreviousContentPresentationSite��$
 (UIElement.Visibility)�..�i� $ 00:00:00��  	Collapsed=�  Transition_BounceUpOut��. �� .��W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)� 0 -90T� $)	 #PART_CurrentContentPresentationSite��$
 (UIElement.Visibility)�..�i� $ 00:00:00��  	Collapsed=�  Transition_BounceDownIn��. �� .��W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)� -90 0W�  00:00:00$ 00:00:00D�$)	 #PART_CurrentContentPresentationSite��$
 (UIElement.Opacity)� 0 1T� $*	 $PART_PreviousContentPresentationSite��$
 (UIElement.Visibility)�..�i� $ 00:00:00��  	Collapsed=�  Transition_BounceDownOut��. �� .��W�  00:00:00$ 00:00:00D�$*	 $PART_PreviousContentPresentationSite��$U
 O(UIElement.RenderTransform).(TransformGroup.Children)[1].(TranslateTransform.Y)� 0 -90T� $)	 #PART_CurrentContentPresentationSite��$
 (UIElement.Visibility)�..�i� $ 00:00:00��  	Collapsed=�.+���  ��Name$* $PART_PreviousContentPresentationSite��#��z��#��z��#��z����Z� z�V� ~���  �� ScaleX$ 1Q� �� ScaleY$ 1Q�T�  T� X$ 0Q� T� Y$ 0Q��� $) #PART_CurrentContentPresentationSite��#��z��#��z��#��z����Z� z�V� ~��� $ 1Q�$ 1Q�T� $ 0Q�$ 0Q�