   M S B A M L   `   `   `  ����U  QWarehouseManagementSystem1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:WarehouseManagementSystem1.Information_Statistics1WarehouseManagementSystem1.Information_Statistics  5   	   L    FWarehouseManagementSystem1.Information_Statistics.ProductResult_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Qlocal?clr-namespace:WarehouseManagementSystem1.Information_Statistics     5   	   -   5          � Title$  包纱信息统计结果��5   	   $	��720��6   $	��900��6'   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��Product_message��5
      $
��Left=�6*      AutoGenerateColumns .  $��	0,0,0,120q�6a      CanUserAddRows .     ColumnHeaderStyle 5      �� 5       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5      ��  �� Property � �� �� Value$ Center=�6C   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 日期��6>   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6J   
   FontSize$
 16Q�5   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   %   �� *Data+5   %     5      $ 型号��6?   $	 * 6K   $
 16Q�5   %    5   %   �� *Model+5   %     5      $ 重量��6@   $	 * 6L   $
 16Q�5   %    5   %   �� *Weight+5   %     5      $ 颜色��6?   $	 * 6K   $
 16Q�5   %    5   %   �� *Color+5   %     5      $ 箱数��6@   $	 * 6L   $
 16Q�5   %    5   %   �� *Number+5   %     5      $ 是否发货��6@   $	 * 6N   $
 16Q�5   %    5   %   �� *IsSend+5   %     5      $ 	收货商��6>   $	 * 6K   $
 16Q�5   %    5   %   �� *Name+5   %   5!      �� 5"   
   -   5         ��Name$ bnEdit_Copy��5"      $��导出��6&   $
��Left=�63   $��250,630,0,0q�6N   $	��Top=�6c   $	��100��5#      $��30��6   6%   �� 5$   
   -   5        $ bnquit��5$      $��返回��6!   $
��Left=�6.   $��550,630,0,0q�6I   $	��Top=�6^   $	��100��5%      $��30��6   6%   �� 5&   
   $��重量合计：��6   $
��Left=�6    $��220,580,0,0q�6;   $	��Top=�6P   $��18(�6i   $
��Bold"�6w   �� 5'   
   -   5        $��WeightContent��5'      $�� ��6   $
��Left=�60   $��310,580,0,0q�6K   $	��Top=�6`   $��18(�6y   $
��Bold"�6�   �� 5(   
   $��箱数合计：��6   $
��Left=�6    $��520,580,0,0q�6;   $	��Top=�6P   $��18(�6i   $
��Bold"�6w   �� 5)   
   -   5        $��XiangziContent��5)      $�� ��6   $
��Left=�61   $��610,580,0,0q�6L   $	��Top=�6a   $��18(�6z   $
��Bold"�6�   5*      5+      