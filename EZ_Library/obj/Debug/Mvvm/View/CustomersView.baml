   M S B A M L   `   `   `  ����E  AEZ_Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:EZ_Library.Mvvm.ViewEZ_Library.Mvvm.View  5      (    "EZ_Library.Mvvm.View.CustomersView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:EZ_Library.Mvvm.View     5        � DataContext  5	      ��    Locator �� Source# [   �� Path$ 	Customers�.��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ lvCustomers��5        ModernListView#��[ 6(   $��1��6P   $��1��6]   $��2��6m   $��10q�6�   ��6~   �� *	Customers+ �� SelectedItem 6�   �� *SelectedCustomer+ �� View 5      �� 5      .P�5      �� $��
First Name��6%    �� DisplayMemberBinding 69   �� *	FirstName+�� 5      $��	Last Name��6%    68   �� *
LastName+�� 5      $��Phone Number��6%    6;   �� *PhoneNumber+5      5      �� 5      $��Add Customer:��6   
�������$��25(�6D   $��Center=�6R   $��DemiBold"�6o   $��0��6�   $��2��6�   �� 5      $��First-Name:��6   
�������$��16(�6B   $��0��6P   $��2��6]   $��Center=�6m   �� 5       $��
Last-Name:��6   
�������$��16(�6A   $��0��6O   $��2��6\   $��Center=�6l   $��0,50,0,0q�6�   �� 5!   
   $��Phone:��6   
�������$��16(�69   $��0��6G   $��2��6T   $��Bottom=�6d   $��0,0,0,5q�6   �� 5"   
     ModernTextBox#��[ 6   $��0��69   $��2��6F   ��6V   �� *
LastName+6r   �� 5#   
   #��[ 6   $��0��69   $��2��6F   $��Center=�6V   $��0,60,0,0q�6q   ��6�   �� *	FirstName+6�   �� 5$   
   #��[ 6   $��0��69   $��2��6F   $��Bottom=�6W   ��6r   �� *PhoneNumber+6�   �� 5%   
     ButtonsTheme#��[ 6   $��Add Customer��67   $��2��6N   $��2��6[   $��Bottom=�6�   ��6l   �� *AddCustomerCommand+6�   �� 5&   
   #��[ 6   $��Upload Image��67   $��2��6N   $��2��6[   ��6k   �� *UploadImageCommand+6�   �� 5'   
   $��1��6   $��2��6   $��0,20,0,0q�6[   ��6-   �� *CustomerImageToShow.Source+6p   �� 5(   
   #��[ 6   $��1��6;   $��2��6H   $��10q�6Y   ��6e   �� *	Rentals+ 5)      �� 5*      .P�5+      �� $��Product name��6%    6;   �� *Product.Title+�� 5,      $��	Rent date��6%    68   �� *	StartDate+�� 5-      $��End date��6%    67   �� *	EndDate+�� 5.      $��Return date��6%    6:   �� *
ReturnDate+5/      51      �� 52   
   -   5        	 ��Name$	 editCustomer_btn��52      #��[ 6+   $��Edit Customer��6p   6�   53      54      