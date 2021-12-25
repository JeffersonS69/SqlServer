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
    public partial class frmActualizar : Form
    {
        public frmActualizar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void txtPeso_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private DataTable getPersonas(string cedula = "")
        {
            SqlConnection conexion = new SqlConnection("server=JEFF\\SQLEXPRESS; database=TI2021; Integrated Security=true");

            string sql = "";
            if (cedula == "")//si no hay cédula
            {
                sql = "Select Cedula, Apellidos, Nombres, upper(Apellidos +' '+ Nombres) as NombreCompleto, FechaNacimiento, Peso ";
                sql += "from personas order by Apellidos, Nombres";
            }
            else
            {
                sql = "Select Cedula, Apellidos, Nombres, upper(Apellidos +' '+ Nombres) as NombreCompleto, FechaNacimiento, Peso ";
                sql += "from personas where Cedula=@Cedula order by Apellidos, Nombres";
            }


            SqlCommand comando = new SqlCommand(sql, conexion);
            if (cedula != "")//si se pasa la cédula, entonces agregar el parámetro
            {
                comando.Parameters.Add(new SqlParameter("@Cedula", cedula));
            }
            SqlDataAdapter ad1 = new SqlDataAdapter(comando);

            //Pasar los datos desde el adaptador a un datatable
            DataTable dt = new DataTable();
            ad1.Fill(dt);


            return dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cmbPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = getPersonas(this.cmbPersona.SelectedValue.ToString());
            //mostrar la infromación en los cuadros de texto
            foreach (DataRow row in dt.Rows)
            {
                this.txtCedula.Text = row["Cedula"].ToString();
                this.txtApellidos.Text = row["Apellidos"].ToString();
                this.txtNombres.Text = row["Nombres"].ToString();
                this.dtpFechaNacimiento.Text = row["FechaNacimiento"].ToString();
                this.txtPeso.Text = row["Peso"].ToString();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DialogResult dial = MessageBox.Show("Desea Actualizar los datos", "Mensaje para los Papus", MessageBoxButtons.YesNo);
            if (dial == DialogResult.Yes)
            {
                SqlConnection conexion = new SqlConnection("server=JEFF\\SQLEXPRESS; database=TI2021; Integrated Security=true");
                string sql = "update personas set Cedula=@Cedula, Apellidos=@Apellidos, Nombres=@Nombres, FechaNacimiento=@FechaNacimiento, Peso=@Peso where Cedula=@Cedula";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.Add(new SqlParameter("@Cedula", this.txtCedula.Text));
                comando.Parameters.Add(new SqlParameter("@Apellidos", this.txtApellidos.Text));
                comando.Parameters.Add(new SqlParameter("@Nombres", this.txtNombres.Text));
                comando.Parameters.Add(new SqlParameter("@FechaNacimiento", this.dtpFechaNacimiento.Value));
                comando.Parameters.Add(new SqlParameter("@Peso", Convert.ToDouble(this.txtPeso.Text)));
                conexion.Open();
                int res = comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Filas Editada: " + res.ToString());

                
            }
            else
            {
                return;
            }
        }

        private void frmActualizar_Load(object sender, EventArgs e)
        {
            DataTable dt = getPersonas();
            this.cmbPersona.DataSource = dt;

            this.cmbPersona.DisplayMember = "nombreCompleto";
            this.cmbPersona.ValueMember = "cedula";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form menu = new frmMenu();
            menu.Show();
            this.Hide();
        }
    }
}
