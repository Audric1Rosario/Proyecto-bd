   M S B A M L   `   `   `  ����C  ?Proyecto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Proyecto.VistasProyecto.Vistas  5   	   "    Proyecto.Vistas.winCrearAuto   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Proyecto.Vistas     5   	     � Title$  Validar Autorización��5   	   $	��598��6&   $	��800��63    � 
ResizeMode$ NoResize=�6?    � Topmost .  � WindowStartupLocation$ CenterScreen=�6d    � Icon$1 +/Proyecto;component/Images/hospital (1).png��6�   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5
      $	��385��6%   $
��Left=�61   $��10,10,0,220q�6L   � 5   
   $��75��6   $��Bottom=�6   $��
400,0,0,-2q�66   .+�5      �� #��� ��6   $��1q�6c   �� 5      -   5         ��Name$ 
btnValidar��5      $��Validar��6)   $��Center=�6;   $��Center=�6X   $	��150��6s   $��	0,0,160,0q�6   $��50��6�   6�   �� 5      -   5        $ btnSalir��5      $��Salir��6'   $��Center=�67   $��Center=�6T   $	��150��6o   $��	160,0,0,0q�6{   $��50��6�   6�   5      � 5   
   $��Right=�6   $	��394��6+   $��0,0,0,73q�67   .+�5      � $��50��6   $	��Top=�6   $��1,1,-1,0q�67   .+�5      �� $$��Información de Procedimiento.��6   $��Center=�6@   $��Center=�6]   $��Times New Roman)�6x   $��24(�6�   $
��Bold"�6�   $��Italic$�6�   5      � 5      $��0,50,0,0q�6   .+�5      �� $��
Cobertura:��6   $
��Left=�6-   $	��Top=�6H   $��	10,20,0,0q�6`   �� 5      $��Tipo de Procedimiento:��6   $
��Left=�69   $	��Top=�6T   $��	10,55,0,0q�6l   �� 5      $��Fecha:��6   $
��Left=�6)   $	��Top=�6D   $��	10,90,0,0q�6\   �� 5      $��Descripción:��6   $
��Left=�6/   $	��Top=�6J   $��
10,160,0,0q�6b   �� 5      $��Medicamento:��6   $
��Left=�6/   $	��Top=�6J   $��
10,390,0,0q�6b   �� 5      -   5         ��Name$ txtCobertura��5      $��25��60    �� TextWrapping$
 Wrap=�6<   $	��Top=�6P   $��150,20,30,0q�6h   $��Center=�6}   {�.  6�   �� 5      -   5        $ txtTipoConsulta��5      $��25��63   $
 Wrap=�6?   $	��Top=�6S   $��150,55,30,0q�6k   $��Center=�6�   {�.  6�   �� 5      -   5        $ txtFecha��5      $��25��6,   $
 Wrap=�68   $	��Top=�6L   $��150,90,30,0q�6d   $��Center=�6y   {�.  6�   �� 5      -   5        $ txtMedicamento��5      $��25��62   $
 Wrap=�6>   $	��Top=�6R   $��150,390,30,0q�6j   $��Center=�6�   {�.  6�   �� 5      -   5        $ txtDescripcion��5      $��150,160,30,75q�62   $
 Wrap=�6I   $	 �� HorizontalScrollBarVisibility$
	 Auto=�6]   "
 �� VerticalScrollBarVisibility$

 Auto=�6�    �� 	MaxLength$	 256��6�   {�.  6�   5      5       �� 5!   
   -	   5        $ btnSeleccionar��5!      $��Seleccionar��6)   $
��Left=�6?   $��
20,0,20,10q�6Z   $��Bottom=�6n   $��75��6�   $��25��6�    � ToolTip$" Seleccione un procedimiento.��6�   6�   �� 5"   
   -
   5         ��Name$ 	cbxCentro��5"      $
��Left=�6&   $��
20,384,0,0q�6A   $	��Top=�6U   $	��150��6m   $��25��6y   �� 5#   
   -   5        $ 	cbxMedico��5#      $
��Left=�6&   $��223,384,0,0q�6A   $	��Top=�6V   $	��150��6n   $��25��6z   $ Escoja el doctor.��6�   �� 5$   
   -   5        $ cbxProcedimiento��5$      $
��Left=�6-   $��
20,446,0,0q�6H   $	��Top=�6\   $	��150��6t   $��25��6�   {�.  6�   �� 5%   
   $��Centro Medico.��6   $
��Left=�6)   $��
20,354,0,0q�6D   $	��Top=�6X   $	��150��6p   �� 5&   
   $��Procedimiento��6   $
��Left=�6(   $��
20,415,0,0q�6C   $	��Top=�6W   $	��150��6o   �� 5'   
   $��Codigo Paciente��6   $
��Left=�6*   $��223,415,0,0q�6E   $	��Top=�6Z   $	��150��6r   �� 5(   
   $��Codigo médico.��6   $
��Left=�6)   $��223,353,0,0q�6D   $	��Top=�6Y   $	��150��6q   �� 5)   
   -   5        $ cbxPaciente��5)      $
��Left=�6(   $��223,446,0,0q�6C   $	��Top=�6X   $	��150��6p   $��25��6|   $ Escoja el doctor.��6�   5+      5,      