   M S B A M L   `   `   `  ����F  BPhotoKeeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PhotoKeeperPhotoKeeper  5   	       PhotoKeeper.AddPhoto   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PhotoKeeper     5   	   -   5          � Title$  	Add Photo��5   	   $��280.933��6   $��312.712��6,   .��5	      � .+�5
   
   �� -   5         ��Name$ 	addButton��5
      $	��Add��6$   $��	0,0,10,10q�62   $��Bottom=�6E   $��Right=�6x   $��75��6�   �� 5   
   -   5        $ cancelButton��5      $��Cancel��6'   $��	0,0,90,10q�68   $��20��6K   $��Bottom=�6W   $��Right=�6�   $��75��6�   �� 5   
   -   5         ��Name$ 
titleLabel��5      $��Title��6$   $
��Left=�64   $��	10,39,0,0q�6O   $	��Top=�6b   �� 5   
   -   5        $ artistLabel��5      $��Artist��6%   $
��Left=�66   $��	10,70,0,0q�6Q   $	��Top=�6d   �� 5   
   -   5        $ 
fileButton��5      $
��File��6%   $
��Left=�64   $��	10,10,0,0q�6O   $	��Top=�6b   $��66��6z   $��24��6�   6�   �� 5   
   -   5         ��Name$ imagePathTextBox��5      $��23��6,   $��
81,11,10,0q�68    �� TextWrapping$
 Wrap=�6L   $	��Top=�6`   �� 5   
   -   5        $ dateTakenLabel��5      $��
Date Taken��6(   $
��Left=�6=   $��
10,101,0,0q�6X   $	��Top=�6l   �� 5   
   -	   5        $ descriptionLabel��5      $��Description��6*   $
��Left=�6@   $��
10,132,0,0q�6[   $	��Top=�6o   �� 5   
   -
   5        $ keywordsLabel��5      $��Keywords��6'   $
��Left=�6:   $��	10,0,0,40q�6U   $��Bottom=�6h   �� 5   
   -   5        $ titleTextBox��5      $��23��6(   $��
81,43,10,0q�64   $
 Wrap=�6H   $	��Top=�6\   �� 5   
   -   5        $ artistTextBox��5      $��23��6)   $��
81,74,10,0q�65   $
 Wrap=�6I   $	��Top=�6]   �� 5   
   -   5        $ descriptionTextBox��5      $��81,136,10,70q�6.   $
 Wrap=�6D   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ takenDatePicker��5      $��81,102,10,0q�6.   $	��Top=�6C   �� 5   
   -   5        $ keywordsTextBox��5      $��23��6+   $��
81,0,10,40q�67   $
 Wrap=�6K   $��Bottom=�6_   5      5      