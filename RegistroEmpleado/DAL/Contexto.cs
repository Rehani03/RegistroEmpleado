using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEmpleado.Entidades;
using System.Data.Entity;

namespace RegistroEmpleado.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Empleado> Empleado { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
