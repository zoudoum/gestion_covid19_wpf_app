   M S B A M L   `   `   `  ����B  >WpfTEST, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Projet_API_et_Services_Web.pageProjet_API_et_Services_Web.page  5      0    *Projet_API_et_Services_Web.page.RendezVous   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:Projet_API_et_Services_Web.page     5        N� Title$  
RendezVous��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��4* �6   .+�5   
   �� $��0��6   $��0��6!   $��Numéro patient:��61   $��Center=�6H   $��18(�6c   $��	0 20 0 10q�6q   �� 5   
   -   5        $��txtNumeroPatient��5   /   $��0��6   $��1��6   $��Center=�6G   $��	0 20 0 10q�6b   �� 5   
   $��1��6   $��0��6!   $��Structure de santé:��61   $��Center=�6L   $��18(�6g   $��	0 20 0 10q�6u   �� 5    
   -   5        $��cmbStructureSante��5    0   $��1��6   $��1��6    $��Center=�6I   $��	0 20 0 10q�6d   5#      �� 5%   
   $��2��6   $��0��6!   $ ��Date prise de rendez-vous:��61   $��Center=�6S   $��18(�6o   $��	0 20 0 10q�6}   (  "System.Windows.Controls.DatePicker  5&   
   -   5        $��dpDateRendezVous��5&   2   $��2��6   $��1��6"   $��Center=�6J   $��	0 20 0 10q�6e   �� 5(   
   $��3��6   $��0��6!   $��Heure du rendez-vous:��61   $��Center=�6N   $��18(�6i   $��	0 20 0 10q�6w   �� 5)   
   -   5        $��cmbHeureService��5)   0   $��3��6   $��1��6    $��Center=�6G   $��	0 20 0 10q�6b   .@�5*      �� $��09:00��6   �� 5+      $��10:00��6   �� 5,      $��11:00��6   �� 5-      $��12:00��6   �� 5.      $��13:00��6   �� 5/      $��14:00��6   �� 50      $��15:00��6   52      �� 54   
   $��4��6   $��0��6!   $��Type de rendez-vous:��61   $��Center=�6M   $��18(�6h   $��	0 20 0 10q�6v   �� 55   
   -   5        $��cmbTypeRendezVous��55   0   $��4��6   $��1��6    $��Center=�6I   $��	0 20 0 10q�6d   .@�57      �� $
��Test��6   �� 58      $��Vaccin��6   �� 59      $��
Traitement��6   5:      �� 5;   
   -   5        $��
btnValider��5;   �   $��5��6   $��0��6   $��2��6.   $��Valider��6B   $��Center=�6T   $��Center=�6q   $	��120��6�   $��40��6�   $��50q�6�   6�   5<      5=      