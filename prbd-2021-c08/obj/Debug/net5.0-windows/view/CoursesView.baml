   M S B A M L   `   `   `  ����I  EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework  5      H Dprbd_2021_c08, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:prbd_2021_c08.viewprbd_2021_c08.view 5      A%clr-namespace:prbd_2021_c08.viewmodelprbd_2021_c08.viewmodel 6=   $   prbd_2021_c08.view.CoursesView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:prbd_2021_c08.view     5      4vm%clr-namespace:prbd_2021_c08.viewmodel     6=     � 	Resources  5         	BoolToVis��%   &	        �� 5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $
��auto �6   �� 5      $��1* �6   �� 5      $��55 �6   .+�5   
   � $��10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��auto �6#   .+�5      �� $��14(�6S   ��6   �� *Filter+ �� UpdateSourceTrigger$ PropertyChanged=�6S   �� 5      $��Clear��6   $��1��6%   $��5,0,0,0q�6U   ��65   �� *ClearFilter+6U   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��
10,0,10,10q�6;   y�6O   �� *	IsStudent+ �� 	Converter# [  .+�5      	� $	��All��5       ���	#FF5CBEF1 d� 	IsChecked 5      �� *All+��64   �� *GetAll+5    (   	� 5!      $��10,0,0,0q�6W   $��Related��6i   ���	#FF5CBEF1 6   �� *	Related+��68   �� *
GetRelated+6{   5#      �� 5%   
   -   5         ��Name$ listView��5%      $��2��6E   
������  �� SelectionMode$ Single=�6l   $��Disabled=�6�   ��6%   �� *	Courses+��6�   Z� ��5'      �� 5(      .R�5)      � 5*      ��5,      �� 5-      .R�5.      �� $	��120��6   $	��160��6*   
����·�$��5,5,5,5q�6L   	 J� Opacity$		 0.7Q�6]   ��6l   �� ��5/      �� 
 �� Path$
 DataContext.DisplayCourse� �� RelativeSource ��  �� AncestorType" >�.��52      �  53      �� 54   "   $
��auto �60   �� 55   "   $��* �60   �� 56   "   $
��auto �60   �� 57   "   $
��auto �60   �� 58   "   $
��auto �60   �� 59   "   $
��auto �60   �� 5:   "   $
��auto �60   .+�5>      �� $��WrapWithOverflow=�6(   $��17(�6^   
���   �$��0��6    �� TextAlignment$ Center=�6�   $��
AR DESTINE)�6�   ��6H   �� *Name+6�   �� 5?      $��WrapWithOverflow=�6(   $��WordEllipsis=�6H   $��10(�6   
���   �$��1��6�   $ Center=�6�   $��Center=�6�    �� Padding$ 5q�6�   ��6e   �� *	Summary+6�   �� 5@      $��WrapWithOverflow=�6(   $��14(�6m   
���   �$��2��6�   $ Center=�6�   ��6H   �� *ActiveStudent.Count+6�   �� 5A      $��WrapWithOverflow=�6(   $��Teacher��6H   $��12(�6W   
���   �$��3��6x   $ Center=�6�   $��	Underline{�6�   �� 5B      $��WrapWithOverflow=�6(   $��12(�6j   
���   �$��4��6�   $ Center=�6�   ��6H   �� *Teacher.LastName+6�   5E      5F      5G      5I      �� 5J   
   $��Profile��6   $��3��6?   $	��100��6L   $��33��6X   $��Right=�6d   $��	0,5,29,17q�6�   $��16(�6�   $
��Bold"�6�   $		 0.7Q�6�   
����·�$��
AR DESTINE)�6�   ��6#   �� *	Profile+6�   �� 5K   
   $��
New Course��6   $��3��6D   $	��100��6Q   $��33��6]   $��Right=�6i   $��
0,5,150,17q�6�   $��16(�6�   $
��Bold"�6�   $		 0.7Q�6�   
����·�$��
AR DESTINE)�6$  ��6&   �� *	NewCourse+y�6�   �� *	IsTeacher+# [  6$  5M      5O      