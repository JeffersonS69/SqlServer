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
                //1. conectar a la base de datos
                SqlConnection conexion = new SqlConnection("server=L-ELR-001\\SQLEXPRESS; database=TI2021; Integrated Security=true");
                //2. definir operacion
                string sql = "insert into personas(Cedula, Apellidos, Nombres, FechaNacimiento, Peso) ";
                sql += "values (@Cedula, @Apellidos, @Nombres, @FechaNacimiento, @Peso)";
                // 3. ejecutar operacion
                SqlCommand comando = new SqlCommand(sql, conexion);
                //3.1. configurar los parámetros -> @Cedula, @Apellidos, @Nombres, @Nacimiento, @Peso
                comando.Parameters.Add(new SqlParameter("@Cedula", this.txtCedula.Text));
                comando.Parameters.Add(new SqlParameter("@Apellidos", this.txtApellidos.Text));
                comando.Parameters.Add(new SqlParameter("@Nombres", this.txtNombres.Text));
                comando.Parameters.Add(new SqlParameter("@FechaNacimiento", this.dtpFechaNacimiento.Value));
                comando.Parameters.Add(new SqlParameter("@Peso", this.txtPeso.Text));
                //3.2 Abrir conexión
                conexion.Open();
                //3.3 ejecutar el comando e insertar el registro en la base de datos
                int res = comando.ExecuteNonQuery();
                //4. Cerrar la conexión
                conexion.Close();
                MessageBox.Show("Filas insertadas: " + res.ToString());
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
    }
}
