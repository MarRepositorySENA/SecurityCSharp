using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Location
{
    public class City
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public int countryId { get; set; }
        public Country country { get; set; }
        public DateTime? create_at { get; set; }
        public DateTime? update_at { get; set; }
        public DateTime? delete_at { get; set; }
        public bool state { get; set; }
    }
}
