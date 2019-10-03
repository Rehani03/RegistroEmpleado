using RegistroEmpleado.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistroEmpleado.BLL;

namespace RegistroEmpleado.UI.Registros
{
    public partial class rEmpleado : Form
    {
        public rEmpleado()
        {
            InitializeComponent();
        }

        private void LimpiarCampos()
        {
            MyerrorProvider.Clear();
            EmpleadoIDnumericUpDown.Value = 0;
            NombrestextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
            DirecciontextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            CelularmaskedTextBox.Text = string.Empty;
            CedulamaskedTextBox.Text = string.Empty;
            SueldotextBox.Text = string.Empty;
            IncentivotextBox.Text = string.Empty;
        }

        private Empleado LlenaClase()
        {
            Empleado e = new Empleado();
            e.EmpleadoID = Convert.ToInt32(EmpleadoIDnumericUpDown.Value);
            e.Nombres = NombrestextBox.Text;
            e.Fecha = FechadateTimePicker.Value;
            e.Direccion = DirecciontextBox.Text;
            e.Telefono = TelefonomaskedTextBox.Text;
            e.Celular = CelularmaskedTextBox.Text;
            e.Cedula = CedulamaskedTextBox.Text;
            e.Sueldo = Convert.ToDecimal(SueldotextBox.Text);
            e.Incentivo = Convert.ToDecimal(IncentivotextBox.Text);

            return e;
        }

        private void LlenaCampos(Empleado e)
        {
            EmpleadoIDnumericUpDown.Value = e.EmpleadoID;
            NombrestextBox.Text = e.Nombres;
            FechadateTimePicker.Value = e.Fecha;
            DirecciontextBox.Text = e.Direccion;
            TelefonomaskedTextBox.Text = e.Telefono;
            CelularmaskedTextBox.Text = e.Celular;
            CedulamaskedTextBox.Text = e.Cedula;
            SueldotextBox.Text = Convert.ToString(e.Sueldo);
            IncentivotextBox.Text = Convert.ToString(e.Incentivo);
        }

        private bool Validar()
        {
            bool paso = true;
            MyerrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(NombrestextBox.Text))
            {
                MyerrorProvider.SetError(NombrestextBox, "El campo Nombres no puede estar vacío.");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                MyerrorProvider.SetError(DirecciontextBox, "El campo Dirección no puede estar vacío.");
                paso = false;
            }

            if (!TelefonomaskedTextBox.MaskFull)
            {
                MyerrorProvider.SetError(TelefonomaskedTextBox, "El campo Telefono tiene que estar completo.");
                paso = false;
            }

            if (!CelularmaskedTextBox.MaskFull)
            {
                MyerrorProvider.SetError(CelularmaskedTextBox, "El campo Celular tiene que estar completo.");
                paso = false;
            }

            if (!CedulamaskedTextBox.MaskFull)
            {
                MyerrorProvider.SetError(CedulamaskedTextBox, "El campo Cedula tiene que estar completo.");
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(SueldotextBox.Text))
            {
                MyerrorProvider.SetError(SueldotextBox, "El campo Sueldo no puede estar vacío.");
                paso = false;
            }
            else
            {
                try
                {
                    decimal sueldo = Convert.ToDecimal(SueldotextBox.Text);
                    if(sueldo <= 0)
                    {
                        MyerrorProvider.SetError(SueldotextBox, "El Sueldo debe ser mayor a 0");
                        paso = false;
                    }
                }
                catch (Exception)
                {
                    MyerrorProvider.SetError(SueldotextBox, "El campo Sueldo debe ser numérico.");
                    paso = false;
                }
            }

            if (string.IsNullOrWhiteSpace(IncentivotextBox.Text))
            {
                MyerrorProvider.SetError(IncentivotextBox, "El campo Incentivo no puede estar vacío.");
                paso = false;
            }
            else
            {
                try
                {
                    decimal incentivo = Convert.ToDecimal(IncentivotextBox.Text);
                    if(incentivo < 0)
                    {
                        MyerrorProvider.SetError(IncentivotextBox, "El Incentivo debe ser mayor a 0");
                        paso = false;
                    }
                }
                catch (Exception)
                {
                    MyerrorProvider.SetError(IncentivotextBox, "El campo Incentivo debe ser numérico.");
                    paso = false;
                }
            }

            return paso;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
