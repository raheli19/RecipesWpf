   M S B A M L   `   `   `  ����B  >Recipes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FlightsMap.WindowsFlightsMap.Windows  5   	   'clr-namespace:FlightsMap
FlightsMap  6n   ;"clr-namespace:FlightsMap.ViewModelFlightsMap.ViewModel  6�   #    FlightsMap.Windows.WatchesWin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:FlightsMap.Windows     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  68   %local1clr-namespace:FlightsMap  6n   2	viewmodel"clr-namespace:FlightsMap.ViewModel  6�   $	��510��5   )   $	��850��66     � 
ResizeMode$  NoResize=�6B    � Title 6	   �� *MyUser.UserId+ � 	Resources 5	         FlightsMap.DateConverter   DateConverter��%   &	          5
   
   6   5      .��5      � .+�5   
   �� -   5         ��Name$ listView��5      $
��Left=�6%   $��
288,62,0,0q�6A   $	��Top=�6U   $y�Visible=�5   5   $	��246��6J   $	��486��6W   ��6   �� *	WatchList+ �� View 5      �� 5       �� AllowsColumnReorder . .P�5      �� $��Recipe��6R    �� DisplayMemberBinding 6%   ��  �� Path$ Recipe�6R   �� 5      $
��Date��6z    6%   �� $
 Date� �� 	Converter# [  6z   �� 5      $��Holiday Name��6[    6)   �� $ HolidayName�6[   5      5      &   System.Windows.Controls.Calendar  5   
   -   5        	  Name$	 calender��5      
   SelectionMode$
 
SingleDate=�6%   $
��Left=�6c   $	��358��6~   $��	10,61,0,0q�6�   $	��Top=�6�   $	��241��6�   5      �� 5   
   $��30(�6*   $��Center=�68   $��39,10,310.2,0q�6V   $	��Top=�6m   $��Gill Sans Ultra Bold)�6�   $��44��6�   $	��494��6�   ��6   �� *Title+6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $y�Hidden=�6&   $��251,140,0,10q�6:    J� Opacity$	 0.8Q�6P   5      �� 5   
   -   5         ��Name$ SimilarRecipes��5      
�������$
 0.75Q�6:   
�������$��20(�6c   $��Arial )�6q   $
��Bold"�6�   $��Get Similar Recipes:��6�   $
��Left=�6�   $��8,23,0,0q�6�   $	��Top=�6�   $��35��6�   $	��207��6  �� 5    
   -   5         ��Name$ SearchByIngTB��5       
�������
���   �$
��Left=�6W   $��32��6r   $��
237,26,0,0q�6~   $	��Top=�6�   $	��136��6�   ��6�   �� *ListOfIngredients+ �� Mode$ OneWayToSource=��� 5!   
   -   5         ��Name$ enter��5!      $��Enter��6    $
��Left=�60   $��34��6K   $��
410,26,0,0q�6W   $	��Top=�6k   $	��107��6�   $��16(�6�   $
��Bold"�6�   
������� � Cursor$
 Hand��5"   <   5#      5$      