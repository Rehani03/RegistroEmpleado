using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroEmpleado.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroEmpleado.Entidades;

namespace RegistroEmpleado.BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void RepositorioBaseTest()
        {
            

        }

        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Empleado> repositorio = new RepositorioBase<Empleado>();
            Empleado e = new Empleado();

            e.EmpleadoID = 0;
            e.Nombres = "Juan Camilo";
            e.Fecha = DateTime.Now;
            e.Direccion = "Sanchez #16";
            e.Telefono = "(829)-383-1662";
            e.Celular = "(849)-963-7895";
            e.Cedula = "402-2555004-4";
            e.Sueldo = 12000;
            e.Incentivo = 1000;


            Assert.IsTrue(repositorio.Guardar(e));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Empleado> repositorio = new RepositorioBase<Empleado>();
            Empleado e = new Empleado();

            e.EmpleadoID = 2;
            e.Nombres = "Juan Perez";
            e.Fecha = DateTime.Now;
            e.Direccion = "Sanchez #16";
            e.Telefono = "(829)-383-1662";
            e.Celular = "(849)-963-7895";
            e.Cedula = "402-2555004-4";
            e.Sueldo = 12000;
            e.Incentivo = 1000;


            Assert.IsTrue(repositorio.Guardar(e));
        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Empleado> repositorio = new RepositorioBase<Empleado>();
            Assert.IsTrue(repositorio.Eliminar(2));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Empleado> repositorio = new RepositorioBase<Empleado>();
            Empleado e = new Empleado();
            e = repositorio.Buscar(2);
            Assert.IsNotNull(e);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Empleado> repositorio = new RepositorioBase<Empleado>();
            List<Empleado> lista = new List<Empleado>();
            lista = repositorio.GetList(p => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}