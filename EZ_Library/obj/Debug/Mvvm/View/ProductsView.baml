   M S B A M L   `   `   `  ����E  AEZ_Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:EZ_Library.Mvvm.ViewEZ_Library.Mvvm.View  5      '    !EZ_Library.Mvvm.View.ProductsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:EZ_Library.Mvvm.View     5        � DataContext  5	      ��    Locator �� Source# [   �� Path$ Products�.��5
      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� -   5         ��Name$ 
lvProducts��5        ModernListView#��[ 6'   $��3��6O   $��10,0,0,0q�6\   $��1��6n   $��5��6~   ��6�   �� *
Products+ �� SelectedItem 6�   �� *SelectedProduct+ �� View 5      �� 5      .P�5      �� $��Category��6%    �� Width$ 55��6a   	 �� DisplayMemberBinding	 67   �� *
Category+6n   �� 5      $��Title��6%   $ 55��6[   	 64   �� *Title+6h   �� 5      $��Author��6%   $ 55��6]   	 65   �� *Author+6j   �� 5      $��Genre��6%   	 64   �� *Genre+6]   �� 5       $��
Rent Price��6%   	 69   �� *	RentPrice+6f   5!      5#      �� 5$   
   #��[ 6   $��3��6;   $��5��6H   ��6Y   �� *	Customers+ 6{   �� *SelectedCustomer+ 5%      �� 5&      .P�5'      �� $��
First name��6%   	 69   �� *	FirstName+6f   �� 5(      $��	Last name��6%   	 68   �� *
LastName+6d   �� 5)      $��Phone number��6%   	 6;   �� *PhoneNumber+6j   5*      5,      �� 5-   
     ButtonsTheme#��[ 6   $��	Open Rent��67   $��2��6K   ��6X   �� *OpenRentCommand+6~   �� 5.   
   -   5        
 ��Name$
 editProduct_btn��5.      #��[ 6*   $��1��6P   $��Edit Product��6]   6�   �� 50   
   $��0��6   $��2��6"   $��3��63   .+�51      �� $��Filter By : ��6   
�������$��Center=�6C   6b   �� 52      -   5         ��Name$ 
categoryCb��52       �� Text$ Category��6+    �� 
IsReadOnly .  �� 
IsEditable .   ModernComboBox#��[ 6_    6�   �� *SelectedCategory+6�   �� 53      -   5        $ genreCb��53      $ Genre��6(    .  . #��[ 6Y    6�   �� *SelectedGenre+6�   �� 54      -   5        $ topicCb��54      $ Topic��6(    .  . #��[ 6Y    6�   �� *SelectedTopic+6�   �� 55      -   5        $ availabilityCb��55      $ Availability��6/    .  . #��[ 6g    6�   �� *SelectedAvailability+6�   �� 56      #��[ 6   $��Filter��6;   ��6L   �� *FilterCommand+6p   57      58      59      