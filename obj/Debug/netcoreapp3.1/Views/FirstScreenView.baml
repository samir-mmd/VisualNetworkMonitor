   M S B A M L   `   `   `  ����Q  MVisual Network Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:VNM2020.ViewsVNM2020.Views  5      /clr-namespace:VNM2020.ModelsVNM2020.Models  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
      3clr-namespace:VNM2020.ServicesVNM2020.Services  5      #    VNM2020.Views.FirstScreenView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      'localclr-namespace:VNM2020.Views  5      (modelclr-namespace:VNM2020.Models  5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
      (serclr-namespace:VNM2020.Services  5        � 	Resources  5       �� Source�� 5   
   $% ../Resources/DataTemplates.xaml?�6   %    .��5      �  � ColumnDefinitions 5   
   �� 5      $	��280 �6   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��1��6   .��5      �� .��5      �� .+�5       R� -   5         R�Name$ mainTree��5        $��Stretch=�62      CategoryListTemplate#��[  5!   =     CategoryListItem#��[ 6r   ��6   �� *CategoryView+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5"      +  %Microsoft.Xaml.Behaviors.EventTrigger  5#         	EventName$ SelectedItemChanged��6-   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5$   "   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 69   �� *MainTreeSelectionCommand+	   CommandParameter	 6f   �� 
 �� ElementName$
 mainTree��5%      5'      �� 5(      $��2q�6   $��+��6(   ���	#19000000 � ToolTip$ Add New Category��6x   ��64   �� *AddCategoryDialogCommand+6x   5)      5*      5+      ]� 5,   
   $��2��6   .+�5-      �� $	��≡��6   $��4,-1,4,0q�6I   
������ $��27��6w   $��20(�6�   $ Settings��6�   ��6!   �� *OpenSettingsCommand+6�   �� 5.      $����6   $��webdings)�6!   $	��4,0q�6`   
������ $��27��6�   $	 Log��6�   ��67   �� *OpenLogWindowCommand+6�   d� 5/      $��Bottom=�68    � Cursor$
 Hand��6W     OkStatusColor#��[ 6g    d� 	IsChecked 6   �� *Okbox+z�50      V� 51      .~�52      ��  �� ScaleX$	 0.7Q�6)    �� ScaleY$	 0.7Q�66   53      55      d� 56      $��Bottom=�69   $
 Hand��6U     HoldStatusColor#��[ 6d    6   �� *	Holdbox+z�57      V� 58      .~�59      �� $	 0.7Q�6)   $	 0.7Q�66   5:      5<      d� 5=      $��Bottom=�6;   $
 Hand��6W     PausedStatusColor#��[ 6g    6   �� *
Pausebox+z�5>      V� 5?      .~�5@      �� $	 0.7Q�6)   $	 0.7Q�66   5A      5C      d� 5D      $��Bottom=�6:   $
 Hand��6W     ErrorStatusColor#��[ 6f    6   �� *
Errorbox+z�5E      V� 5F      .~�5G      �� $	 0.7Q�6)   $	 0.7Q�66   5H      5J      �� 5K      $	��2,1q�6`   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search��6m      HintOpacity$	 0.3Q�6�      
IsFloating$ False��6�   $��Bottom=�6�   ��6   �� *Search+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6	   5L        5M      $ TextChanged��6%   . 5N         60   �� *SearchCommand+5O      .��5P   *   5Q      5R      9� 5S   
    9� ExpandDirection$ Right=�6   $��1��6+   $��3��6;     DarkGray100#��[ 6L   $��2q�6v   .��5T      � $	��410��6    5U      �� 5V      $
��auto �6$   �� 5W      $
��auto �6$   �� 5X      $
��auto �6$   �� 5Y      $
��auto �6$   �� 5Z      $
��auto �6$   �� 5[      $
��auto �6$   �� 5\      $
��auto �6$   �� 5]      $
��auto �6$   �� 5^      $
��auto �6$   �� 5_      $
��auto �6$   .+�5c      ]� $��Stretch=�6   .+�5d      �� $	��200��6   $��Bottom=�6*   $��5q�6f   $ 	Host Name��6q   ��6G   �� *Selected.Name+6q   �� 5e      $��5q�6   $��Try Get DNS Name��6)   $��Bottom=�6n   ��6D   �� *GetHostDNSNameCommand+6n   5f      ]� 5h      $��1��6   .+�5i      �� $	��200��6   $��Center=�6+   $��5q�6i   $ Address��6t   ��6G   �� *Selected.Address+6t   �� 5j      $��5q�6   $��Bottom=�6I   
�������$ Physical��6w   ��6*   �� *Selected.Mac+6w   5k      ]� 5m      $��2��6   .+�5n      �� $	��200��6   $��Center=�6+   $��5q�6m   $" Notify To (Empty if Default)��6x   ��6G   �� *Selected.MailAddress+6x   �� 5o      $��5,0,0,5q�6!   $��Enable Notifications��62   $
��Left=�6N   $��Bottom=�6i   
�������6�   d� 5p      $	��5,5q�6L   $
��Left=�6Y   $��Bottom=�6t    6$   �� *Selected.Mailable+6t   5q      �� 5s      $��3��6   $��Center=�6'   $��5q�6c   $ Notes��6n   ��6C   �� *Selected.Notes+6n   �� 5u      $��4��6   $��5q�6)   $��Update Interval��64   $
��Left=�6K   $��Center=�6f   
�������6�   ]� 5v      $��5��6   .+�5w      �� $��5q�6    $��20��6M   $��Center=�6X   $��Right=�6s   
���������6+   �� *Selected.Seconds+6�   �� 5x      $��Bottom=�6    � Maximum$	 300Q�68    � Minimum$ 0Q�6F   $��5q�6u    �� IsSnapToTickEnabled$
 True��6�    �� TickFrequency$ 10Q�6�    � Value 6R   �� *Selected.Seconds+6�   5y      �� 5|      $��6��6   $��5q�6)   $��Category��64   $
��Left=�6D   $��Center=�6_   
�������6z   ]� 5}      $��7��6   .+�5~      �� $	��Set��6   $��Right=�6+   $��Right=�6G   $��5q�6�   ��6^   �� *SetCategoryCommand+6�   �� 5      $��Stretch=�6     �� DisplayMemberPath$
 Name��6�   $��5q�6�   
���������6E   �� *
Categories+ �� SelectedItem 6h   �� *SelectedHostCategory+6�   5�      �� 5�      $��8��6   $
��Auto=�6,   $��Hidden=�6Q   $��0,2,5,2q�6v   .��5�      �� $��8��6$    J� RenderTransformOrigin$ 0.5,0.5&�5�   /   $��RightToLeft=�5�   /   ��5�   2   �� *Selected.Actions+z�5�      V� 5�      .~�5�   "   �� $ -1Q�61   $ 1Q�6=   �� 5�   "    �� AngleY$ 0Q�60    �� AngleX$ 0Q�6;   �� 5�   "     �� Angle$  0Q�62   T� 5�   "   5�      ��5�      �� 5�      .R�5�   "   �� $	��200��6R   $
}�True��6a   $	��150��6u   ���	#FF151515$��Stretch=�6�   $��Stretch=�6�   ��6)   �� *Selected.Actions.Count+! � LayoutTransform! 5�   &   �� 5�   *   $ 2Q�69   $ 2Q�6E   5�   #   5�      ��5�      �� 5�      .R�5�   "   � $��Center=�6'   .+�5�   &   �� $	��150��60   $��1��6=   $	��Top=�6G   $��Right=�6_    5�   *     5�   .   $ 
MouseEnter��6=   . 5�   2      6I   �� *DataContext.ShowTipCommand+" �� RelativeSource" �� *FindAncestor+# �� AncestorType"# >�	 6�   �� *	ToolTip+5�   /     5�   .   $ 
MouseLeave��6=   . 5�   2      6I   �� *DataContext.ClearTipCommand+" �� *FindAncestor+"# >�5�   /   ��5�   *   �� 5�   .   $ �� 
TargetType"$ ��64   .�5�   2   �� % �� Property% � ��& �� Value#& [ 6I   ' �� Triggers' 5�   2   �� 5�   6   ( �� Binding( 6B   �� *Status+) �� Value) Success6]   .a�5�   :   �� % � ��#& [ 6Q   5�   7   �� 5�   6   ( 6B   �� *Status+) TimedOut6]   .a�5�   :   �� % � ��#& [ 6Q   5�   7   �� 5�   6   ( 6B   �� *Status+) Network Error6]   .a�5�   :   �� % � ��  NetworkErrorStatusColor#& [ 6Q   5�   7   P� 5�   6   * P� Property* �@J�IsMouseOver+ P� Value$+ False��6U   . �5�   :   �� % �@J�Opacity$& 0Q�6^   5�   7   P� 5�   6   * �@J�IsMouseOver$
+ True��6U   . �5�   :   �� % �@J�Opacity$	& 0.3Q�6^   5�   7   5�   /   5�   '   �� 5�   &   $	��0.4��6+   , �� StrokeEndLineCap$, Triangle=�6B   - �� StrokeLineJoin$- Round=�6^   	. �� X1. 6u   �� *Count+	/ �� X2/ 6�   �� *	PrevCount+	0 �� Y10 6�   �� *Reply+	1 �� Y21 6�   �� *	PrevReply+ 6�   �� *	ToolTip+��5�   *   �� 5�   .   "$ ��64   .�5�   2   �� % � ��#& [ 6K   ' 5�   2   �� 5�   6   ( 6B   �� *Status+) Success6]   .a�5�   :   �� % � ��#& [ 6S   5�   7   �� 5�   6   ( 6B   �� *Status+) TimedOut6]   .a�5�   :   �� % � ��#& [ 6S   5�   7   �� 5�   6   ( 6B   �� *Status+) Network Error6]   .a�5�   :   �� % � ��#& [ 6S   5�   7   5�   /   5�   '   5�   #   5�      5�      5�      �� 5�      $��10q�6   
�������$��8��6W   $��Right=�6d   $	��Top=�6�   ��6?   �� *TipBox+6�   a� 5�      2 �� Orientation$2 
Horizontal=�6   $��9��68   $��2q�6E   .+�5�      �� $��2q�6   $��Remove��6(   $��6q�69     AttentionButtonStyle#��[ 6l   ��6F   �� *RemoveHostCommand+6l   �� 5�      $��2q�6   $��Reset Parent��6(   $��6q�6?   ��6K   �� *ResetFatherCommand+�� 5�      $��2q�6   $��Reset Position��6(   $��6q�6A   ��6M   �� *ResetPositionCommand+�� 5�      $��2q�6   $��Manual Ping��6(   $��6q�6>   ��6J   �� *PingHostCommand+5�      5�      5�      �� 5�   
   -   5        3 ��Name$3 	MapViewer��5�   �   $��2��6   $��3��6'   
������ $��Hidden=�6S   $��Hidden=�6z   .��5�      �� -   5        $��	MapCanvas��5�   )   $
}�True��6   !  VNM2020.Services.DragEngine4   Drag$
4 True��6:   $��Center=�6�   $��Center=�6�   ��6U   �� *ActualHeight+$
 MainMap����6�   �� *ActualWidth+$
 MainMap��! 5�      �� 5�       6%   �� *	Mapzoom+ 6A   �� *	Mapzoom+.+�5�      �� -   5        5 ��Name$5 MainMap��5�   &   $��10000��6   $
��Left=�6T   $	��Top=�6o   ��67   �� *
MapImage+6 J� Opacity6 6�   �� *
Mapopacity+�� 5�      
������ $��Center=�6Z   $��Center=�6w   $��Center=�6�   $��Center=�6�    	 MapItemsTemplate#��� 	 6�   ��6    �� *
AllHosts+6�   5�      5�      � 5�   
   $��3��6   $��4��6#   ���	#66000000y�6K   �� *WaitingVisibility+.+�5�      �� $	��200��6   $��/Resources/vnmlogo.png��6    7 � Triggers7 5�      :� 5�      8 :� RoutedEvent$8 Loaded��6#   .[�5�      �� .��5�      �� .��5�   "   W� 9 �� TargetProperty$9 Opacity�62   : W� From: 0.26V   	; W� To; 16a   < g� 	BeginTime	< 0:0:06h   = g� Duration$= 0:0:.450D�6z   > g� AutoReverse$
> True��6�   ? g� RepeatBehavior$? Forever��6�   5�      5�      5�      5�      5�      5�      5�      