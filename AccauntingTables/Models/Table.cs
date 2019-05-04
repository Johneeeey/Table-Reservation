using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccauntingTables.Models
{
    public class Table
    {
        [Key]
        public int TableNumber { get; set; }
        public int SeatsCount { get; set; }
        public string Color { get; set; }
        public string FormFactor { get; set; }
        public string Status { get; set; }

        public int? OwnerId { get; set; }
    }
}
