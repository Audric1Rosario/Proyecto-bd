   M S B A M L   `   `   `  ����C  ?Proyecto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProyectoProyecto  5   	       Proyecto.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Proyecto     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Login��5	   	   $	��480��6   $	��720��6$    � 
ResizeMode$ NoResize=�60    � Icon$ Images/first-aid-kit.png��6F    � 	Resources 5         placeHolder �� 
TargetType �� BasedOn �� Property �� Value	 �� 
TargetType
 ��Name K� ZIndex �� Path �� RelativeSource �� Mode �� UpdateSourceTrigger
 � Tag �� Triggers �� Binding �� Source%  System.Windows.Markup.Reference �� Value��%  &	        7���� 5   
   " ��6$   8   .�5      ��  � �� 5      �� 5      "	 ��6&   .R�5      � .+�5      �� $
 
textSource��5   "   
������ $ 2��5   "   $��Center=�5   "   $��Center=�5   "   ��5   &   �� $
 Text� �� *TemplatedParent+$ TwoWay=�$ PropertyChanged=�5   "   �� 5      #��z 6&   #��z��6C   $ 1��6m   .��6~   ��5   "   �� 5   &   " ��6,   .�5   *   ��  � ��
 ���� 6G    5   *   �� 5   .    6:   �� $
 Text�   *
textSource+  6y   .a�5    2   ��  � ��
 �����6O   �� 5!   2    � ��$ Center=�6X   �� 5"   2    � ��$ Center=�6V   �� 5#   2    � ��
 ���� 6P   5$   /   5&   '   .��5'   1   5(      5)      5*      5,      5-      50      .��52      � .+�53   
   � $��200,50q�6   .+�54      � $��50��6   $��Bottom=�6   $	��314��6:   .+�55      �� -   5         ��Name$ btnIngresar��55      $��Ingresar��6.   $
��20,5q�6A   6O   56      � 57      $	��100��6   $��Bottom=�6    $	��314��6;   $��0,0,0,50q�6G   .+�58      �� -   5        $
 
txtloginid��58   N   #��[  6   $ Login ID��6?    �� TextWrapping$
 Wrap=�6b   $��10,10,10,55q�6v   G� 59      -   5         G�Name$ 	passlogin��59      $��10,55,10,10q�61   $��Center=�6F   $��Center=�6j   5:      � 5;      $��	0,0,0,150q�6   .+�5<      �� -   5         ��Name$ imguser��5<      $��Images/user.png��6)   $��10q�6B   5=      5>      5@      5A      