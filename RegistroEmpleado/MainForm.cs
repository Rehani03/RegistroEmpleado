using RegistroEmpleado.UI.Consultas;
using RegistroEmpleado.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroEmpleado
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void EmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEmpleado empleado = new rEmpleado();
            empleado.Show();
        }

        private void ConsultarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cEmpleado empleado = new cEmpleado();
            empleado.Show();

        }
    }
}
