   M S B A M L   `   `   `  ����C  ?Proyecto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Proyecto.VistasProyecto.Vistas  5   	   $    Proyecto.Vistas.winCrearCentro   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Proyecto.Vistas     5   	     � Title$  Crear Centro��5   	   $	��480��6   $	��640��6+    � 
ResizeMode$ NoResize=�67    � WindowStartupLocation$ CenterScreen=�6M    � Topmost .  � Icon$1 +/Proyecto;component/Images/hospital (1).png��6�   .��5	      � .+�5
   
   � $��75��6   $��Bottom=�6   $��0q�66   .+�5      �� #��� ��6   $��1q�6c   �� 5      -   5         ��Name$ btnCrear��5      $��Crear��6'   $��Center=�67   $��Center=�6T   $	��150��6o   $��	0,0,160,0q�6{   $��50��6�   6�   �� 5      -   5        $ btnSalir��5      $��Salir��6'   $��Center=�67   $��Center=�6T   $	��150��6o   $��	160,0,0,0q�6{   $��50��6�   6�   5      � 5   
   $
��Left=�6   $	��400��6*   $��0,0,0,75q�66   .+�5      �� #��� ��6   $��1q�6b   �� 5      $��Nombre:��6   $
��Left=�6&   $	��Top=�6A   $��	10,20,0,0q�6Y   �� 5      $��
Provincia:��6   $
��Left=�6)   $	��Top=�6D   $��	10,55,0,0q�6\   �� 5      $��
Municipio:��6   $
��Left=�6)   $	��Top=�6D   $��	10,90,0,0q�6\   �� 5      $��Plazas Disponibles:��6   $
��Left=�62   $	��Top=�6M   $��
10,280,0,0q�6e   �� 5      -   5         ��Name$ lstMunicipio��5      $	��175��6,   $	��Top=�69   $��150,90,30,0q�6Q   �� 5      -   5         ��Name$ cbxProvincia��5      $	��Top=�6-   $��150,55,30,0q�6E   $��25��6Z   �� 5      -   5         ��Name$ 	txtNombre��5      $��25��6)   	 �� TextWrapping$
	 Wrap=�65   $	��Top=�6I   $��150,20,30,0q�6a   $��Center=�6v   �� 5      -   5        $ 	txtPlazas��5      $��25��6)   $
	 Wrap=�65   $	��Top=�6I   $��150,280,30,0q�6a   $��Center=�6w   6�   �� 5      $��N. Afiliación: ��6   $
��Left=�6.   $	��Top=�6I   $��
10,315,0,0q�6a   �� 5      -   5        $ cbxAfiliacion��5      $	��Top=�6.   $��150,315,30,0q�6F   $��25��6\   �� 5      -   5        $ 	btnSelect��5      $
��Left=�6(   $	��Top=�6C   $��30��6[   $��
110,55,0,0q�6f   $��25��6z   .��5      �� $��20��6   $��20��6$   $/��)/Proyecto;component/Images/check-mark.png��6/   5      5      � 5   
   $��Right=�6   $	��234��6+   $��0,0,0,75q�67   .+�5       �� $��25q�6   $1��+/Proyecto;component/Images/hospital (3).png��6    5!      5#      5$      