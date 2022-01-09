using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccesoaDatos
{
    public partial class frmConxPersonas : Form
    {
        private string mCedula;
        public frmConxPersonas(string cedula)
        {
            this.mCedula = cedula;
            InitializeComponent();
        }

        private void frmConxPersonas_Load(object sender, EventArgs e)
        {
            DataTable dt = Clases.Personas.seleccionar(mCedula);
            foreach (DataRow row in dt.Rows)
            {
                this.txtCedula.Text = row["cedula"].ToString();
                this.txtApellidos.Text = row["apellidos"].ToString();
                this.txtNombres.Text = row["nombres"].ToString();
                this.txtFechaNac.Text = row["fechaNacimiento"].ToString();
                this.txtPeso.Text = row["peso"].ToString();
            }
            //MessageBox.Show("La cédula es: " + mCedula);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
