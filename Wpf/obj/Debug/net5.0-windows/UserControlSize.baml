   M S B A M L   `   `   `  ����>  :Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPF_CFWPF_CF  5          WPF_CF.UserControlSize   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:WPF_CF     5      .��5	      �� .+�5
   
   �� $��Form lập Size��6   � 5   
   $
��50,0q�6     � ColumnDefinitions  5      �� 5      �� 5      $��4* �6#    � RowDefinitions 5      �� 5      .+�5      �� $��0��6   $��0��6(   $��	Tên Size��65   �� 5      -   5         ��Name$ txtTen��5   3   $��1��6   $��0��6&   63   5      �� 5   
   -   5         ��Name$ btnThemLoai��5   3   $
��50,5q�6   $��
Tạo SiZe��6   6H   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg��5   ;   $��10q�6      AutoGenerateColumns$ False��6    �� SelectedValuePath$ Id��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$	 Mã��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *Id+  5!      $
 Tên��6%   	 62   �� *Name+4  .System.Windows.Controls.DataGridTemplateColumn  5#      
   CellTemplate
 5$      �� 5%      .R�5'      �� $ btnXoa��6&   -   5        $��25��5'   K   $��25��6V   .��5(   "   �� $9��3C:\Users\TRUONG\Desktop\TTTN\Wpf\Wpf\icon\trash.png��6(   6g   5)      5*      5,         RowDetailsTemplate 5/      �� 50      .R�51      9� .��52      �� .+�53      �   54   "   �� 55   &   �� 56   &   $��3* �67    58   "   �� 59   &   �� 5:   &   �� 5;   &   �� 5<   &   .+�5>   "   �� $��0��6,   $��0��69   $��
Mã Loại��6I   �� 5?   "   $��1��6,   $��0��69   $��	Tên Tên��6I   �� 5A   "   $ 	txtMaLoai��6G   $��0��6*   $��1��67    �� 
IsReadOnly$
 True��6Z   �� 5B   "   $ 
txtTenLoai��6G   $��1��6*   $��1��67   6G   5E      �� 5F      $ btnSua��6K   -   5        $��10q�5F   %   $��60��62   $��Sửa��6=   6[   5G      5H      5I      5K      5L      5M      