﻿using Microsoft.AspNetCore.Identity;

namespace MovieMart.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }

    }
}
