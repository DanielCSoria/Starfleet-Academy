   M S B A M L   `   `   `  ����I  EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework  5      H Dprbd_2021_c08, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:prbd_2021_c08.viewprbd_2021_c08.view 5      &    prbd_2021_c08.view.CategorieView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5      2local clr-namespace:prbd_2021_c08.view     5      .��5
      �   � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $	��25* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $	��19* �6   �� 5      $��* �6   .+�5   
   � $��1��6   $��1��6   
����ح� J� Opacity$	 0.7Q�6C     5      �� 5      $��* �6#   �� 5      $	��25* �6#   �� 5      $��* �6#    5      �� 5      $��* �6    �� 5      $	��19* �6    �� 5      $��3* �6    �� 5       $��* �6    .+�5"      &   System.Windows.Controls.DataGrid  -   5          Name$ gridCategorie��5"   5   $��1��6   $��1��6%   $��
10,10,10,9q�6L      AutoGenerateColumns$ False��6`      
IsReadOnly$
 True��5#       �� SelectedItem 5$      �� *	Catgories+   Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)   	   SortDirection	 	Ascending6P   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 150 6j   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Name+6j     5(      $ Question��6)   	 	Ascending6X   $	
 150 6r    6;   �� *
Question+6r   5+      � 5,      $��2��6   $��1��6      5-      �� 5.      $��* �6'   �� 5/      $��* �6'   .+�51      �� $
��Save��6   $
��Left=�6B   $	��100��6]   $��25��6i   $��1��6v   $��5q�6�   $��
AR DESTINE)�6�   ��6)   �� *Save+6�   �� 52      $��Cancel��6   $��Center=�6E   $	��100��6b   $��25��6n   $��1��6{   $��5q�6�   $��
AR DESTINE)�6�   ��6*   �� *Cancel+6�   �� 53      $��Delete��6   $��Right=�6E   $	��100��6a   $��25��6m   $��1��6z   $��5q�6�   $��
AR DESTINE)�6�   ��6*   �� *Delete+6�   54      55      56      57      