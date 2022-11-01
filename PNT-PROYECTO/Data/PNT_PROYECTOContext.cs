using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PNT_PROYECTO.Models;

namespace PNT_PROYECTO.Data
{
    public class PNT_PROYECTOContext : DbContext
    {
        public PNT_PROYECTOContext(DbContextOptions<PNT_PROYECTOContext> options)
            : base(options)
        {
        }

        public DbSet<PNT_PROYECTO.Models.Alumno> Alumno { get; set; } = default!;

        public DbSet<PNT_PROYECTO.Models.Examen> Examen { get; set; }

        public DbSet<PNT_PROYECTO.Models.Persona> Persona { get; set; }

        public DbSet<PNT_PROYECTO.Models.Profesor> Profesor { get; set; }

        public DbSet<PNT_PROYECTO.Models.Material> Material { get; set; }
    }
}
