   M S B A M L   `   `   `  ����F  BPhotoKeeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PhotoKeeperPhotoKeeper  5   	       PhotoKeeper.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PhotoKeeper     5   	   -   5          �Name$  PhotoKeeper��5   	    � Title$ PhotoKeeper��5	   	   $��476.356��6   $��880.742��6.   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ image��5      $��0,20,0,0q�6<   ��6   �� *	ImagePath+6<   o� 5   
   -   5         o�Name$
 menu��5      $��20��6   $	��Top=�6)   $��2��6A   .@�5      m� $
��File��6   .@�5      m� -   5         m�Name$ newMenuItem��5      $	��New��60   $
��Left=�6=   $	��140��6X   6d   m� 5      -   5        $ openMenuItem��5      $��Open...��61   $
��Left=�6B   $	��140��6]   6i   m� 5      -   5        $ saveMenuItem��5      $
��Save��61   $
��Left=�6?   $	��140��6Z   6f   m� 5      -   5        $ saveAsMenuItem��5      $��
Save As...��63   $
��Left=�6G   $	��140��6b   6n   �� 5      $
��Left=�6   $��1��67   $	��140��6B   m� 5      -   5        $ exitMenuItem��5      $
��Exit��61   $
��Left=�6?   $	��140��6Z   6f   5      5      �� 5   
   -	   5         ��Name$ label5��5      $��File Location:��6    $
��Left=�69   $��1��6T   �� 5   
   -
   5        $ imagePathLabel��5      $��1��6F   $��84,0,0,0q�6S   $��2��6e   ��6(   �� *	ImagePath+6e   &   System.Windows.Controls.DataGrid  5    
   -   5          Name$ photographDataGrid��5       	   AutoGenerateColumns	 .  $��1��6�   $��10,56,10,123q�6�   ��6/   �� 
 �� ElementName$
 PhotoKeeper�� �� Path$ Photos� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Title+  5#      $ 
Date Taken��6%    69   �� *Taken+ �� StringFormat$ {0:MM/dd/yyyy}��  5$      $ Description��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Z    6:   �� *Description+6Z   5&      �� 5'   
   -   5        $ label��5'      $��Added��6   $��1��6/   $
��Left=�6?   $��	10,0,0,38q�6Z   $��Bottom=�6m   �� 5(   
   -   5         ��Name$ addedTextBox��5(   )   $��1��6?   $
��Left=�6O   $��23��6j   $��	10,0,0,10q�6v    �� TextWrapping$
 Wrap=�6�   $��Bottom=�6�    �� 
IsReadOnly . $	��137��6�   ��6   �� *Added+6�   �� 5)   
   -   5        $ label1��5)      $��Keywords��6    $��1��63   $
��Left=�6C   $��
152,0,0,92q�6^   $��Bottom=�6r    J� RenderTransformOrigin$ 0.158,-0.115&�6�   �� 5*   
   -   5         ��Name$ keywordsListBox��5*   3   $��1��6M   $��152,0,10,10q�6]   $��77��6r   $��Bottom=�6~   ��6   �� *
Keywords+6~   �� 5+   
   -   5        $ label2��5+      $��Artist��6    $��1��61   $
��Left=�6A   $��	10,0,0,92q�6\   $��Bottom=�6o   �� 5,   
   -   5        $ artistTextBox��5,   +   $��1��6B   $
��Left=�6R   $��23��6m   $��	10,0,0,64q�6y   $
 Wrap=�6�   $��Bottom=�6�   $	��137��6�   ��6   �� *Artist+6�   �� 5-   
   -   5        $ label3��5-      $��Search:��6    $��1��62   $
��Left=�6B   $��	10,25,0,0q�6]   $	��Top=�6p   �� 5.   
   -   5        $ searchTextBox��5.      $��1��6)   $��23��69   $��
63,28,10,0q�6E   $
 Wrap=�6Y   $	��Top=�6m   6�   �� 5/   
   -   5        $ keywordTextBox��5/      $��1��6*   $��20��6:   $��293,0,10,95q�6F   $
 Wrap=�6[   $��Bottom=�6o   �� 50   
   -   5         ��Name$ addKeywordButton��50      $	��Add��6+   $��1��69   $��
213,0,0,95q�6I   $��Bottom=�6]   $
��Left=�6�   $��75��6�   52      53      