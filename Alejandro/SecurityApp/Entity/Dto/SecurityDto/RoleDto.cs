using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.SecurityDto
{
    public class RoleDto
    {
        public string? Name { get; set; }
        public string Description { get; set; }
        public bool state { get; set; }
        public DateTime? create_at { get; set; }
    }
}
