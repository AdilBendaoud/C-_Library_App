   M S B A M L   `   `   `  ����N  JGestionBibliotheque, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GestionBibliothequeGestionBibliotheque  5   	   $    GestionBibliotheque.auteurForm   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   -local!clr-namespace:GestionBibliotheque  5   	   -   5          � WindowStyle$
  None=�5   9   $	��600��5   	   $	��400��6    � Title$ 
auteurForm��5
   	   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 0Q�6      CornerRadius$ 0��6)      GlassFrameThickness$ 0q�6:   .��5      �� $��5q�6   ���#2c2c2c._�5   
   ]� .+�5      ]� $��False��6   $	��Top=�6.   ���#2c2c2c$��30��6X   .+�5      �� $
��Left=�6    �� Orientation$ 
Horizontal=�68   .+�5      �� $��20��6   $��20��6'   $	��5 0q�63   $[��UC:\Users\pc\source\repos\GestionBibliotheque\GestionBibliotheque\Assets\lightlogo.png��6@   �� 5      $��Center=�6    $��SemiBold"�6;   
������� BiblioSphère - Ajouter Auteur6�   5      �� 5      $ 
Horizontal=�6   $��Right=�66   $��Center=�6M   .+�5      �� -   5         � Cursor$
 Hand��5   1   $��30��6@   $��20��6K   
������ $��0q�6p   .��5      "  FontAwesome.WPF.ImageAwesome     Icon$ WindowMinimize=�6*   $��14��6@   	   
Foreground
	 �����6K   ��5      �� 5      
 �� 
TargetType"
 ��6$   .�5   "   ��  �� Property � �� �� Value
 ���� 6?    �� Triggers 5   "   P� 5   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5   *   ��  � �� �#3d3d3d6G   5   '   5       5"      �� 5#      -   5        $
 Hand��5#   1   $��30��6?   $��20��6J   
������ $��0q�6o   .��5$        $ WindowMaximize=�6*   $��14��6@   
	 �����6K   ��5%      �� 5&      "
 ��6$   .�5'   "   ��  � ��
 ���� 6?    5(   "   P� 5)   &    �@J�IsMouseOver$
 True��6E   . �5*   *   ��  � �� �#3d3d3d6G   5+   '   5-      5/      �� 50      -   5        $��30��50   *   $��20��65      	DangerBtn#���   6A   .��51        $ Times=�6*   $��14��67   
	 �����6B   52      53      54      � 55      $��50 35q�6    � RowDefinitions 56      �� 57      6&   �� 58      6&   �� 59      6&   �� 5:      6&   .+�5=      �� $��0��6   .+�5>      �� $��5q�6   $��14(�6(   $��Nom :��66   �� 5?      -   5         ��Name$ nomInput��5?      $��5q�60   $��25��6;   5@      �� 5B      $��1��6   .+�5C      �� $��Prenom :��6   $��14(�6/   �� 5D      -   5        $ prenomInput��5D      $��5q�63   $��25��6>   5E      �� 5G      $��2��6   .+�5H      �� $��14(�6   $��Date naissance :��6*   (  "System.Windows.Controls.DatePicker  5I      -   5          Name$ 	dateInput��5I   !   5J      �� 5L      -   5        $ idInput��5L      $y�	Collapsed=�6+   �� 5M      $��Center=�6   $��Center=�6:   $��3��6U   $ 
Horizontal=�6b   .+�5N      �� -	   5         ��Name$ addBtn��5O        
primaryBtn#���  5P      $��Center=�5Q   *   $	��120��6G   $��35��6S   $��Bottom=�5R      .��5S      �� $ 
Horizontal=�6%   .+�5T        
	 �����$
 Plus=�6A   $��16��6M   $��0 0 5 0q�6X   �� 5U      Add6-   5V      5W      �� 5Y      -
   5        $ 	updateBtn��5Z      #���  5[      $��Center=�5\   -   $	��120��6J   $��35��6V   $��Bottom=�5]      .��5^      �� $ 
Horizontal=�6%   .+�5_        
	 �����$ FloppyOutline=�6A   $��18��6V   $��0 0 5 0q�6a   �� 5`      
Sauvgarder64   5a      5b      �� 5d      -   5        $ 	deleteBtn��5e      #���   5f      $��3��6=   $
��Left=�5g   -   $	��120��6H   $��35��6T   $��Bottom=�5h      .��5i      �� $ 
Horizontal=�6%   .+�5j        
	 �����$ TrashOutline=�6A   $��18��6U   $��0 0 5 0q�6`   �� 5k      �� 6)   $�	Supprimer��6-   6A   5l      5m      5n      5o      5p      5q      5r      