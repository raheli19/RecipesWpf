   M S B A M L   `   `   `  ����B  >Recipes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Recipes.WindowsRecipes.Windows  5   	       Recipes.Windows.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Recipes.Windows     5   	     � Title$  Window1��5   	   $	��200��6   $	��400��6&   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ CommentGrid��5
      $y�Visible=�6+   $��10,10,31.6,10.4q�6B    J� Opacity$	 0.8Q�6]   .@�5      �� -   5         ��Name$ commentBlock��5      $
��Left=�6.   $��	10,50,0,0q�6I   $
��Wrap=�6\   $	��Top=�6p   $��79��6�   $	��285��6�   ��6�   �� *	Comment+ �� Mode$ TwoWay=��� 5      -   5        $��update��5      $
��Left=�6(   $��265,141,0,0q�6E   $	��Top=�6\   $��84��6v   $��24��6�   $��14(�6�   6�   5      �� 5   
   -   5         ��Name$ comment��5      $y�Visible=�6#   
�������$
 0.50Q�6N   
�������$��20(�6{   $��Arial )�6�   $
��Bold"�6�   $��Enter your comment here:��6�   $
��Left=�6�   $��	10,10,0,0q�6�   $	��Top=�6  $��35��6'  $	��303��65  5      5      