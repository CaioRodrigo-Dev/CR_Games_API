﻿using CR_Games_API___Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___Domain.Entities.User
{
    public class UserDomain : BaseDomain
    {

        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Cpf { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
