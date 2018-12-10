﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspCore_Roles.Models;

namespace AspCore_Roles.Data
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {      
      base.OnModelCreating(modelBuilder);
    }
  }
}
