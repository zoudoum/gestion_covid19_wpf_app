using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Api.Service.Web.Entite
{
    public class Patient
    {
       
        public long id { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string NumeroDeTelephone { get; set; }
    }
}