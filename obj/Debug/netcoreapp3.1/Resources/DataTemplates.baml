   M S B A M L   `   `   `  ����Q  MVisual Network Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:VNM2020.ViewModelsVNM2020.ViewModels  5      -clr-namespace:VNM2020.ViewsVNM2020.Views  5      3clr-namespace:VNM2020.ServicesVNM2020.Services  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089_ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3ab ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962a  �� MergedDictionaries �� Source �� DataType-   'VNM2020.ViewModels.FirstScreenViewModel#   VNM2020.Views.FirstScreenView)  #VNM2020.ViewModels.AddHostViewModel   VNM2020.Views.AddHostView-  'VNM2020.ViewModels.AddCategoryViewModel#   VNM2020.Views.AddCategoryView.  (VNM2020.ViewModels.EditCategoryViewModel$   VNM2020.Views.EditCategoryView*  $VNM2020.ViewModels.SettingsViewModel 	   VNM2020.Views.SettingsView+
  %VNM2020.ViewModels.LogScreenViewModel!   VNM2020.Views.LogScreenView   BorderLightBlueColor �� Color  DarkGray100  
MiddleGray  CoreGray100  
CoreGray50  CategoryColor  OkStatusColor  HoldStatusColor  PausedStatusColor 	 ErrorStatusColor 
 NewStatusColor  NetworkErrorStatusColor  DoneLogColor  ExceptionLogColor  OnlineLogColor  OfflineLogColor(  "System.Windows.Controls.DatePicker �� 
TargetType �� BasedOn �� 	Resources:  4System.Windows.Controls.Primitives.DatePickerTextBox �� Property �� Value	 �� 
TargetType
 � 	Resources  Key'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   Transitions%  System.Windows.VisualTransition   GeneratedDuration	   To   States   System.Windows.VisualState   
Storyboard g� Duration	 �� To �� TargetProperty �� 
TargetName	 W� To ��Name �� CornerRadius J� Opacity �� Padding �Name ��Name J� IsHitTestVisible ��Name  MaterialDesignPaper # MaterialDesignToolTipBackground,  &MaterialDesignThemes.Wpf.ToolTipAssist#   CustomPopupPlacementCallback ��Name  �� ContentStringFormat! �� ContentStringFormat  validationFailed  RangeListItem" �� Triggers# �� Binding$ �� Value  RangeListTemplate#  MaterialDesignThemes.Wpf.Card%   UniformCornerRadius   MaterialDesignBody2TextBlock& �� StringFormat  MaterialDesignTextBox)  #MaterialDesignThemes.Wpf.HintAssist' P� Property( P� Value) �� RelativeSource* �� Path  AttentionButtonStyle " MaterialDesignFlatDarkBgButton  MapRectangleStyle  CategoryListItem  MaterialDesignTreeViewItem+ �� Mode, ^� 
Conditions- �� Binding. �� Value/ �� AncestorType  CategoryListTemplate0 �� ItemsSource1 j� Stretch2 �� ImageSource3 �� Opacity4 � ColumnDefinitions*  $Microsoft.Xaml.Behaviors.Interaction5   Triggers+  %Microsoft.Xaml.Behaviors.EventTrigger6   	EventName*  $Microsoft.Xaml.Behaviors.TriggerBase7   Actions2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction8   Command9   CommandParameter: j� TileMode; �� ItemTemplate< � RowDefinitions= � ToolTip> �� TextAlignment  MapItemsTemplate? ��Name@ J� RenderTransformOrigin!  VNM2020.Services.DragEngineA   Drag	B �� X1	C �� X2	D �� Y1	E �� Y2F �� Left
G �� TopH �� ScaleXI �� ScaleYJ � TriggersK :� RoutedEventL W� FromM g� AutoReverseN g� 	BeginTimeO g� RepeatBehavior  PrimaryHueMidBrush   CategoryList�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      'vm clr-namespace:VNM2020.ViewModels  5      !vclr-namespace:VNM2020.Views  5      $sclr-namespace:VNM2020.Services  5      3i+http://schemas.microsoft.com/xaml/behaviors  5      FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5        5
      �� 5   
   $d ^pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml?�6   �� 5   
   $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6   �� 5   
   $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6   �� 5   
   $r lpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Red.xaml?�6   �� 5   
   $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�6   %11  (��       5      *,  +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *, +)(�� �     5!      *,
 +)&	  ,    &	 O    &	 r    &	 �    &	 �    &	 �    &	 �    &	 !    &	 D    &		 g    &	
 �    &	 �    &	 �    &	 �    &	     &	 9    '  \    7 7  7  '_�     &	 �    &	 �    &	 �    '��     7  &	 �    7  7  '�� ,    7  7  &	 �    7  7  7 	 7  7  7 
 &	 @    7  &	     7  7  &	 "    7  7  7 	 7  7  7 
 7  7  &	  �.    �� 5      "   6   .R�5   
     5      �� 5      "  6   .R�5   
     5      �� 5      "  6   .R�5   
     5      �� 5      "  6   .R�5   
     5      �� 5      "  6   .R�5   
   	  5       �� 5!      " 
 6   .R�5"   
     5#      �� 5%      $ 	#FF4E8FC5��63   �� 5&      $ 	#FF1F1F1F��6*   �� 5'      $ 	#FF2C2C2C��6)   �� 5(      $ 	#FF494949��6*   �� 5)      $ 	#7F494949��6)   �� 5*      $ 	#FF252525��6,   �� 5+      $ 	#FF71FB71��6,   �� 5,      $ 	#FFFF8735��6.   �� 5-      $ 	#FFF8FF77��60   �� 5.      $ 	#FFFF2525��6/   �� 5/      $ 	#FF6AEFF5��6-   �� 50      $ 	#FF5B77FB��66   �� 51      $ 	#FF1D4B47��6+   �� 52      $ 	#FF633F1B��60   �� 53      $ 	#FF1D851D��6-   �� 54      $ 	#FF701D1D��6.   �� 56      "  6   8    57   
   ���� 58      '        "  6   .�59      ��  � ��
 ���� 6/   �� 5:       � ��8  6/   �� 5;       � ��$ Center=�66   �� 5<       �@��PanningMode$ VerticalFirst=�6=   �� 5=       �@��IsFlicksEnabled$ False��6;   �� 5>       � �� 5?      �� 5@      "	  6*   .R�5A      � 
 5B   "   ���� 5C   &   WatermarkBrush $ 	#FFAAAAAA��6M   5D   #    5E   "     5F   &   CommonStates�� 5G   *     5H   .   $ 0D�6?     5I   .   $ 0:0:0.1D�6?   $ 	MouseOver��6[   . 5K   *     
Normal��66     5L   *   	MouseOver��. 5M   .   �� .��5N   2   �� $ 0D�6A    Red6N   $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6W   $ ContentElement��6�   �� 5O   2   $ 0D�6A    Red6N   $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6W   $ watermark_decorator��6�   5P   /   5Q   +   5R   '     5S   &   WatermarkStates�� 5T   *     5U   .   $ 0D�6?   . 5W   *     Unwatermarked��66     5X   *   Watermarked��. 5Y   .   �� .��5Z   2   W� $ 0D�6B    06O   $ Opacity�6V   $ ContentElement��6z   W� 5[   2   $ 0D�6B    16O   $ Opacity�6V   $ PART_Watermark��6z   5\   /   5]   +   5^   '     5_   &   FocusStates�� 5`   *     5a   .   $ 0D�6?   . 5c   *     	Unfocused��66     5d   *   Focused��. 5e   .   �� .��5f   2   W� $ 0D�6B    16O   $ Opacity�6V   $ FocusVisual��6z   5g   /   5h   +   5i   '   .+�5k   "   �� $ Border��6)   #��z��69   #��z��6e   #��z��6�   $ 1��6�   $ 1Q�6�   # z��6�   ._�5l   &   � $ WatermarkContent��6+   #��z��6E   #��z��6�   .+�5m   *   �� $ ContentElement��61   ���	#FFFFFFFF$��1q�6a   $y�Hidden=�6u   �� 5n   *   $ watermark_decorator��61   ���	#FFFFFFFF$��1q�6f   $y�Hidden=�6z   ._�5o   .   �� $ PART_Watermark��6=   $|�False��6U   $ False��6g   $ 0Q�6�   $��2q�6�   5p   +   �� 5q   *   $ PART_ContentHost��67   #��z��6Q   $��0q�6�   #��z��6�   �� 5r   *   $ FocusVisual��61   ���	#FF45D6FA$ 1��6^   $ False��6o   $ 0Q�6�   5s   '   5t   #   5u      5v      5x      5y      5z      .�5{   
   ��  � ��$	 2,0q�6#   �� 5|   
    � ��$ Center=�65   �� 5}   
    � ��8  6'   �� 5~   
    � ��
 ���� 6'   �� 5   
    � ��$ 0q�6,   5�      �� 5�      " _�6   .�5�   
   ��  � ��# �  6'   �� 5�   
    � ��# �  6'   �� 5�   
    � ��$ 8q�6$   �� 5�   
    �@_�	Placement$ Mouse=�6&   �� 5�   
    �@_�	StaysOpen$
 True��6&   �� 5�   
    �@^�BetweenShowDelay$ 0��6<   �� 5�   
    �@^�InitialShowDelay$ 0��6<   �� 5�   
    �@^�ShowDuration$
 5000��68   �� 5�   
   $ �@_�CustomPopupPlacementCallback# Z 69   �� 5�   
    � �� 5�      �� 5�      "	 _�6"   .R�5�      �� #��z��6   $ 2��6G   #��z��6X   ._�5�      �� $ ContentPresenter��6+   #��z��5�   +   #��z��5�   +   #��z��6^   #! z  6�   5�      5�      5�      5�      5�      �� 5�      5�      �� 5�      " ��6"   " 5�   
   �� 5�      # 6   �� *Status+	$ Error65   .a�5�      ��  � y�$ 	Collapsed=�6/   5�      �� 5�      # 6   �� *Status+$ New65   .a�5�      ��  � y�$ Hidden=�6/   5�      5�      �� 5�      .R�5�   
     $% 3Q�6   $��3q�66   .��5�      �� .+�5�      �� $	��5,2q�6   #���  6V   ��6)   �� *Name+$& 	Name: {0}��6V   �� 5�      $	��5,2q�6   #���  6\   ��6)   �� *	Address+$& Address: {0}��6\   5�      5�      5�      �� 5�      " ��6   8   .�5�   
   ��  �@ 
IsFloating$
 True��6A   �� 5�   
    �@ FloatingScale$	 1.1Q�6D   �� 5�   
    � �� �	#FFDADADA6'   " 5�   
   P� 5�      ' �@=�HasError$
( True��65   . �5�      ��  �@�ToolTip 5�      �� ) �� *Self+$)* #(Validation.Errors)[0].ErrorContent��� 5�       � ��
 �  ��6/   5�      5�      �� 5�      " ��6)   8   .�5�   
   ��  � ��8  6'   �� 5�   
    � �� �	#FFFD81816'   �� 5�   
    � ��$ 0q�6,   5�      �� 5�      " ��6   8   .�5�   
   ��  � ��8  6'   �� 5�   
    � ��
 �����6'   �� 5�   
    � ��$ 0q�6,   5�      �� 5�      " ��6&   " 5�   
   �� 5�      # 6   �� *Status+$ Ok65   .a�5�      ��  � ��8   6)   5�      �� 5�      # 6   �� *Status+$ Hold65   .a�5�      ��  � ��8  6)   5�      �� 5�      # 6   �� *Status+	$ Error65   .a�5�      ��  � ��8  6)   5�      �� 5�      # 6   �� *Status+
$ Paused65   .a�5�      ��  � ��8  6)   5�      �� 5�      # 6   �� *Status+$ Network Error65   .a�5�      ��  � ��8  6)   5�      �� 5�      # 6   �� *Status+$ New Host65   .a�5�      ��  � ��8  6)   5�      5�      �� 5�      " Q�6%   8   .�5�   
   ��  �@Q�
IsExpanded 6'   �� *
Expanded+$+ TwoWay=�5�      " 5�   
   ^� 5�      , 5�      �� 5�      - 6    �� *Status+. Ok6;   �� 5�      - 6    �� ) �� "/ >�$* DataContext.Okbox�	. False6�   .0�5�      ��  � y�$ 	Collapsed=�6/   5�      ^� 5�      , 5�      �� 5�      - 6    �� *Status+. Hold6;   �� 5�      - 6    �� ) �� "/ >�$* DataContext.Holdbox�	. False6�   .0�5�      ��  � y�$ 	Collapsed=�6/   5�      ^� 5�      , 5�      �� 5�      - 6    �� *Status+	. Error6;   �� 5�      - 6    �� ) �� "/ >�$* DataContext.Errorbox�	. False6�   .0�5�      ��  � y�$ 	Collapsed=�6/   5�      ^� 5�      , 5�      �� 5�      - 6    �� *Status+
. Paused6;   �� 5      - 6    �� ) �� "/ >�$* DataContext.Pausebox�	. False6�   .0�5     ��  � y�$ 	Collapsed=�6/   5     ^� 5     , 5     �� 5     - 6    �� *Status+. Network Error6;   �� 5     - 6    �� ) �� "/ >�$* DataContext.Errorbox�	. False6�   .0�5	     ��  � y�$ 	Collapsed=�6/   5
     5     �� 5     0 6<   �� *	HostsView+.R�5  
   � $��-7q�6   ��5     �� 5     $1 UniformToFill=�6:   2 6   �� *Icon+3 6R   �� *IconOpacity+4 5     �� 5     �� 5     $
��auto �6#   �� 5     $
��auto �6#   .+�5     �� $��0��6   $��Center=�6>   $��8,0,0,0q�6Y   ��6(   �� *Name+6Y   �� 5     $��1��6   $��+��6(   $
��Bold"�61   $��Center=�6C   5 5       5     $6 	MouseDown��6%   .7 5       8 60   �� *" DataContext.AddHostDialogCommand+) �� *FindAncestor+"/ >�9 6�   �� 5     5     �� 5      $��2��6   $	��7,0q�6�   $��20,0,5,0q�6�   $��Center=�6�   ��6&   �� *!DataContext.EditCategoryCommand+) �� *FindAncestor+"/ >���6�   �� ��5!     �� 5"     $2 /Resources/edit.png��6!   $
: None=�6C   $1 Uniform=�6S   5$     5%     ; 5'  
   �� 5(     .R�5)     � $��-10,-7,0,-7q�6   8��  $	��205��6U   4 5*     �� 5+     $��10 �6+   �� 5,     �� 5-     $��30 �6+   < 5/     �� 50     �� 51     .+�53     �� $��0,0,2,0q�6    $��2��61   8�� 6B   �� 54     $��1��6    $��2��60   $��4,2,0,2q�6D   $= 	Host Name��6k   $��	ExtraBold"�6   ��6U   �� *Name+6   �� 55     $��2��6    $��1��60   $��4,2,4,2q�6=   $> Right=�6m   $= Time Counter��6�   ��6O   �� *Timecounter+y�6�   �� *HostVisibility+�� 56     $��1��6    $	��4,0q�60   $��1��6=   $
> Left=�6d   $= Host Address��6y   ��6J   �� *	Address+y�6�   �� *HostVisibility+57     58     5:     �� 5>     .R�5?  
   �� $? 
HostCanvas��6   $@ 0.5,0.5&�6%   $
A True��6^   = 6E   �� *Name+.+�5@     �� $��ConnectionLine��6   B 5A     �� *	Colnumber+C 6,   �� *Father.Colnumber+D 6L   �� *	Rownumber+E 6e   �� *Father.Rownumber+��5B     �� 5C     " ��6   " 5D     �� 5E     # 6*   �� *Father.Status+$ Ok6L   .a�5F  "   ��  � ��8   6;   5G     �� 5H     # 6*   �� *Father.Status+$ Hold6L   .a�5I  "   ��  � ��8  6;   5J     �� 5K     # 6*   �� *Father.Status+	$ Error6L   .a�5L  "   ��  � ��8  6;   5M     �� 5N     # 6*   �� *Father.Status+
$ Paused6L   .a�5O  "   ��  � ��8  6;   5P     �� 5Q     # 6*   �� *Father.Status+$ Network Error6M   .a�5R  "   ��  � ��8  6;   5S     �� 5T     # 6*   �� *Father.Status+$ New Host6M   .a�5U  "   ��  � ��8  6;   5V     �� 5W     # 6*   �� *Father.Selection+$ True6O   .a�5X  "   ��  � ��$ 5��6D   5Y     �� 5Z     # 6*   �� *Father.Selection+	$ False6O   .a�5[  "   ��  � ��$ 2��6D   5\     �� 5]     # 6*   �� *Father.Selection+$ True6O   .a�5^  "   ��  �@J�Opacity$	 100Q�6<   5_     �� 5`     # 6*   �� *Father.Selection+	$ False6O   .a�5a  "   ��  �@J�Opacity$ 80Q�6<   5b     5e     5g     � 5i     $	@ 0,0&�6V   F 6   �� *	Colnumber+G 65   �� *	Rownumber+5 5j       5k     $6 	MouseDown��6%   .7 5l       8 60   �� *DataContext.Selectfrommap+) �� *FindAncestor+"/ >�9 6�   �� 5m     z�5o     V� 5p     .~�5q     �� H 6)   �� *Scale+I 6B   �� *Scale+5r     J 5t     :� 5u     $K 
MouseEnter��6#   .[�5v     �� .��5w     �� .��5x  "   W� $ ConnectionLine��62   $ (Line.Opacity)�6Y   L 15y  2    06;   $
M True��6B   	N 0:0:06V   $ 0:0:.125D�6h   $O 3x��6|   5z     5|     5}     4 5     �� 5�     $��10 �6'   �� 5�     .+�5�     �� $��0��6   $��10��6-   $��10��68   8�� $	��Top=�6o   �� 5�     $��1��6   ��5�     �� 5�     " ��6    " 5�     �� 5�  "   # 6.   �� *	Selection+$ True6L   .a�5�  &   ��  � ��
 �����6D   �� 5�  &    � ��$ 2q�6H   5�  #   �� 5�  "   # 6.   �� *	Selection+	$ False6L   .a�5�  &   ��  � ��8  6D   �� 5�  &    � ��$ 1q�6H   5�  #   �� 5�  "   # 6.   �� *Father.Selection+$ True6S   .a�5�  &   ��  � ��# �  6D   5�  #   5�     ._�5�     �� ��5�     �� 5�     " ��6$   " 5�  "   �� 5�  &   # 62   �� *	Selection+$ True6P   .a�5�  *   ��  � ��# �  6G   5�  '   �� 5�  &   # 62   �� *	Selection+	$ False6P   .a�5�  *   ��  � ��# �  6G   5�  '   5�     .+�5�     �� $	��5,2q�6$   
�������$
��Bold"�6Z   ��61   �� *Name+6Z   �� 5�     $	��5,2q�6=   
���������6$   �� *	Address+6J   5�     5�     5�     5�     5�     �� 5�     .R�5�  
   �� ��6   �� *Name+5�     5�     