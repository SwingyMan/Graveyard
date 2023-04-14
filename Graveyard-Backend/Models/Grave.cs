using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Graveyard.Models
{
    public class Grave
    {
        [Key]
        public int GraveID { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string status { get; set; }
        public Burried burried { get; set; }
        public DateTime validUntil { get; set; }
        Grave(){}
    }
    public class Burried
    {
        [Key]
        public int BurriedID { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public DateTime date_of_birth { get; set; }
        public DateTime date_of_death { get; set; }
        public Burried(){}
    }
    public class ToBeBurried
    {
        [Key]
        public int ToBeBurriedID { get; set; }
        public DateTime burial_date { get; set; }
        public Burried burried { get; set; }
        ToBeBurried(){}
    }
}
