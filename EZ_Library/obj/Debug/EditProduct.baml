   M S B A M L   `   `   `  ����E  AEZ_Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:EZ_Library
EZ_Library  5   	       EZ_Library.EditProduct   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:EZ_Library     5   	     � Title$  EditProduct��5   	   $	��450��6   $	��500��6*    � DataContext 5	   	   ��    Locator �� Source# [   �� Path$ Products�.��5
      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��	Category:��6   $��Right=�6'   6E   �� 5   
   $��Title:��6   $��Right=�6"   $��1��6>   6M   �� 5   
   $��Author:��6   $��Right=�6$   $��2��6@   6O   �� 5   
   $��Publishing:��6   $��Right=�6(   $��3��6D   6S   �� 5    
   $��
RentPrice:��6   $��Right=�6'   $��4��6C   6R   �� 5!   
   -   5         ��Name$ topicgenretxt��5!      $��Right=�6+   $��5��6G   6V   �� 5"   
   -   5        $ printpublishtxt��5"      $��Right=�6-   $��6��6I   6X   �� 5#   
   -   5         ��Name$ 
categoryCb��5#        ModernComboBox#��[ 6'   $��1��6O    �� SelectedItem 6�   �� *SelectedProduct.Category+6�   �� 5$   
     ModernTextBox#��[ 6   $��1��69   $	��top=�6F   $��1��6_   ��6o   �� *SelectedProduct.Title+6�   �� 5%   
   #��[ 6   $��2��69   $	��top=�6F   $��1��6_   ��6o   �� *SelectedProduct.Author+6�   �� 5&   
   #��[ 6   $��3��69   $	��top=�6F   $��1��6_   ��6o   �� *SelectedProduct.Publishing+6�   �� 5'   
   #��[ 6   $��4��69   $	��top=�6F   $��1��6_   ��6o   �� *SelectedProduct.RentPrice+6�   �� 5(   
   -   5        $ genreCb��5(      #��[ 6$   $��1��6L   $	��Top=�6\   $��5��6t   $y�Hidden=�6�    6�   �� *SelectedProduct.Genre+6�   �� 5)   
   -   5        $ topicCb��5)      #��[ 6$   $��1��6L   $��5��6\   $	��Top=�6i   $y�Hidden=�6�    6�   �� *SelectedProduct.Topic+6�   (  "System.Windows.Controls.DatePicker  5*   
   -   5        	  Name$	 	publishDp��5*      $��1��6(   $��6��68   $	��200��6E   $	��Top=�6Q   $y�Hidden=�6i   
   SelectedDate
 6}   �� *SelectedProduct.PublishDate+6�     5+   
   -   5        $	 printDp��5+      $��1��6&   $��6��66   $	��200��6C   $	��top=�6O   $y�Hidden=�6g   
 6{   �� *SelectedProduct.PrintDate+6�   �� 5,   
     ButtonsTheme#��[ 6   $��8��67   $��3��6D   $��Update Product��6X   6s   5-      5.      