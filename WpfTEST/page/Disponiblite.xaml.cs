using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projet_API_et_Services_Web.page
{
    /// <summary>
    /// Logique d'interaction pour Disponiblite.xaml
    /// </summary>
    public partial class Disponiblite : Page
    {
        public Disponiblite()
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
                    string apiUrl = "http://localhost:7070/consulatation/vaccin";
                    string apiUrl1= "http://localhost:7070/consulatation/test";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                     HttpResponseMessage response1 = await client.GetAsync(apiUrl1);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                         string json1 = await response1.Content.ReadAsStringAsync();
                        List<StructureDeSante> structures = JsonConvert.DeserializeObject<List<StructureDeSante>>(json);
                        List<StructureDeSante> structures1 = JsonConvert.DeserializeObject<List<StructureDeSante>>(json1);

                        // Associez la liste des structures à la source de données du DataGridView
                        dataGrid1.ItemsSource = structures;
                        dataGrid2.ItemsSource = structures1;

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
    }
}
