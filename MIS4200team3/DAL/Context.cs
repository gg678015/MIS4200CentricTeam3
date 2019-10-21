using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS4200team3.Models;
using System.Data.Entity;

namespace MIS4200team3.DAL
{
    public class Context : DbContext
    {
        public Context() : base ("name=DefaultConnection")
        {

        }

        public DbSet<Profile> Profile { get; set; }
        public DbSet<Recognition> Recognition { get; set; }
    }
}