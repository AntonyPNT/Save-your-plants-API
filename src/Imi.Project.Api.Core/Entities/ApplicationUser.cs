﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Imi.Project.Api.Core.Entities;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public bool HasApprovedTermsAndConditions { get; set; }
    public DateTime BirthDate { get; set; }
}

