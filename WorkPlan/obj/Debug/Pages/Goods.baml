   M S B A M L   `   `   `  ????C  ?WorkPlan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WorkPlan.PagesWorkPlan.Pages  5          WorkPlan.Pages.Goods   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:WorkPlan.Pages     5        N? Title$  Goods??5	      .??5      ? -   5         ? RowDefinitions 5   
   ?? 5      $??30 ?6   ?? 5      $??* ?6   ?? 5      $??50 ?6   .+?5   
   ?? -   5         ??Name$ 
filterText??5   C   
???????$2??,Введите название товара??6$   $
??Left=?6W   $??5q?6r   $??0??6}   $??20??6?   $	??200??6?   6	  &   System.Windows.Controls.DataGrid  5      -   5          Name$ 	GoodsGrid??5   R   $??1??6      
IsReadOnly .    AutoGenerateColumns .     	CellStyle 5      ?? 5       ?? 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .?5      ??  ?? Property ? ??	 ?? Value
	 ?????63   ?? 5       ? ??
	 ??  ?64   ?? 5       ? ??$	 1q?68   ?? 5       ? ??$	 15(?61   ?? 5       ? ??$	 4q?6/   ?? 5       ? ??$	 Inder)?63   ?? 5       ? ??$	 30??6/   ?? 5       ? ??$	 Center=?6:   
 ?? Triggers
 5      P? 5       P? Property ?@ 
IsSelected P? Value . . ?5      ??  ? ??
	 ??ح?6;   ?? 5        ? ??
	 ??  ?6;   5!      5#         Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ Название??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   ??  ?? Path$ Название?6Y     5'      $ Цена??6%   $	 200 6j    63   ?? $ Цена? ?? StringFormat$ 
{0:#.} ₽??6j   4  .System.Windows.Controls.DataGridTemplateColumn  5(      -   5        button_cell??   	CellStyle 5(   >   Z?    CellTemplate 5)      ?? 5*      .R?5+      ?? -   5        $??15(?5+   %   $	??100??63   $??30??6?   .??6d   УДАЛИТЬ6m   5,      5.      50      ?? 51   
   $??2??6   $??Right=?6"   $??Center=?6>    ?? Orientation$ 
Horizontal=?6Y   .+?52      ?? $??Inder)?6   $??20(?6'   $??30??65   $$??Добавить новое...??6A   ?? 53      -   5        $$??Добавить новое...??53      $??50??61   $??50??6<   $??0,0,20,0q?6H   ??54      ?? 55      .R?56      ? .+?57      A? ??59   "   ?? 5:   &    ?? Color$ 	LightBlue??66   5<      A? 5=      $??5??6'   ??5>   "   ?? 5?   &   StrokeColor??$
 Blue??6L   ??5A   "   ?? 5B   &    ?? ImageSource$ /Pictures/plus.png??61    ? Triggers 5D   "   :? 5E   &    :? RoutedEvent$ 
MouseEnter??63   .[?5F   *   ??  ??Name$ 	EllipseSB??6;   .??5G   .   ?? .??5H   2   W?  g? 
SpeedRatio$ 5Q?6B    ?? TargetProperty$ StrokeThickness?6Q   	 W? To$ 10X?6}   ?? 5I   2   $ 5Q?6A    ?? 
TargetName$ StrokeColor??6P   $ Color?6t   	 ?? To$ BlackX?6?   5J   /   5K   +   5L   '   :? 5M   &   $ 
MouseLeave??63   .[?5N   *   ?? $ 
EllipseSBn??6;   .??5O   .   ?? .??5P   2   W? $ 5Q?6B   $ StrokeThickness?6Q   $ 5X?6}   ?? 5Q   2   $ 5Q?6A   $ StrokeColor??6P   $ Color?6t   $
 BlueX?6?   5R   /   5S   +   5T   '   5V      5W      5X      5Z      5\      5]      5^      