﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleTitle { get; set; }
        public string RoleName { get; set; }
        public virtual List<User> Users { get; set; }
        public Role()
        {

        }
    }
}
