   M S B A M L   `   `   `  ����E  AEZ_Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:EZ_Library.Mvvm.ViewModelEZ_Library.Mvvm.ViewModel  5   	   'clr-namespace:EZ_Library
EZ_Library  5   	       EZ_Library.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =	viewModel'clr-namespace:EZ_Library.Mvvm.ViewModel     5   	   *localclr-namespace:EZ_Library     5   	     � Title$  
MainWindow��5
   	   $	��700��6   $	��920��6)    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � DataContext 5	   	   ��    Locator �� Source# [   �� Path$
 Main�.��5      �� ���#272537 �� CornerRadius$ 20��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   61   �� 5      6%   	 � RowDefinitions	 5      �� 5      $��75 �6    6.   �� 5      6"   .+�5      �� $��
EZ-Library��6   $��Center=�5      $
��Left=�5      
�������$��22(�5      $��20,0,0,0q�5       6(   �� 5"      $��1��6   .+�5#      	� $
��Home��6   $��50��5$      
�������$��14(�5&        MenuButtonsTheme#��[ 5'      
 d� 	IsChecked$

 TrueY�5(      ��5)      �� *HomeViewCommand+6D   	� 5*      $��Rentals��6   $��50��5+      
�������$��14(�5-      #��[ 5.      $

 TrueY�5/      ��50      �� *OpenRentViewCommand+6H   	� 51      $��Products��6   $��50��52      
�������$��14(�54      #��[ 55      ��56      �� *ProductsViewCommand+6H   	� 57      $��	Customers��6   $��50��58      
�������$��14(�5:      #��[ 5;      ��5<      �� *CustomersViewCommand+6I   	� 5=      $��Add-Product��6   $��50��5>      
�������$��14(�5@      #��[ 5A      ��5B      �� *AddProductViewCommand+6J   5C      �� 5D      $	��250��6   $��40��5E      $��Center=�5F      $
��Left=�5G      $��5q�5H      $��1��5I        ModernTextBox#��[ 5J      �� 5L      $��1��6   $��1��5M      $��10q�5N      ��5O      �� *CurrentView+5Q      5R      5U      5V      