   M S B A M L   `   `   `  ����N  JGestionBibliotheque, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GestionBibliothequeGestionBibliotheque  5   	   $    GestionBibliotheque.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:GestionBibliotheque     5   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1280��6)    � 	Resources 5	         navBarButton �� 
TargetType �� Property �� Value��%�   &	        �� 5
   
   " ��6%   .�5      ��  � ��$ 10q�6'   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ 40��6'   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.2* �6   6.   �� 5      $
��0.8* �6   6.   .+�5   
   �� ���#2C3E50$��Stretch=�6*   .+�5      �� $��	Dashboard��6   #��[  6)   
����� �6O   �� 5      -   5        $��Emprunts��5   +   #��[  6>   �� 5      -   5        $��	Adherants��5   ,   #��[  6@   �� 5      -   5        $��Livres��5   )   #��[  6:   �� 5      -   5        $��Quitter��5   "   #��[  64   5      �� 5"   
   $��1��6   $��10q�6%   $	��Top=�61   .+�5$      �� $��
Page Title��6   $��20(�6*   $
��Bold"�68   ���#3336J   � 5&      .+�5'      �� -   5         ��Name$ SearchTermTextBox��5*   K   $	��250��5(      $��30��6!   $��Center=�5)      $��5,0,0,0q�67   $��Center=�5*      $
��Left=�60   $��5q�6f   �� 5+      $��14(�6    J� IsHitTestVisible$ False��6*   $��Enter Search Term Here��6C   $��Center=�6a   $
��Left=�6|   $��10,0,0,0q�6�   
���������5,      �� 5-      " ��6    .�5.      ��  � y�$ 	Collapsed=�6;    �� Triggers 5/      �� 50   "   	 �� Binding	 6.   �� *Text+
 �� ElementName$
 SearchTermTextBox�� �� Value  6f   .a�51   &   ��  � y�$ Visible=�6C   52   #   54      56      57      �� 5:      -   5        $��dataListView��5:      $
��Auto��6+   $	��300��68    �� View 5;      �� 5<      .P�5=      �� $��Column 1��6)    �� Width$	 150��6d    �� DisplayMemberBinding 6;   �� *	Column1+6d   �� 5>      $��Column 2��6)   $	 150��6d    6;   �� *	Column2+6d   5?      5A      5B      5C      5D      