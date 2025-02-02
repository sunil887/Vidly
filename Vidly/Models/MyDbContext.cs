﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Vidly.Models;
namespace Vidly.Controllers
{
    public class MyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> movie { get; set; }
        public DbSet<MembershipType> membershiptype { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rental> Rental { get; set; }
    }
}