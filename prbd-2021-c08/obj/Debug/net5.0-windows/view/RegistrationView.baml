   M S B A M L   `   `   `  ����I  EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework  5      H Dprbd_2021_c08, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:prbd_2021_c08.viewprbd_2021_c08.view 5      )   #prbd_2021_c08.view.RegistrationView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5      2local clr-namespace:prbd_2021_c08.view     5        � 	Resources  5
         	BoolToVis��%   &	        �� 5   
   6'   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��25* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $	��19* �6   �� 5      $��* �6   .+�5   
   � $��1��6   $��1��6   
����ح� J� Opacity$	 0.7Q�6C    5      �� 5      $
��0.2* �6    �� 5      $
��0.3* �6    �� 5      $
��0.2* �6    �� 5      $��2* �6    �� 5      $
��0.2* �6     5!      �� 5"      $
��0.5* �6#   �� 5#      $��4* �6#   �� 5$      $��2* �6#   �� 5%      $��4* �6#   �� 5&      $
��0.1* �6#   .+�5(      �� $��Active student��6   $��1��6.   $��1��6B   $��1��6R   $��Center=�6_   $��20(�6|   $��
AR DESTINE)�6�   ��5)      �� 5*       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5+      �  � Color$ 	#FF1C296F��6'   � 5,      $ 	#FF0F0FF9��6'    � Offset$ 1Q�69   5-      5/      �� 50      $#��             Unactive student��6   $��3��6=   $��2��6Q   $��1��6a   $��Center=�6n   $��20(�6�   $��
AR DESTINE)�6�   ��51      �� 52      $ 0.5,1&�6*   $ 0.5,0&�6;   .��53      � $ 	#FF1C296F��6'   � 54      $ 	#FF0F0FF9��6'   $ 1Q�69   55      57      � 58      $��3��6   $��2��6     59      �� 5:      $��* �6$   �� 5;      $��* �6$   �� 5<      $��* �6$   �� 5=      $��* �6$   .+�5A      �� $��
 Activate ��6   $��1��6.   $��40��6=   $	��100��6I   $��14(�6U   $��
AR DESTINE)�6�   ��6d   �� *
Activate+6�   �� 5B      $�� Deactivate ��6   $��2��61   $��40��6@   $	��100��6L   $��14(�6X   $��
AR DESTINE)�6�   ��6g   �� *
Deactivate+6�   5D      &   System.Windows.Controls.DataGrid  5E      -   5          Name$ gridMembers��5E   5   $��3��6   $��1��6%   $��
10,10,10,9q�6J   	   AutoGenerateColumns$	 False��6^   
   
IsReadOnly$

 True��5F      ��5E   z   �� *Active+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5G      �� *SelectedActive+   Columns 5H      4  .System.Windows.Controls.DataGridTemplateColumn  5I      ,  &System.Windows.Controls.DataGridColumn   Header$ Division��6-      CellTemplate 5J      �� 5K      .R�5L   "   �� $��30��6�    �� BitmapScalingMode$
 Fant=�6�   ��6(   �� *Division.AbsolutePicturePath+ �� 	Converter .   (PRBD_Framework.UriToCachedImageConverter  6�   5M      5O      0  *System.Windows.Controls.DataGridTextColumn  5P      $ 	FirstName��6)      SortDirection 	Ascending6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *	FirstName+6Z     5Q      $ LastName��6)    	Ascending6X      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6s    6;   �� *
LastName+6s   5V      � 5W      $��3��6   $��3��6     5X      �� 5Y      $��* �6$   �� 5Z      $
��0.2* �6$   �� 5[      $��* �6$   .+�5]        $��0��6   $��
10,10,10,9q�6)   $	 False��6=   $	��250��6Y   $

 True��5^      ��5_      �� *
UnActive+$ PropertyChanged=� 5`      �� *SelectedUnactive+ 5a        5c      $ 	FirstName��6-    	Ascending6^   $	 100 6x    6@   �� *	FirstName+6x     5d      $ LastName��6-    	Ascending6\   $ * 6v    6?   �� *
LastName+6v   5g      �� 5h      $��Unregistered students��6   $��1��69   $��Center=�6F   $��20(�6c   $��
AR DESTINE)�6q   
����  �6�     5i      $��2��6   $��
10,10,10,9q�6)   $	 False��6=   $	��250��6Y   $

 True��5j      ��5k      �� *
Students+$ PropertyChanged=� 5l      �� *SelectedUnactive+ 5m        5o      $ 	FirstName��6-    	Ascending6^   $	 100 6x    6@   �� *	FirstName+6x     5p      $ LastName��6-    	Ascending6\   $ * 6v    6?   �� *
LastName+6v   5s      5t      5u      5v      5x      