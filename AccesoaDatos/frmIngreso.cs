using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesoaDatos
{
    public partial class frmIngreso : Form
    {
        public frmIngreso()
        {
            InitializeComponent();
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int res = Clases.Personas.insertar(this.txtCedula.Text, this.txtApellidos.Text, this.txtNombres.Text, Convert.ToDateTime(this.dtpFechaNacimiento.Value.ToString()), Convert.ToDouble(this.txtPeso.Text));
                //MessageBox.Show("Filas insertadas: " + res.ToString());
                if (res > 0)
                {
                    MessageBox.Show("Registro guardado con éxito...");
                }
                else
                    MessageBox.Show("No se puedo guardar el registro...");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            

        }

        private void frmIngreso_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.txtCedula.Clear();
            this.txtApellidos.Clear();
            this.txtNombres.Clear();
            this.txtPeso.Clear();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form menu = new frmMenu();
            menu.Show();
            this.Hide();
        }
    }
}
