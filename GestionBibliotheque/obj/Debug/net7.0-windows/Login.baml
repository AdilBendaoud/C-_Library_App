   M S B A M L   `   `   `  ����N  JGestionBibliotheque, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GestionBibliothequeGestionBibliotheque  5   	       GestionBibliotheque.Login   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:GestionBibliotheque     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	     � Title$  Login��5	   	   $	��480��6   $	��800��6$    � 	Resources 5
         LoginButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value��%�  &	        �� 5   
   " ��6)   .�5      ��  � �� �#3498DB6+   �� 5       � ��
 �����6+   �� 5       � �� �#2980B96,   �� 5       � ��$ 1q�60   �� 5       � ��$ 10q�6(   �� 5       � ��$ 5q�6'   �� 5       � ��$ Stretch=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ Segoe UI)�6+   �� 5       � ��$ 14(�6)   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 5��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5        5!      P� 5"       �@J�IsMouseOver$
	 True��6=   . �5#   "   ��  � �� �#2980B96?   5$      P� 5%       � ��$
	 True��6;   . �5&   "   ��  � �� �#1F618D6?   5'      5)      5+      5,      5-      .��5.      � 
 � ColumnDefinitions
 5/   
   �� 50      6!   �� 51      6!   .+�53   
   � ��54      �� 56       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��57      �  � Color$ #dfe9f3��6#    � Offset$ 0Q�63   � 58      $
 #fff��6#   $ 1Q�60   59      .+�5=      � $��20q�6    � RowDefinitions 5>      �� 5?      $
��1.5* �6$   �� 5@      $
��1.1* �6$   �� 5A      $
��1.1* �6$   �� 5B      $��1* �6$   .+�5E      �� $	��150��6   $	��120��6$   $��/small-logo.png��61   �� 5H      $��1��6   .+�5I      ��  �� Orientation$ 
Horizontal=�6!   .+�5J      �� $��14(�6    $��28 0 7 0q�6.   $��Arial Rounded MT Bold)�6@   .��6c   CIN6h   "  FontAwesome.WPF.ImageAwesome  5K         Icon$ 
CreditCard=�6*      
Foreground
 �   �$��25��6O   5L      �� 5M      -   5         ��Name$ CINInput��5N      $	��300��5O      $��35��5P      $��Center=�5Q      $��1��5R      $��Arial)�6&   5S      �� 5V      $��2��6   .+�5W      �� $ 
Horizontal=�6!   .+�5X      �� $��14(�6    $��28 0 7 0q�6.   $��Arial Rounded MT Bold)�6@   .��6c   Mot de passe6q     5Y      $
 Lock=�6*   
 �   �$��15��6I   5Z      G� 5[      -   5         G�Name$ passwordInput��5\      $	��300��5]      $��Center=�5^      $��35��5_      5a      �� 5d      -   5        $��Login��5f      $��4��5g      $	��150��5h      $��35��5i      #��[  5j      $��Arial Rounded MT Bold)�6?   5k      5l      �� 5m   
   $��1��6   $��/login library image.png��6    $
��Fill=�6B   5n      5o      