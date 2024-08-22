using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.SecurityDto
{
    public class ViewDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string route { get; set; }
        public int moduleId { get; set; }
        public bool state { get; set; }
    }
}
