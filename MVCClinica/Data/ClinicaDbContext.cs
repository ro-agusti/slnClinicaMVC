using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using MVCClinica.Models;

namespace MVCClinica.Data
{
    public class ClinicaDbContext:DbContext
    {
        public ClinicaDbContext() : base("keyDB") { }
        public DbSet<Medico> Medicos { get; set; }
    }
}