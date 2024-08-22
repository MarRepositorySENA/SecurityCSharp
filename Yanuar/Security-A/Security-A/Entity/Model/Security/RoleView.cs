using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class RoleView
    {
        public int Id { get; set; }
        public int Role_id { get; set; }
        public Role Role { get; set; }
        public int View_id { get; set; }
        public View View { get; set; }
        public Boolean State { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime Deleted_at { get; set; }
    }
}
