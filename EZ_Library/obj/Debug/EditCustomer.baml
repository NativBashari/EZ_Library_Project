   M S B A M L   `   `   `  ����E  AEZ_Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:EZ_Library
EZ_Library  5   	       EZ_Library.EditCustomer   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:EZ_Library     5   	     � Title$  EditCustomer��5   	   $	��350��6   $	��400��6+    � DataContext 5	   	   ��    Locator �� Source# [   �� Path$ 	Customers�.��5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��First name:��6   $��18(�6'   $	��Top=�65   6O   �� 5   
   $��
Last name:��6   $��18(�6&   $��1��64   $	��Top=�6A   6[   �� 5   
   $��Phone:��6   $��18(�6"   $��2��61   $	��Top=�6>   6X   �� 5   
   $��Image:��6   $��18(�6"   $��3��61   $	��Top=�6>   6X   �� 5   
     ModernTextBox#��[ 6   $��1��69   $	��Top=�6u   ��6I   �� *SelectedCustomer.FirstName+6�   �� 5   
   #��[ 6   $��1��69   $��1��6I   $	��Top=�6�   ��6V   �� *SelectedCustomer.LastName+6�   �� 5   
   #��[ 6   $��1��69   $��2��6I   $	��Top=�6�   ��6V   �� *SelectedCustomer.PhoneNumber+6�   �� 5   
     ButtonsTheme#��[ 6   $��Browse��68   $��3��6I   $��1��6V   $��2��6f   $	��Top=�6z   6�   �� 5   
   $��3��6   $��2��6   #��[ 62   $��Bottom=�6X   $��Update��6s   ��6�   �� *UpdateCustomerDetailsCommand+6�   5!      5"      