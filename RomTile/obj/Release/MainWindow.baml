   M S B A M L   `   `   `  ����   RomTile    RomTile.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    X TXceed.Wpf.Toolkit, Version=2.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  RomTile��$	��550��$	��700��.���  � ColumnDefinitions �� $��2* ��� $��3* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+�� $��0��$��0��$��2��$��0,5,0,0q� �� $
��Auto ��� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��OblyTile Executable Path��$��0��$��0��$��0,1,0,1q���  �� Orientation$ 
Horizontal=�$��0��$��1��$��2��$��0,1,0,1q�.+��� -   $��OblyTilePath��$	��300��$��5,1,5,1q�$��Center=��� -   $��Browse��$��21��$��73���� $��Emulator Executable Path��$��1��$��0��$��0,1,0,1q��� $ 
Horizontal=�$��1��$��1��$��2��$��0,1,0,1q�.+��� -   $��EmulatorPath��$	��300��$��5,1,5,1q�$��Center=��� -   $��Browse��$��21��$��73���� $��Roms Directory��$��2��$��0��$��0,1,0,1q��� $ 
Horizontal=�$��2��$��1��$��2��$��0,1,0,1q�.+��� -   $��RomDirectory��$	��300��$��5,1,5,1q�$��Center=��� -   $��Browse��$��21��$��73���� $ 
Horizontal=�$��1��$��0��$��2��$��0,1,0,1q�.+��� $��Emulator Arguments��$��0,1,0,1q��� -   $��emuArgs��$	��150��$��5,1,5,1q�$��Center=��� $��Rom Extensions��$��0,1,0,1q��� -   $��MyExtensions��$	��150��$��5,1,5,1q�$��Center=��� $��2��$��0��$��2��$
��Auto��$��5,5,5,5q��� -	   $��	MyListBox��$��3��$��0��$��5q�� $��3��$��1��$��5q� �� $
��Auto ��� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $
��Name��$��0��$��0��$��0,1,0,1q��� $��Additional Arguments��$��1��$��0��$��0,1,0,1q��� $��Tile Image Location��$��2��$��0��$��0,1,0,1q��� $��Tile Image Preview��$��3��$��0��$��0,1,0,1q��� $��Tile Background Color��$��4��$��0��$��0,1,0,1q��� $��Tile Text Color��$��5��$��0��$��0,1,0,1q��� $��Show ROM Name��$��6��$��0��$��0,1,0,1q��� $��	Tile Size��$��7��$��0��$��0,1,0,1q��� -
   $��romName��$��0��$��1��$��0,1,0,1q�$��Center=��� -   $��romArgs��$��1��$��1��$��0,1,0,1q�$��Center=��� $ 
Horizontal=�$��2��$��1��$��2��$��0,1,0,1q�.+��� -   $��romImagePath��$	��170��$��0,0,5,0q�$��Center=��� -   $��Browse��$��21��$��73���� -   $��imagePreview��$��3��$��1��$	��100��$	��100��$��0,1,0,1q�$
��Left=�#  Xceed.Wpf.Toolkit.ColorPicker  -   $��	tileColor��$��4��$��1��   DisplayColorAndName . $
��Auto��$��0,1,0,1q�  -   $��	textColor��$��5��$��1�� . $
��Auto��$��0,1,0,1q��� -   $��showNameCheck��$��6��$��1��$��Center=�$��0,1,0,1q��� -   $��	tileCombo��$��7��$��1��$
��Left=�$	��200��$��0,1,0,1q�.@��� $
��Tiny���� $��Square���� $
��Wide���� $��Large���� $ 
Horizontal=�$
��Left=�$��8��$��0��$��2��$��0,5,0,0q�.+��� -   $��Update��$��21��$��73���� -   $��Remove��$��21��$��73��$��5,0,0,0q��� $ 
Horizontal=�$��4��$��0��$��2��$��5,0,5,5q�.+��� -   $��	Find Roms��$��21��$��73���� -   $��Generate Report��$��21��$	��120��$��5,0,0,0q��� -   $��Generate Shortcuts��$��21��$	��120��$��5,0,0,0q�