using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistroEmpleado.Entidades;
using RegistroEmpleado.BLL;

namespace RegistroEmpleado.UI.Consultas
{
    public partial class cEmpleado : Form
    {
        RepositorioBase<Empleado> repositorio;
        
        public cEmpleado()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            repositorio = new RepositorioBase<Empleado>();
            List<Empleado> lista = new List<Empleado>();

            if(CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0:
                        lista = repositorio.GetList(p => true);
                        break;
                    case 1:
                        int ID = GetID();
                        lista = repositorio.GetList(p=> p.EmpleadoID == ID);
                        break;
                    case 2:
                        lista = repositorio.GetList(p => p.Nombres.Contains(CriteriotextBox.Text));
                        break;
                    case 3:
                        lista = repositorio.GetList(p => p.Direccion.Contains(CriteriotextBox.Text));
                        break;
                    case 4:
                        lista = repositorio.GetList(p => p.Cedula.Contains(CriteriotextBox.Text));
                        break;
                    case 5:
                        lista = repositorio.GetList(p => p.Telefono.Contains(CriteriotextBox.Text));
                        break;
                    case 6:
                        lista = repositorio.GetList(p => p.Celular.Contains(CriteriotextBox.Text));
                        break;
                    case 7:
                        decimal sueldo = GetSueldo();
                        lista = repositorio.GetList(p => p.Sueldo == sueldo);
                        break;
                    case 8:
                        decimal incentivo = GetIncentivo();
                        lista = repositorio.GetList(p => p.Incentivo == incentivo);
                        break;
                    default:
                        MessageBox.Show("No existe este filtro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                lista = lista.Where(p => p.Fecha >= DesdedateTimePicker.Value.Date && p.Fecha <= HastadateTimePicker.Value.Date).ToList();
            }
            else
            {
                lista = repositorio.GetList(p => true);
            }

            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = lista;

        }

        private int GetID()
        {
            int ID = 0;
            try
            {
                 ID = Convert.ToInt32(CriteriotextBox.Text);
                return ID;
            }
            catch (Exception)
            {
                MessageBox.Show("El criterio para el ID debe ser numérico.", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            return ID;
        }

        private decimal GetSueldo()
        {
            decimal sueldo = 0;

            try
            {
                sueldo = Convert.ToDecimal(CriteriotextBox.Text);
                return sueldo;
            }
            catch (Exception)
            {
                MessageBox.Show("El criterio debe ser numérico para Sueldo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sueldo;

        }

        private decimal GetIncentivo()
        {
            decimal incentivo = 0;

            try
            {
                incentivo = Convert.ToDecimal(CriteriotextBox.Text);
                return incentivo;
            }
            catch (Exception)
            {
                MessageBox.Show("El criterio debe ser numérico para Incentivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return incentivo;

        }
    }
}
