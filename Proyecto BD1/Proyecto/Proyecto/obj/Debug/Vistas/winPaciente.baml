   M S B A M L   `   `   `  ����C  ?Proyecto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Proyecto.VistasProyecto.Vistas  5   	   !    Proyecto.Vistas.winPaciente   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Proyecto.Vistas     5   	     � Title$  Lista de pacientes.��5   	   $	��600��6%   $	��800��62    � 
ResizeMode$ NoResize=�6>    � Icon$1 +/Proyecto;component/Images/hospital (1).png��6T    � WindowStartupLocation$ CenterScreen=�6�   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5
      $	��400��6%   $
��Left=�61   $��0,0,0,52q�6L   � 5   
   $��75��6   $��Bottom=�6   $��	400,0,0,0q�66   .+�5      �� #��� ��6   $��1q�6c   �� 5      -   5         ��Name$ btnActualizar��5      $��
Actualizar��6,   $��Center=�6A   $��Center=�6^   $	��150��6y   $��	0,0,160,0q�6�   $��50��6�   �� 5      -   5        $ btnSalir��5      $��Salir��6'   $��Center=�67   $��Center=�6T   $	��150��6o   $��	160,0,0,0q�6{   $��50��6�   6�   5      � 5   
   $��Right=�6   $	��394��6+   $��0,0,0,75q�67   .+�5      � $��50��6   $	��Top=�6   $��1,1,-1,0q�67   .+�5      �� $��Información del cliente.��6   $��Center=�6;   $��Center=�6X   $��Times New Roman)�6s   $��24(�6�   $
��Bold"�6�   $��Italic$�6�   5      � 5      $��0,50,0,0q�6   .+�5      �� $��Cédula:��6   $
��Left=�6*   $	��Top=�6E   $��	10,87,0,0q�6]   �� 5      $��Nombre completo:��6   $
��Left=�63   $	��Top=�6N   $��
10,122,0,0q�6f   �� 5      $��Fecha de nacimiento:��6   $
��Left=�67   $	��Top=�6R   $��
10,157,0,0q�6j   �� 5      $��Tipo de sangre:��6   $
��Left=�62   $	��Top=�6M   $��
10,192,0,0q�6e   �� 5      -   5         ��Name$ txtCobertura��5      $��25��60    �� TextWrapping$
 Wrap=�6<   $	��Top=�6P   $��150,87,30,0q�6h   $��Center=�6}   {�.  6�   �� 5      -   5        $ txtTipoConsulta��5      $��25��63   $
 Wrap=�6?   $	��Top=�6S   $��150,122,30,0q�6k   $��Center=�6�   {�.  6�   �� 5      -   5        $ txtFecha��5      $��25��6,   $
 Wrap=�68   $	��Top=�6L   $��150,157,30,0q�6d   $��Center=�6z   {�.  6�   �� 5      -   5        $ txtMonto��5      $��25��6,   $
 Wrap=�68   $	��Top=�6L   $��150,192,30,0q�6d   $��Center=�6z   {�.  6�   �� 5      $��N. Afiliación��6   $
��Left=�60   $	��Top=�6K   $��
10,332,0,0q�6c   �� 5      -   5        $ txtAfiliacion��5      $��25��61   $
 Wrap=�6=   $	��Top=�6Q   $��150,332,30,0q�6i   $��Center=�6    � ToolTip$A ;Modifique aquí para actualizar la afiliación del cliente.��6�   �� 5      $��Estado civil: ��6   $
��Left=�61   $	��Top=�6L   $��
10,262,0,0q�6d   �� 5       -	   5        $ txtEstadoCivil��5       $��25��62   $
 Wrap=�6>   $	��Top=�6R   $��150,262,30,0q�6j   $��Center=�6�   $A ;Modifique aquí para actualizar la afiliación del cliente.��6�   {�.  6�   �� 5!      $��Tipo de plan:��6   $
��Left=�60   $	��Top=�6K   $��
10,297,0,0q�6c   �� 5"      -
   5        $ txtPlan��5"      $��25��6+   $
 Wrap=�67   $	��Top=�6K   $��150,297,30,0q�6c   $��Center=�6y   $A ;Modifique aquí para actualizar la afiliación del cliente.��6�   {�.  6�   �� 5#      $��	Telefono:��6   $
��Left=�6,   $	��Top=�6G   $��
10,227,0,0q�6_   �� 5$      -   5        $ txtTelefono��5$      $��25��6/   $
 Wrap=�6;   $	��Top=�6O   $��150,227,30,0q�6g   $��Center=�6}   $A ;Modifique aquí para actualizar la afiliación del cliente.��6�   {�.  6�   5%      5&      �� 5'   
   -   5        $ btnSeleccionar��5'      $��Seleccionar��6)   $
��Left=�6?   $��	20,0,0,10q�6Z   $��Bottom=�6m   $��75��6�   $��25��6�   $" Seleccione un procedimiento.��6�   �� 5(   
   -   5        	 ��Name$	 	cbxOpcion��5(      $��
115,0,0,10q�6&   $��Bottom=�6:   $��25��6U   $
��Left=�6a   $	��180��6|   �� 5)   
   -   5        $ 	btnBuscar��5)      $
��Left=�6$   $��
310,0,0,10q�6?   $��Bottom=�6S   $��75��6n   $��25��6y   .��5*      �� $��20��6   $��20��6    $*��$/Proyecto;component/Images/loupe.png��6+   5+      5-      5.      