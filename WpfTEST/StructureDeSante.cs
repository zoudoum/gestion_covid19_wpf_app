using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_API_et_Services_Web
{
    public class StructureDeSante
    {
        public int id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Contact { get; set; }
        public int QuantiteDisponibleTest { get; set; }
        public int QuantiteDisponibleVaccin { get; set; }
    }
}
