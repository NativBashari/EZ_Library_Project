   M S B A M L   `   `   `  ����E  AEZ_Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:EZ_Library.Mvvm.ViewEZ_Library.Mvvm.View  5      )    #EZ_Library.Mvvm.View.AddProductView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:EZ_Library.Mvvm.View     5        � DataContext  5	      ��    Locator �� Source# [   �� Path$ 
AddProduct�.��5
      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   ��   ModernTextBlock#��[ 6   $��	Category:��6=   $��Right=�6O   6m   �� 5   
   #��[ 6   $��Title:��6=   $��Right=�6K   $��1��6g   6v   �� 5   
   #��[ 6   $��Author:��6=   $��Right=�6M   $��2��6i   6x   �� 5   
   #��[ 6   $��Publishing:��6=   $��Right=�6Q   $��3��6m   6|   �� 5    
   #��[ 6   $��
RentPrice:��6=   $��Right=�6P   $��4��6l   6{   �� 5!   
   -   5         ��Name$ topicgenretxt��5!      #��[ 6+   $��Right=�6U   $��5��6q   6�   �� 5"   
   -   5        $ printpublishtxt��5"      #��[ 6-   $��Right=�6V   $��6��6r   6�   �� 5#   
   -   5         ��Name$ 
categoryCb��5#        ModernComboBox#��[ 6'   $��1��6O   $	��top=�6_    �� SelectedItem 6�   �� *
Category+6�   �� 5$   
     ModernTextBox#��[ 6   $	��top=�69   $��1��6Q   $��1��6^   ��6n   �� *Title+6�   �� 5%   
   #��[ 6   $	��top=�69   $��2��6Q   $��1��6^   ��6n   �� *Author+ �� Mode$ OneWayToSource=�6�   �� 5&   
   #��[ 6   $	��top=�69   $��3��6R   $��1��6_   ��6o   �� *
Publishing+6�   �� 5'   
   #��[ 6   $	��top=�69   $��4��6Q   $��1��6^   ��6n   �� *	RentPrice+6�   �� 5(   
   -   5        $ genreCb��5(      #��[ 6$   $��1��6L   $	��top=�6\   $��5��6t   $y�Hidden=�6�    6�   �� *Genre+6�   �� 5)   
   -   5        $ topicCb��5)      #��[ 6$   $��1��6L   $	��top=�6\   $��5��6t   $y�Hidden=�6�    6�   �� *Topic+6�   (  "System.Windows.Controls.DatePicker  5*   
   -   5        	  Name$	 	publishDp��5*      $��1��6(   $��6��68   $	��200��6E   $	��Top=�6Q   $y�Hidden=�6i   
   SelectedDate
 6}   �� *PublishDate+6�     5+   
   -   5        $	 printDp��5+      $��1��6&   $��6��66   $	��200��6C   $	��Top=�6O   $y�Hidden=�6g   
 6{   �� *	PrintDate+6�   �� 5,   
     ButtonsTheme#��[ 6   $��8��67   $��1��6D   $��Add Product��6T   ��6j   �� *AddProductCommand+6�   5-      5.      