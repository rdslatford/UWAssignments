   M S B A M L   `   `   `  ����D  @Checkbook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Checkbook	Checkbook  5   	       Checkbook.EditTransaction   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Checkbook     5   	   -   5          � Title$  EditTransaction��5   	   $��220.042��6!   $��494.068��62   .��5	      � .+�5
   
   �� -   5         ��Name$ IDLabel��5
      $	��ID:��6!   $
��Left=�6/   $��	10,10,0,0q�6J   $	��Top=�6]   �� 5   
   -   5         ��Name$ 	IDTextBox��5      $
��Left=�6%   $��23��6@   $��	39,13,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $��1��6s   $	��Top=�6|   $��29��6�    J� RenderTransformOrigin$ 2.793,3.342&�6�    �� 
IsReadOnly . 6�   �� 5   
   -   5        $ 	typeLabel��5      $��Type:��6#   $
��Left=�63   $��	73,10,0,0q�6N   $	��Top=�6a   �� 5   
   -   5        $ checkNumLabel��5      $��
Check Num:��6'   $
��Left=�6<   $��
310,10,0,0q�6W   $	��Top=�6k   �� 5   
   -   5        $ checkNumTextBox��5      $
��Left=�6+   $��23��6F   $��
389,13,0,0q�6R   $
 Wrap=�6f   $��000001��6z   $	��Top=�6�   $��78��6�   �� 5   
   -   5        $ descriptionLabel��5      $��Description:��6*   $
��Left=�6A   $��0,38,0,0q�6\   $	��Top=�6n   $ 0.403,0.516&�6�   �� 5   
   -   5        $ descriptionTextBox��5      $
��Left=�6.   $��23��6I   $��	78,42,0,0q�6U   $
 Wrap=�6h   $	��Pay��6|   $	��Top=�6�   $	��222��6�   �� 5   
   -	   5        $ 	dateLabel��5      $��Date:��6#   $
��Left=�63   $��
305,37,0,0q�6N   $	��Top=�6b   $ 0.403,0.516&�6z   �� 5   
   -
   5        $ dateTextBox��5      $
��Left=�6'   $��23��6B   $��
347,41,0,0q�6N   $
 Wrap=�6b   $��
12/12/2014��6v   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ amountInWordsTextBox��5      $
��Left=�60   $��23��6K   $��5,68,0,0q�6W   $
 Wrap=�6i   $>��8One thousand two hundred thirty four and 00/100s Dollars��6}   $	��Top=�6�   $	��331��6�   #��� ��6�    . 6%  �� 5   
   -   5        $ amountLabel��5      $��Amount:��6%   $
��Left=�67   $��
336,69,0,0q�6R   $	��Top=�6f   $ 0.403,0.516&�6~   $��53��6�   �� 5   
   -   5        $ amountTextBox��5      $
��Left=�6)   $��23��6D   $��
392,72,0,0q�6P   $
 Wrap=�6d   $��	$1,234.00��6x   $	��Top=�6�   $��78��6�   6�   �� 5   
   -   5        $ categoryLabel��5      $��	Category:��6'   $
��Left=�6;   $��5,92,0,0q�6V   $	��Top=�6h   $ 0.403,0.516&�6�   $��68��6�   �� 5   
   -   5         ��Name$ cancelButton��5      $��Cancel��6'   $
��Left=�68   $��392,151,0,0q�6S   $	��Top=�6h   $��75��6�   6�   �� 5   
   -   5        $ okButton��5      $��OK��6#   $
��Left=�60   $��312,151,0,0q�6K   $	��Top=�6`   $��75��6x   6�   �� 5   
   -   5         ��Name$ categoryComboBox��5      $
��Left=�6-   $��	73,96,0,0q�6H   $	��Top=�6[   $	��120��6s    �� 
IsEditable . 6   �� 5   
   -   5        $ typeTextBox��5      $
��Left=�6'   $��23��6B   $��
110,14,0,0q�6N   $
 Wrap=�6b   $��TextBox��6v   $	��Top=�6�   $	��120��6�    . 6�   5      5      