   M S B A M L   `   `   `  ����I  EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework  5   	   H Dprbd_2021_c08, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:prbd_2021_c08.viewprbd_2021_c08.view 5   	   A%clr-namespace:prbd_2021_c08.viewmodelprbd_2021_c08.viewmodel 5   	   "   prbd_2021_c08.view.LoginView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:prbd_2021_c08.view     5   	   4vm%clr-namespace:prbd_2021_c08.viewmodel     5   	   $	��500��5
   
   $	��800��6     � WindowStartupLocation$  CenterScreen=�6#   .��5      � ��5   
   �� 5       �� ImageSource$ /Ressources/space.png��6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��5* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��7* �6   �� 5      $��* �6   .+�5   
   � $��1��6   $��1��6   
����ح� J� Opacity$	 0.7Q�6C    5      �� 5      $
��0.2* �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $
��Auto �6    �� 5"      $
��0.2* �6    �� 5#      $
��Auto �6    �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    �� 5&      $
��0.4* �6    �� 5'      $
��Auto �6    �� 5(      $
��0.5* �6    �� 5)      $
��Auto �6    �� 5*      $
��0.5* �6     5,      �� 5-      $��* �6#   �� 5.      $��6* �6#   �� 5/      $��* �6#   .+�51      �� $��Log In��6   $��1��6%   $��1��65   $��Center=�6B   $
��Bold"�6_   $��30(�6q   $��
AR DESTINE)�6   ��52      �� 53       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��54      �  � Color$ 	#FF010B3D��6'   � 55      $ 	#FF293FE0��6'    � Offset$ 1Q�69   56      58      �� 59      $��Mail :��6   $��2��6&   $��1��63   $��18(�6D   $
��Bold"�6R   $��25��6e   ���	#FF0427796t   #   PRBD_Framework.ValidatedField  5:      $��3��6    $��1��6-   .+�5;      �� $��27��6   ��6&   �� *Mail+	 �� UpdateSourceTrigger$	 PropertyChanged=�5<      �� 5=      $��
Password :��6   $��6��6)   $��1��66   $��18(�6G   $
��Bold"�6U   $��25��6h   ���	#FF0427796w     5>      $��7��6   $��1��6,   .+�5?      G� -   5        
 G�Name$
 PasswordBox��5?   =   #   PRBD_Framework.PasswordHelper   Attach$
 True��6   $��27��5@         Password 6   �� *
PassWord+$	 PropertyChanged=�5A      � 5B      $��9��6   $��1��6     5C      �� 5D      $��* �6'   �� 5E      $
��Auto �6'   �� 5F      $��* �6'   �� 5G      $
��Auto �6'   �� 5H      $��* �6'   .+�5J      �� $��Log in��6   $��1��6*   $��33��6[   $	��100��6g   $��14(�6s   $
��Bold"�6�   $��
AR DESTINE)�6�   ��6:   �� *LoginCommand+6�   �� 5K      -   5        $��Sign up��5K      $��3��6+   $��33��6]   $	��100��6i   $��14(�6u   $
��Bold"�6�   $��
AR DESTINE)�6�   ��6;   �� *SignupCommand+6�   5L      �� 5M      $��Log as a student��6   $��1��60   $��10��6@   $��30��6v   $	��277��6�   $��14(�6�   $
��Bold"�6�   $��
AR DESTINE)�6�   ��6N   �� *LoginStudentCommand+6�   5N      5O      5P      