﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Column("USR_CPF")]
        public string CPF { get; set; }
        [Column("USR_TIPO")]
        public int Tipo { get; set; }
    }
}