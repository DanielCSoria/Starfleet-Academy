   M S B A M L   `   `   `  ����I  EPRBD_Framework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:PRBD_Framework;assembly=PRBD_FrameworkPRBD_Framework  5   	   H Dprbd_2021_c08, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:prbd_2021_c08.viewprbd_2021_c08.view 5   	   A%clr-namespace:prbd_2021_c08.viewmodelprbd_2021_c08.viewmodel 5      !   prbd_2021_c08.view.MainView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Bf4clr-namespace:PRBD_Framework;assembly=PRBD_Framework     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /vw clr-namespace:prbd_2021_c08.view     5   	   4vm%clr-namespace:prbd_2021_c08.viewmodel     5      $	��720��5
   	   $
��1024��6     � WindowStartupLocation$  CenterScreen=�6#    � DataContext 5      + %prbd_2021_c08.viewmodel.MainViewModel  5   
   + %prbd_2021_c08.viewmodel.MainViewModel   DisplayCourse$ Vm_DisplayCourse��6'      Profile$ Vm_DisplayProfile��6H      	NewCourse$ Vm_DisplayNewCourse��6d      CloseProfile$ Vm_CloseTabProfile��6�      CloseNewCourse$ Vm_CloseTabNewCourse��6�      CloseCourseDetail$ Vm_CloseTabDetail��6�      NewQuizz$ Vm_DisplayNewQizz��5      	   DisplaySubscribe$	 Vm_DisplaySubscribtion��68   
   DisplayRegistration$
 Vm_DisplayRegistration��6b      DisplayQuestion$ Vm_DisplayQuestion��6�      DisplayCategories$ Vm_Categorie��6�      DisplayNewQuestion$ Vm_DisplayNewQuestion��5         CloseNewQuestion$ Vm_CloseTabNewQuestion��6F      DisplayQuizz$ Vm_DisplayQuizz��6p      CloseNewQuizz$ Vm_CloseTabNewQuizz��6�      	EditQuizz$ Vm_DisplayeditQuizz��5         	PassQuizz$ Vm_DisplayPassQuizz��6;      
CheckQuizz$ Vm_DisplayCheckQuizz��6[      DisplayNoteBook$ Vm_DisplayNoteBook��6}      CloseEditQuizz$ Vm_CloseTabEditQuizz��6�      ClosePassQuizz$ Vm_CloseTabPassQuizz��6�   -   5        vm��5   �   .��5      � ��5   
   �� 5       �� ImageSource$ /Ressources/space.png��6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��77 �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� 
���   �.@�5      m� $��Logout��6   $��12(�6I   ���	#FFF0E6E6 m� Command 6'   �� *LogoutCommand+6X   m� 5      $��Reload��6   $��12(�6M   ���	#FFF0E6E6 6'   �� *ReloadDataCommand+6\   5       !   PRBD_Framework.MyTabControl  5"   
   -   5          Name$ 
tabControl��5"      $��10q�6-   $��3��69    J� Opacity$ 1Q�6F    J� OpacityMask
 �   ���6f   Z� .@�5#      �� -   5         ��Name$ 	courseTab��5#      $��Courses��6)   
 � Tag$ Courses��6:   $��14(�6H   $
��Bold"�6V   .��5$      �� .��5%      $  prbd_2021_c08.view.CoursesView  5&      5'      5(      �� 5)   
   $
��Left=�6   $��57��6+   $��36,0,0,0q�67   $��1��6I   $��Center=�6V   $��59��6q   $��/image/aca.png��6|    �� BitmapScalingMode$
 Fant=�6�   �� 5*   
   $��STARFLEET ACADEMY��6   $
��Left=�6,   $��	110,0,0,0q�6G   $��1��6Z   $��Center=�6g   $	��350��6�   $��55��6�   $
��Bold"�6�   $��30(�6�   
�������$��
AR DESTINE)�6�   �� 5+   
   $��Welcome��6   $
��Left=�6"   $��	512,0,0,0q�6=   $��1��6P   $��Center=�6]   ���	#FFEEE5E5$��24(�6�   $��Italic$�6�   $��
AR DESTINE)�6�   �� 5,   
   $
��Left=�60   $��	625,0,0,0q�6K   $��1��6^   $��Center=�6k   ���	#FFF6ECEC$��24(�6�   $��Normal"�6�   $��Italic$�6�     J� RenderTransformOrigin$  0.513,0.525&�6�   $��
AR DESTINE)�6�   ��6   �� *CurrentUser+6�   5-      5.      