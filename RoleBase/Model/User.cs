﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public int RoleID { get; set; }
    }
}
