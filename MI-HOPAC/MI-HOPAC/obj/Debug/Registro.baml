   M S B A M L   `   `   `  ����C  ?MI-HOPAC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MI_HOPACMI_HOPAC  5   	       MI_HOPAC.Registro   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:MI_HOPAC     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $��547.854��5      $��743.635��6+     � WindowStyle$
  None=�6;    � WindowStartupLocation$ CenterScreen=�6N    J� Effect 5	      3  -System.Windows.Media.Effects.DropShadowEffect  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��521* �6   �� 5      $	��37* �6   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #82c3ef��6    � Offset$	 0.5Q�6/   � 5      $ #6a8e9e��6   $	 0.5Q�6/   5      .+�5   
   �� -   5        $��resources/close.png��5   ,   $��15��6I   $��15��6T   $	��Top=�6`   $��Right=�6x   $��0,5,5,0q�6�   ��5      �� 5       �� 
TargetType" ��6   	 �� Triggers	 5      P� 5      
 P� Property
 �@J�IsMouseOver P� Value . . �5       ��  �� Property �@J�Opacity �� Value$ .5Q�68   5!      5#      5%      �� 5'   
   $��0 40 0 0q�6    
  Fuente#��[  6&   $��29(�6F   
������� �� TextAlignment$ Center=�6g   $��2��6~   
Homeacup6�   #  MaterialDesignThemes.Wpf.Card  5(   
   $��32q�6   $��50,120,50,0q�6+   $	��357��6@   .��5)      �  � ColumnDefinitions 5*      �� 5+      $��* �6'   �� 5,      $��* �6'   .+�5/      � $��0��6    50      �� 51      $��* �6(   �� 52      $��* �6(   �� 53      $��* �6(   �� 54      $��* �6(   �� 55      $��* �6(   .+�58      ��  �� Orientation$ 
Horizontal=�6!   $��0��6:   .+�59      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$
 User=�62   $��Center=�6>   6[   �� 5:      -   5         ��Name$ 	txtNombre��5:   "   $	��200��65   $��	10 0 0 20q�6A   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nombre��6T      
IsFloating . 6�   5;      �� 5=      $ 
Horizontal=�6!   $��1��6:   .+�5>        $
 User=�62   $��Center=�6>   6[   �� 5?      -   5        $ txtApellido��5?   "   $	��200��67   $��	10 0 0 20q�6C   $ 	Apellidos��6V    . 6�   5@      �� 5B      $ 
Horizontal=�6!   $��2��6:   .+�5C        $ Email=�62   $��Center=�6?   6\   �� 5D      -   5        $ 	txtCorreo��5D   "   $	��200��65   $��	10 0 0 20q�6A   $ Correo��6T    . 6�   5E      �� 5G      $ 
Horizontal=�6!   $��3��6:   .+�5H        $	 Key=�62   $��Center=�6=   6Z   G� 5I      -   5         G�Name$ txtContrasena��5I   &   $	��200��6=   $��	10 0 0 20q�6I   $ Contraseña��6\    . 6�   5J      �� 5L      $ 
Horizontal=�6!   $��4��6:   .+�5M        $	 Key=�62   $��Center=�6=   6Z   G� 5N      -   5        $ txtConfirmarContrasena��5N   &   $	��200��6F   $��	10 0 0 20q�6R   $ Confirmar constraseña��6e    . 6�   5O      5P      � 5R      $��1��6    5S      �� 5T      $��* �6(   �� 5U      $��3* �6(   �� 5V      $��* �6(   �� 5W      $��* �6(   .+�5Z      �� $��Center=�6    $��0��6;   $��Center=�6H   #��[  6e   $��20(�6�   
���   �$ Center=�6�   
Medicina6�   �� 5[      $��1��6!   $��Center=�6.   .+�5\      	� -   5         	�Name$ radHomeopatia��5\   &    d� 	IsChecked$
 TrueY�6=   $��10q�6N   $��Center=�6Z   $��1��6u   #��[  6�   .��6�   Homeopatía6�   	� 5]      -   5        $ radAcupuntura��5]   &   $��10q�6=   $��Center=�6I   $��2��6d   #��[  6q   .��6�   
Acupuntura6�   	� 5^      -	   5        $ radAmbos��5^   &   $��10q�68   $��Center=�6D   $��3��6_   #��[  6l   .��6�   Ambos6�   5_      �� 5`      $��2��6    $��Bottom=�6-   $��10q�6H   $ Right=�6T   �� 6k   -
   5        $��12(�5`   �   
������� % !MaterialDesignSubheadingHyperlink#���  6�   .�6�   ¿Ya tienes una cuenta?6�   6
  �� 5a      -   5        $��Bottom=�5a   4   $��Right=�6O   $��10q�6k   $	��170��6w   $��3��6�   .��6�   	Registrar6�   5b      5c      5d      5e      5f      