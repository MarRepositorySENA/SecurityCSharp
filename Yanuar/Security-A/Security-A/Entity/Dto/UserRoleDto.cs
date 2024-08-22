using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class UserRoleDto
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public string User { get; set; }
        public int Role_id { get; set; }
        public string Role { get; set; }
        public bool State { get; set; }
    }
}
