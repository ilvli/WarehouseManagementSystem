   M S B A M L   `   `   `  ����U  QWarehouseManagementSystem1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:WarehouseManagementSystem1.Information_Statistics1WarehouseManagementSystem1.Information_Statistics  5   	   L    FWarehouseManagementSystem1.Information_Statistics.ChangsiResult_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Qlocal?clr-namespace:WarehouseManagementSystem1.Information_Statistics     5   	   -   5          � Title$%  长丝/氨纶原料统计结果��5   	   $	��720��6   $	��900��6*   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��Changsi_message��5
      $
��Left=�6*      AutoGenerateColumns .  $��	0,0,0,120q�6a      CanUserAddRows .     ColumnHeaderStyle 5      �� 5       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5      ��  �� Property � �� �� Value$ Center=�6C   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 收货日期��6>   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6L   
   FontSize$
 16Q�6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Data+6V     5      $ 类别��6>   $	 * 6J   $
 16Q�6T    6%   �� *Type+6T     5      $ 型号��6?   $	 * 6K   $
 16Q�6U    6%   �� *Model+6U     5      $ 重量��6@   $	 * 6L   $
 16Q�6V    6%   �� *Weight+6V     5      $ 颜色��6?   $	 * 6K   $
 16Q�6U    6%   �� *Color+6U     5      $ 	供货商��6>   $	 * 6K   $
 16Q�6U    6%   �� *Name+6U   5      �� 5   
   -   5         ��Name$ bnEdit_Copy��5      $��导出��6&   $
��Left=�63   $��250,630,0,0q�6N   $	��Top=�6c   $	��100��5      $��30��6   6%   �� 5   
   -   5        $ bnquit��5      $��返回��6!   $
��Left=�6.   $��550,630,0,0q�6I   $	��Top=�6^   $	��100��5      $��30��6   6%   �� 5   
   $��重量合计：��6   $
��Left=�6    $��350,580,0,0q�6;   $	��Top=�6P   $��18(�6i   $
��Bold"�6w   �� 5   
   -   5        $��WeightContent��5      $�� ��6   $
��Left=�60   $��450,580,0,0q�6K   $	��Top=�6`   $��18(�6y   $
��Bold"�6�   5       5!      