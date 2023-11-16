using Newtonsoft.Json;
using Projet.Api.Service.Web.Entite;
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
using WpfTEST;

namespace Projet_API_et_Services_Web.page
{
    /// <summary>
    /// Logique d'interaction pour RendezVous.xaml
    /// </summary>
    public partial class RendezVous : Page
    {
        List<StructureDeSante> structures;
        List<string> nomsStructures;
        List<StructureDeSante> centreTest;
     
        List<StructureDeSante> centreVaccination;  
        public RendezVous()
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
                    string apiUrl1 = "http://localhost:7070/consulatation/test";
                        string apiUrl2 = "http://localhost:7070/consulatation/vaccin";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    HttpResponseMessage response1 = await client.GetAsync(apiUrl1);
                    HttpResponseMessage response2 = await client.GetAsync(apiUrl2);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        string json1 = await response1.Content.ReadAsStringAsync();
                        string json2 = await response2.Content.ReadAsStringAsync();
                        structures = JsonConvert.DeserializeObject<List<StructureDeSante>>(json);
                        centreTest = JsonConvert.DeserializeObject<List<StructureDeSante>>(json1);
                        centreVaccination = JsonConvert.DeserializeObject<List<StructureDeSante>>(json2);
                        nomsStructures = structures.Select(s => s.Nom).ToList();
                        cmbStructureSante.ItemsSource = nomsStructures;

                        // Associez la liste des structures à la source de données du DataGridView

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

        private async Task bouutonValider()
        {
            if (((cmbTypeRendezVous.SelectedItem as ComboBoxItem)?.Content.ToString() == "Test" && centreTest.Any(ct => ct.id == structures[cmbStructureSante.SelectedIndex].id))|| (cmbTypeRendezVous.SelectedItem as ComboBoxItem)?.Content.ToString() == "Vaccin" && centreVaccination.Any(ct => ct.id == structures[cmbStructureSante.SelectedIndex].id))
            {
                try
                {
                    // Create an instance of the RendezVous class to hold the data

                    Patient patient;
                    StructureDeSante structure;


                    // Retrieve values from the WPF controls
                    Rv rendezVousData = new Rv
                    {
                        patient = new Patient
                        {
                            id = int.Parse(txtNumeroPatient.Text) // Obtenez l'ID du patient à partir du champ de texte txtNumeroPatient
                        },
                        structure = new StructureDeSante
                        {
                            id = structures[cmbStructureSante.SelectedIndex].id // Obtenez l'ID de la structure à partir de la liste structures en fonction de l'index sélectionné dans cmbStructureSante
                        },
                        date = dpDateRendezVous.SelectedDate.Value,
                        heure = cmbHeureService.SelectedItem != null ? (cmbHeureService.SelectedItem as ComboBoxItem)?.Content.ToString() : string.Empty,// Utilisez la date sélectionnée dans dpDateRendezVous ou la date actuelle si aucune n'est sélectionnée
                        typeRendezVous = (cmbTypeRendezVous.SelectedItem as ComboBoxItem)?.Content.ToString()  // Utilisez le type de rendez-vous sélectionné dans cmbTypeRendezVous ou "Consultation" par défaut
                    };
                    // Serialize the data to JSON
                    string jsonData = JsonConvert.SerializeObject(rendezVousData);

                    // Define the URL where you want to send the JSON data
                    string apiUrl = "http://localhost:7070/rendezvous"; // Replace with your API URL

                    // Create an HttpClient to send the JSON data
                    using (HttpClient client = new HttpClient())
                    {
                        // Create a StringContent with JSON data
                        StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

                        // Send a POST request to the API URL
                        HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                        string responseContent = await response.Content.ReadAsStringAsync();
                        System.Windows.MessageBox.Show(cmbHeureService.SelectedItem.ToString());

                        // Check if the request was successful
                        if (response.IsSuccessStatusCode)
                        {
                            // Handle the success response here
                            // For example, display a success message
                            System.Windows.MessageBox.Show("Rendez-vous enregistré avec succès!");
                        }
                        else
                        {
                            // Handle the error response here
                            // Display an error message or log the error
                            System.Windows.MessageBox.Show("Erreur lors de l'enregistrement du rendez-vous.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the process
                    System.Windows.MessageBox.Show("Une erreur s'est produite : " + ex.Message);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Le centre n'est pas disponible a faire de test");
            }

        }

        private void bouttonValider(object sender, RoutedEventArgs e)
        {
            bouutonValider();
        }
    }
}
