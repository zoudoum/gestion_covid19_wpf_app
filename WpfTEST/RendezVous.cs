using Projet.Api.Service.Web.Entite;
using Projet_API_et_Services_Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_API_et_Services_Web.page
{
    internal partial class Rv
    {
       

        public long id { get; set; }

        public Patient patient { get; set; }
       
        public StructureDeSante structure { get; set; }
        public DateTime date { get; set; }
        public String heure { get; set; }
        public string typeRendezVous { get; set; }
        public void SetPatientId(Patient patient)
        {
            patient = patient;
        }

        public void SetStructureId(StructureDeSante structureDeSante)
        {
            structure = structureDeSante;
        }

        public void SetDateHeure(DateTime selectedDate)
        {
            date = selectedDate ;
        }

        public void SetTypeRendezVous(string selectedItem)
        {
            typeRendezVous = selectedItem;
        }
        public void SetHeure(string selectedheure)
        {
            heure = selectedheure;
        }

    }
}
