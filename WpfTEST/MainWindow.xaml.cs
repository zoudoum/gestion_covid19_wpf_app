using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Projet_API_et_Services_Web.page;
using System.Net.Http;
using Projet_API_et_Services_Web;
using Newtonsoft.Json;

namespace WpfTEST
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BindingSource shlist = new BindingSource();

        public MainWindow()
        {
            InitializeComponent();
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "http://localhost:7070/structure";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<StructureDeSante> structures = JsonConvert.DeserializeObject<List<StructureDeSante>>(json);

                        // Associez la liste des structures à la source de données du DataGridView
                        dataGridView1.ItemsSource = structures;
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Erreur lors de la récupération des données.");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }
        }
    

    private void boutonClick1(object sender, RoutedEventArgs e)
        {

        }


        private void boutonClick2(object sender, RoutedEventArgs e)
        {
            contenu.Navigate(new Carte());
            dataGridView1.Visibility = Visibility.Collapsed;
            recherche.Visibility = Visibility.Collapsed;
            tblrech.Visibility = Visibility.Collapsed;
            contenu.Visibility = Visibility.Visible;
            titre.Visibility = Visibility.Collapsed;
            dataGridView1.Visibility = Visibility.Collapsed;
        }

        private void boutonClick3(object sender, RoutedEventArgs e)
        {
            contenu.Navigate(new RendezVous());
            dataGridView1.Visibility = Visibility.Collapsed;
            recherche.Visibility = Visibility.Collapsed;
            tblrech.Visibility = Visibility.Collapsed;
            contenu.Visibility = Visibility.Visible;
            titre.Visibility = Visibility.Collapsed;
            dataGridView1.Visibility = Visibility.Collapsed;
        }

        private void boutonClick4(object sender, RoutedEventArgs e)

        {
            contenu.Navigate(new Disponiblite());
            dataGridView1.Visibility = Visibility.Collapsed;
            dataGridView1.Visibility = Visibility.Collapsed;
            recherche.Visibility = Visibility.Collapsed;
            tblrech.Visibility = Visibility.Collapsed;
            contenu.Visibility = Visibility.Visible;
            titre.Visibility = Visibility.Collapsed;
            dataGridView1.Visibility = Visibility.Collapsed;

        }




    }
}
