using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2019AM606WACRUD.models;


namespace _2019AM606WACRUD
{
    public class equipoContext : DbContext
    {
        public equipoContext(DbContextOptions<equipoContext> options) : base(options)
        {

        }

        public DbSet<equipos> equipos { get; set; }

    }
}
