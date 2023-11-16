using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTEST
{
    internal class StructureDeSanteLocation
    {
        public int Id { get; set; }

        
        public double Latitude { get; set; }

        
        public double Longitude { get; set; }

        
        public int StructureId { get; set; }
    }
}
