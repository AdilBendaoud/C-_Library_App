   M S B A M L   `   `   `  ����N  JGestionBibliotheque, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GestionBibliothequeGestionBibliotheque  5   	   '    !GestionBibliotheque.AdherentsForm   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:GestionBibliotheque     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   -   5          � WindowStyle$
  None=�5   	    � Title$ AdherentsForm��5	      $	��600��61   $	��500��6>   '  !System.Windows.Shell.WindowChrome   WindowChrome 5
        5   
      CaptionHeight$ 0Q�6      CornerRadius$ 0��6)      GlassFrameThickness$ 0q�6:   .��5      �� $��5q�6   ���#2c2c2c._�5   
   ]� .+�5      ]� $��False��6   $	��Top=�6.   ���#2c2c2c$��30��6X   .+�5      �� $
��Left=�6    �� Orientation$ 
Horizontal=�68   .+�5      �� $��20��6   $��20��6'   $	��5 0q�63   $[��UC:\Users\pc\source\repos\GestionBibliotheque\GestionBibliotheque\Assets\lightlogo.png��6@   �� 5      $��Center=�6    $��SemiBold"�6;   
�������'%BiblioSphère - Modifier un adherents6�   5      �� 5      $ 
Horizontal=�6   $��Right=�66   $��Center=�6M   .+�5      �� -   5         � Cursor$
 Hand��5   1   $��30��6@   $��20��6K   
������ $��0q�6p   .��5      "  FontAwesome.WPF.ImageAwesome     Icon$ WindowMinimize=�6*   $��14��6@   	   
Foreground
	 �����6K   ��5      �� 5      
 �� 
TargetType"
 ��6$   .�5   "   ��  �� Property � �� �� Value
 ���� 6?    �� Triggers 5   "   P� 5   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5   *   ��  � �� �#3d3d3d6G   5   '   5      5!      �� 5"      -   5        $
 Hand��5"   1   $��30��6?   $��20��6J   
������ $��0q�6o   .��5#        $ WindowMaximize=�6*   $��14��6@   
	 �����6K   ��5$      �� 5%      "
 ��6$   .�5&   "   ��  � ��
 ���� 6?    5'   "   P� 5(   &    �@J�IsMouseOver$
 True��6E   . �5)   *   ��  � �� �#3d3d3d6G   5*   '   5,      5.      �� 5/      -   5        $��30��5/   *   $��20��65      	DangerBtn#���   6A   .��50        $ Times=�6*   $��14��67   
	 �����6B   51      52      53      � 54      $��50 35q�6    � RowDefinitions 55      �� 56      6&   �� 57      6&   �� 58      6&   �� 59      6&   �� 5:      6&   �� 5;      6&   .+�5>      �� $��0��6   .+�5?      �� $��5q�6   $��14(�6(   $��Prenom :��66   �� 5@      -   5         ��Name$ prenomInput��5@      $��5q�63   $��25��6>   5A      �� 5C      $��1��6   .+�5D      �� $��Nom :��6   $��14(�6,   �� 5E      -   5        $ nomInput��5E      $��5q�60   $��25��6;   5F      �� 5H      $��2��6   .+�5I      �� $��14(�6   $��Email :��6*   �� 5J      -   5        $ 
emailInput��5J      $��5q�62   $��25��6=   5K      �� 5M      $��3��6   .+�5N      �� $��14(�6   $��	Adresse :��6*   �� 5O      -   5        $ adresseInput��5O      5P      �� 5R      $��4��6   .+�5S      �� $��14(�6   $��Tel :��6*   �� 5T      -	   5        $ telInput��5T      5U      �� 5X      -
   5        $ idInput��5X      $y�	Collapsed=�6+   �� 5Y      $��5��6   $ 
Horizontal=�6*   $��Center=�6C   $��Center=�6`   .+�5Z      �� -   5         ��Name$ 	updateBtn��5[        
primaryBtn#���  5\      $��5��6B   $��Center=�5]   5   $	��120��6R   $��35��6^   $��Bottom=�5^      $��
0,10,10,10q�68   .��5_      �� $ 
Horizontal=�6%   .+�5`        
	 �����$ FloppyOutline=�6A   $��18��6V   $��0 0 5 0q�6a   �� 5a      
Sauvgarder64   5b      5c      �� 5d      -   5        $ 	deleteBtn��5e      #���   5f      $��5��6A   $��Center=�5g   5   $	��120��6R   $��35��6^   $��Bottom=�5h      $��
0,10,10,10q�68   .��5i      �� $ 
Horizontal=�6%   .+�5j        
	 �����$ TrashOutline=�6A   $��18��6U   $��0 0 5 0q�6`   �� 5k      	Supprimer63   5l      5m      5n      5o      5p      5q      5r      