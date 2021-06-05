﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual AspNetUsersBusinesEntity AspNetUsersBusinesEntity { get; set; }
    }
}