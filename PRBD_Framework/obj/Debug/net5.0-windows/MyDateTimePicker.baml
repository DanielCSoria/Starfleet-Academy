   M S B A M L   `   `   `  ����I  EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PRBD_FrameworkPRBD_Framework  5      %    PRBD_Framework.MyDateTimePicker   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *fclr-namespace:PRBD_Framework     5      -   5          >�Name$  uc��5       � 	Resources 5	      (  "PRBD_Framework.TimeFormatConverter   TimeFormatConverter��%   &	          5
   
   6    5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ 
datePicker��5      $��0��6)   $��0,0,5,0q�5   K   $	��Top=�6\      SelectedDate 6   �� *SelectedDate+ �� ElementName$ uc��6\   �� 5   
   -   5         ��Name$ textBox��5      $��1��6#   $��30��5       �� TextWrapping$ NoWrap=�5      $��Center=�5       �� TextAlignment$ Center=�5      $��Stretch=�6)   .��5   .   ��5      `� 5      	 `� 	Converter#	 [  6   
 `� ValidatesOnDataErrors$

 True��6P    `� NotifyOnValidationError$
 True��6m    �� TargetNullValue$  ��6�   .1�5      ��  �� Path$ SelectedTime�6   $ uc��62   $  ��6C   �� 5      $ 
TimeFormat�6   $ uc��60    �� Mode$ OneWay=�6A   5      .��5      5      5       5!      