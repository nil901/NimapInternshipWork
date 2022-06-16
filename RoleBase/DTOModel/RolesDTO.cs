using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModel
{
 public class RolesDTO : Roles
    {
        public string UserName { get; set; }

        public string password { get; set; }
    }
}
