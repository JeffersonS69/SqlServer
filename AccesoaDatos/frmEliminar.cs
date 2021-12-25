using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AccesoaDatos
{
    public partial class frmEliminar : Form
    {
        public frmEliminar()
        {
            InitializeComponent();
        }

        private void cmbPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = getPersonas(this.cmbPersona.SelectedValue.ToString());
            //mostrar la infromación en los cuadros de texto
            foreach (DataRow row in dt.Rows)
            {
                this.txtCedula.Text = row["cedula"].ToString();
                this.txtApellidos.Text = row["apellidos"].ToString();
                this.txtNombres.Text = row["nombres"].ToString();
                this.txtFechaNac.Text = row["fechaNacimiento"].ToString();
                this.txtPeso.Text = row["peso"].ToString();
            }
        }

        private void frmEliminar_Load(object sender, EventArgs e)
        {
            DataTable dt = getPersonas();
            this.cmbPersona.DataSource = dt;

            this.cmbPersona.DisplayMember = "nombreCompleto";
            this.cmbPersona.ValueMember = "cedula";
        }
        private DataTable getPersonas(string cedula = "")
        {
            SqlConnection conexion = new SqlConnection("server=JEFF\\SQLEXPRESS; database=TI2021; Integrated Security=true");

            string sql = "";
            if (cedula == "")//si no hay cédula
            {
                sql = "Select cedula, apellidos, nombres, upper(apellidos +' '+ nombres) as nombreCompleto, fechaNacimiento, peso ";
                sql += "from personas order by apellidos, nombres";
            }
            else
            {
                sql = "Select cedula, apellidos, nombres, upper(apellidos +' '+ nombres) as nombreCompleto, fechaNacimiento, peso ";
                sql += "from personas where cedula=@cedula order by apellidos, nombres";
            }


            SqlCommand comando = new SqlCommand(sql, conexion);
            if (cedula != "")//si se pasa la cédula, entonces agregar el parámetro
            {
                comando.Parameters.Add(new SqlParameter("@cedula", cedula));
            }
            SqlDataAdapter ad1 = new SqlDataAdapter(comando);

            //Pasar los datos desde el adaptador a un datatable
            DataTable dt = new DataTable();
            ad1.Fill(dt);


            return dt;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dial =  MessageBox.Show("Desea Eliminar los datos", "Mensaje para los Papus", MessageBoxButtons.YesNo);
            if(dial == DialogResult.Yes)
            {
                SqlConnection conexion = new SqlConnection("server=L-ELR-001\\SQLEXPRESS; database=TI2021; Integrated Security=true");
                string sql = "delete from personas where cedula = @cedula";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.Add(new SqlParameter("@Cedula", this.txtCedula.Text));
                conexion.Open();
                int res = comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Filas eliminada: " + res.ToString());
                
                this.txtCedula.Clear();
                this.txtApellidos.Clear();
                this.txtFechaNac.Clear();
                this.txtNombres.Clear();
                this.txtPeso.Clear();
                this.cmbPersona.ResetText();
            }
            else
            {
                return;
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form menu = new frmMenu();
            menu.Show();
            this.Hide();
        }
    }
}
