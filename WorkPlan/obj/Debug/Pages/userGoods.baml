   M S B A M L   `   `   `  ????C  ?WorkPlan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WorkPlan.PagesWorkPlan.Pages  5          WorkPlan.Pages.userGoods   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WorkPlan.Pages     5        N? Title$  Goods??5	      .??5      ? -   5         ? RowDefinitions 5   
   ?? 5      $??30 ?6   ?? 5      $??* ?6   ?? 5      $??50 ?6   .+?5   
   ?? -   5         ??Name$ 
filterText??5   C   
???????$2??,Введите название товара??6$   $
??Left=?6W   $??5q?6r   $??0??6}   $??20??6?   $	??200??6?   6	  &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	GoodsGrid??5   _   $??1??6   $??2??6       
IsReadOnly .    AutoGenerateColumns .     	CellStyle 5      ?? 5       ?? 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .?5      ??  ?? Property ? ??	 ?? Value
	 ?????63   ?? 5       ? ??
	 ??  ?64   ?? 5       ? ??$	 2q?68   ?? 5       ? ??$	 15(?61   ?? 5       ? ??$	 4q?6/   ?? 5       ? ??$	 Inder)?63   ?? 5       ? ??$	 30??6/   ?? 5       ? ??$	 Center=?6:   
 ?? Triggers
 5      P? 5       P? Property ?@ 
IsSelected P? Value . . ?5      ??  ? ??
	 ??ح?6;   ?? 5        ? ??
	 ??  ?6;   5!      5#         Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ Название??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   ??  ?? Path$ Название?6Y     5'      $ Цена??6%   $	 200 6j    63   ?? $ Цена? ?? StringFormat$ 
{0:#.} ₽??6j   4  .System.Windows.Controls.DataGridTemplateColumn  5(         	CellStyle 6)   Z?    CellTemplate 5)      ?? 5*      .R?5+      ?? -   5        $??15(?5+   %   $	??100??63   $??30??6?   .??6d   Добавить6n   5,      5.      50      51      52      