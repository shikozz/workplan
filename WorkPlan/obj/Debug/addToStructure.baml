   M S B A M L   `   `   `  ����C  ?WorkPlan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WorkPlanWorkPlan  5   	       WorkPlan.addToStructure   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WorkPlan     5   	     � Title$'  !Форма авторизации��5   	   $	��200��6#   $	��200��60   $	��200��6<   $	��350��6L    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$
 None=�5
   	    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	   
������ .��5      ��  �� CornerRadius$ 
50,0,50,50��6   $��10q�6'   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ 	CadetBlue��6   	 � Offset$		 0.0Q�61   � 5      $
 Blue��6   $		 1.0Q�6,   5      ._�5   
   �� $ 
35,0,35,35��6   $��15q�6+   ��5      �� 5      $	 0,0&�6&   $	 1,1&�67   .��5      � $ 	LightBlue��6#   $		 0.0Q�65   � 5      $ 	AliceBlue��6#   $		 1.0Q�65   5      ._�5      � -   5        
 �Name$
 MainGrid��5       � RowDefinitions 5      �� 5      $	��38* �6$   �� 5      $
��137* �6$   ��5!      �� 5"      $	 0,0&�6*   $	 1,1&�6;   .��5#      � $ 	LightBlue��6'   $		 0.0Q�69   � 5$      $ 	AliceBlue��6'   $		 1.0Q�69   5&       � ColumnDefinitions 5(      .+�5*      �� $��2��6   .+�5+      �  5,      �� 5-      $��50 �6,   �� 5.      $��50 �6,   �� 5/      $
��Auto �6,   .+�51      �� $��0��6%    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $��Center=�6h   .+�52      �� $��Inder)�6$   $,��&Добавить в структуру��67   $��5,5,0,0q�6V   $��20(�6g   $��Center=�6u   53      �� 54      $��1��6%   $ 
Horizontal=�62   $��Center=�6K   $��Stretch=�6f   .+�55      �� $��Inder)�6$   $��Сотрудник��67   $��0,5,0,0q�6K   $��16(�6\   �� 56      -   5         ��Name$	 emp��56   '    �� DisplayMemberPath$ ФИО��64   $��Inder)�6L   $��19(�6_   
���   � �� Text$  ��6�   $	��150��6�   $��42,5,5,5q�6�   57      �� 58      $��2��6%   $ 
Horizontal=�62   $��Center=�6K   $��Bottom=�6h   .+�59      �� -   5         ��Name$ ApplicationCommit��59   8   $��Inder)�6%   $��Подтвердить��6S   $��35��6i   $	��100��6u   $��15,15,15,15q�6�   5:      �� 5;      -   5        $ ApplicationBack��5;   8   $��Inder)�6%   $��Отменить��6Q   $��35��6d   $	��100��6p   $��15,15,15,15q�6|   5<      5=      5?      5@      5A      5B      5C      5D      