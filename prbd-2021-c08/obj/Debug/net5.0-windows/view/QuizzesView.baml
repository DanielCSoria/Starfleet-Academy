   M S B A M L   `   `   `  ����H  Dprbd_2021_c08, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:prbd_2021_c08.viewprbd_2021_c08.view  5      I EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework 5      $    prbd_2021_c08.view.QuizzesView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:prbd_2021_c08.view     5      Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5        � 	Resources  5
         	BoolToVis��%   &	        �� 5   
   6'   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��25* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $	��19* �6   �� 5      $��* �6   .+�5   
   � $��1��6   $��1��6   
����ح� J� Opacity$	 0.7Q�6C    5      �� 5      $��* �6#   �� 5      $	��25* �6#   �� 5      $��* �6#    5      �� 5       $��* �6    �� 5!      $	��19* �6    �� 5"      $	��19* �6    �� 5#      $
��Auto �6    �� 5$      $��* �6    .+�5&      &   System.Windows.Controls.DataGrid  -   5          Name$ gridCategorie��5&   5   $��1��6   $��1��6%   $��
10,10,10,9q�6L      AutoGenerateColumns$ False��6`      
IsReadOnly$
 True��5'      ��5(      �� *	Quizzes+ �� SelectedItem 5)      �� *SelectedQuizz+   Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Title (Current)��6)   
   SortDirection
 	Ascending6\      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6v   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *Title+6v     5,      $	 Start��6)   
 	Ascending6R   $	 150 6l    68   �� *Start+6l     5-      $	 Finish��6)   
 	Ascending6T   $	 150 6n    69   �� *Finish+6n     5.      $	 
#Questions��6)   
 	Ascending6a   $ * 6{    6=   �� *NumberQuestions+6{   50      � 51      $��3��6   $��1��6     52      �� 53      $
��Auto �6'   �� 54      $
��Auto �6'   �� 55      $
��Auto �6'   �� 56      $
��Auto �6'   .+�58      �� $��	New Quizz��6   $��Right=�6J   $	��100��6f   $��27��6r   $��0��6   $��5q�6�   $��
AR DESTINE)�6�   ��6-   �� *
NewQuizz+y�6�   �� *	IsTeacher+ �� 	Converter# [  �� 59      $��
Edit quizz��6   $��Right=�6L   $	��100��6h   $��27��6t   $��1��6�   $��5q�6�   $��
AR DESTINE)�6�   ��6.   �� *	EditQuizz+y�6�   �� *	IsTeacher+# [  �� 5:      $��
Pass Quizz��6   $��Right=�6L   $	��100��6h   $��27��6t   $��2��6�   $��5q�6�   $��
AR DESTINE)�6�   ��6.   �� *	PassQuizz+y�6�   �� *	IsStudent+# [  �� 5;      $��Check quizz��6   $��Right=�6N   $	��100��6j   $��27��6v   $��3��6�   $��5q�6�   $��
AR DESTINE)�6�   ��6/   �� *
CheckQuizz+6�   5<        5=      $��2��6   $��1��6%   $��
10,10,10,9q�66   $ False��6J   $
 True��5>      ��5?      �� *PastQuizzes+ 5@      �� *SelectedPastQuizz+ 5A        5B      $	 Title (Past)��6)   
 	Ascending6Y   $	 150 6s    6?   �� *Title+6s     5C      $	 Start��6)   
 	Ascending6R   $	 150 6l    68   �� *Start+6l     5D      $	 Finish��6)   
 	Ascending6T   $	 150 6n    69   �� *Finish+6n     5E      $	 
#Questions��6)   
 	Ascending6a   $ * 6{    6=   �� *NumberQuestions+6{   5G      5I      5J      5K      