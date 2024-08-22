﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Module
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? created_by { get; set; }


        public DateTime? updated_at { get; set; }

        public DateTime? updated_by { get; set; }

        public DateTime? deleted_at { get; set; }
        public DateTime? deleted_by { get; set; }

        public bool state { get; set; }
    }
}
