using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class UserRole
    {
        public int Id { get; set; }
        public Role role { get; set; }
        public int RoleId { get; set; } 
        public User user { get; set; }
        public int UserId { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? created_by { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? updated_by { get; set; }
        public DateTime? deleted_at { get; set; }
        public DateTime? deleted_by { get; set; }
        public bool state { get; set; }
    }
}
