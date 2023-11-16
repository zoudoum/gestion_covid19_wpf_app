using Projet_API_et_Services_Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_API_et_Services_Web.page
{
    public class CentreTest
    {
        
        public long Id { get; set; }

        
        public long StructureId { get; set; }
       

        public string Disponibilite { get; set; }
        public int CapaciteTests { get; set; }
        public string Contact { get; set; }
    }
}
