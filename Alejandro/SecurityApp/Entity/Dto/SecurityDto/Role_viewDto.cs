using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.SecurityDto
{
    public class Role_viewDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ViewId { get; set; }
        public bool state { get; set; }
    }
}
