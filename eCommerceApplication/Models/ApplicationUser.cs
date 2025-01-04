﻿using Microsoft.AspNetCore.Identity;

namespace eCommerceApplication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsDisabled { get; set; }
    }
}
