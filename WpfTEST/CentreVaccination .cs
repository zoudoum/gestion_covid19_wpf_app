using Projet_API_et_Services_Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTEST
{
    public class CentreVaccination
    {
        
        public long Id { get; set; }

        public StructureDeSante Structure { get; set; }

        public string Disponibilite { get; set; }
        public int CapaciteVaccins { get; set; }
        public string Contact { get; set; }
    }
}
