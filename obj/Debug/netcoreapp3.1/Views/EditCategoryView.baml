   M S B A M L   `   `   `  ����Q  MVisual Network Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:VNM2020.ViewsVNM2020.Views  5      $    VNM2020.Views.EditCategoryView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:VNM2020.Views     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignPaper#���   5        � 	Resources  5       �� Source�� 5   
   $% ../Resources/DataTemplates.xaml?�6   %    .��5      a� $	��200��6   .+�5   
   �� $��5q�6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Category Name��6f   ��6   �� *TargetCategory.Name+ �� UpdateSourceTrigger$ PropertyChanged=�6f   �� 5   
   $��Select Icon��6   $��5,5,5,0q�6'   
�������68   �� 5   
   $��5,0,5,5q�6e   
���������6   �� *
IconList+ �� SelectedItem 64   �� *TargetCategory.IconPath+6v   �� 5   
   $��Icon Opacity��6   $��5,5,5,0q�6(   
�������69   �� 5   
    � Minimum$ 0Q�6>    � Maximum$ 1Q�6J    �� TickFrequency$	 0.1Q�6V    � Value 6   �� *TargetCategory.IconOpacity+6V   �� 5   
   $��5q�6     AttentionButtonStyle#��[ 6   $��Remove��6K   ��6\   �� *RemoveCategoryCommand+��6�   �� 	 �� RelativeSource	 �� 
 �� Mode$
 FindAncestor=� �� AncestorType" �5      5      