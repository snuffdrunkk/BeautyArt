   M S B A M L   `   `   `  ����D  @BeautyArt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BeautyArt.EditBeautyArt.Edit  5   	   $    BeautyArt.Edit.CompositionEdit   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BeautyArt.Edit     5   	   c _MaterialDesignThemes.MahApps, Version=3.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	   	     � Title$   ��5   	   $	��320��6   $	��323��6      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	   ��5      �� 5   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ #EEE8AA��6    � Offset$ 1Q�6+   5      .��5      � .+�5   
   �� 
�������$��10q�5      
�������$
��Left=�5      $��30,10,30,10q�5      $	��250��5       �� CornerRadius$ 25��5      ._�5      �� .+�5      �� -   5         ��Name$ ComboBoxStud��5       )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$%	 Фамилия студента��5!      $��
0, 0, 0, 6q�5"      $	��Top=�5#      5$      �� 5&      -   5        $ ComboBoxEnable��5'      $4	 .Находится в курсе сейчас?��5(      $��
0, 0, 0, 7q�5)      $	��Top=�5*      .@�5+      �� $
��Да��6#   �� 5,      $��Нет��6#   5-      �� 5/      -   5        $ ComboBoxReason��50      {�.  $	 Причина ухода��52      $��0, 0, 0, 57q�53      $	��Top=�54      .@�55      �� $(��"Не понарвился курс��6#   �� 56      $A��;Не понарвилась система обучения��6#   �� 57      $I��CНе понарвился состав преподавателей��6#   �� 58      $G��AЗахотелось попробовать другой курс��6#   �� 59      $��Другое��6#   5:      �� 5<      -   5        
 ��Name$
 
EditButton��5>      $ ��Редактировать��5=      ���#877495���#877495$��1q�5A       " MaterialDesignRaisedDarkButton#��[ 5C      $��
0, 0, 0, 5q�5D      {�5B      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�5E      �� 5G      -   5        $
 CloseButton��5I      $��Закрыть��5H      ���#877495���#877495$��1q�5L      #��[ 5N      $��
0, 0, 0, 0q�5O      {�5M      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�5P      5Q      5R      5S      5T      