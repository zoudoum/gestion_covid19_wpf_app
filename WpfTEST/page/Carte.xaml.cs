using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsPresentation;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfTEST;

namespace Projet_API_et_Services_Web.page
{
    /// <summary>
    /// Logique d'interaction pour Carte.xaml
    /// </summary>
    public partial class Carte : Page
    {
        private GMap.NET.WindowsForms.GMapControl gmapControl;
        private List<StructureDeSante> structures;
        private List<string> nomsStructures;
        GMapOverlay markersOverlay;

        public Carte()
        {
            InitializeComponent();
            LoadDataAsync();
            gmapControl = new GMap.NET.WindowsForms.GMapControl();
            gmapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gmapControl.MapProvider = GMapProviders.GoogleMap; // Utilisez le fournisseur de cartes de votre choix (Google Maps ici).
            
            gmapControl.MaxZoom = 15;
            gmapControl.Zoom = 12; // Ajustez le niveau de zoom selon vos besoins.

            // Centrez la carte sur Dakar, Sénégal
            double latitude = 14.750869; // Latitude de Dakar, Sénégal
            double longitude = -17.3738145; // Longitude de Dakar, Sénégal
            gmapControl.Position = new PointLatLng(latitude, longitude);

            // Ajoutez la carte GMap.NET au WindowsFormsHost
            windowsFormsHost.Child = gmapControl;

            // Créez une couche d'overlays
            markersOverlay = new GMapOverlay("markers");

            // Ajoutez des marqueurs pour les 4 lieux à Dakar
            
        }
        private void AjouterMarqueur(GMapOverlay overlay, double latitude, double longitude, string label)
        {
            GMap.NET.WindowsForms.GMapMarker marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), GMarkerGoogleType.red);
            marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
            marker.ToolTipText = label;
            overlay.Markers.Add(marker);
        }
        private async void LoadDataAsync()
        {
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "http://localhost:7070/structure"; 
                    string apiUrl1= "http://localhost:7070/structure/location";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    HttpResponseMessage response1 = await client.GetAsync(apiUrl1);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        string json1 = await response1.Content.ReadAsStringAsync();
                        List<StructureDeSanteLocation> structureDeSanteLocation= JsonConvert.DeserializeObject<List<StructureDeSanteLocation>>(json1);
                        structures = JsonConvert.DeserializeObject<List<StructureDeSante>>(json);
                        nomsStructures = structures.Select(s => s.Nom).ToList();
                        for (int i = 0; i < structureDeSanteLocation.Count; i++)
                        {
                            AjouterMarqueur(markersOverlay, structureDeSanteLocation[i].Latitude, structureDeSanteLocation[i].Longitude, nomsStructures[i]);
                            gmapControl.Overlays.Add(markersOverlay);

                        }

                        


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
    }
}
