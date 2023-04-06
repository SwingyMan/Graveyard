using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Graveyard.Models
{
    public class Grave
    {
        [Key]
        public int id_g { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string status { get; set; }
        public Burried burried { get; set; }
        public DateTime validUntil { get; set; }        
        public Customer customer { get; set; }
    }
    public class Burried
    {
        [Key]
        public int id_z { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public DateTime date_of_birth { get; set; }
        public DateTime date_of_death { get; set; }

 
    }
    public class ToBeBurried
    {
        [Key]
        public int id_b { get; set; }
        public DateTime burial_date { get; set; }
        public Burried burried { get; set; }
    }
}
