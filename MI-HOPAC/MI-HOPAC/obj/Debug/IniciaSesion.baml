   M S B A M L   `   `   `  ����C  ?MI-HOPAC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MI_HOPACMI_HOPAC  5   	       MI_HOPAC.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:MI_HOPAC     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $��566.5��5      $	��408��6)     � WindowStyle$
  None=�65    � WindowStartupLocation$ CenterScreen=�6H    J� Effect 5	      3  -System.Windows.Media.Effects.DropShadowEffect  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��521* �6   �� 5      $	��37* �6   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #82c3ef��6    � Offset$	 0.5Q�6/   � 5      $ #6a8e9e��6   $	 0.5Q�6/   5      .+�5   
   �� -   5        $��resources/close.png��5   ,   $��15��6I   $��15��6T   $	��Top=�6`   $��Right=�6x   $��0,5,5,0q�6�   ��5      �� 5       �� 
TargetType" ��6   	 �� Triggers	 5      P� 5      
 P� Property
 �@J�IsMouseOver P� Value . . �5      ��  �� Property �@J�Opacity �� Value$ .5Q�68   5       5"      5$      �� 5&   
   $��0 40 0 0q�6    
  Fuente#��[  6&   $��29(�6F   
������� �� TextAlignment$ Center=�6g   $��2��6~   Iniciar sesión6�   #  MaterialDesignThemes.Wpf.Card  5'   
   $��32q�6   $��50,120,50,0q�6+   $	��357��6@   .��5(      �� $��0 10 0 0q�6   .+�5)      ��  �� Orientation$ 
Horizontal=�6   .+�5*      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Account=�6.   $��Center=�6=   6Z   �� 5+      -   5         ��Name$ txt_Usuario��5+   =   $	��200��6   $��	10 0 0 20q�6*   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Correo��6R      
IsFloating . 6�   5,      �� 5.      $ 
Horizontal=�6   .+�5/        $	 Key=�6.   $��Center=�69   6V   G� 50      -   5         G�Name$ txt_Contrasena��50   A   $	��200��6"   $��	10 0 0 20q�6.   $ Contraseña��6Y    . 6�   51      �� 53      $��0 10 0 0q�6   $ Right=�6.   �� 6E   -   5        $��12(�53   g   
������� % !MaterialDesignSubheadingHyperlink#���  6�   .�6�   Crea una cuenta6�   6�   �� 54      $��0 0 0 30q�6   $ Right=�6.   �� 6E   $��12(�6O   
�������#���  6o   .�6�    ¿Has olvidado tu contraseña?6�   6�   �� 55      -   5         # MaterialDesignRaisedLightButton#��[ 55   .   $��0 55 0 0q�6g   $	��120��6y   .��6�   Login6�   56      57      58      59      