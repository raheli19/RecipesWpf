   M S B A M L   `   `   `  ����d  `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF  5   	   B >Recipes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FlightsMap.ViewModelFlightsMap.ViewModel 5   >      FlightsMap.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5   	   4maps#using:Windows.UI.Xaml.Controls.Maps     5   	   8
syncfusion!http://schemas.syncfusion.com/wpf     5   	   4local"clr-namespace:FlightsMap.ViewModel     6>   Aav2http://schemas.microsoft.com/expression/blend/2008     6o   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�   $	��600��5   	   $
��1005��6      MaterialDesignPaper#���   5	   	     MaterialDesignBody#���  5
   	     � Left$  0��6G    � 	Resources 5        pushpin_customIn  pushpin_customOut  location  land  takeoff��%4  &	       &	 h     &	 �     &	 /    &	 �    �� 5   
   .R�5      �� .+�5      �� $ ��airplane_take_off_48px.png��6   5      5      �� 5   
   .R�5      �� .+�5      �� $ ��airplane_landing_100px.png��6   5      5      �� 5   
   .R�5      �� .+�5      �� $��location_48px.png��6   5      5      �� 5   
   .R�5      �� .+�5      �� $!��airplane_landing_r100px.png��6   5       5!      �� 5"   
   .R�5#      �� .+�5$      �� $"��airplane_take_off_r100px.png��6   5%      5&      5(      .��5+      � ��5,   
   �� 5-       �� ImageSource$! recipes_enter_maccarron.jpg��6    j� Stretch$ UniformToFill=�6C    � RowDefinitions 50   
   �� 52      $��70 �6   �� 53      $��* �6   .+�59   
   �� -   5         ��Name$ btnCreatePolygon��59      $
��Left=�5:      $��0��6o    � Cursor$
 Hand��6|   $��	0,19,0,19q�6�   ��6-   �� *
watchCmd+��6J   �� *MyUser+.��5;      �� -   5         ��Name$ 	txtButton��5;      �� 6,   $�View History��60   6G   5<      �� 5=   
   -   5         ��Name$ Title��5=      
�������$��Gastronomy Genius��69   $��Center=�6U   $��Center=�6s   $��35(�6�   $
��bold"�6�   $��Gill Sans Ultra Bold)�6�   �� 5?   
   $��22��6   $
��Left=�6:   $��568,101.6,0,377.2q�6U   $��Center=�6p   $	��366��6�   $��1��6�   $��Arial Rounded MT)�6�   $��14(�6�   ���	#DD461FAB��6   �� *	TitleText+6�   �� 5@   
   -   5        $ SearchbyIng��5@      
�������	 J� Opacity$
	 0.75Q�67   
�������$��20(�6`   $��Arial )�6n   $
��Bold"�6�   $$��Search recipes by ingredients:��6�   $
��Left=�6�   $��8,23,0,0q�6�   $��1��6�   $	��Top=�6�   $��35��6  $	��303��6  �� 5A   
   -   5        $ SearchbykeyWords��5A      $
��Bold"�6*   
�������$
	 0.75Q�6N   
�������$��20(�6w   $��Arial )�6�   $"��Search recipes by key words:��6�   $
��Left=�6�   $��
550,23,0,0q�6�   $��1��6�   $	��Top=�6�   $��35��6  $	��288��6!  �� 5B   
   -   5        
 ��Name$
 SearchByIngTB��5B      
�������
�������$
��Left=�6^   $��32��6y   $��
313,18,0,0q�6�   $	��Top=�6�   $	��136��6�   $��1��6�   ��6�   �� *ListOfIngredients+ �� Mode$ OneWayToSource=�6�   �� 5C   
   -   5        $ enter��5C      $��Enter��6    $
��Left=�60   $��34��6K   $��
360,63,0,0q�6W   $	��Top=�6k   $	��107��6�   $��16(�6�   $
��Bold"�6�   
�������$��1��5D   <   $
 Hand��6I   &   System.Windows.Controls.DataGrid  5E   
   -   5          Name$ dataGrid��5E      $y�Hidden=�6&   $��1��6;   $��
0,124,0,10q�6H   $		 0.8Q�6\      Columns 5F      4  .System.Windows.Controls.DataGridTemplateColumn  5G         CellTemplate 5H      �� 5I      .R�5J      �� $	��100��6$   $	��100��60   ��6=   �� *	ImageLink+5K      5M        5N       5O      �� 5P      .R�5Q      �� -	   5        $��Steps��5Q   %   $��Right=�5R      $��0��6E   $
 Hand��6R   ��5Q   5   �� *	ImageLink+��6\   �� 
 � Tag 5R   .   �� *Id+6`   5S      5U        5V       5W      �� 5X      .R�5Y      �� $��Right=�6C   $��0��6r   $
 Hand��6   ��6(   �� *	TextTitle+ 6_   �� *Id+6   5Z      5\      5^      �� 5_   
   -
   5        $
 
SearchByKW��5_      $
��Left=�6&   $��32��6A   $��
843,18,0,0q�6M   $	��Top=�6b   $	��136��6z   
�������
�������$��1��6�   ��6�   �� *ListOfIngredients+$ OneWayToSource=�6�   �� 5`   
   -   5        $ enter_KW��5`      $��Enter��6#   $
��Left=�63   $��34��6N   $��
892,63,0,0q�6Z   $	��Top=�6n   $	��101��6�   $��16(�6�   $
��Bold"�6�   
�������$��1��5a   
   $
 Hand��6   6%     5b   
   -   5        $ 
dataGridKW��5b      $y�Hidden=�6'   $��1��6;   $��4,124,-4,10q�6H    5c        5d       5e      �� 5f      .R�5g      �� $	��100��6$   $	��100��60   ��6=   �� *	ImageLink+5h      5j        5k       5l      �� 5m      .R�5n      �� -   5        $��Steps��5n   %   $��Right=�5o      $��0��6D   $
 Hand��6Q   ��5n   5   �� *	ImageLink+��6\   ��  5o   .   �� *Name+6_   5p      5r      5t      �� 5u   
   -   5         ��Name$ image��5u      $
��Left=�6   $��../recipe.ico��6:   $��52��6Q   $��	285,0,0,0q�6]   $��Center=�6p   $��61��6�   �� 5v   
   -   5        $ viewDatabase��5v      $��0��6)   $
 Hand��66   $��877,19,0,19q�6D   $
��Left=�6Y   $	��128��6t   .��5w      �� -   5        $ 
txtButton1��5w      �� 6-   $�View ��61   �� 6@    � Language$ fr-fr�6D   $�Database��6U   6h   5x      5z      5|      