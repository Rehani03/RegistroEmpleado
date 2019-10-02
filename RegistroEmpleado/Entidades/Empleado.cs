using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroEmpleado.Entidades
{
    public class Empleado
    {
        int empleadoID;
        DateTime fecha;
        string nombres;
        string direccion;
        string telefono;
        string celular;
        string cedula;
        decimal sueldo;
        decimal incentivo;

        public Empleado()
        {

        }
        [Key]
        public int EmpleadoID { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Cedula { get; set; }
        public decimal Sueldo { get; set; }
        public decimal Incentivo { get; set; }
    }
}
